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

		private static string RandomValue()
		{
			int value = random.Next(1, 14);
			switch (value)
			{
				case 1:
					return "Ace";
				case 11:
					return "Jack";
				case 12:
					return "Queen";
				case 13:
					return "King";
				default:
					// The integers 2 -> 10 can just be converted to a string
					return value.ToString();
			}
		}

		private static string RandomSuit()
		{
			int value = random.Next(1, 5);
			switch (value)
			{
				case 1:
					return "Clubs";
				case 2:
					return "Diamonds";
				case 3:
					return "Hearts";
				default:
					return "Spades";
			}
		}
	}
}
