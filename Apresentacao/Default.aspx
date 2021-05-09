<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Apresentacao._Default" %>
<asp:Content ContentPlaceHolderID="NavbarContent" runat="server">
    <div class="nav-item dropdown me-5">
          <a class="nav-link dropdown-toggle me-5" 
              href="#" id="navbarDropdownMenuLink" role="button" 
              data-bs-toggle="dropdown" aria-expanded="false">
            Fazer Login
          </a>
          <div class="dropdown-menu me-2" 
              aria-labelledby="navbarDropdownMenuLink" 
              style="min-width: 200px">
            <div>
                <h2>Entrar</h2></div>
                    <asp:Login ID="Login1" runat="server" FailureText="A tentativa de login não teve êxito. Tente novamente." LoginButtonText="Fazer Login" RememberMeText="Lembrar" TitleText="Fazer Login" UserNameLabelText="Email:" UserNameRequiredErrorMessage="O Email é obrigatório.">
                        <LayoutTemplate>
                            <div>
                                <asp:Label 
                                    ID="lblUserNameLabel" runat="server" 
                                    AssociatedControlID="UserName" 
                                    CssClass="form-label">
                                    Email:
                                </asp:Label>
                                <asp:RequiredFieldValidator 
                                    runat="server" ID="UserNameRequired" 
                                    ControlToValidate="UserName" 
                                    ErrorMessage="O Email é obrigatório."
                                    ToolTip="O Email é obrigatório." 
                                    ValidationGroup="Login1">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox  
                                    ID="UserName"
                                    CauseValidation=true
                                    runat="server"
                                    TextMode="Email"
                                    CssClass="form-control" >
                                </asp:TextBox>
                                <asp:RegularExpressionValidator
                                    runat="server" 
                                    ID="RegularExpressionValidator1"
                                    ErrorMessage="Não é um email válido!"
                                    ControlToValidate="UserName"
                                    ValidationGroup="Login1"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" >
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblPasswordLabel" runat="server" AssociatedControlID="Password" CssClass="form-label">Senha:</asp:Label>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="A senha é obrigatória." ToolTip="A senha é obrigatória." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                
                            </div>
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>

                            <asp:Button ID="btnLoginButton" runat="server" CommandName="Login" Text="Fazer Login" ValidationGroup="Login1" CssClass="btn btn-primary" />
                        </LayoutTemplate>
                    </asp:Login>
            </div>
        </div>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Forum de Estudos</h1>
        <p class="lead">Para ver as publicações e publicar seus próprios posts faça login.<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </p>
        <p>Frase aleatória do dia: 
            <asp:Label ID="lblFrase" runat="server" Text="Label"></asp:Label>
        </p>
        
            <div class="row">
                <div class="col-sm">
                   <div>
                       <h2>Registrar!</h2>
                   </div>
                    <div>
                        <asp:Label ID="lblRgNome" runat="server" AssociatedControlID="txtRgNome" CssClass="form-label">
                            Nome
                        </asp:Label>
                        <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="txtRgNome" ErrorMessage="O nome é obrigatória." ToolTip="O nome é obrigatória." >*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRgNome" runat="server" CssClass="form-control"></asp:TextBox>
                        
                    </div>
                   
                    <div>
                        <asp:Label ID="lblRgEmail" runat="server" AssociatedControlID="txtRgEmail" CssClass="form-label">
                            Email
                        </asp:Label>
                        <asp:RequiredFieldValidator ID="rgEmailRequired" runat="server" ControlToValidate="txtRgEmail" ErrorMessage="Email é obrigatório." ToolTip="Email é obrigatório." >*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRgEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1"  ErrorMessage="Não é um email válido!" ControlToValidate="txtRgEmail"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                    </div>

                    <div>
                        <asp:Label ID="lblrgCPF" runat="server" AssociatedControlID="txtRgCPF" CssClass="form-label">
                            CPF
                        </asp:Label>
                        <asp:RequiredFieldValidator ID="rgCPFRequired" runat="server" ControlToValidate="txtRgCPF" ErrorMessage="O CPF é obrigatório." ToolTip="O CPF é obrigatório." >*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRgCPF" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblRgPass" runat="server" AssociatedControlID="txtRgPass" CssClass="form-label">
                            Senha
                        </asp:Label>
                        <asp:RequiredFieldValidator ID="rgSenharRequired" runat="server" ControlToValidate="txtRgPass" ErrorMessage="A senha é obrigatória." ToolTip="A senha é obrigatória." >*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRgPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <asp:Button ID="Button1" runat="server" Text="Registrar" CausesValidation=true CssClass="btn btn-primary"/>    
                        <asp:Label ID="rgMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-sm" >
                    <img class="w-100" 
                        src="https://drive.google.com/uc?export=view&id=1PWtY2Gvj47GAheJsf5UknZTa5fHCFb80"  
                        style="max-height: 400px; max-width: 400px"/>
                </div>
            </div>

            <asp:Label ID="lblCount" runat="server" Text="Tentativas de login: 0"></asp:Label>
            <asp:Label ID="lblVisits" runat="server" Text="Visitas a essa página: 0"></asp:Label>
            
        
    </div>

    <div class="row">
        <div class="col-sm">
            <h2>Publique conhecimento!</h2>
            <p>
                Utilize este espaço para publicar o 
                que está estudando, links úteis e qualquer
                outra coisa que possa ser útil à equipe!
                Fique a vontade para compartilhar o que 
                quiser! Vamos construir conhecimentos juntos!
            </p>
            
        </div>
        <div class="col-sm">
            <h2>Ambiente coorporativo</h2>
            <p>
                É importante ressaltar que o objetivo do fórum é 
                disseminar conhecimentos úteis para o trabalho. 
                Deixe os assusntos corriqueiros e cotidianos para
                os bate-papos, não os publique aqui!
            </p>
            
        </div>
    </div>
    <script type="text/javascript">
        function novaFrase() {
            $.ajax({
                url: "https://allugofrases.herokuapp.com/frases/random",
                success: function (data) {
                    $("#<%=lblFrase.ClientID %>").text(data.frase + " - " + data.livro)
                    $("#<%=lblFrase.ClientID%>").effect("fade")
                }
            })
        }
        $(document).ready(function () {
            novaFrase();
            $("#<%=txtRgCPF.ClientID%>").mask('000.000.000-00');
            
        })

    </script>



</asp:Content>
