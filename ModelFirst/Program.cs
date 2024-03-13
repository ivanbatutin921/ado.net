using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    internal class Program
    {
        //DBFirst бд уже существует
        //CodeFirst бд создается из кода
        //ModelFirst

        static void AddAuthor(Author author)
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                Author a = db.AuthorSet.Where(x=>
                x.FirstName== author.FirstName && x.LastName==author.LastName).FirstOrDefault();    
                if (a == null)
                {
                    db.AuthorSet.Add(author);
                    db.SaveChanges();
                    Console.WriteLine($"Ok add: {author.LastName}");
                }
            }
        }
        static void AddBook(Book book)
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {                
                Book a = db.BookSet.Where(x =>
                x.Title == book.Title && x.Pages == book.Pages && x.Price == book.Price).FirstOrDefault();
                if (a == null)
                {
                    db.BookSet.Add(book);
                    db.SaveChanges();
                    Console.WriteLine($"Ok add: {book.Title}");
                }
            }
        }

        static void AddPublisher(Publisher publisher)
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                // && x.AuthorId = book.AuthorId && x.PublisherId=book.PublisherId
                Publisher p = db.PublisherSet.Where(x =>
                x.PublisherName == publisher.PublisherName && x.Address == publisher.Address && x.CountryId == publisher.CountryId).FirstOrDefault();
                if (p == null)
                {
                    db.PublisherSet.Add(publisher);
                    db.SaveChanges();
                    Console.WriteLine($"Ok add: {publisher.PublisherName}");
                }
            }
        }
        static void AddCountry(Country country)
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                // && x.AuthorId = book.AuthorId && x.PublisherId=book.PublisherId
                Country c = db.CountrySet.Where(x =>
                x.Name == country.Name).FirstOrDefault();
                if (c == null)
                {
                    db.CountrySet.Add(country);
                    db.SaveChanges();
                    Console.WriteLine($"Ok add: {country.Name}");
                }
            }
        }



        static void AllAuthors()
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                var all_authors=db.AuthorSet.ToList();
                foreach (var author in all_authors)
                {
                    Console.WriteLine($"{author.FirstName,15} {author.LastName,15}");
                }
            }
        }
        static void AllBook()
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                var all_books = db.BookSet.ToList();
                foreach (var book in all_books)
                {
                    Console.WriteLine($"{book.Title}");
                }
            }
        }
        static void AllPublisher()
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                var all_publisher = db.PublisherSet.ToList();
                foreach (var publisher in all_publisher)
                {
                    Console.WriteLine($"{publisher.PublisherName}");
                }
            }
        }
        static void AllCountry()
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                var all_country = db.CountrySet.ToList();
                foreach (var country in all_country)
                {
                    Console.WriteLine($"{country.Name}");
                }
            }
        }


        static void SelectAuthor(string authorName)
        {
            using (LibraryModelContainer db = new LibraryModelContainer())
            {
                var authors = db.AuthorSet.Where(a => a.FirstName == authorName);
                
                foreach (var author in authors)
                {
                    Console.WriteLine(author.FirstName + " " + author.LastName);
                }


            }

        }
    



        static void Main(string[] args)
        {
            //Author a1 = new Author()
            //{
            //    FirstName = "Ivan1",
            //    LastName = "Batutin1"
            //};
            //Author a2 = new Author()
            //{ 
            //    FirstName = "Ivan2",
            //    LastName = "Batutin2"
            //};
            //Author a3 = new Author()
            //{
            //    FirstName = "Ivan3",
            //    LastName = "Batutin3"
            //};

            //AddAuthor(a1);
            //AddAuthor(a2);
            //AddAuthor(a3);

            //Book b1 = new Book()
            //{
            //    Title = "Заголовок1",
            //    Pages = "99",
            //    Price = "88",
            //    //AuthorId = 1,
            //    //PublisherId = 1
            //};
            //Book b2 = new Book()
            //{
            //    Title = "Заголовок2",
            //    Pages = "99",
            //    Price = "88",
            //    //AuthorId = 2,
            //    //PublisherId = 2
            //};
            //Book b3 = new Book()
            //{
            //    Title = "Заголовок3",
            //    Pages = "99",
            //    Price = "88",
            //    //AuthorId = 2,
            //    //PublisherId = 2
            //};
            //AddBook(b1);
            //AddBook(b2);
            //AddBook(b3);

            //Publisher p1 = new Publisher()
            //{
            //    PublisherName = "имя1",
            //    Address = "адрес1",
            //    CountryId = 1
            //};
            //Publisher p2 = new Publisher()
            //{
            //    PublisherName = "имя2",
            //    Address = "адрес2",
            //    CountryId = 2
            //};
            //Publisher p3 = new Publisher()
            //{
            //    PublisherName = "имя3",
            //    Address = "адрес3",
            //    CountryId = 2
            //};
            //AddPublisher(p1);
            //AddPublisher(p2);
            //AddPublisher(p3);

            //Country c1 = new Country()
            //{
            //    Name = "страна1"
            //};
            //Country c2 = new Country()
            //{
            //    Name = "страна2"
            //};
            //Country c3 = new Country()
            //{
            //    Name = "страна3"
            //};
            //AddCountry(c1);
            //AddCountry(c2);
            //AddCountry(c3);

            //AllAuthors();
            //AllPublisher();
            //AllCountry();

            SelectAuthor("Ivan1");

            Console.ReadKey();

        }
    }
}
