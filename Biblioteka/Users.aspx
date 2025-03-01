<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Upravljanje članovima</h2>
    <form>
        <fieldset class="custom-fieldset">
            <legend>Dodaj novog člana</legend>
            <asp:TextBox ID="nameTextBox" runat="server" required="true" placeholder="Ime" CssClass="custom-textbox" />
            <asp:TextBox ID="surnameTextBox" runat="server" required="true" placeholder="Prezime" CssClass="custom-textbox" />
            <asp:TextBox ID="membershipTextBox" runat="server" required="true" placeholder="Broj članske kartice" CssClass="custom-textbox"/>
            <asp:TextBox ID="contactTextBox" runat="server" required="true" placeholder="Email" CssClass="custom-textbox"/>
            <asp:Button ID="AddButton" runat="server" Text="Dodaj člana" OnClick="AddUser" class="custom-button" />
        </fieldset>
    </form>

    <h3>Lista članova</h3>
    <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="UsersGridView_RowDeleting" DataKeyNames="UserID">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="Name" HeaderText="Ime" />
            <asp:BoundField DataField="Surname" HeaderText="Prezime" />
            <asp:BoundField DataField="MembershipCard" HeaderText="Članska kartica" />
            <asp:BoundField DataField="Contact" HeaderText="Kontakt" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
