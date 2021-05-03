<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="Apresentacao.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="accordion" id="accordion">
            <asp:Repeater id="Posts" runat="server">
            
                <ItemTemplate>
                    <div class="accordion-item">
                        <h2 class="accordion-header">
                          <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapse<%# DataBinder.Eval(Container.DataItem, "id") %>" aria-expanded="true" aria-controls="collapse<%# DataBinder.Eval(Container.DataItem, "id") %>">
                            <%# DataBinder.Eval(Container.DataItem, "title") %>
                          </button>
                        </h2>
                        <div id="collapse<%# DataBinder.Eval(Container.DataItem, "id") %>" class="accordion-collapse collapse show"  data-bs-parent="#accordion">
                          <div class="accordion-body">
                            <%# DataBinder.Eval(Container.DataItem, "text") %>
                          </div>
                        </div>
                      </div>
            </ItemTemplate>


    

            </asp:Repeater>
    </div>
        <form>
            <asp:TextBox ID="texto" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
            <asp:TextBox ID="titulo" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Enviar Post" />
            <asp:Label ID="msgPost" runat="server" Text="Label"></asp:Label>
        </form>
        
</asp:Content>
