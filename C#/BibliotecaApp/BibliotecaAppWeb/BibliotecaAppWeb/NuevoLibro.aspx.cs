using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaAppWeb
{
    public partial class NuevoLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        private string connectionString = WebConfigurationManager.ConnectionStrings["BibliotecaDBConnectionString"].ConnectionString;

        protected void ClickAceptar(object sender,EventArgs e)
        {
            Books libronuevo = new Books();
            //1 Tengo que convertir el valor  en texto
            //2 Guardarlo en la propiedad que se va a guardar en el Store Porcedure

            libronuevo.Titulo = this.idTextBoxTitulo.Text;
            libronuevo.EditorialNombre = this.idTextBoxEditorial.Text;
            libronuevo.AutorNombre = this.idTextBoxAutor.Text;
            libronuevo.CategoriaNombre = this.idTextGenero.Text;
            libronuevo.IdentificadorComercial = "Prueba";
            //No hace falta enviar el IDBook ya que lo tengo en Autentic (1,1) o AUTO_INCREMENT

            //Books.CrearLibroNuevo(connectionString, libronuevo);    //LLamo al metodo de la clase, le envio la conexio y el NUevo libro
           
            libronuevo.CrearLibroNuevo(connectionString, libronuevo);

            Response.Redirect("Biblioteca.aspx");


        }

        protected void ClickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("Biblioteca.aspx");
        }


    }
}