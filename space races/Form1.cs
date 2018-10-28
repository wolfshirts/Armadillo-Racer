using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace space_races
{
    public partial class Form1 : Form
    {
        //Declare our bettors.
        private Bettor bob;
        private Bettor al;
        private Bettor joe;

        //Declare arrays
        private Bettor[] bettors;
        private Racer[] racers;

        //declare our racers
        private Racer racerOne;
        private Racer racerTwo;
        private Racer racerThree;
        private Racer racerFour;

        public Form1()
        {
            InitializeComponent();
            InitBettors();
            InitRacers();
            Update();
        }

        private void InitBettors()
        {
            //Create our bettors, and add them to their array.
            joe = new Bettor() { myCash = 50, myLabel = bettorOneLabel, myRadioButton = bettorOneRadio, name = "Joe" };
            al = new Bettor() { myCash = 45, myLabel = bettorTwoLabel, myRadioButton = bettorTwoRadio, name = "Al" };
            bob = new Bettor() { myCash = 75, myLabel = bettorThreeLabel, myRadioButton = bettorThreeRadio, name = "Bob" };

            bettors = new Bettor[] { joe, al, bob };
        }

        private void InitRacers()
        {
            //Get the track length
            int trackLength = this.Size.Width - checkerFlag.Width;
            //Create our racers, and add them to their array.
            racerOne = new Racer() { location = 0, racerPicture = trackOneBox, startingPosition = trackOneBox.Left, racetrackLength = trackLength };
            racerTwo = new Racer() { location = 0, racerPicture = trackTwoBox, startingPosition = trackTwoBox.Left, racetrackLength = trackLength };
            racerThree = new Racer() { location = 0, racerPicture = trackThreeBox, startingPosition = trackThreeBox.Left, racetrackLength = trackLength };
            racerFour = new Racer() { location = 0, racerPicture = trackFourBox, startingPosition = trackFourBox.Left, racetrackLength = trackLength };
            racers = new Racer[] { racerOne, racerTwo, racerThree, racerFour };
        }

        private void Update()
        {
            minimumBetLabel.Text = "The minimum bet is: " + betAmountControl.Minimum;
            //update the bettors.
            for (int i = 0; i < bettors.Length; i++)
            {
                bettors[i].UpdateLabels();
            }
        }

        private Bettor WhoIsBetting()
        {
            Bettor activeBettor = null;

            for (int i = 0; i < bettors.Length; i++)
            {
                if (bettors[i].myRadioButton.Checked)
                {
                    activeBettor = bettors[i];
                }
            }
            return activeBettor;
        }

        private void ResetRacers()
        {
            for (int i = 0; i < racers.Length; i++)
            {
                racers[i].TakeStartingPosition();
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            if (WhoIsBetting() == null)
            {
                return;
            }
            Bettor activeBettor = WhoIsBetting();

            int x = 200;
            while (x > 0) {
                x--;
                for (int i = 0; i < racers.Length; i++)
                {
                    racers[i].Run();
                }
            }
            ResetRacers();
        }
    }
}