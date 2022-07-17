using System;
using System.Linq;
using System.Collections.Generic;
namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cards = new List<Card>();

            var deckCardsInfo = Console.ReadLine().Split(", ").ToArray();
            
            foreach (var cardInfo in deckCardsInfo)
            {
                try
                {
                    var cardFaceInfo = cardInfo.Split();
                    var cardFace = cardFaceInfo[0];
                    var cardSuit = cardFaceInfo[1];
                    var card = new Card(cardFace, cardSuit);
                    cards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }


    public class Card
    {

        private readonly ICollection<string> validFaces;
        private readonly ICollection<string> validSuits;

        private string face;
        private string suit;

        private Card()
        {
            this.validFaces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            this.validSuits = new List<string> { "S", "H", "D", "C", };
        }

        public Card(string face, string suit)
            : this()
        {
            this.Face = face;
            this.Suit = suit;

        }


        public string Face
        {
            get { return face; }
            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                //ValidateFace(face);
                face = value;
            }
        }

        public string Suit
        {
            get { return suit; }
            private set
            {
                if (!validSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                //ValidateSuit(suit);
                if (value == "S")
                    this.suit = "\u2660";
                else if (value == "H")
                    this.suit = "\u2665";
                else if (value == "D")
                    this.suit = "\u2666";
                else
                    this.suit = "\u2663";
            }
        }

        public override string ToString()
        {
            return $"[{this.face}{this.suit}]";
        }

        //private void ValidateFace(string face)
        //{
        //    if (!faces.Contains(face))
        //    {
        //        throw new ArgumentException($"Invalid card!");
        //    }

        //}
        //private void ValidateSuit(string suit)
        //{
        //    if (!suits.Contains(suit))
        //    {
        //        throw new ArgumentException($"Invalid card!");
        //    }

        //}

    }
}
