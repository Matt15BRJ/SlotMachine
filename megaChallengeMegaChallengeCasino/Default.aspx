<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="megaChallengeMegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFF00;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body style="background-color: #000000">
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="270px" OnDataBinding="pullLeverButton_Click" BorderColor="#FFCC00" BorderWidth="6px" />
        <asp:Image ID="Image2" runat="server" Height="270px" OnDataBinding="pullLeverButton_Click" Width="236px" BorderColor="#FFCC00" BorderWidth="6px" />
        <asp:Image ID="Image3" runat="server" Height="270px" OnDataBinding="pullLeverButton_Click" Width="236px" BorderColor="#FFCC00" BorderWidth="6px" />
        <br />
        <br />
        <br />
        <span class="auto-style1"><strong>Your Bet:</strong></span>
        <asp:TextBox ID="playersBetTextBox" runat="server" BackColor="Black" ForeColor="#33CC33"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server" ForeColor="Lime" style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
        <br />
        <br />
        <asp:Button ID="pullLeverButton" runat="server" OnClick="pullLeverButton_Click" Text="Pull The Lever!!" BackColor="#66FF66" ForeColor="Black" />
        <br />
        <br />
        <br />
        <strong><asp:Label ID="playersBankLabel" runat="server" CssClass="auto-style1" ForeColor="#33CC33"></asp:Label>
        <br class="auto-style1" />
        <br class="auto-style1" />
        </strong><span class="auto-style1"><strong>Payout::</strong></span><strong><br class="auto-style1" />
        </strong><span class="auto-style1"><strong>1 Cherry - 2x Your Bet</strong></span><strong><br class="auto-style1" />
        </strong><span class="auto-style1"><strong>2 Cherries - 3x Your Bet</strong></span><strong><br class="auto-style1" />
        </strong><span class="auto-style1"><strong>3 Cherries - 4x Your Bet</strong></span><strong><br class="auto-style1" />
        </strong><span class="auto-style1"><strong>3 7&#39;s - JACKPOT - 100x Your Bet</strong></span><strong><br class="auto-style1" />
        <br class="auto-style1" />
        </strong><span class="auto-style1"><strong>HOWEVER</strong></span><strong><br class="auto-style1" />
        </strong><span class="auto-style1"><strong>If there is even one(1) BAR showing you win nothing...<br />
        <br />
        </strong>
        <asp:Button ID="addMoneyButton" runat="server" BackColor="#66FF66" OnClick="addMoneyButton_Click" Text="Add Another $100" />
        </span><br />
    
    </div>
    </form>
</body>
</html>
