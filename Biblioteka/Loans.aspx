<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Loans.aspx.cs" Inherits="Loans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Upravljanje posudbama</h2>
<form>
    <fieldset class="custom-fieldset-posudbe">
        <legend>Dodaj novu posudbu</legend>
        
        <div class="form-row">
            <div>
                <label for="bookId" class="custom-label-posudbe">ID Knjige:</label>
                <input type="text" id="bookId" name="bookId" required class="custom-input-posudbe" />
            </div>

            <div>
                <label for="memberId" class="custom-label-posudbe">ID Člana:</label>
                <input type="text" id="memberId" name="memberId" required class="custom-input-posudbe" />
            </div>
        </div>

        <div class="form-row">
            <div>
                <label for="loanDate" class="custom-label-posudbe">Datum posudbe:</label>
                <input type="date" id="loanDate" name="loanDate" required class="custom-input-posudbe" />
            </div>

            <div>
                <label for="returnDate" class="custom-label-posudbe">Datum povratka:</label>
                <input type="date" id="returnDate" name="returnDate" required class="custom-input-posudbe" />
            </div>
        </div>

        <asp:Button ID="btnAddLoan" runat="server" Text="Dodaj posudbu" OnClick="AddLoan" CssClass="custom-button-posudbe" />

    </fieldset>
</form>

    <h3>Lista posudbi</h3>
    <asp:GridView ID="LoansGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="LoanId" OnRowDeleting="LoansGridView_RowDeleting">
        <Columns>
            <asp:BoundField DataField="LoanId" HeaderText="Loan ID" SortExpression="LoanId" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
        <asp:BoundField DataField="LoanDate" HeaderText="Loan Date" SortExpression="LoanDate" 
                       DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" SortExpression="ReturnDate" 
                       DataFormatString="{0:dd/MM/yyyy}" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
</asp:Content>