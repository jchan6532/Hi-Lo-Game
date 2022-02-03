/*
*Filename       :       page1.aspx.cs
* project       :       WDD: A5 - Client Hi - Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the first code-behind page of the hi-lo game that required player to input a name 
*                       and submit to start the game            
*/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_A05.page1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// This method initiate the current page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            nameErrorMsgID.InnerText = "";
            nameRequiredValidtor.Display = ValidatorDisplay.Static;
        }

        /// <summary>
        /// This method validate the player name input in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void nameSubmitBtnID_Click(object sender, EventArgs e)
        {

            if (nameRequiredValidtor.IsValid == true)
            {       
                Session["name"] = (object)nameTBoxID.Text;
                Server.Transfer("../page2/page2.aspx");
            }
        }
    }
}