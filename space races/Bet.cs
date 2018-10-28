using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_races
{
    //It's odd to create a bet object, but I guess it works.
    class Bet
    {
        public int amount;
        public int racer;
        public Bettor bettor;

        public string GetDescription()
        {
            //return who placed the bet, how much the bet was for,
            //if the amount is 0 no bet placed.
            //"Joe bets 8 on dog #4"
            if(amount == 0)
            {
                return bettor + " has no bet placed.";
            }
            else
            {
                return bettor.name + " bets " + amount + "on racer # " + racer;
            }
        }

        public int Payout(int winner)
        {
            //parameter is the winner of the race if the dog won return
            //the amount bet, otherwise return negative.
            if( winner == racer)
            {
                return amount;
            }
            else
            {
                return -amount;
            }
        }
    }
}
