﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaAppWeb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BOOKSEntities : DbContext
    {
        public BOOKSEntities()
            : base("name=BOOKSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTHOR> AUTHOR { get; set; }
        public virtual DbSet<BOOK> BOOK { get; set; }
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<PUBLISHER> PUBLISHER { get; set; }
        public virtual DbSet<GetBookData> GetBookData { get; set; }
    
        public virtual int CreateBook(string title, string isbn, string publisherName, string authorName, string categoryName)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var isbnParameter = isbn != null ?
                new ObjectParameter("Isbn", isbn) :
                new ObjectParameter("Isbn", typeof(string));
    
            var publisherNameParameter = publisherName != null ?
                new ObjectParameter("PublisherName", publisherName) :
                new ObjectParameter("PublisherName", typeof(string));
    
            var authorNameParameter = authorName != null ?
                new ObjectParameter("AuthorName", authorName) :
                new ObjectParameter("AuthorName", typeof(string));
    
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateBook", titleParameter, isbnParameter, publisherNameParameter, authorNameParameter, categoryNameParameter);
        }
    
        public virtual int DeleteBook(Nullable<int> bookId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteBook", bookIdParameter);
        }
    
        public virtual int UpdateBook(Nullable<int> bookId, string title, string iSBN, string publisherName, string authorName, string categoryName)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var iSBNParameter = iSBN != null ?
                new ObjectParameter("ISBN", iSBN) :
                new ObjectParameter("ISBN", typeof(string));
    
            var publisherNameParameter = publisherName != null ?
                new ObjectParameter("PublisherName", publisherName) :
                new ObjectParameter("PublisherName", typeof(string));
    
            var authorNameParameter = authorName != null ?
                new ObjectParameter("AuthorName", authorName) :
                new ObjectParameter("AuthorName", typeof(string));
    
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateBook", bookIdParameter, titleParameter, iSBNParameter, publisherNameParameter, authorNameParameter, categoryNameParameter);
        }
    }
}
