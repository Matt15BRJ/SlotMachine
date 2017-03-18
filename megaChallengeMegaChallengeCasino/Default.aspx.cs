using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;

namespace megaChallengeMegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();//create random class to get random number for spin images later

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //set initial reel images
                string[] reelSpinImages = new string[3];
                getReelSpinImages(out reelSpinImages);
                //initialize players bank with $100
                ViewState.Add("PlayersBank", 100);
                displayPlayersBank();
            }
            SoundPlayer my_wav_file = new SoundPlayer("C:/Users/Owner/Documents/Visual Studio 2015/Projects/megaChallengeMegaChallengeCasino/megaChallengeMegaChallengeCasino/sounds/slotSound.wav");
            my_wav_file.PlayLooping();
        }

        private void displayPlayersBank()
        {
            playersBankLabel.Text = String.Format("Player's Money: {0:C}", ViewState["PlayersBank"]);
        }

        protected void pullLeverButton_Click(object sender, EventArgs e)
        {
            //get players bet
            int playersBet = getPlayerBet();
            //ensure players bet is valid and not more than what is in their bank
            if (!validatePlayersBet(playersBet)) return;
            //get random images for 3 reels
            string[] reelSpinImages = new string[3];
            getReelSpinImages(out reelSpinImages);
            //check results
            winnerOrLose(playersBet, reelSpinImages);
        }

        private int getPlayerBet()
        {
            int playersBet;
            if (!int.TryParse(playersBetTextBox.Text, out playersBet))
                return 0;
            return playersBet;
        }

        private bool validatePlayersBet(int playersBet)
        {
            //make sure the player entered a valid integer for a bet and
            //that it doesn't exceed their bank
            if ((playersBet == 0) || (playersBet > getPlayersBank()))
            {
                resultLabel.Text = "Please enter a valid bet.";
                return false;
            }
            else return true;
        }

        private void getReelSpinImages(out string[] reelSpinImage)
        {
            reelSpinImage = new string[3] { getReelImages(), getReelImages(), getReelImages() };
            displayReelSpinImages(reelSpinImage);
        }

        private void displayReelSpinImages(string[] reelSpinImage)
        {
            Image1.ImageUrl = "images/" + reelSpinImage[0];
            Image2.ImageUrl = "images/" + reelSpinImage[1];
            Image3.ImageUrl = "images/" + reelSpinImage[2];
        }

        private string getReelImages()
        {
            string[] reelImages = new string[12] { "Bar.png", "Bell.png", "Cherry.png",
                "Clover.png", "Diamond.png", "HorseShoe.png", "Lemon.png", "Orange.png",
                "Plum.png", "Seven.png", "Strawberry.png", "Watermellon.png"};
            string spinImage = reelImages[random.Next(reelImages.Length)];
            return spinImage;
        }

        private void winnerOrLose(int playersBet, string[] reelSpinImages)
        {
            //check images for winning combos and return win multiplier
            int winMultiplier = checkImageCombo(reelSpinImages);
            //calculate winnings, if any
            int winnings = calculateWinnings(winMultiplier, playersBet);
            //add or subtract win/loss from players bank
            calculatePlayerBank(winnings, playersBet);
            //output result of spin
            displaySpinResult(winnings, playersBet);
        }

        private int checkImageCombo(string[] reelSpinImages)
        {
            //check for winning combos and return win multiplier
            if(checkForBars(reelSpinImages)) return 0;
            if(checkForJackpot(reelSpinImages)) return 100;
            if(checkForThreeCherries(reelSpinImages)) return 4;
            if(checkForTwoCherries(reelSpinImages)) return 3;
            if(checkForOneCherry(reelSpinImages)) return 2;
            else return 0;
        }

        private bool checkForBars(string[] reelSpinImages)
        {
            if ((reelSpinImages[0] == "Bar.png")
                || (reelSpinImages[1] == "Bar.png")
                || (reelSpinImages[2] == "Bar.png"))
                return true;
            return false;
        }

        private bool checkForJackpot(string[] reelSpinImages)
        {
            if ((reelSpinImages[0] == "Seven.png")
                && (reelSpinImages[1] == "Seven.png")
                && (reelSpinImages[2] == "Seven.png"))
                return true;
            return false;
        }

        private bool checkForThreeCherries(string[] reelSpinImages)
        {
            if ((reelSpinImages[0] == "Cherry.png")
                && (reelSpinImages[1] == "Cherry.png")
                && (reelSpinImages[2] == "Cherry.png"))
                return true;
            return false;
        }

        private bool checkForTwoCherries(string[] reelSpinImages)
        {
            if (((reelSpinImages[0] == "Cherry.png") && (reelSpinImages[1] == "Cherry.png"))
                || ((reelSpinImages[0] == "Cherry.png") && (reelSpinImages[2] == "Cherry.png"))
                || ((reelSpinImages[1] == "Cherry.png") && (reelSpinImages[2] == "Cherry.png")))
                return true;
            return false;
        }

        private bool checkForOneCherry(string[] reelSpinImages)
        {
            if ((reelSpinImages[0] == "Cherry.png")
                || (reelSpinImages[1] == "Cherry.png")
                || (reelSpinImages[2] == "Cherry.png"))
                return true;
            return false;
        }

        private int calculateWinnings(int winMultiplier, int playersBet)
        {
            int winnings = winMultiplier * playersBet;
            return winnings;
        }

        private void calculatePlayerBank(int winnings, int playersBet)
        {
            ViewState["PlayersBank"] = getPlayersBank() - playersBet + winnings;
            displayPlayersBank();
        }

        private void displaySpinResult(int winnings, int playersBet)
        {
            //display results of the lever pull to the user
            if (winnings > 0)
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!",
                    playersBet, winnings);
            else
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.",
                    playersBet);
        }

        protected void addMoneyButton_Click(object sender, EventArgs e)
        {
            addMoneyToPlayersBank();
            addCoinsSound();
        }

        private void addCoinsSound()
        {
            SoundPlayer addCoins = new SoundPlayer("C:/Users/Owner/Documents/Visual Studio 2015/Projects/megaChallengeMegaChallengeCasino/megaChallengeMegaChallengeCasino/sounds/insertCoins.wav");
            addCoins.Play();
        }

        private void addMoneyToPlayersBank()
        {
            ViewState["PlayersBank"] = getPlayersBank() + 100;
            displayPlayersBank();
        }

        private int getPlayersBank()
        {
            return Convert.ToInt32(ViewState["PlayersBank"]);
        }
    }
}