<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmEventDetails.aspx.cs" Inherits="FrmEventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table>
            <thead><tr><td colspan="2"><center><asp:Label ID="lblEventDet" runat="server" Font-Bold="True" Font-Size="Large" Text="Event Details"></asp:Label></center></td></tr></thead>
            <tbody><tr><td><asp:Label ID="lblBooking_Id" runat="server" Text="Booking Id:"></asp:Label></td><td><asp:TextBox ID="txtBook_ID" runat="server" style="margin-bottom: 0px"></asp:TextBox></td><td rowspan="6">
                <br />
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
            <tr><td><asp:Label ID="lblPartyName" runat="server" Text="Party Name:"></asp:Label></td><td><asp:TextBox ID="txtParty_Name" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="lblQuot_Id" runat="server" Text="Quotation Id:"></asp:Label></td><td><asp:TextBox ID="txtQuot_Id" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="lblBill_Amt" runat="server" Text="Bill Amount:"></asp:Label></td><td><asp:TextBox ID="txtBill_amt" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="lblAdv_amt" runat="server" Text="Advance Amount:"></asp:Label></td><td><asp:TextBox ID="txtAdv_Amt" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="lblRecvdBy" runat="server" Text="Received By:"></asp:Label></td><td><asp:TextBox ID="txtRecvd_By" runat="server"></asp:TextBox></td></tr>
            <tr><td colspan="2">
                <asp:Button ID="btnAdd" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Add" Width="85px" OnClick="btnAdd_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEdit" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Edit" Width="85px" OnClick="btnEdit_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="85px" OnClick="btnDelete_Click" style="height: 29px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Cancel" Width="85px" OnClick="btnCancel_Click" />
                </td></tr>
                 <tr><td colspan="2"><center><asp:Button ID="btnShow" runat="server" class="btn btn-dark" Text="Show Data" Width="106px" Font-Bold="True" Font-Size="Medium" OnClick="btnShow_Click"></asp:Button>
       </center></td></tr>
            <tr><td colspan="3">
               
                </td></tr>
                </tbody>
        </table>
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
    </center>
</asp:Content>

