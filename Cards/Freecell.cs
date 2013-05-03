using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cselian.Cards
{
	class Freecell
	{

		const int ColumnCount = 8;
		CardView[] tempCards = new CardView[4];
		List<List<CardView>> finishedCards = new List<List<CardView>>();
		List<List<CardView>> cardsInPlay = new List<List<CardView>>();

		public Freecell(Panel playingRegion)
		{
			List<Card> cards = Card.CreatePack();
			for (int i = 0; i < ColumnCount; i++)
				cardsInPlay.Add(new List<CardView>());
			for (int i = 0; i < 4; i++)
				finishedCards.Add(new List<CardView>());

			int index = 0;
			while (cards.Count > 0)
			{
				Card c = cards.GetRandomCard();
				int col = index % ColumnCount;
				int row = index / ColumnCount;

				CardView cardView = new CardView(c, col, row);
				cardsInPlay[col].Add(cardView);
				cardView.PreBeginMove += new CardView.CardSetHandler(cardView_PreBeginMove);
				cardView.WhileMove += new CardView.CardSetHandler(cardView_WhileMove);
				cardView.MoveComplete+=new CardView.CardSetHandler(cardView_MoveComplete);
				cardView.CardDoubleClick += new CardView.CardSetHandler(cardView_CardDoubleClick);
				playingRegion.Controls.Add(cardView);
				cardView.BringToFront(); //only after adding
				index += 1;
				//if (index == 10) return;
			}
		}

		void cardView_CardDoubleClick(CardView sender, CardView.CardSetEventArgs e)
		{
			if (sender.Row == -1 && sender.Column > 3)
				return; //cant click on finishedCards

			if (sender.Row > -1)
			{
				foreach (List<CardView> col in cardsInPlay)
				{
					int index;
					if ((index = col.IndexOf(sender)) != -1 && index < col.Count - 1)
						return; //can only dbl click on last card
					}
			}

			List<CardView> fin = finishedCards[Convert.ToInt32(sender.Card.Suit)];
			if (fin.Count == 0 && sender.Card.Face == Face.Ace ||
				fin.Count > 0 && Convert.ToInt32(sender.Card.Face) == Convert.ToInt32(fin[fin.Count - 1].Card.Face) + 1)
			{
				if (sender.Row > -1)
					cardsInPlay[sender.Column].RemoveRange(sender.Row, 1);
				else
					for (int i = 0; i < 4; i++) if (tempCards[i] == sender) tempCards[i] = null;

				fin.Add(sender);
				sender.SetLocation(4 + Convert.ToInt32(sender.Card.Suit), -1);
			}

		}

		CardView target;
		int dropColumn = -1; bool dropOk;

		void cardView_MoveComplete(CardView sender, CardView.CardSetEventArgs e)
		{
			if (null != target)
				target.TargetedErrorNotOk = null;

			if (e.Valid = dropOk)
			{
				if (sender.Row != -1)
					cardsInPlay[sender.Column].RemoveRange(sender.Row, e.CardSet.Count);
				else
					for (int i = 0; i < 4; i++) if (tempCards[i] == sender) tempCards[i] = null;


				bool belowBar = sender.Location.Y < 120;
				if (belowBar)
				{
					tempCards[dropColumn] = sender;
					sender.SetLocation(dropColumn, -1);
				}
				else
				{
					foreach (CardView item in e.CardSet)
					{
						cardsInPlay[dropColumn].Add(item);
						item.SetLocation(dropColumn, cardsInPlay[dropColumn].Count - 1);
					}
				}
				target = null;
				dropOk = false;
			}
		}

		void cardView_WhileMove(CardView sender, CardView.CardSetEventArgs e)
		{
			bool belowBar = sender.Location.Y < 120;
			int nearestColumn = Math.Min(belowBar ? 3 : ColumnCount - 1, (sender.Location.X + CardView.ColumnWidth / 2) / CardView.ColumnWidth);

			if (belowBar && (nearestColumn.Equals(dropColumn) == false || null == target ||
				(null != target && target.Row == -1 != belowBar)))
			{
				if (null != target)
					target.TargetedErrorNotOk = null;

				dropColumn = nearestColumn;
				e.Valid = e.CardSet.Count == 1 && ((sender.Row == -1 && sender.Column == nearestColumn) == false);
				if (e.Valid && null != (target = tempCards[nearestColumn]))
					target.TargetedErrorNotOk = !(e.Valid = false);
				dropOk = e.Valid;
			}
			else if ((nearestColumn.Equals(dropColumn) == false || null == target ||
				(null != target && target.Row == -1 != belowBar)))
			{
				if (null != target)
					target.TargetedErrorNotOk = null;

				dropColumn = nearestColumn;
				target = null;
				if (dropColumn != sender.Column || sender.Row == -1)
				{
					dropOk = true;
					if (cardsInPlay[dropColumn].Count > 0)
					{
						target = cardsInPlay[dropColumn][cardsInPlay[dropColumn].Count - 1];
						dropOk = sender.Card.CanFallOn(target.Card);
						target.TargetedErrorNotOk = !dropOk;
					}
				}
				else
				{
					dropOk = false;
				}
			}
			else if (target != null && target.Row == -1 != belowBar) //cross the line
			{
				target.TargetedErrorNotOk = null;
			}
			sender.FindForm().Text = nearestColumn.ToString();
		}

		void cardView_PreBeginMove(CardView sender, CardView.CardSetEventArgs e)
		{
			dropColumn = -1;
			List<CardView> set = new List<CardView>();
			if (sender.Row == -1)
			{
				set.Add(sender);
			}
			else
			{
				foreach (List<CardView> col in cardsInPlay)
				{
					int index;
					if ((index = col.IndexOf(sender)) != -1)
					{
						set.AddRange(col.GetRange(index, col.Count - index));
					}
				}
				if (set.Count > 1)
				{
					for (int i = 0; i <= set.Count - 2; i++)
					{
						if (set[i + 1].Card.CanFallOn(set[i].Card) == false)
						{
							e.Valid = false;
							return;
						}
					}
				}
			}
			e.Valid = true;
			e.CardSet = set;
		}
	}
}
