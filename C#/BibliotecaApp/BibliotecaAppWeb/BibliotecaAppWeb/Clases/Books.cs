
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace BibliotecaAppWeb
{
    public  class Books
        //Esta clase es la que tiene los STORE PROCEDURE
    {   
                                             //Propiedades
        public int LibroId { get; set; }        //Libro Id
        public string Titulo { get; set; }          //Nombre del libro
        public string IdentificadorComercial { get; set; } //Identificador unico del libro (para uso comercial)
        public string EditorialNombre { get; set; }          //Nombre de la editorial
        public string AutorNombre { get; set; }                 //Nombre del Autor
        public string CategoriaNombre { get; set; }                  //Nombre de Categoria


            
                                         ///////////Metodos-----------------------------------------------
        public static List<Books> GetTodosLosLibros(string connectionString)     //Obtener todos los libros
        {// Recupera la lista con todos los libros que existen en la base de datos
         // Este método usa los objetos de ADO.Net: connection, command y datareader.

           /* //1 Creo 1 lista del tipo BOOKS para almacenar la informacion
            //2 Creo un objeto del tipo SqlConnection y en los parametros la Conexion STRING
            //recibida por paramatro del Metodo
            //3 Creo la Query o consulta (En esta consulta  uso el VIEW)
            //4 Usamos el objeto de connexion y abrimos la conexion OBJ.OPEN();
            //5 Creo el CURSOR o COMMAND con SqlCommand (Query,Connexion)
            //6 Creo un objeto de tipo SqlDataReader ya que el metodo  OBJ.Reader devuelve un Objeto del tipo DATAREADER
            //7 Metodo  ExecuteReader
            //8 if (obj !=null ) entonces While OBJ.READ() para leer mientras sea True
            //9 Creo un nuevo objeto de tipo book que luego almacenaremos en la LIST<BOOKS>
            //10 Guardo el dato ObjDataReader() en la variable correspondiente con el casteo correcto
            //11 Convert.toInt32(ObjDataReader["columna(de la query)"]) para Int / ObjDataReader["Columna(de la query)"].toString() + 
            //12 add/appendChild al objetoLIST el resultado 
            //13 Despues del While y el Condicional, devolver la Lista YA QUE EL METODO ES UN GETTER
            // QUE DEVUELVE TODOS LOS OBJETOS DE LISTA TIPO LIBRO*/
            List<Books> bookList = new List<Books>();

            SqlConnection conexion = new SqlConnection(connectionString);

            string query = "SELECT BookId, Title, Isbn, PublisherName, AuthorName, CategoryName FROM GetBookData";

            conexion.Open();

            SqlCommand cmd = new SqlCommand(query,conexion);


            SqlDataReader dr = cmd.ExecuteReader();

            if(dr != null)
            {
                while (dr.Read())
                {
                    Books book = new Books();

                    book.LibroId = Convert.ToInt32( dr["BookId"]);
                    book.Titulo = dr["Title"].ToString();
                    book.IdentificadorComercial = dr["Isbn"].ToString();
                    book.EditorialNombre = dr["PublisherName"].ToString();
                    book.AutorNombre = dr["AuthorName"].ToString();
                    book.CategoriaNombre = dr["CategoryName"].ToString();

                    bookList.Add(book);
                }
            }

            return bookList;

        }



        public  void CrearLibroNuevo(string connectionString,Books nuevoLibro)
        {// Inserta un nuevo libro, en la tabla de libros de la base de datos
         // Este método usa los objetos de ADO.Net: connection, command y parameter.
            try
            {
                using (SqlConnection conexion=new SqlConnection(connectionString))
                {
                        
                    SqlCommand comand = new SqlCommand("CreateBook",conexion);//LLamo al StorePorcedure+la conexion ala BD
                                                                              //Envio una nueva instancia del parametro con la variable para el StoreProcedure       
                    comand.CommandType = CommandType.StoredProcedure;       //Se de especificar si es tabla o store
                    comand.Parameters.Add(new SqlParameter("@Title",nuevoLibro.Titulo));//Primer valor= la variable StoreProcedure, segundo Valor=Viene por parametros del METODO PADRE, que
                                                                                        //se obtiene del igual el TEXTBOX enviada o igualada a la propiedad Correspondiente de BOOK 

                    comand.Parameters.Add(new SqlParameter("@Isbn",nuevoLibro.IdentificadorComercial));
                    comand.Parameters.Add(new SqlParameter("@PublisherName", nuevoLibro.EditorialNombre));
                    comand.Parameters.Add(new SqlParameter("@AuthorName",nuevoLibro.AutorNombre));
                    comand.Parameters.Add(new SqlParameter("@CategoryName", nuevoLibro.CategoriaNombre));

                    conexion.Open();        //Abro la conexion, Ejecuto el CURSOR y cierro la conexion
                    comand.ExecuteNonQuery();       //Ejecutar y verificar la accion de la query
                    conexion.Close();

                }




            }
            catch(Exception ex)
            {
                throw ex;
            }






        }   //Crear libro Nuevo + recibir Click Aceptar +



            //InformacionEditable es un metodo GET que devuelve un objeto de tipo BOOKS para la editar por el ID recibido
        public  Books InformacionEditable(string connectionString,int libroIDRecibidoParametro)        //Informacion para recuperar en la siguiente pag
        {                                                                               //para editar

            SqlConnection conexionEditable = new SqlConnection(connectionString);//Recibo la conexion  ala BD String

            //Ejecuto la consulta
            //Utilizo la View Creada en el SQL  GetBookData
            string consultaSql = "select BookId, Title , Isbn, PublisherName, AuthorName, CategoryName FROM GetBookData WHERE BookId = " + libroIDRecibidoParametro;
            //LA CONSULTA TIENE QUE ESTAR EN UNA SOLA LINEAAAAA 
            //LA CONSULTA TIENE QUE ESTAR EN UNA SOLA LINEAAAAA 



            //Llamo a la clase Command para ejecutar la conexion y la consulta

            //ABRIR LA CONEXIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN


            conexionEditable.Open();

            //////////////////////////////////////////////////////////

            SqlCommand cursor = new SqlCommand(consultaSql, conexionEditable);


            //Utilizo  el  cursor.EXECUTE DATAREADER que devuelve un SQlDATAREADER y luego del objeto creado uso el metodo READ

            SqlDataReader dr = cursor.ExecuteReader();


            Books libroEditable = new Books();

            if(dr != null)  //Primero verifico que no sea NULL lo que lea
            {
                while (dr.Read())//Mientras esto sea TRUE que lea la informacion y la asigno a las propiedades
                {                   //Del BOOK(TENGO que crear previo al CONDICIONAL una nueva instancia de BOOK 
                                    //PARA RETURN ese nuevo objeto de tipo BOOKS) y luego en el metodo de la pagina, uso este meotod InformacionEditable
                                    //y lo asigno a los TextBox

                    //se las asigno a las propiedades de la nueva instancia del BOOK
                    //Va a ser igual a el PARSEO(OBJTO DATAREADER["COLUMNA DE BD"])

                    libroEditable.LibroId = Convert.ToInt32(dr["BookId"]);
                    libroEditable.Titulo = dr["Title"].ToString();
                    libroEditable.IdentificadorComercial = dr["ISBN"].ToString();
                    libroEditable.EditorialNombre = dr["PublisherName"].ToString();
                    libroEditable.AutorNombre = dr["AuthorName"].ToString();
                    libroEditable.CategoriaNombre = dr["CategoryName"].ToString();

                }

            }


            return libroEditable;


        }


        public void LibroEditado(string connectionString, Books libroEditado)   //Este metodo trabaja en conjunto con el STORE PROCEDURE
        {                                                                          //TRY Y CATCH      
                                                                                   //Uso Using para este tipo de conexion 
                                                                                     //FUNDAMENTAL EL COMMANDTYPE.STORE; PROCEDURE EN EL CURSOR
            try                                                                         //Fundamental CURSOR.EXECUTENONQUERY();
            {
                using ( SqlConnection conexionEditable = new SqlConnection(connectionString))//Le envio por parametros la conexion recibida x parametros
                {
                
                    SqlCommand cursor = new SqlCommand("UpdateBook", conexionEditable);            //Recibe la QUERY o el STORE PROCEDURE + CONEXION
                    cursor.CommandType = CommandType.StoredProcedure;


                    cursor.Parameters.Add(new SqlParameter("@BookId",libroEditado.LibroId));
                    cursor.Parameters.Add(new SqlParameter("@Title",libroEditado.Titulo));
                    cursor.Parameters.Add(new SqlParameter("@Isbn", libroEditado.IdentificadorComercial));
                    cursor.Parameters.Add(new SqlParameter("@PublisherName", libroEditado.EditorialNombre));
                    cursor.Parameters.Add(new SqlParameter("@AuthorName",libroEditado.AutorNombre));
                    cursor.Parameters.Add(new SqlParameter("@CategoryName",libroEditado.CategoriaNombre));



                    conexionEditable.Open();
                    cursor.ExecuteNonQuery();             //Ejecutar y verificar la accion de la query
                    conexionEditable.Close();
                        
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }




        }



        public void BorrarLibro(string connectionString,int deleteBook)//Este metodo trabaja en conjunto con el STORE PROCEDURE
        {                                                                           //Recibe un objeto seleccionado de la Biblioteca 
                                                                                    //O un ID
            try
            {
                using (SqlConnection conexionDelete=new SqlConnection(connectionString))
                {
                    SqlCommand cursor = new SqlCommand("DeleteBook", conexionDelete);   //Aca va la query o el Store Procedure
                    cursor.CommandType = CommandType.StoredProcedure;


                    cursor.Parameters.Add(new SqlParameter("DeleteBook",deleteBook));




                    conexionDelete.Open();
                    cursor.ExecuteNonQuery();
                    conexionDelete.Close();

                }

            }
            catch(Exception ex)
            {
                throw ex;
            }



        }


    }
}