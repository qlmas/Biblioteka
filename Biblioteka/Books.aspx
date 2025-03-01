<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Upravljanje knjigama</h2>
    <form>
        <fieldset class="custom-fieldset">
            <legend>Dodaj novu knjigu</legend>
            <asp:TextBox ID="titleTextBox" runat="server" required="true" placeholder="Naslov" CssClass="custom-textbox" />
            <asp:TextBox ID="authorTextBox" runat="server" required="true" placeholder="Autor" CssClass="custom-textbox"/>
            <asp:TextBox ID="yearTextBox" runat="server" required="true" placeholder="Godina" CssClass="custom-textbox"/>
            <asp:TextBox ID="categoryTextBox" runat="server" required="true" placeholder="Kategorija" CssClass="custom-textbox" />
            <asp:Button ID="AddBookButton" runat="server" Text="Dodaj knjigu" OnClick="AddBook_Click" class="custom-button"/>
        </fieldset>
    </form>

    <h3>Lista knjiga</h3>
    <asp:GridView ID="BooksGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="BooksGridView_RowDeleting" DataKeyNames="BookID" CssClass="gridview-margin">
        <Columns>
            <asp:BoundField DataField="BookID" HeaderText="Book ID" />
            <asp:BoundField DataField="Title" HeaderText="Naslov" />
            <asp:BoundField DataField="Author" HeaderText="Autor" />
            <asp:BoundField DataField="Year" HeaderText="Godina" />
            <asp:BoundField DataField="Category" HeaderText="Kategorija" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
