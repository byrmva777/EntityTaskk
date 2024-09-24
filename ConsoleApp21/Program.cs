using ConsoleApp21.Context;
using ConsoleApp21.Entities;
using System;

static void CreateAuthorBooks(LibraryDbContext context)
{
    var author = new Author { Id = 1, Name = "Aygun Bayramova" };
    var book1 = new Book { Id = 1, Title = " Xez Paltolu Madonna" };
    var book2 = new Book { Id = 2, Title = "Cerpeleng Ucuran" };

    var authorBook1 = new AuthorBook { Author = author, Book = book1 };
    var authorBook2 = new AuthorBook { Author = author, Book = book2 };

    context.Authors.Add(author);
    context.Books.AddRange(book1, book2);
    context.SaveChanges();

    Console.WriteLine("Yazar ve kitablar elave edildi");
}

static Author GetAuthorById(int Id, LibraryDbContext context)
{
    var author = context.Authors.Where(a => a.Id == Id).FirstOrDefault();
    return author;
}


using var context = new LibraryDbContext();

CreateAuthorBooks(context);

var author = GetAuthorById(1, context);

if (author != null)
{
    Console.WriteLine($"Author: {author.Name}");
    foreach (var item in author.AuthorBooks)
    {
        Console.WriteLine($"Book: {item.Book.Title}");
    }
}