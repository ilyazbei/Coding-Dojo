using System;
using System.Collections.Generic;

namespace BlackJack{
    public class Player{
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name){
            Name = name;
            Hand = new List<Card>();
        }

        public Card Draw(Deck deck){
            Card DealtCard = deck.Deal();
            Hand.Add(DealtCard);
            return DealtCard;
        }

        public Card Discard(int idx){
            idx--;
            if(idx >= Hand.Count || idx < 0){
                Console.WriteLine("OUT OF INDEX");
                return null;
            }
            Card DiscardedCard = Hand[idx];
            Hand.RemoveAt(idx);
            return DiscardedCard;
        }
    }
}