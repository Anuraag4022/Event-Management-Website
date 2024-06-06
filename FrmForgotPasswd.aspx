<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmForgotPasswd.aspx.cs" Inherits="FrmForgotPasswd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <center>
        <table style="height: 208px; width: 256px">
             <tr><td colspan="2"><asp:Label ID="lblfrgt_Password" runat="server" Text="Forget Password:" Font-Bold="True" Font-Size="X-Large"></asp:Label></td></tr>
             <tr><td>
                 <asp:Label ID="lbludername" runat="server" Font-Bold="True" Font-Size="Large" Text="User Name:"></asp:Label>
                 </td><td>
                     <asp:TextBox ID="txtuser_Name" runat="server"></asp:TextBox>
                 </td></tr>
             <tr><td>
                 <asp:Label ID="lbludername0" runat="server" Font-Bold="True" Font-Size="Large" Text="Enter Email ID:"></asp:Label>
                 </td><td>
                     <asp:TextBox ID="txtEmail_Id" runat="server"></asp:TextBox>
                 </td></tr>
             <tr><td>
                 <asp:Label ID="lbludername1" runat="server" Font-Bold="True" Font-Size="Large" Text="Enter School Name:"></asp:Label>
                 </td><td>
                     <asp:TextBox ID="txtschool_Name" runat="server"></asp:TextBox>
                 </td></tr>
             <tr><td>
                 <asp:Label ID="lbludername2" runat="server" Font-Bold="True" Font-Size="Large" Text="Enter Contact No:"></asp:Label>
                 </td><td>
                     <asp:TextBox ID="txtcontact_No" runat="server"></asp:TextBox>
                 </td></tr>
             <tr><td>
                 <asp:Button ID="btnshowpasswd" runat="server" Font-Bold="True" Height="29px"  Text="Remember Password:" Width="213px" OnClick="btnshowpasswd_Click" />
                 </td><td>
                     <asp:Button ID="btnshowpasswd0" runat="server" Font-Bold="True" Height="32px" Text="Clear:" Width="120px" OnClick="btnshowpasswd0_Click"  />
                 </td></tr>
        </table>

    </center>
    
</asp:Content>

