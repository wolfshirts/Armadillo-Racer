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

        //give our racers a randomizer;
        public Random randomGen = new Random();

        public Form1()
        {
            InitializeComponent();
            InitBettors();
            InitRacers();
            Update();
            //currentBettorLabel.Text = WhoIsBetting().name;
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

            racerOne = new Racer()
            {
                location = 0,
                racerPicture = trackOneBox,
                startingPosition = trackOneBox.Left,
                racetrackLength = trackLength,
                randomizer = randomGen
            };

            racerTwo = new Racer()
            {
                location = 0,
                racerPicture = trackTwoBox,
                startingPosition = trackTwoBox.Left,
                racetrackLength = trackLength,
                randomizer = randomGen
            };

            racerThree = new Racer()
            {
                location = 0,
                racerPicture = trackThreeBox,
                startingPosition = trackThreeBox.Left,
                racetrackLength = trackLength,
                randomizer = randomGen
            };

            racerFour = new Racer()
            {
                location = 0,
                racerPicture = trackFourBox,
                startingPosition = trackFourBox.Left,
                racetrackLength = trackLength,
                randomizer = randomGen
            };

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
            currentBettorLabel.Text = WhoIsBetting().name;
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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            raceButton.Enabled = false;
            for (int i = 0; i < racers.Length; i++)
            {
                if (racers[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Racer " + (i+1) + " wins!");
                   
                    ResetRacers();
                    Update();
                    for (int j = 0; j < bettors.Length; j++)
                    {
                        bettors[j].Collect(i + 1); //Array starts at 0, racers are numbered 1-4, should've used 0 as start but didn't.
                                                   //So adding +1 to the array gives us the correct winner to collect on.
                    }
                    raceButton.Enabled = true;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Bettor currentBettor = WhoIsBetting();
            if (!currentBettor.PlaceBet((int)betAmountControl.Value, (int)racerSelectionControl.Value))
            {
                MessageBox.Show("Not enough funds.");
            }
            else
            {
                currentBettor.PlaceBet((int)betAmountControl.Value, (int)racerSelectionControl.Value);
                Update();
            }
        }

        private void bettorOneRadio_CheckedChanged(object sender, EventArgs e)
        {
            //This is just to ensure that the bettor name changes when radiobuttons are clicked.
            //All of the radio buttons link up to this method.
            Update();
        }

    }
}