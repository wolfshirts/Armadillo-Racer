using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace space_races
{
    class Bettor
    {
        public string name; //bettors name;
        public Bet myBet = new Bet(); //the bet.
        public int myCash; //available cash.
        public RadioButton myRadioButton; //This is assigned at instantiation
        public Label myLabel; //assigned at instantiation.

        public void UpdateLabels()
        {
            //set my label to my bet's description, and the label on my button to show my cash.
            //"joe has 43 bucks"
            myRadioButton.Text = name + " has " + myCash + " Dollars.";
            myLabel.Text = myBet.GetDescription();
        }

        public void ClearBet()
        {
            //reset my bet to 0;
            myBet.amount = 0;
        }

        public bool PlaceBet(int betAmount, int racerToWin)
        {
            //place a new bet and store it in the bet field.
            //return true if i have enough to bet.
            if(myCash - betAmount <= 0)
            {
                return false;
            }
            else
            {
                myBet = new Bet()
                {
                    amount = betAmount,
                    bettor = this,
                    racer = racerToWin
                };
                return true;
            }
        }

        public void Collect(int winner)
        {
            //ask my bet to pay out, clear my bet, and update my labels.
            myBet.Payout(winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
