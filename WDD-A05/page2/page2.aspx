<%--
* Filename      :       page2.aspx
* project       :       WDD: A5 - Client Hi-Lo Game with Server Side Validation
* By            :       Justin Chan, Paige Lam
* Date          :       Nov 8th, 2021
* Description   :       This aspx page is the second page of the hi-lo game that required player to input a max number 
*                       as range and submit to move on the next step of the game
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="WDD_A05.page2.WebForm1" %>

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
                    <div id="greetingMsgID" runat="server"></div>
                    <br />
                    <asp:Label ID="maxRangeLabelID" runat="server" Text="Please enter the max range"></asp:Label>
                    <asp:TextBox ID="maxRangeTBoxID" runat="server"></asp:TextBox>
                    <br />
                    <div id="validatorsID">
                        <asp:RequiredFieldValidator ID="maxRangeRequiredValidtor" runat="server" Display="Dynamic" ControlToValidate="maxRangeTBoxID" SetFocusOnError="true" ErrorMessage="max range cannot be empty" ForeColor="Brown"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="maxRangeValidtor" runat="server" Display="Dynamic" ControlToValidate="maxRangeTBoxID" SetFocusOnError="true" ErrorMessage="max range must be greater than 1" ForeColor="Brown" OnServerValidate="maxRangeValidtor_ServerValidate"></asp:CustomValidator>
                    </div>
                    <br /><br />
                    <asp:Button ID="maxRangesubmitBtnID" runat="server" Text="submit max range" OnClick="maxRangesubmitBtnID_Click" />
                    <div id="maxRangeErrorMsgID" runat="server" name="maxRangeErrorMsgNAME" class="errorMsg"></div>
                    <input type="hidden" id="randIntID" runat="server" name="randIntNAME" value="0" />

                    <asp:PlaceHolder ID="placeholder" runat="server"></asp:PlaceHolder>
                </div>
            </form>
        </div>
    </body>
</html>
