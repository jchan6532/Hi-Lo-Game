/*
* Filename      :       page2.aspx.cs
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the second code-behind page of the hi-lo game that required player to input a max number 
*                       as range and submit to move on the next step of the game
*/

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_A05.page2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string name;
        private int randInt;

        /// <summary>
        /// This method helps to load the current page, player name is retrieved from previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // obtain player name
            if (this.PreviousPage != null)
            {
                name = (string)Session["name"];
            }
            else if (this.IsPostBack)
            {
                name = (string)Session["name"];
            }
            else
            {
                name = "unknown";
            }
            greetingMsgID.InnerText = "hello " + name;
        }

        /// <summary>
        /// This method helps to validate max number input and random number generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void maxRangesubmitBtnID_Click(object sender, EventArgs e)
        {

            if (maxRangeRequiredValidtor.IsValid) 
            {
                // generate a random number when max range input is valid
                if (maxRangeValidtor.IsValid)
                {
                    maxRangeRequiredValidtor.Display = ValidatorDisplay.Static;
                    maxRangeValidtor.Display = ValidatorDisplay.Static;
                    randInt = 0;
                    Random random = new Random();
                    randInt = random.Next(1, Int32.Parse(maxRangeTBoxID.Text));
                    Session["randInt"] = (object)randInt;
                    Session["maxRange"] = (object)Int32.Parse(maxRangeTBoxID.Text);
                    Server.Transfer("../page3/page3.aspx");
                }
                else
                {
                    maxRangeValidtor.Display = ValidatorDisplay.Dynamic;
                }
            }
            else
            {
                maxRangeRequiredValidtor.Display = ValidatorDisplay.Dynamic;
            }
        }

        /// <summary>
        /// This method validate the max number input textbox 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void maxRangeValidtor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int testInt;

            if (Int32.TryParse(args.Value, out testInt))
            {
                // max number must be greater than 1
                if(testInt > 1)
                {
                    args.IsValid = true;
                }

                // provide feedback message to player 
                else
                {
                    maxRangeTBoxID.Text = "";
                    maxRangeValidtor.ErrorMessage = "max range must be greater than 1";
                    args.IsValid = false;
                    maxRangeValidtor.Display = ValidatorDisplay.Dynamic;
                    maxRangeRequiredValidtor.Display = ValidatorDisplay.Dynamic;
                }
            }
            else
            {
                float testFloat;

                // max number must be an integer 
                if(float.TryParse(args.Value, out testFloat))
                {
                    maxRangeValidtor.ErrorMessage = "max range must be an integer";
                }

                // provide feedback message to player 
                else
                {
                    maxRangeValidtor.ErrorMessage = "max range must be an integer only, no alphabets";
                }

                maxRangeTBoxID.Text = "";
                args.IsValid = false;
                maxRangeValidtor.Display = ValidatorDisplay.Dynamic;
                maxRangeRequiredValidtor.Display = ValidatorDisplay.Dynamic;
            }
        }
    }
}