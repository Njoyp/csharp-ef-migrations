using ef.intro.wwwapi.Models;

namespace ef.intro.wwwapi.Repository
{
    public interface ILibraryRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        bool AddAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(int id);


        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);

        IEnumerable<Publisher> GetAllPublishers();
        Publisher GetAPublisher(int id);
        bool AddPublisher(Publisher publisher);
        bool UpdatePublisher(Publisher publisher);
        bool DeletePublisher(int id);
    }
}
