<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-container">
        <form id="loginForm">
            <h2>Prijava u sistem biblioteke</h2>
            <label for="username" class="custom-label">Korisničko ime:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="input custom-input-login" placeholder="Unesite korisničko ime"></asp:TextBox>
            <label for="password" class="custom-label">Lozinka:</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input custom-input-login" TextMode="Password" placeholder="Unesite lozinku"></asp:TextBox>
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
            <asp:Button ID="btnLogin" runat="server" CssClass="button custom-button" Text="Prijava" OnClick="btnLogin_Click" />
        </form>
    </div>
</asp:Content>
