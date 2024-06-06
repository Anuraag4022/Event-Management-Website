<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="backup.aspx.cs" Inherits="backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <center><table><tr><td><asp:Button ID="btnbackup" runat="server" class="btn btn-dark" Text="Back Up" Width="106px" Font-Bold="True" Font-Size="Medium" OnClick="btnbackup_Click"></asp:Button>
       </td><td>
      <asp:Button ID="Btnrestore" runat="server" class="btn btn-dark" Text="Restore" Width="106px" Font-Bold="True" Font-Size="Medium" OnClick="Btnrestore_Click"></asp:Button>
   </center>  </table>   
     
</asp:Content>

