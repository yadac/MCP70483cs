using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_10
    {
        public static void DoProc()
        {
        }
    }

    class Deck
    {
        private int _maximumNumberOfCards;

        //public ICollection<Card> Cards { get; private set; }
        public List<Card> Cards { get; private set; }


        public Deck()
        {
            List<int> myList = new List<int>() { 1, 3, 5 };
            myList[0] = 1;
        }

        public Deck(int maximumNumberOfCards)
        {
            _maximumNumberOfCards = maximumNumberOfCards;
            Cards = new List<Card>();
        }

        // indexer
        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }

    }

    class Card
    {

    }
}
