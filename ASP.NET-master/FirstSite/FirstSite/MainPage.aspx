<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="FirstSite.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
        Site
    </title>
    <h1>Hello world!</h1>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <p>My name is First Site!</p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button_Click" />
            
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>IDT</asp:ListItem>
            <asp:ListItem>Epam</asp:ListItem>
            <asp:ListItem>Sam solutions</asp:ListItem>
            
        </asp:DropDownList>
        <asp:CheckBox ID="CheckBox1" runat="server" />
    </form>
</body>
</html>
