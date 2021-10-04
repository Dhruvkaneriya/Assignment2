using System;
using System.Collections.Generic;

namespace A2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of cards to pick: ");
			string line = Console.ReadLine();
			if (int.TryParse(line, out int numCards))
			{
				foreach (var card in CardPicker.PickSomeCards(numCards))
				{
					Console.WriteLine(card);
				}
			}
			else
			{
				Console.WriteLine("Please enter a valid number.");
			}
		}
	}

	public static class SubsequenceFinder
	{
		public static bool IsValidSubsequeuce(List<int> seq, List<int> subseq)
		{
			int seqIdx = 0;
			int subseqIdx = 0;
			while (seqIdx < seq.Count && subseqIdx < subseq.Count)
			{
				if (seq[seqIdx] == subseq[subseqIdx])
				{
					++subseqIdx;
				}
				++seqIdx;
			}
			return subseqIdx == subseq.Count;
		}
	}

	class CardPicker
	{
		static Random random = new Random(1);

		public static string[] PickSomeCards(int numCards)
		{
			string[] pickedCards = new string[numCards];
			for (int i = 0; i < numCards; ++i)
			{
				pickedCards[i] = RandomValue() + " of " + RandomSuit();
			}
			return pickedCards;
		}

		enum Values
		{ 
			Ace,
			Jack,
			Queen,
			King,
		}

		private static string RandomValue()
		{
			int value = random.Next(1, 14);
			switch (value)
			{
				case 1:
					Values One = Values.Ace;
					return One.ToString();
				case 11:
					Values Eleven = Values.Jack;
					return Eleven.ToString();
				case 12:
					Values Twelve = Values.Queen;
					return Twelve.ToString();
				case 13:
					Values Thirteen = Values.King;
					return Thirteen.ToString();
				default:
					// The integers 2 -> 10 can just be converted to a string
					return value.ToString();
			}
		}

		enum Suits
		{
			Clubs,
			Diamonds,
			Hearts,
			Spades,
		}

		private static string RandomSuit()
		{
			int value = random.Next(1, 5);
			switch (value)
			{
				case 1:
					Suits C = Suits.Clubs;
					return C.ToString();
				case 2:
					Suits D = Suits.Diamonds;
					return D.ToString();
				case 3:
					Suits H = Suits.Hearts;
					return H.ToString();
				default:
					Suits S = Suits.Spades;
					return S.ToString();
			}
		}
	}
}
