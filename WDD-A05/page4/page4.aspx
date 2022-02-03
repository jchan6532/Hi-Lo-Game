<%--
* Filename      :       page4.aspx
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the fourth page of the hi-lo game that required player to choose 
*                       if they would like to play again after winning the game
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page4.aspx.cs" Inherits="WDD_A05.page4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="../styles/style1.css"/>

    </head>
    <body>
        <div class="center">
            <form id="form1" runat="server">
                <div class ="content">
                    <h1 id="winMsgID" runat="server" name="winMsgNAME" style="font-family: 'Yu Gothic UI'; color: white"></h1>
                    <asp:Button ID="playAgainBtnID" runat="server" Text="play again" OnClick="playAgainBtnID_Click" />
                </div>
            </form>
        </div>
    </body>
</html>
