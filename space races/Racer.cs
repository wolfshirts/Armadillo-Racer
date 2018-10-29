using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace space_races
{
    class Racer
    {
        public int startingPosition; //start location
        public int racetrackLength; //how long is the track
        public PictureBox racerPicture = null;
        public int location = 0; //location on the ractrack
        public Random randomizer; //only need this one.

        public bool Run()
        {
            //move forward either 1,2,3 or 4 spaces.
            int moveAmount = randomizer.Next(4);
            location += moveAmount;
            //update the picture on the form
            racerPicture.Left = startingPosition + location;

            if (racerPicture.Right >= racetrackLength)
            {   
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            //reset my location to 0 and my picturebox to start.
            location = 0;
            racerPicture.Left = startingPosition;
        }
        
    }
}
