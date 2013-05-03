using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cselian.Cards
{
	public class Card
	{
		public Suit Suit { get; set; }
		public Face Face { get; set; }

		public static List<Card> CreatePack()
		{
			List<Card> cards = new List<Card>();
			foreach (Face face in Enum.GetValues(typeof(Face)))
			{
				foreach (Suit suit in Enum.GetValues(typeof(Suit)))
				{
					cards.Add(new Card() { Face = face, Suit = suit });
				}
			}
			return cards;
		}
	}

	static partial class extensions
	{
		public static string GetFileName(this Card card)
		{
			string face;
			switch (card.Face)
			{
				case Face.Ace:
					face = "a";
					break;
				case Face.Jack:
					face = "j";
					break;
				case Face.Queen:
					face = "q";
					break;
				case Face.King:
					face = "k";
					break;
				default:
					face = Convert.ToInt32(card.Face).ToString();
					break;
			}
			//spades-8-75.png
			return string.Format("{1}-{0}-75.png", face, card.Suit.ToString().ToLower());
		}

		public static bool CanFallOn(this Card what, Card on)
		{
			bool wRed = what.Suit == Suit.Diamonds || what.Suit == Suit.Hearts;
			bool oRed = on.Suit == Suit.Diamonds || on.Suit == Suit.Hearts;
			if (oRed == wRed)
				return false;
			return Convert.ToInt32(on.Face) - Convert.ToInt32(what.Face) == 1;
		}

		public static Card GetRandomCard(this List<Card> cards)
		{
			Card c = cards[Convert.ToInt32(new Random().NextDouble() * (cards.Count-1))];
			cards.Remove(c);
			return c;
		}
	}
}

