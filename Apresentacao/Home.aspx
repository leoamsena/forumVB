<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="Apresentacao.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="text-center mt-5 mb-5"><h1>Publicações: </h1></div>
        <div class="accordion" id="accordion">
            <asp:Repeater id="Posts" runat="server">
                <ItemTemplate>
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse<%# DataBinder.Eval(Container.DataItem, "id") %>" aria-expanded="false" aria-controls="collapse<%# DataBinder.Eval(Container.DataItem, "id") %>">
                            <%# DataBinder.Eval(Container.DataItem, "title") %>
                          </button>
                        </h2>
                        <div id="collapse<%# DataBinder.Eval(Container.DataItem, "id") %>" class="accordion-collapse collapse"  data-bs-parent="#accordion">
                          <div class="accordion-body">
                            <%# DataBinder.Eval(Container.DataItem, "text") %>
                          </div>
                        </div>
                      </div>
            </ItemTemplate>


    

            </asp:Repeater>
            
    </div>
    <div class="row mt-3">
        <div class="col-sm-12"><h2>Enviar novo post</h2></div>
        <div class="col-sm-12">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Título"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Título é obrigatório!" ControlToValidate="titulo"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-12">
            <asp:TextBox ID="txtText" runat="server" Rows="5" TextMode="MultiLine" placeholder="Texto" CssClass="form-control" CausesValidation="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Texto é obrigatório!" ControlToValidate="texto"></asp:RequiredFieldValidator>
        </div>
        
    </div>
    <asp:Button ID="Button1" runat="server" Text="Enviar Post" CssClass="btn btn-primary" />
    <asp:Label ID="msgPost" runat="server" Text=""></asp:Label>
        
</asp:Content>
