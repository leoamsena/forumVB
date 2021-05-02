<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Apresentacao._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Forum de Estudos</h1>
        <p class="lead">Para ver as publicações e publicar seus próprios posts faça login.<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Login ID="Login1" runat="server" FailureText="A tentativa de login não teve êxito. Tente novamente." LoginButtonText="Fazer Login" RememberMeText="Lembrar" TitleText="Fazer Login" UserNameLabelText="Email:" UserNameRequiredErrorMessage="O Email é obrigatório.">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2">Fazer Login</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Email:</asp:Label>
                                        </td>
                                        <td style="width: 195px">
                                            <asp:TextBox ID="UserName" runat="server" TextMode="Email"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="O Email é obrigatório." ToolTip="O Email é obrigatório." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                                        </td>
                                        <td style="width: 195px">
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="A senha é obrigatória." ToolTip="A senha é obrigatória." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Lembrar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Fazer Login" ValidationGroup="Login1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
            <table style="width:30%;">
                <tr>
                    <td>Nome</td>
                    <td >
                        <asp:TextBox ID="rgNome" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="rgEmail" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                 <tr>
                    <td>CPF</td>
                    <td >
                        <asp:TextBox ID="rgCPF" runat="server"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <td>Senha</td>
                    <td >
                        <asp:TextBox ID="rgPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td></td>
                    <td >
                        <asp:Button ID="Button1" runat="server" Text="Registrar" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td >
                        
                        <asp:Label ID="rgMsg" runat="server" Text=""></asp:Label>
                        
                    </td>
                </tr>
            </table>
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting Started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
