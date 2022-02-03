 <%--
* Filename      :       page1.aspx
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the first page of the hi-lo game that required player to input a name 
*                       and submit to start the game
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="WDD_A05.page1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>hi-lo game</title>
        <link rel="stylesheet" type="text/css" href="../styles/style.css"/>
    </head>
    <body>
        <div class="center">
            <form id="form1" runat="server">
                <div class ="content">
                    <asp:Label ID="nameLabelID" runat="server" Text="Please enter your name"></asp:Label>
                    <asp:TextBox ID="nameTBoxID" runat="server"></asp:TextBox>
                    <br />
                    <div id="validatorsID">
                        <asp:RequiredFieldValidator ID="nameRequiredValidtor" runat="server" Display="dynamic" ControlToValidate="nameTboxID" SetFocusOnError="true" ErrorMessage="a name must be required to continue, name field cannot be empty" ForeColor="Brown"></asp:RequiredFieldValidator>
                    </div>
                    <br /><br />
                    <asp:Button ID="nameSubmitBtnID" runat="server" Text="submit name" OnClick="nameSubmitBtnID_Click" CausesValidation="true"/>
                    <div id="nameErrorMsgID" runat="server" name="nameErrorMsgNAME" class="errorMsg"></div>
                </div>
            </form>
        </div>
    </body>
</html>
