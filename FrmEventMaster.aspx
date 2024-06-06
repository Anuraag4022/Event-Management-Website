<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmEventMaster.aspx.cs" Inherits="FrmEventMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 118px;
        }
        .auto-style2 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <table>
        <thead>
        <tr><td colspan="2" class="auto-style2"><center><asp:Label ID="lblEvents" runat="server" Text="Events" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr></thead>
        <tbody><tr><td><asp:Label ID="lblEventId" runat="server" Text="Event ID:"></asp:Label></td><td class="auto-style1"><asp:TextBox ID="txtEventId" runat="server"></asp:TextBox></td><td rowspan=6>
            <br />
            <asp:Button ID="btnFirst" class="btn btn-dark" runat="server" Text="First" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnFirst_Click" />
<br />
            <br />
            
            <asp:Button ID="btnNext" class="btn btn-dark" runat="server" Text="Next" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnNext_Click" />
<br />
            <br />
            <asp:Button ID="btnPrevious" class="btn btn-dark" runat="server" Text="Previous" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnPrevious_Click" />
<br />
            <br />
            <asp:Button ID="btnLast" class="btn btn-dark" runat="server" Text="Last" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnLast_Click" />
            <br />
            </td></tr>
        <tr><td><asp:Label ID="lblEventName" runat="server" Text="Event Name:"></asp:Label></td><td class="auto-style1"><asp:TextBox ID="txtEventName" runat="server"></asp:TextBox></td></tr>
            <tr><td ><asp:Label ID="lblItems" runat="server" Text="Items:"></asp:Label></td><td>
                <asp:CheckBox ID="CheckBoxMusician" runat="server" Text="Musician" />
                <br />
                <asp:CheckBox ID="CheckBoxPhotographer" runat="server" Text="Photographer" />
                <br />
                <asp:CheckBox ID="CheckBoxBreakfast" runat="server" Text="Breakfast" />
                <br />
                <asp:CheckBox ID="CheckBoxLaunch" runat="server" Text="Launch/Dinner" />
                <br />
                <asp:CheckBox ID="CheckBoxIceCream" runat="server" Text="Ice Cream" />
                <br />
                <asp:CheckBox ID="CheckBoxflower" runat="server"  Text="Flower Decoration" />
                <br />
                <asp:CheckBox ID="CheckBoxbhatgi" runat="server"  Text="Bhatgi" />
                <br />
                <asp:CheckBox ID="CheckBoxOther" runat="server" Text="Other" />
                </td></tr>
        
        <tr><td><asp:Label ID="lblrateperpartic" runat="server" Text="Rate Per Participant:"></asp:Label></td><td class="auto-style1"><asp:TextBox ID="txtrateprpartic" runat="server"></asp:TextBox></td></tr>
        <tr><td colspan="2">
            &nbsp;
            &nbsp;
            &nbsp;
            <asp:Button ID="btnAdd" class="btn btn-dark" runat="server" Text="Add" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnAdd_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEdit" class="btn btn-dark" runat="server" Text="Edit" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnEdit_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" class="btn btn-dark" runat="server" Text="Delete" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnDelete_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" class="btn btn-dark" runat="server" Text="Cancel" Width="85px" Font-Bold="True" Font-Size="Medium" OnClick="btnCancel_Click" />
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

