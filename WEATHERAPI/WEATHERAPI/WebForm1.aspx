<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="YourNamespace.Weather" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weather</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Weather in Your City</h2>
            <asp:TextBox ID="cityval" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblTemp" runat="server"></asp:Label><br />
            <asp:Label ID="Label1" runat="server"></asp:Label><br />
            <asp:Label ID="Label2" runat="server"></asp:Label><br />
            <asp:Label ID="Label4" runat="server"></asp:Label><br />
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" runat="server" />
        </div>
    </form>
</body>
</html>
