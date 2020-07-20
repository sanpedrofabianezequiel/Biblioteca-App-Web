<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarLibro.aspx.cs" Inherits="BibliotecaAppWeb.EditarLibro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header class="portada">
        <h2 class="text-primary align-content-center; text-center">Biblioteca Virtual
            Edicion
        </h2>
    </header>
    <hr />

    <div>
        <img class="mediano w-100" src="Imagenes/BibliotecaFoto.jpg" alt="Alternate Text" />
    </div>

        <hr />
  
    <div>
            <asp:Label ID="idLabelTitulo" CssClass="text-primary text-center" runat="server" Text="Titulo"></asp:Label>
            <br />
            <asp:TextBox ID="idTextBoxTitulo" runat="server" Width="300px"></asp:TextBox>
            <br />

         <!--   <asp:Label ID="idLabelISBN" runat="server" CssClass="text-primary text-center" Text="ISBN:"></asp:Label>
            <br />
            <asp:TextBox ID="idTextBoxISBN" runat="server" Width="300px"></asp:TextBox>
            <br /> 
        -->    
            <asp:Label ID="idLabelEditorial" runat="server" CssClass="text-primary text-center" Text="Editorial:"></asp:Label>
            <br />
            <asp:TextBox ID="idTextBoxEditorial" runat="server" Width="300px"></asp:TextBox>
            <br />

            <asp:Label ID="idLabelAutor" runat="server" CssClass="text-primary text-center" Text="Autor:"></asp:Label>
             <br />
            <asp:TextBox ID="idTextBoxAutor" runat="server" Width="300px"></asp:TextBox>
            <br />
            
            <asp:Label ID="idLabelGenero" runat="server" CssClass="text-primary text-center" Text="Género:"></asp:Label>
             <br />
            <asp:TextBox ID="idTextBoxGenero" runat="server" Width="300px"></asp:TextBox>
        <hr />
            <asp:Button runat="server" Text="Aceptar" CssClass="btn-primary btn-sm"  OnClick="ClickAceptar"/>
            <asp:Button runat="server" Text="Cancelar" CssClass="btn-primary btn-sm"  OnClick="ClickCancelar"/>

    </div>







</asp:Content>
