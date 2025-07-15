using LiteraHouse.Models;

namespace LiteraHouse.Repository.AddPost
{

    public interface IBooksRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }

}