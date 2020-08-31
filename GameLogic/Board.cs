using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    public class Board<T>
    {
        private readonly IEnumerable<T> r_DeckOfCards;
        private IEnumerator<T> m_CardsIterator;

        public Board(IEnumerable<T> i_DeckOfCards, int i_Height, int i_Width)
        {
            IEnumerable<T> deckOfCards = i_DeckOfCards.ToList();
            r_DeckOfCards = deckOfCards;
            Height = i_Height;
            Width = i_Width;
            Cards = new Card<T>[i_Height, i_Width];
            m_CardsIterator = deckOfCards.GetEnumerator();
            AvailableCards = new LinkedList<Card<T>>();

            for (int i = 0; i < i_Height; i++)
            {
                for (int j = 0; j < (i_Width + 1) / 2; j++)
                {
                    T cardValue = getNextCardInDeck();
                    Cards[i, j] = new Card<T>(cardValue);
                    Cards[i, i_Width - j - 1] = new Card<T>(cardValue);
                    AvailableCards.AddLast(Cards[i, j]);
                    AvailableCards.AddLast(Cards[i, i_Width - j - 1]);
                }
            }

            shuffleBoard();
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public Card<T>[,] Cards { get; }

        public LinkedList<Card<T>> AvailableCards { get; }

        public void FlipCardUpWards(Card<T> i_Card)
        {
            i_Card.IsSelected = true;
            AvailableCards.Remove(i_Card);
        }

        public void FlipCardDownWards(Card<T> i_Card)
        {
            i_Card.IsSelected = false;
            AvailableCards.AddLast(i_Card);
        }

        public Card<T> GetAvailableCardByIndex(int i_Index)
        {
            LinkedList<Card<T>>.Enumerator iterator = AvailableCards.GetEnumerator();
            for (int i = 0; i <= i_Index; i++)
            {
                iterator.MoveNext();
            }

            return iterator.Current;
        }

        public Card<T> RemoveAvailableCardByIndex(int i_Index)
        {
            Card<T> cardToRemove = GetAvailableCardByIndex(i_Index);
            cardToRemove.IsSelected = true;
            AvailableCards.Remove(cardToRemove);

            return cardToRemove;
        }

        public bool IsGameOver()
        {
            bool isGameOver = AvailableCards.Count <= 0;

            return isGameOver;
        }

        private T getNextCardInDeck()
        {
            m_CardsIterator.MoveNext();
            if (m_CardsIterator == null)
            {
                m_CardsIterator = r_DeckOfCards.GetEnumerator();
            }

            return m_CardsIterator.Current;
        }

        private void shuffleBoard()
        {
            Random random = new Random();

            for (int i = 0; i < Cards.GetLength(0); i++)
            {
                for (int j = 0; j < Cards.GetLength(1); j++)
                {
                    int randomRow = random.Next(Cards.GetLength(0) - 1);
                    int randomColumn = random.Next(Cards.GetLength(1) - 1);
                    Card<T> tempCard = Cards[i, j];
                    Cards[i, j] = Cards[randomRow, randomColumn];
                    Cards[randomRow, randomColumn] = tempCard;
                }
            }
        }
    }
}
