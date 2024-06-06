<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmEventBooking.aspx.cs" Inherits="FrmEventBookingt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    &nbsp;<table>
        <thead><tr><td colspan="2"><center><asp:Label ID="lblEventBoki" runat="server" Font-Bold="True" Font-Size="Large" Text="Event Booking"></asp:Label></center></td></tr></thead>
        <tbody><tr><td> <asp:Button ID="btnShow0" runat="server" class="btn btn-dark" Text="Current Date" Width="150px" Font-Bold="True" Font-Size="Medium" OnClick="btnShow0_Click1"></asp:Button>
            </td><td> <asp:Button ID="btnShow1" runat="server" class="btn btn-dark" Text="Show Name" Width="106px" Font-Bold="True" Font-Size="Medium" OnClick="btnShow1_Click"></asp:Button>
            </td></tr>
            <tr><td>
            <asp:Label ID="lblBookingId" runat="server" Text="Booking ID:"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtBookingId" runat="server"></asp:TextBox>
            </td><td rowspan="11">
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
        <tr><td>
            <asp:Label ID="lblBookingId0" runat="server" Text="Date:"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblPartyName" runat="server" Text="Party Name:"></asp:Label>
            </td><td>
                <asp:DropDownList ID="ddlPartyName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPartyName_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
            </td></tr>
        <tr><td>
            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblContNo" runat="server" Text="Contact No:"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblEvent" runat="server" Text="Event:"></asp:Label>
            </td><td>
                <asp:DropDownList ID="DropEvent" runat="server" Height="28px" style="margin-left: 0px" Width="124px">
                    <asp:ListItem Value="Wedding">Wedding</asp:ListItem>
                    <asp:ListItem Value="Munj">Munj</asp:ListItem>
                    <asp:ListItem Value="Birthday">Birthday</asp:ListItem>
                    <asp:ListItem Value="Reception">Reception</asp:ListItem>
                    <asp:ListItem Value="Seminar">Seminar</asp:ListItem>
                    <asp:ListItem Value="Family Function">Family Function</asp:ListItem>
                </asp:DropDownList>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblEvent0" runat="server" Text="Event Date:"></asp:Label>
            </td><td>                <asp:TextBox ID="txtEventDate" runat="server" TextMode="DateTime"></asp:TextBox>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblPlaceAddress" runat="server" Text="Place Address:"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtPlaceAddress" runat="server"></asp:TextBox>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblApproxParti" runat="server" Text="Approx Participants:"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtApproxParti" runat="server"></asp:TextBox>
            </td></tr>
        <tr><td>
            <asp:Label ID="lblStartTime" runat="server" Text="Start Time:"></asp:Label>
&nbsp;<asp:TextBox ID="txtStart_Time" runat="server" TextMode="DateTime"></asp:TextBox>
            </td><td>
                <asp:Label ID="lblEnd_Time" runat="server" Text="End Time:"></asp:Label>
&nbsp;<asp:TextBox ID="txtEnd_Time" runat="server" TextMode="DateTime"></asp:TextBox>
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
       &nbsp;&nbsp;&nbsp;&nbsp; 
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

