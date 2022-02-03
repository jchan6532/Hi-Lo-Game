/*
* Filename      :       page3.aspx.cs
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the third code-behind page of the hi-lo game that required player to input a guess
*                       to play the game, player will keep going until the right number is guessed
*/

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_A05.page3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string name;
        private int randInt;
        private int maxRange;
        private int lower;
        private int higher;
        private int guess;
        private int numGuesses;

        /// <summary>
        /// This method contains information required to load guess page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            guess = 0;

            if(this.PreviousPage != null)
            {
                name = (string)Session["name"];
                randInt = (int)Session["randInt"];
                maxRange = (int)Session["maxRange"];

                higher = maxRange;
                lower = 1;
                numGuesses = 0;
                Session["higher"] = (object)higher;
                Session["lower"] = (object)lower;
                Session["numGuesses"] = (object)numGuesses;
            }
            else if (this.IsPostBack)
            {
                name = (string)Session["name"];
                randInt = (int)Session["randInt"];
                maxRange = (int)Session["maxRange"];
                higher = (int)Session["higher"];
                lower = (int)Session["lower"];
                numGuesses = (int)Session["numGuesses"];
            }
            else
            {
                name = "Unknown";
                randInt = -1;
                maxRange = 1;
                lower = 0;
                higher = 0;
                guess = 0;
                numGuesses = 0;
            }

            guessLabelID.Text = name + ", please enter your guess: ";
            guessErrorMsgID.InnerHtml = "number of guesses: " + (numGuesses).ToString() + "<br />";

            // feedback message
            guessErrorMsgID.InnerHtml += "Your allowable guessing range is any value between " + lower.ToString() + " - " + higher.ToString();
        }

        /// <summary>
        /// This method validates guess(es) player entered
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void guessValidtor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Int32.TryParse(args.Value, out guess))
            {
                args.IsValid = true;
            }
            else
            {
                guessTBoxID.Text = "";
                args.IsValid = false;
                guessRequiredValidtor.Display = ValidatorDisplay.Dynamic;
                guessValidtor.Display = ValidatorDisplay.Dynamic;
            }
        }

        /// <summary>
        /// This method provides feedback after player entered a guess
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void guessBtnID_Click(object sender, EventArgs e)
        {
            // appropriate feedback messages will be displayed if out of range
            if (guessRequiredValidtor.IsValid == true)
            {
                if (guessValidtor.IsValid == true)
                {
                    numGuesses++;
                    guessErrorMsgID.InnerHtml = "number of guesses: " + (numGuesses).ToString() + "<br />";
                    guessRequiredValidtor.Display = ValidatorDisplay.Static;
                    guessValidtor.Display = ValidatorDisplay.Static;
                    
                    if ((guess < lower) || (guess > higher))
                    {
                        guessErrorMsgID.InnerHtml += "You are out of Range!" + "<br />";
                        guessErrorMsgID.InnerHtml += "Your allowable guessing range is any value between " + lower.ToString() + " - " + higher.ToString();
                    }
                    else if (guess > randInt)
                    {
                        guessErrorMsgID.InnerHtml += "Your allowable guessing range is any value between " + lower.ToString() + " - " + (--guess).ToString();
                        higher = guess;
                    }
                    else if (guess < randInt)
                    {
                        guessErrorMsgID.InnerHtml += "Your allowable guessing range is any value between " + (++guess).ToString() + " - " + higher.ToString();
                        lower = guess;
                    }

                    // if guess matched random number generated go to next page
                    else if (guess == randInt)
                    {
                        Server.Transfer("../page4/page4.aspx");
                    }
                    guessTBoxID.Text = "";

                    Session["name"] = (object)name;
                    Session["randInt"] = (object)randInt;
                    Session["maxRange"] = (object)maxRange;
                    Session["higher"] = (object)higher;
                    Session["lower"] = (object)lower;
                    Session["numGuesses"] = (object)numGuesses;
                }
                else
                {
                    guessValidtor.Display = ValidatorDisplay.Dynamic;
                }
            }
            else
            {
                guessRequiredValidtor.Display = ValidatorDisplay.Dynamic;
            }
            guessTBoxID.Text = "";
            guessTBoxID.Focus();
        }
    }
}