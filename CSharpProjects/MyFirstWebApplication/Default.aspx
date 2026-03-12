<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyFirstWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <html>
        <head>
            <title>
                My First ASP Web Forms Page
            </title>
        </head>
        <body>
            <form runat ="server" id ="form1">
                <h2>Student Management System</h2>
                Name: <asp:TextBox ID="textName" runat="server" OnTextChanged="textName_TextChanged"></asp:TextBox>
                Age: <asp:TextBox ID="textAge" runat="server" OnTextChanged="textName_TextChanged"></asp:TextBox>

                <asp:Button ID="btnAdd" runat="server" Text="Add Student" OnClick="Btn_Submit" Width="140px" />
                <asp:Label ID="message" runat="server"></asp:Label>
            </form>
        </body>
    </html>



</asp:Content>
