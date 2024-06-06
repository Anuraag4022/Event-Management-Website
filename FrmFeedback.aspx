<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmFeedback.aspx.cs" Inherits="FrmFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table>
            <thead><tr><td colspan="2"><center><asp:Label ID="lblFeedback" runat="server" Text="Feedback" Font-Bold="True" Font-Size="Large"></asp:Label></center></td></tr></thead>
            <tbody><tr><td>
                <asp:Label ID="lblName" runat="server" height="19px" Text="Name:" width="57px"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:Label ID="lblName0" runat="server" height="19px" Text="Email:" width="57px"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:Label ID="lblMessage" runat="server" Text="Message:"></asp:Label>
                </td><td>
                    <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="True" Height="30px" Width="187px"></asp:Button></td></tr>
        
                </tbody></table>
    </center>
</asp:Content>

