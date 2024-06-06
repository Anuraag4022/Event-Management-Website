<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmPayment.aspx.cs" Inherits="FrmPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table>
            <thead>
            <tr><td colspan="2"><center><asp:Label ID="lblPayment" runat="server" Text="Payment" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr>
            </thead>
            <tbody>
                <tr><td>
                    <asp:Button ID="btnShowID" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Show ID" Width="85px" OnClick="btnShowID_Click" />
                    </td><td>
                    <asp:Button ID="btnShowname" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Show Name" Width="120px" OnClick="btnShowname_Click" Height="30px" />
                    </td></tr><tr><td>
                <asp:Label ID="lblBill_No" runat="server" Text="Bill No:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtBill_No" runat="server"></asp:TextBox>
                </td><td rowspan="5">
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
                    <br />
                </td></tr>
            <tr><td>
                <asp:Label ID="lblEventId" runat="server" Text="Event Id:"></asp:Label>
                </td><td>
                    <asp:DropDownList ID="ddlEvent_Id" runat="server" Height="68px" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="ddlEvent_Id_SelectedIndexChanged" >
                    </asp:DropDownList>
                    <br />
                </td></tr>
            <tr><td>
                <asp:Label ID="lblEvent_Name" runat="server" Text="Event Name:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtEvent_Name" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:Label ID="lblCust_Name" runat="server" Text="Customer Name:"></asp:Label>
                </td><td>
                    <asp:DropDownList ID="ddlCust_Name" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                </td></tr>
            <tr><td>
                <asp:Label ID="lblPay_Due_Amt" runat="server" Text="Payment Due Amount:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtPay_Due_amt" runat="server"></asp:TextBox>
                </td></tr>
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
            <tr><td colspan="2">
               
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

