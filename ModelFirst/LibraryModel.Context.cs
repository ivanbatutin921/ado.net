﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryModelContainer : DbContext
    {
        public LibraryModelContainer()
            : base("name=LibraryModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> AuthorSet { get; set; }
        public virtual DbSet<Publisher> PublisherSet { get; set; }
        public virtual DbSet<Book> BookSet { get; set; }
        public virtual DbSet<Country> CountrySet { get; set; }
    }
}
