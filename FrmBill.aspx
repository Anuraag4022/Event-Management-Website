<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmBill.aspx.cs" Inherits="FrmBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
        
     <table>
    <thead>
        <tr><td colspan="2"><center><asp:Label ID="lblBill" runat="server" Text="Bill" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr></thead>
    <tbody><tr><td>
                    <asp:Button ID="btnShowID" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Show ID" Width="85px" OnClick="btnShowID_Click" />
                </td><td><asp:Button ID="btnShow" runat="server" class="btn btn-dark" Text="Show Data" Width="106px" Font-Bold="True" Font-Size="Medium" OnClick="btnShow_Click"></asp:Button>
        </td></tr>
        <tr><td><asp:Label ID="lblBill_No" runat="server" Text="Bill No:"></asp:Label></td><td><asp:TextBox ID="txtBill_No" runat="server"></asp:TextBox></td><td rowspan="9">
        <asp:Button ID="btnFirst" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="First" Width="85px" OnClick="btnFirst_Click" />
        <br />
        <br />
        <asp:Button ID="btnNext" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Next" Width="85px" OnClick="btnNext_Click" />
        <br />
        <br />
        <asp:Button ID="btnPrevious" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Previous" Width="85px" OnClick="btnPrevious_Click" />
        <br />
        <br />
        <asp:Button ID="btnLast" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Last" Width="85px" OnClick="btnLast_Click" />
        <br />
        </td></tr>
    <tr><td class="auto-style1"><asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label></td><td class="auto-style1"><asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td></tr>
    <tr><td><asp:Label ID="lblQuotId" runat="server" Text="Quotation ID:"></asp:Label></td><td>
        <asp:DropDownList ID="ddlQuotId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuotId_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
                </td></tr>
    <tr><td><asp:Label ID="lblCustName" runat="server" Text="Customer Name:"></asp:Label></td><td><asp:TextBox ID="txtCustName" runat="server"></asp:TextBox></td></tr>
    <tr><td><asp:Label ID="lblAmount" runat="server" Text="Amount:"></asp:Label></td><td><asp:TextBox ID="txtAmt" runat="server"></asp:TextBox></td></tr>
    <tr><td><asp:Label ID="lblBill_No4" runat="server" Text="Advance Amount:"></asp:Label></td><td><asp:TextBox ID="txtAdv_amt" runat="server"></asp:TextBox></td></tr>
    <tr><td><asp:Label ID="lblBill_No5" runat="server" Text="Balance Amount:"></asp:Label></td><td><asp:TextBox ID="txtBal_amt" runat="server"></asp:TextBox></td></tr>
    <tr><td><asp:Label ID="lblBill_No6" runat="server" Text="Paid By:"></asp:Label></td><td>
        <asp:RadioButton ID="rdbCash" runat="server" Text="Cash" GroupName="a"  />
        <br />
        <asp:RadioButton ID="rdbdebit" runat="server" Text="Debit" GroupName="a" />
        <br />
        <asp:RadioButton ID="rdbUPI" runat="server" Text="UPI" GroupName="a" />
        </td></tr>
    <tr><td><asp:Label ID="lblBill_No7" runat="server" Text="Received By:"></asp:Label></td><td><asp:TextBox ID="txtRecvd_By" runat="server"></asp:TextBox></td></tr>
    <tr><td colspan="2"><asp:Button ID="btnAdd" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Add" Width="85px" OnClick="btnAdd_Click1" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEdit" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Edit" Width="85px" OnClick="btnEdit_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="85px" OnClick="btnDelete_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Cancel" Width="85px" OnClick="btnCancel_Click"  /></td></tr>
   <tr><td colspan="2"><center>
       </center></td></tr>
         <tr><td colspan="3">
        
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </td></tr>
</tbody>
</table>


</center>
</asp:Content>

