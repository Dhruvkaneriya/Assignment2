using System;
using System.Collections.Generic;

namespace A2
{
    class Program
	{
		static void Main(string[] args)
		{
			// first program 
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

            Console.WriteLine();

			// second program
			ParticleMovement particleMover = new ParticleMovement();
			while (true)
			{
				Console.Write("0 for base movement only\n1 if a magnetic field is present\n" +
							  "2 if a gravitational field is present\n3 for both fields\n");
				char key = Console.ReadKey().KeyChar;
				if (key != '0' && key != '1' && key != '2' && key != '3') return;
				
				// 10. I am call MagneticField and GravitationalField in main method.
				particleMover.MagneticField = (key == '1' || key == '3');
				particleMover.GravitationalField = (key == '2' || key == '3');
				Console.WriteLine($"\nParticle with a movement range of {particleMover.MovementRange} units" +
								  $" moved a total distance of {particleMover.DistanceMoved} units.\n");
			}
		}

		// second method class 
		class ParticleMovement
		{
			static Random random = new Random(1);

			// 7. I am making Xml documentation code
			/// <summary>
			/// Also i will explain all public class members in this xml code.
			/// </summary>
			/// <param name="BASE_Movement">Here i will make constant base movement variable.</param>
			/// <param name="GRAVITY_MOVEMENT">Here i will make constant gravity movement variable.</param>
			/// <param name="MovementRange">Here i will make movementRange property. </param>
			/// <param name="MagneticField">Here i will make MagneticField property.</param>
			/// <param name="GravitationalField">Here i will make GravitationalField property.</param>
			/// <param name="Distance">Here i will make auto-property "Distance".</param>
			/// <returns></returns>

			public const int BASE_MOVEMENT = 3;
			public const int GRAVITY_MOVEMENT = 2;

			// 1. I am making MovementRange property with getter and setter values.
			private int movementRange;
			public int MovementRange
			{
				get { return movementRange; }
				set { movementRange = value;}
			}

			// 3. I am making MagneticField property with getter and setter values.
			private bool magneticField;
			public bool MagneticField
			{
				get { return magneticField; }
				set { magneticField = value; }
			}

			// 2. I am making GravitationalField property with getter and setter values.
			private bool gravitationalField;
			public bool GravitationalField
			{
				get { return gravitationalField; }
				set { gravitationalField = value; }
			}

			public int DistanceMoved;

			// 4. I am making auto-implemented property Distance with public and private accessor.
			public double Distance
			{ get; private set; }

			// 5. I am deleting MagneticMultiplier and the GravityMovement field and update CalculateDistance() method.
			public void CalculateDistance()
			{
				if (GravitationalField == true && MagneticField == true)
					DistanceMoved = MovementRange + BASE_MOVEMENT + GRAVITY_MOVEMENT;
			}

			// 6. I am making Particalemovement constructor and call CalculateDistance() method.
			private int movement_range;
			public ParticleMovement()
			{
				movementRange = movement_range;
				CalculateDistance();
				GetMovementRange(); // 9. I am calling GetMovementRange() method in constructor.
			}

			// 8. I am making GetMovementRange() method and calculate movementRange.
			public void GetMovementRange()
			{
				movementRange = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
			}

		}

		// first method class
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

			// I am making cards values like "Ace", "Jack", "Queen", "King" enumaration instad of string.
			enum Values
			{
				Ace,
				Jack,
				Queen,
				King
			}

			private static string RandomValue()
			{
				int value = random.Next(1, 14);
				switch (value)
				{
					// In switch funcation I am calling cards values enumaration.

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

			// I am making cards suits like "Clubs", "Diamonds", "Hearts", "Spades" enumaration instad of string.
			enum Suits
			{
				Clubs,
				Diamonds,
				Hearts,
				Spades
			}

			private static string RandomSuit()
			{
				int value = random.Next(1, 5);
				switch (value)
				{
					// In switch funcation I am calling cards suits enumaration.

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
}
