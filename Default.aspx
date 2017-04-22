<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="MainLabel"></asp:Label>
        <br />
        <asp:RadioButton ID="KMP" runat="server" Checked="True" OnCheckedChanged="KMP_CheckedChanged" Text="KMP Algorithm" AutoPostBack="True" />
        <asp:RadioButton ID="BayerMoore" runat="server" OnCheckedChanged="BayerMoore_CheckedChanged" Text="BayerMoore Algorithm" AutoPostBack="True" />
        <asp:RadioButton ID="Regex" runat="server" OnCheckedChanged="Regex_CheckedChanged" Text="Regex" AutoPostBack="True" />
        <br />
        <asp:TextBox runat="server" ID="TextInput" Height="50px" Width="181px" />
    </div>
        <p>
        <asp:Button runat="server" ID="GreetButton" Text="Search" OnClick="GreetButton_Click" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
