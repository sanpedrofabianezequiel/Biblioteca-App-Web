using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaAppWeb
{
    public partial class EditarLibro : System.Web.UI.Page
    {
        //Connexon BD
        private string connectionString = WebConfigurationManager.ConnectionStrings["BibliotecaDBConnectionString"].ConnectionString;


        int idBookRecibido; //Id Recibido
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
                //Obtencion mediante el metodo GET
                if (Request.QueryString["LibroId"] != "")   //Si no es vacio es decir me llega el ID
                {                                               //lo convierto en INT el string recibido
                    idBookRecibido =Convert.ToInt32( Request.QueryString["LibroId"]);

                }
                else
                {
                    Response.Redirect("Biblioteca.aspx");
                }   
                ////////////////////////////////////////////////
               
                if(!IsPostBack)//Si la pagina a sido cargada por primera vez
                {
                    CargarLibroEditable();
                }
        }


        private void CargarLibroEditable()  //Trae la informacion en base al ID con el metodo de la CLASE
        {
            Books libroEditable = new Books();  //Creo un objeto del tipo libro para mostrar

           

            libroEditable = libroEditable.InformacionEditable(connectionString, idBookRecibido);//Retorna un Objto de tipo Book seugn el ID enviado

            //Utilizo ese objeto Return, para asignarlo a los textos con sus valores

       
            this.idTextBoxTitulo.Text = libroEditable.Titulo.ToString();
            this.idTextBoxEditorial.Text = libroEditable.EditorialNombre.ToString();
            this.idTextBoxAutor.Text = libroEditable.AutorNombre.ToString();
            this.idTextBoxGenero.Text = libroEditable.CategoriaNombre.ToString();




        }




        //Metodos Aceptar y Cancelar
        protected void ClickAceptar(object sender,EventArgs e)
        {
            Books edicionBook = new Books();

            edicionBook.LibroId = idBookRecibido;

            edicionBook.Titulo = idTextBoxTitulo.Text;
            edicionBook.IdentificadorComercial = this.idTextBoxISBN.Text;
            edicionBook.EditorialNombre = this.idTextBoxEditorial.Text;
            edicionBook.AutorNombre = this.idTextBoxAutor.Text;
            edicionBook.CategoriaNombre = this.idTextBoxGenero.Text;


            edicionBook.LibroEditado(connectionString, edicionBook);

            Response.Redirect("Biblioteca.aspx");
        }

        protected void ClickCancelar(object sender,EventArgs e)
        {
            Response.Redirect("Biblioteca.aspx");
        }


    }
}