<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmServices_Quotation.aspx.cs" Inherits="FrmServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    .auto-style2 {
        height: 26px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table><thead>
            <tr><td colspan="3"><center><asp:Label ID="lblServices" runat="server" Text="Services Quotation" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr></thead>
            <tbody><tr><td>
                <asp:Label ID="lblQuotId" runat="server" Text="Quotation ID:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtQuotId" runat="server"></asp:TextBox>
                </td><td><asp:Button ID="btnShow" runat="server" class="btn btn-dark" Text="Show Data" Width="106px" Font-Bold="True" Font-Size="Medium" ></asp:Button>
                </td><td rowspan="14">
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
                <asp:Label ID="lblCustName" runat="server" Text="Customer Name:"></asp:Label>
                </td><td>
                    <asp:DropDownList ID="ddlCustName" runat="server" Height="23px" style="margin-left: 0px" Width="131px" DataSourceID="SqlDataSource1" DataTextField="cstmr_name" DataValueField="cstmr_name" AutoPostBack="True" OnSelectedIndexChanged="ddlCustName_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Event_ManagementConnectionString %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>
                </td><td> <asp:Button ID="btnTodaysDate" runat="server" class="btn btn-dark" Text=" Current Date" Width="150px" Font-Bold="True" Font-Size="Medium" OnClick="btnTodaysDate_Click" ></asp:Button>
                </td></tr>
                <tr><td>
                <asp:Label ID="lblCustomerId" runat="server" Text="Customer ID:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtCustId" runat="server"></asp:TextBox>
                </td><td></td></tr>
            <tr><td>
                <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="lblItem" runat="server" Text="Item" Font-Bold="True"></asp:Label>
                </td><td class="auto-style1">
                    <asp:Label ID="lblNo" runat="server" Text="No" Font-Bold="True"></asp:Label>
                </td><td class="auto-style1">
                    <asp:Label ID="lblAmount" runat="server" Text="Amount" Font-Bold="True"></asp:Label>
                </td></tr>
            <tr><td class="auto-style2">
                <asp:CheckBox ID="chbkMusician" runat="server" Text="Musician" />
                </td><td class="auto-style2">
                    <asp:TextBox ID="txtmusician" runat="server"></asp:TextBox>
                </td><td class="auto-style2">
                    <asp:TextBox ID="txtmusicianAmt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:CheckBox ID="chbkBhatji" runat="server" Text="Bhatji" />
                </td><td>
                    <asp:TextBox ID="txtBhatji" runat="server"></asp:TextBox>
                </td><td>
                    <asp:TextBox ID="txtBhatjiAmt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:CheckBox ID="chbkPhotographer" runat="server" Text="Photographer" />
                </td><td>
                    <asp:TextBox ID="txtPhotographer" runat="server"></asp:TextBox>
                </td><td>
                    <asp:TextBox ID="txtPhotographerAmt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:CheckBox ID="chbkFlowerArtist" runat="server" Text="Flower Artist" />
                </td><td>
                    <asp:TextBox ID="txtFlowerArtist" runat="server"></asp:TextBox>
                </td><td>
                    <asp:TextBox ID="txtFlowerArtistAmt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:CheckBox ID="chbkCook" runat="server" Text="Cook" />
                </td><td>
                    <asp:TextBox ID="txtCook" runat="server"></asp:TextBox>
                </td><td>
                    <asp:TextBox ID="txtCookAmt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td class="auto-style2">
                <asp:CheckBox ID="chbkHelper" runat="server" Text="Helper" />
                </td><td class="auto-style2">
                    <asp:TextBox ID="txthelper" runat="server"></asp:TextBox>
                </td><td class="auto-style2">
                    <asp:TextBox ID="txtHeplerAmt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:CheckBox ID="chbkMakeupart" runat="server" Text="Makeup Artist" />
                </td><td>
                    <asp:TextBox ID="txtmakeup" runat="server"></asp:TextBox>
                </td><td>
                    <asp:TextBox ID="txtmakeupamt" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                &nbsp;</td><td>
                    &nbsp;</td></tr>
            <tr><td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblToBillAmt" runat="server" Text="Total Bill Amount"></asp:Label></td><td><asp:TextBox ID="txtTotBillAmt" runat="server"></asp:TextBox></td></tr>
            <tr><td colspan="3">
                
                <asp:Button ID="btnAdd" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Add" Width="85px" OnClick="btnAdd_Click1"  />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEdit" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Edit" Width="85px" OnClick="btnEdit_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="85px" OnClick="btnDelete_Click"  />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" class="btn btn-dark" Font-Bold="True" Font-Size="Medium" Text="Cancel" Width="85px" />
                </td></tr>
                 <tr><td colspan="2"><center>&nbsp;&nbsp;&nbsp;&nbsp; 
       </center></td></tr>
            <tr><td >
                
                </td><td></td></tr>
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
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

