<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmSkillWorkerMaster.aspx.cs" Inherits="SkillWorkerMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 169px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<table>
    <thead>
        <tr><td colspan="2">
        <center><asp:Label ID="lblSkilledWorker" runat="server" Font-Bold="True" Font-Size="Large" Text="Skilled Worker"></asp:Label></center>
        </td></tr>
 <tr><td><asp:Button ID="btnworkerid" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Worker Id" Width="115px" OnClick="btnworkerid_Click" Height="28px"  /></td></tr>
    </thead>
    </tbody><tr ><td class="auto-style1">
        <asp:Label ID="lblWorkerId" runat="server" Text="Worker ID:"></asp:Label>
        </td><td>
            <asp:TextBox ID="txtWorkerId" runat="server"></asp:TextBox>
        </td><td rowspan="3">
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
    <tr><td class="auto-style1">
        <asp:Label ID="lblDesigntion" runat="server" Text="Designation:"></asp:Label>
        </td><td>
            <asp:DropDownList ID="DropDowndesigntion" runat="server" Height="25px" Width="120px">
                <asp:ListItem>Cook</asp:ListItem>
                <asp:ListItem>Musician</asp:ListItem>
                <asp:ListItem>Bhatji</asp:ListItem>
                <asp:ListItem>Photographer</asp:ListItem>
            </asp:DropDownList>
        </td></tr>
    <tr><td class="auto-style1">
        <asp:Label ID="lblWorkerId1" runat="server" Text="Rate/Day:"></asp:Label>
        </td><td>
            <asp:TextBox ID="txtrate" runat="server"></asp:TextBox>
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
    <tr><td ><asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

