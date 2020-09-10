# Biblioteca-App-Web

Desarrollo de una Biblioteca Web Con ASP y C# cuenta con

Archivos JS Css Boostrap Master Page Entity FrameWork Conexion a base de datos SQL SERVER

Una biblioteca digital es una colección de objetos digitales organizados, 
que sirve a una comunidad de usuarios definida, que tiene los derechos de autor presentes y gestionados y que dispone de mecanismos de preservación y conservación. 
Una definición más exhaustiva propuesta en la bibliografía especializada establece que "biblioteca digital es un sistema de tratamiento técnico, 
acceso y transferencia de información digital, se estructura mediante una colección de documentos digitales, 
sobre los cuales se ofrecen servicios interactivos de valor añadido para el usuario final


    web.config
    <add name="BibliotecaDBConnectionString" connectionString="Data Source=DESKTOP-5ILIF80\;Initial Catalog=BOOKS;Integrated Security=True" providerName="System.Data.SqlClient" />
       
       Implementacion
       private string connectionString = WebConfigurationManager.ConnectionStrings["BibliotecaDBConnectionString"].ConnectionString;
