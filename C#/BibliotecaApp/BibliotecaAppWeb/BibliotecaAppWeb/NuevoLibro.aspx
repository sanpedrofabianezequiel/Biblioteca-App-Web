<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoLibro.aspx.cs" Inherits="BibliotecaAppWeb.NuevoLibro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <header class="portada">
        <h2 class="text-primary align-content-center; text-center">Biblioteca Virtual - Nuevo Libro
        </h2>
    </header>
    <hr />

    <div>
        
        <img class="mediano w-100" src="Imagenes/BibliotecaFoto.jpg" alt="Alternate Text" />
    </div>
        <hr />

       <div> 
            <asp:Label runat="server" ID="idLabelTitulo" Text="Titulo:" CssClass="text-primary text-center"></asp:Label>    
            <br />
            <asp:TextBox runat="server" ID="idTextBoxTitulo" Width="300px"></asp:TextBox>
            <br />          

            <asp:Label ID="idLabelEditorial" runat="server" Text="Editorial:"  CssClass="text-primary text-center"></asp:Label>
            <br />
            <asp:TextBox ID="idTextBoxEditorial" runat="server" Width="300px"></asp:TextBox>
            <br />

            <asp:Label ID="idLabelAutor" runat="server" Text="Autor:" CssClass="text-primary text-center"></asp:Label>
             <br />
            <asp:TextBox ID="idTextBoxAutor" runat="server" Width="300px"></asp:TextBox>
            <br />
            
            <asp:Label ID="idLabelGenero" runat="server" Text="Género:" CssClass="text-primary text-center"></asp:Label>
             <br />
            <asp:TextBox ID="idTextGenero" runat="server" Width="300px"></asp:TextBox>

            <hr />
            <asp:Button ID="idBotonAceptar" runat="server" Text="Aceptar" CssClass="btn-primary btn-sm" Onclick="ClickAceptar"/>
             <asp:Button ID="idBotonCancelar" runat="server" Text="Cancelar" CssClass="btn-primary btn-sm" Onclick="ClickCancelar"/>
        </div>   
</asp:Content>
