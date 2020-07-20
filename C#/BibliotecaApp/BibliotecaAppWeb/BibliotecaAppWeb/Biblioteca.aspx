<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Biblioteca.aspx.cs" Inherits="BibliotecaAppWeb.Biblioteca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="portada">
        <h2 class="text-primary align-content-center; text-center">Biblioteca Virtual
        </h2>
    </header>
    <hr />

    <div>
        <img class="mediano w-100" src="Imagenes/BibliotecaFoto.jpg" alt="Alternate Text" />

        <hr />

        

        <asp:GridView ID="idGridView" runat="server" CssClass="table border border-dark text-center" AutoGenerateColumns="False" OnSelectedIndexChanged="ClickEditarLibro" OnRowDataBound="idGridView_RowDataBound">

            <columns>
                     <asp:BoundField DataField="LibroId" HeaderText="IDLibro" />
                     <asp:BoundField DataField="Titulo" HeaderText="Título" />           
                     <asp:BoundField DataField="EditorialNombre" HeaderText="Editorial" />
                     <asp:BoundField DataField="AutorNombre" HeaderText="Autor" />
                     <asp:BoundField DataField="CategoriaNombre" HeaderText="Categoría" />
                 </columns>


            <headerstyle cssclass="bg-dark text-primary" />



        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server"></asp:XmlDataSource>
    </div>
    <div >
        <asp:Button runat="server" Text="Nuevo" CssClass="btn-primary btn-sm"  OnClick="ClickNuevoLibro" />
        <asp:Button runat="server" Text="Editar" CssClass="btn-primary btn-sm" OnClick="ClickEditarLibro" />
  <!--      <asp:Button runat="server" Text="Eliminar" CssClass="btn-primary btn-sm" OnClick="ClickEliminarLibro" />   -->
    </div>


</asp:Content>
