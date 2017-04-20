<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="HelloWorldLabel"></asp:Label>
        <br /><br />
        <asp:TextBox runat="server" ID="TextInput" Height="50px" Width="181px" />
    </div>
        <p>
        <asp:Button runat="server" ID="GreetButton" Text="Say Hello!" OnClick="GreetButton_Click" />
        </p>
    </form>
</body>
</html>
