using ef.intro.wwwapi.Context;
using ef.intro.wwwapi.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ef.intro.wwwapi.Data
{
    public static class Seeder
    {
        private static List<string> Firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis", 
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate"
        };
        private static List<string> Lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"

        };
        private static List<string> Domain = new List<string>()
        {
            "bbc.co.uk",
            "google.com",
            "theworld.ca",
            "something.com",
            "tesla.com",
            "nasa.org.us",
            "gov.us",
            "gov.gr",
            "gov.nl",
            "gov.ru"
        };
        private static List<string> FirstWord = new List<string>()
        {
            "The",            
            "Two",
            "Several",
            "Fifteen",
            "A bunch of",
            "An army of",
            "A herd of"


        };
        private static List<string> SecondWord = new List<string>()
        {
            "Orange",
            "Purple",
            "Large",
            "Microscopic",
            "Green",
            "Transparent",
            "Rose Smelling",
            "Bitter"
        };
        private static List<string> ThirdWord = new List<string>()
        {
            "Buildings",
            "Cars",
            "Planets",
            "Houses",
            "Flowers",
            "Leopards"
        };
        private static string GeneratePublisherName()
        {
            string[] words = { "Blue", "Readable", "Flying", "Expensive", "Reflective", "Feathery", "Shiny", "Clean", "Brown Bagel", "Unlimited"};


            Random random = new Random();
            return $"The {words[random.Next(words.Length)]} Publishing Company";

        }
        public static void Seed(this WebApplication app)
        {
         
            
            using (var db = new LibraryContext())
            {
                Random authorRandom = new Random();                       
                Random bookRandom = new Random();
                Random publisherRandom = new Random();
                var authors = new List<Author>();
                var books = new List<Book>();
                var publishers = new List<Publisher>();

                if (!db.Authors.Any())
                {
                    for(int x = 1; x < 250; x++)
                    {
                        Author author = new Author();
                        author.Id = x;
                        author.FirstName = Firstnames[authorRandom.Next(Firstnames.Count)];
                        author.LastName = Lastnames[authorRandom.Next(Lastnames.Count)];
                        author.Email = $"{author.FirstName}.{author.LastName}@{Domain[authorRandom.Next(Domain.Count)]}".ToLower();
                        authors.Add(author);

                                              
                    }
                    db.Authors.AddRange(authors);
                }

                if (!db.Publishers.Any())
                {
                    for (int x = 1; x<100; x++)
                    {
                        Publisher publisher = new Publisher();
                        publisher.Id = x;
                        publisher.Name = GeneratePublisherName();
                        publishers.Add(publisher);
                    }
                    db.Publishers.AddRange(publishers);
                }

                if (!db.Books.Any())
                {

                    for (int x = 1; x < 250; x++)
                    {
                        Book book = new Book();
                        book.Id = x;
                        book.Title = $"{FirstWord[bookRandom.Next(FirstWord.Count)]} {SecondWord[bookRandom.Next(SecondWord.Count)]} {ThirdWord[bookRandom.Next(ThirdWord.Count)]}";
                        book.AuthorId = authors[authorRandom.Next(authors.Count)].Id;
                        book.PublisherId = publishers[publisherRandom.Next(publishers.Count)].Id;
                        book.ReleaseDate = DateTime.UtcNow;
                        //book.Author = authors[book.AuthorId-1];
                        books.Add(book);
                    }
                    db.Books.AddRange(books);
                }
                db.SaveChanges();            
            }

        }
    }
}



