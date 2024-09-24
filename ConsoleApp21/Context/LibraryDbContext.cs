﻿using ConsoleApp21.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ConsoleApp21.Context
{
    namespace ConsoleApp21.Context
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext() : base() { }
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=WINDOWS-OQKHAJ5;Initial Catalog=Library2;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<AuthorBook>().HasKey(AB => new { AB.AuthorId, AB.BookId });

                modelBuilder.Entity<AuthorBook>().HasOne(A => A.Author)
                    .WithMany(B => B.AuthorBooks)
                    .HasForeignKey(AB => AB.AuthorId);

                modelBuilder.Entity<AuthorBook>().HasOne(A => A.Book)
                    .WithMany(B => B.AuthorBooks)
                    .HasForeignKey(AB => AB.BookId);
            }

        }
    }
}
