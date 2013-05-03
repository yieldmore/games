using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Cselian.Sudoku
{
	public partial class Form1 : Form
	{

		#region Cell Groups

		public List<List<Cell>> cellsByRow = new List<List<Cell>>();
		public List<List<Cell>> cellsByCol = new List<List<Cell>>();
		public List<List<Cell>> cellsBySqr = new List<List<Cell>>();
		public List<Cell> allCells = new List<Cell>();

		#endregion

		public Form1()
		{
			InitializeComponent();
			InitSudoku();
			btnPossibilities.Click += new EventHandler(btn_Click);
			btnReset.Click += new EventHandler(btn_Click);
			btnSolve.Click += new EventHandler(btn_Click);
			btnRestart.Click+=new EventHandler(btn_Click);
		}

		void btn_Click(object sender, EventArgs e)
		{
			if (sender == btnReset) InitSudoku();
			else if (sender == btnPossibilities) ShowPossibilities(false);
			else if (sender == btnSolve) HelpSolve();
			else if (sender == btnRestart) foreach (Cell c in allCells) c.Reset();
		}

		#region Totals (use labels) - hover to highlight groups
		List<Label> totals = new List<Label>();
		private void ShowTotals()
		{
			foreach (var item in allCells) item.Error = false;
			bool create = totals.Count == 0;
			for (int i = 0; i < 9; i++)
			{
				bool? error; int total = cellsByCol[i].Total(out error);
				Label totalC = create ? new Label() 
				{
					Left = Cell.Grid * i + Cell.InterGap * i / Cell.Sq
					, Top = Cell.End
					, Width = Cell.TextBoxEx.Grid
					, Height = Cell.TextBoxEx.Grid
					, TextAlign = ContentAlignment.MiddleCenter 
				} : totals[i * Cell.Sq];
				totalC.Text = string.Format("C{0}\r\n{1}", i + 1, total.ToString()); totalC.ForeColor = error.Color();

				total = cellsByRow[i].Total(out error);
				Label totalR = create ? new Label() 
				{ 
					Left = Cell.End
					, Top = Cell.Grid * i + Cell.InterGap * i /Cell.Sq
					, Width = Cell.TextBoxEx.Grid
					, Height = Cell.TextBoxEx.Grid
					, TextAlign = ContentAlignment.MiddleCenter 
				} : totals[i * Cell.Sq + 1];
				totalR.Text = string.Format("R{0}\r\n{1}", i + 1, total.ToString()); totalR.ForeColor = error.Color();

				total = cellsBySqr[i].Total(out error);
				Label totalS = create ? new Label()
				{
					Left = (Cell.Cnt + (i % Cell.Sq)) * Cell.Grid
					, Top = Cell.End + (i / Cell.Sq) * Cell.Grid
					, Width = Cell.TextBoxEx.Grid
					, Height = Cell.TextBoxEx.Grid
					, TextAlign = ContentAlignment.MiddleCenter
				} : totals[i * 3 + 2];
				totalS.Text = total.ToString(); totalS.ForeColor = error.Color();

				if (create)
				{
					totals.A(totalC).A(totalR).A(totalS);
					panel1.Controls.A(totalC).A(totalR).A(totalS);
					totalC.Tag = "C"; totalR.Tag = "R"; totalS.Tag = "S";
					totalC.MouseEnter += new EventHandler(total_MouseEnter);
					totalC.MouseLeave += new EventHandler(total_MouseLeave);
					totalR.MouseEnter += new EventHandler(total_MouseEnter);
					totalR.MouseLeave += new EventHandler(total_MouseLeave);
					totalS.MouseEnter += new EventHandler(total_MouseEnter);
					totalS.MouseLeave += new EventHandler(total_MouseLeave);
				}
				foreach (var item in allCells) item.Refresh();
			}
		}

		void total_MouseLeave(object sender, EventArgs e)
		{
			ShowCellGroups(sender as Label, false);
		}

		void total_MouseEnter(object sender, EventArgs e)
		{
			ShowCellGroups(sender as Label, true);
		}

		private void ShowCellGroups(Label l, bool show)
		{
			int i = totals.IndexOf(l);
			int index = i / 3; int what = i % 3; //CRS is add order
			List<Cell> list = what == 1 ? cellsByRow[index]
				: what == 0 ? cellsByCol[index] : cellsBySqr[index];
			foreach (var item in list) item.Highlight(!show);
		}
		
		#endregion

		private void HelpSolve()
		{
			int count = 0; int lastCount = ShowPossibilities(true);
			do { lastCount = count; } while (lastCount != (count = ShowPossibilities(true)));
		}

		private int ShowPossibilities(bool autoSet)
		{
			int withValue = 0;
			foreach (Cell cell in allCells)
			{
				if (cell.Value.HasValue)
				{
					withValue += 1;
					cell.SetPossible(null, autoSet);
				}
				else
				{
					List<int> poss = new List<int>(Cell.AllValues);
					foreach (Cell c in cellsByCol.MyList(cell)) if (c.Value.HasValue) poss.Remove(c.Value.Value);
					foreach (Cell c in cellsByRow.MyList(cell)) if (c.Value.HasValue) poss.Remove(c.Value.Value);
					foreach (Cell c in cellsBySqr.MyList(cell)) if (c.Value.HasValue) poss.Remove(c.Value.Value);
					cell.SetPossible(poss, autoSet);
				}
			}
			return withValue;
		}

		private void InitSudoku()
		{
			panel1.Controls.Clear(); totals.Clear();
			allCells.Clear(); cellsBySqr.Clear(); cellsByRow.Clear(); cellsByCol.Clear();

			Dictionary<int, int> values = SudoGen.GetSudokuValues(); //GetSudokuValuesOld();
			List<int> wanted = new List<int>();
			for (int i = 0; i < 9; i++)
			{
				int count = 3 + new Random(DateTime.Now.Millisecond).Next(2);
				List<int> places = new List<int>();
				for (int j = 0; j < count; j++)
				{
					int place = 0; Random r = new Random(DateTime.Now.Millisecond);
					do { place = r.Next(8); } while (places.Contains(place));
					wanted.Add(i * 9 + place);
					places.Add(place);
				}
			}

			for (int i = 0; i < 9; i++)
			{
				cellsByRow.Add(new List<Cell>());
				cellsByCol.Add(new List<Cell>());
				cellsBySqr.Add(new List<Cell>());

			}
			int index = 0;
			for (int i = 0; i < 9; i++)
			{
				Cell square = new Cell(i);
				for (int j = 0; j < 9; j++)
				{
					Cell c; //int value;
					if (wanted.Contains(index)) // values.TryGetValue(index, out value))
						c = new Cell(j, square, panel1, values[index]);
					else
						c = new Cell(j, square, panel1);
					cellsByRow[square.Y * Cell.Sq + c.Y].Add(c);
					cellsByCol[square.X * Cell.Sq + c.X].Add(c);
					cellsBySqr[i].Add(c);
					allCells.Add(c);
					c.ValueChanged += new EventHandler(c_ValueChanged);
					index += 1;
				}
			}
			ShowTotals();
		}

		void c_ValueChanged(object sender, EventArgs e)
		{
			ShowTotals();
			if (true)
			{
				Cell cell = sender as Cell;
				List<int> poss = new List<int>(Cell.AllValues);
				List<Cell> cells = cellsByCol.MyList(cell);
				foreach (Cell c in cells) if (c.Value.HasValue) poss.Remove(c.Value.Value);
				cells = cellsByRow.MyList(cell);
				foreach (Cell c in cells) if (c.Value.HasValue) poss.Remove(c.Value.Value);
				cells = cellsBySqr.MyList(cell);
				foreach (Cell c in cells) if (c.Value.HasValue) poss.Remove(c.Value.Value);
			}
		}

	}

}
