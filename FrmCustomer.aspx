<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmCustomer.aspx.cs" Inherits="FrmCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table>
            <thead><tr><td colspan="2"><center><asp:Label ID="lblCustomer" runat="server" Text="Customer" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr></thead>
           
            <tbody><tr><td><asp:Label ID="lblCustomerId" runat="server" Text="Customer ID:"></asp:Label></td><td><asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox></td><td rowspan="4">
                <br />
                <asp:Button ID="btnFirst" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="First" Width="85px" OnClick="btnFirst_Click"  />
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
            <tr><td><asp:Label ID="lblCustomerName" runat="server" Text="Customer Name:"></asp:Label></td><td><asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox></td></td></tr>
            <tr><td><asp:Label ID="lblWhatsApp_No" runat="server" Text="WhatsApp No:"></asp:Label></td><td><asp:TextBox ID="txtwpNo" runat="server"></asp:TextBox></td></td></tr>
            <tr><td><asp:Label ID="lblEmailId" runat="server" Text="Email ID:"></asp:Label></td><td><asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox></td></td></tr>
            <tr><td colspan="2">
                <asp:Button ID="btnAdd" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Add" Width="85px" OnClick="btnAdd_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEdit" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Edit" Width="85px" OnClick="btnEdit_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="85px" OnClick="btnDelete_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Cancel" Width="85px" OnClick="btnCancel_Click" />
                </td></tr>
              <tr><td colspan="2"><center><asp:Button ID="btnShow" runat="server" class="btn btn-dark" Text="Show Data" Width="106px" Font-Bold="True" Font-Size="Medium" OnClick="btnShow_Click"></asp:Button>
       </center></td></tr>   

            <tr><td colspan="2"><asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="132px" Width="230px">
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
                </asp:GridView></td></tr>
                </tbody>
        </table>
    </center>
</asp:Content>

