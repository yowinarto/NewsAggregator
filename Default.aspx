<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News Aggregator</title>
    <style type="text/css">
        body {
            background: #d9d9d9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size: xx-large; font-family: 'Maiandra GD'; font-weight: bold">
        <asp:Label runat="server" ID="MainLabel">News Aggregator</asp:Label>
        </div>
        <br />
        <div style="border: medium dashed #000000; padding: 25px 15px 15px 15px; margin: inherit; font-family: Arial, Helvetica, sans-serif; font-size: medium; display: block; width: 316px; height: 109px; vertical-align: bottom; text-align: center;">
            <br />
        <asp:RadioButton ID="KMP" runat="server" Checked="True" OnCheckedChanged="KMP_CheckedChanged" Text="KMP Algorithm" AutoPostBack="True" />
            <br />
        <asp:RadioButton ID="BayerMoore" runat="server" OnCheckedChanged="BayerMoore_CheckedChanged" Text="BayerMoore Algorithm" AutoPostBack="True" />
            <br />
        <asp:RadioButton ID="Regex" runat="server" OnCheckedChanged="Regex_CheckedChanged" Text="Regex" AutoPostBack="True" />
        </div>
        <br />
    </div>
        <div style="width: 1393px; margin-left: 0px; margin-top: 0px">
        <asp:TextBox runat="server" ID="TextInput" Height="16px" Width="344px" style="margin-left: 0px; margin-top: 0px" />
        <asp:Button runat="server" ID="GreetButton" Text="Search" OnClick="GreetButton_Click" style="margin-left: 14px" />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
