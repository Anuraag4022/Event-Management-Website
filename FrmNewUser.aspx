<%@ Page Title="" Language="C#" MasterPageFile="~/EventMng.master" AutoEventWireup="true" CodeFile="FrmNewUser.aspx.cs" Inherits="FrmNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table>
            <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Create User" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Username" Font-Size="Small" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" Width="260px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Size="Small" ForeColor="Black" Text="Email"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="260px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Password" Font-Size="Small" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" Width="260px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="School" Font-Size="Small" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSchool" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                        

                        <asp:Label ID="Label10" runat="server" Font-Size="Small" ForeColor="Black" Text="Contact"></asp:Label>

                        

                    </td>

                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="txtMob" runat="server"  Width="260px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                            <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Already a member ? "></asp:Label>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmLogin.aspx">Login </asp:HyperLink>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td>
                        <center><asp:Button ID="btnCreate" runat="server" Text="Create User" Width="234px" BackColor="White" Font-Bold="True" Font-Size="Medium" OnClick="btnCreate_Click" /></center>
                    </td>
                </tr>
        </table>
    </center>
</asp:Content>

