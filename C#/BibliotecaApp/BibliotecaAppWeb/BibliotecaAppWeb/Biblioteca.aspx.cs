using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaAppWeb
{
    public partial class Biblioteca : System.Web.UI.Page
    {
        // CONECTIONSTRING
            //Nombre que le asigne  a la CONEXION
        private string connectionString = WebConfigurationManager.ConnectionStrings["BibliotecaDBConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    //Verificamos si la pagina a sido recargada
            {
                VerTodosLosLibros();
            }

        }


        protected void VerTodosLosLibros()  
        {

            this.idGridView.DataSource = Books.GetTodosLosLibros(connectionString); //Conectar/o donde encontrar la base de datos
            this.idGridView.DataBind();                                             //Enlazar
        }   //Metodo
        

        protected void ClickNuevoLibro(object sender,EventArgs e)
        {
            Response.Redirect("Nuevolibro.aspx");
        }   //Metodo

    
       protected void ClickEditarLibro(object sender, EventArgs e)   //Metodo +
        {                                                               //Get para enviar el ID por URL en formato STRING
           string idLibro = null;
            if(idGridView.SelectedIndex != -1){      //Verificamos que no sea un ID Inexistente
                                                     //idGridView = ID DEL GRIWVIEW

                idLibro = idGridView.SelectedRow.Cells[0].Text;    //Selecciona el ID
                                                                            //Selecciona la fila
                                                                                //Selecciona y convierte en Object la cel
            }
            if ( Convert.ToInt32(idLibro) >= 1 )        //Condicional para evitar pasar de pagina
            {                                               //si no selecciona una opcion
              
                Response.Redirect("EditarLibro.aspx?LibroId=" + idLibro);

            }

        }



        protected override void Render(HtmlTextWriter writer) //el siguiente metodo envia el ID o row selecciondo con click
        {
            foreach (GridViewRow filas in idGridView.Rows)  //Rows o column lo que prefiera
            {
                filas.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference
                    (idGridView, "Select$" + filas.RowIndex.ToString(), true));
            }

            base.Render(writer);
          
        }

        protected void idGridView_RowDataBound(object sender, GridViewRowEventArgs e)   //Puntero para el GridView
        {
            if (e.Row.RowType == DataControlRowType.DataRow ) //(Obtiene el tipo ce FILa))
            {
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer'");
            }
        }


        protected void ClickEliminarLibro(object sender,EventArgs e)   //Formato para obtener valor de la celda this.idGridView.SelectedRow.Cells[0].Text;
        {
            int idLibroDelete=0;

                if(this.idGridView.SelectedIndex >= 1)
                {
                        idLibroDelete = Convert.ToInt32( this.idGridView.SelectedRow.Cells[0].Text);

                        Books libroDelete = new Books();


                        //Uso el metodo creado que tiene el STORE PROCEDURE Y PIDE 2 PARAMETROS LA CONEXION Y EL ID
                        libroDelete.BorrarLibro(connectionString, idLibroDelete);

                         VerTodosLosLibros(); //Llamo al metodo para ver todo de nuevo
                }




        }




    }
}