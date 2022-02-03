/*
* Filename      :       page4.aspx.cs
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the fourth code-behind page of the hi-lo game that required player to choose 
*                       if they would like to play again after winning the game
*/

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_A05.page4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string name;

        /// <summary>
        /// This method display a message after the player won the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (string)Session["name"];
            winMsgID.InnerHtml = "Congrats " + name + ", you have won this hi-lo game!";
        }

        /// <summary>
        /// This method will take the player back to max number entry page if wish to play again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void playAgainBtnID_Click(object sender, EventArgs e)
        {
            Server.Transfer(@"../page2/page2.aspx");
        }
    }
}