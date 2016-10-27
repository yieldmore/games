using System;
using System.Collections.Generic;

namespace Cselian.Sudoku
{
	public static class SudoGen
	{

		#region Wrap Around Sudogen by http://www.codeproject.com/Members/The-ANZAC
		public static Dictionary<int, int> GetSudokuValuesOld()
		{
			Dictionary<int, int> values = new Dictionary<int, int>();
			#region Initial Data
			int r = 0;
			values.A(r + 0, 7).A(r + 4, 4).A(r + 5, 1).A(r + 6, 5).A(r + 8, 3); r += 9;
			values.A(r + 2, 9).A(r + 7, 8); r += 9;
			values.A(r + 2, 5).A(r + 3, 8).A(r + 4, 6).A(r + 6, 1).A(r + 7, 9); r += 9;
			values.A(r + 5, 4).A(r + 7, 3).A(r + 8, 2); r += 9;
			values.A(r + 2, 6).A(r + 3, 8).A(r + 5, 2).A(r + 6, 4); r += 9;
			values.A(r + 0, 7).A(r + 1, 4).A(r + 3, 3); r += 9;
			values.A(r + 1, 1).A(r + 2, 6).A(r + 4, 9).A(r + 5, 7).A(r + 6, 4); r += 9;
			values.A(r + 1, 5).A(r + 6, 7); r += 9;
			values.A(r + 0, 4).A(r + 2, 3).A(r + 3, 5).A(r + 4, 1).A(r + 8, 6); r += 9;
			#endregion
			return values;
		}


		public static Dictionary<int, int> GetSudokuValues()
		{
			GenerateGrid();
			Dictionary<int,int> values = new Dictionary<int,int>();
			foreach (var item in Sudoku)
			{
				values.Add((item.Region - 1) * 9 + ((item.Down - 1) % Cell.Sq) * Cell.Sq + ((item.Across - 1) % Cell.Sq), item.Value);
			}
			return values;
		}
		
		#endregion

		private static List<Square> Sudoku = new List<Square>();
		static Random r = new Random();

		private static void GenerateGrid()
		{
			Clear();
			Square[] Squares = new Square[81];
			//an arraylist of squares: see line 86
			List<int>[] Available = new List<int>[81];
			//an arraylist of generic lists (nested lists)
			//we use this to keep track of what numbers we can still use in what squares
			int c = 0;
			//use this to count the square we are up to

			for (int x = 0; x <= Available.Length - 1; x++)
			{
				Available[x]= new List<int>();
				for (int i = 1; i <= 9; i++)
				{
					Available[x].Add(i);
				}
			}

			while (!(c == 81))
			{
				//we want to fill every square object with values
				if (!(Available[c].Count == 0))
				{
					//if every number has been tried and failed then backtrack
					int i = GetRan(0, Available[c].Count - 1);
					int z = Available[c][i];
					if (Conflicts(Squares, Item(c, z)) == false)
					{
						//do a check with the proposed number
						Squares[c] = Item(c, z);
						//this number works so we add it to the list of numbers
						Available[c].RemoveAt(i);
						//we also remove it from its individual list
						//move to the next number
						c += 1;
					}
					else
					{
						// this number conflicts so we remove it from its list
						Available[c].RemoveAt(i);
					}
				}
				else
				{
					for (int y = 1; y <= 9; y++)
					{
						//forget anything about the current square
						//by resetting its available numbers
						Available[c].Add(y);
					}
					Squares[c - 1] = default(Square); //TODO: cannot convert to null as non-nullable -> how come nothing was allowed in VB?
					//go back and retry a different number 
					//in the previous square
					c -= 1;
				}
			}
			int j = 0;
			// this produces the output  list of squares
			for (j = 0; j <= 80; j++)
			{
				Sudoku.Add(Squares[j]);
				//This algorithm produces a Sudoku in an average of 0.02 seconds, tested over 5000 iterations
			}
		}

		private static void Clear()
		{
			Sudoku.Clear();
		}

		private static int GetRan(int lower, int upper)
		{
			return r.Next(lower, upper + 1);
		}

		private static bool Conflicts(Square[] CurrentValues, Square test)
		{

			foreach (Square s in CurrentValues)
			{
				if ((s.Across != 0 & s.Across == test.Across) || (s.Down != 0 & s.Down == test.Down) || (s.Region != 0 & s.Region == test.Region))
				{

					if (s.Value == test.Value)
					{
						return true;
					}
				}
			}

			return false;
		}

		private struct Square
		{
			public int Across;
			public int Down;
			public int Region;
			public int Value;
			public int Index;

			public override string ToString()
			{
				return string.Concat(Index.ToString("00"), " ", Region, " ", Down, " ", Across, " ", Value);
			}

		}

		private static Square Item(int n, int v)
		{
			Square functionReturnValue = default(Square);
			n += 1;
			functionReturnValue.Across = GetAcrossFromNumber(n);
			functionReturnValue.Down = GetDownFromNumber(n);
			functionReturnValue.Region = GetRegionFromNumber(n);
			functionReturnValue.Value = v;
			functionReturnValue.Index = n - 1;
			return functionReturnValue;
		}

		private static int GetAcrossFromNumber(int n)
		{
			int k = 0;
			k = n % 9;
			if (k == 0) return 9; else return k;
		}

		private static int GetDownFromNumber(int n)
		{
			int k = 0;
			if (GetAcrossFromNumber(n) == 9)
			{
				k = n / 9;
			}
			else
			{
				k = n / 9 + 1;
			}
			return k;
		}

		private static int GetRegionFromNumber(int n)
		{
			int k = 0;
			int a = GetAcrossFromNumber(n);
			int d = GetDownFromNumber(n);

			if (1 <= a & a < 4 & 1 <= d & d < 4)
			{
				k = 1;
			}
			else if (4 <= a & a < 7 & 1 <= d & d < 4)
			{
				k = 2;
			}
			else if (7 <= a & a < 10 & 1 <= d & d < 4)
			{
				k = 3;
			}
			else if (1 <= a & a < 4 & 4 <= d & d < 7)
			{
				k = 4;
			}
			else if (4 <= a & a < 7 & 4 <= d & d < 7)
			{
				k = 5;
			}
			else if (7 <= a & a < 10 & 4 <= d & d < 7)
			{
				k = 6;
			}
			else if (1 <= a & a < 4 & 7 <= d & d < 10)
			{
				k = 7;
			}
			else if (4 <= a & a < 7 & 7 <= d & d < 10)
			{
				k = 8;
			}
			else if (7 <= a & a < 10 & 7 <= d & d < 10)
			{
				k = 9;
			}
			return k;
		}

	}
}
