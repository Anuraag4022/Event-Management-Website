<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmLogin.aspx.cs" Inherits="FrmLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }
        .auto-style2 {
            width: 159px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
       <table>
           <thead><tr><td colspan="2"><center><asp:Label ID="Login" runat="server" Text="Login" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr></thead>
           <tbody><tr><td class="auto-style2">
               <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Text="Enter Username:"></asp:Label>
               </td><td class="auto-style1">
                   <asp:TextBox ID="txtusername" runat="server" Height="26px" Width="134px"></asp:TextBox>
               </td></tr>
           <tr><td class="auto-style2">
               <asp:Label ID="lblEnterPass" runat="server" Font-Bold="True" Text="Enter Password:"></asp:Label>
               </td><td class="auto-style1">
                   <asp:TextBox ID="txtpass" runat="server" TextMode="Password" Height="29px" Width="139px"></asp:TextBox>
               </td></tr>
           <tr><td class="auto-style2">
               <asp:Button ID="btnLogin" runat="server" class="btn btn-dark" Font-Bold="True" Text="Login" OnClick="btnLogin_Click"  />
               </td><td class="auto-style1">
                   <asp:Button ID="btncancel" runat="server" class="btn btn-dark" Font-Bold="True" Text="Cancel" Font-Italic="False" />
               </td></tr>
               <tr><td class="auto-style2">
               <asp:Button ID="btnnewuser" runat="server" class="btn btn-dark" Font-Bold="True" Text="Create New User" OnClick="btnnewuser_Click" Height="30px" Width="150px"  />
                   </td><td class="auto-style1">
               <asp:Button ID="btnforgetpasswd" runat="server" class="btn btn-dark" Font-Bold="True" Text="Forget Password" OnClick="btnforgetpasswd_Click" Height="30px" Width="150px"  />
                   </td></tr>
               </tbody>
       </table>
   </center>
            
        
</asp:Content>

