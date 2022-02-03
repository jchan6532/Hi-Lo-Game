<%--
* Filename      :       page3.aspx
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the third page of the hi-lo game that required player to input a guess
*                       to play the game, player will keep going until the right number is guessed
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page3.aspx.cs" Inherits="WDD_A05.page3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="../styles/style.css"/>
    </head>
    <body>
        <div class="center">
            <form id="form1" runat="server">
                <div class ="content">
                    <asp:Label ID="guessLabelID" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="guessTBoxID" runat="server"></asp:TextBox>
                    <br />
                    <div id="validatorsID">
                        <asp:RequiredFieldValidator ID="guessRequiredValidtor" runat="server" Display="Dynamic" ControlToValidate="guessTBoxID" SetFocusOnError="true" ErrorMessage="guess cannot be empty" ForeColor="Brown"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="guessValidtor" runat="server" Display="Dynamic" ControlToValidate="guessTBoxID" SetFocusOnError="true" ErrorMessage="guess must be an integer" ForeColor="Brown" OnServerValidate="guessValidtor_ServerValidate"></asp:CustomValidator>
                    </div>
                    <br /><br />
                    <asp:Button ID="guessBtnID" runat="server" Text="make this guess" OnClick="guessBtnID_Click"/>
                    <div id="guessErrorMsgID" runat="server" name="guessErrorMsgNAME" class="errorMsg"></div>        
                </div>
            </form>
        </div>
    </body>
</html>
