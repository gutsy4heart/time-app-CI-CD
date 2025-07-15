using LiteraHouse.Models;
using LiteraHouse.Repository.AddPost;

namespace LiteraHouse.Repository.Concrete;
public class EFCoreBookRepository : IBooksRepository
{
    private readonly AppDbContext _context;

    public EFCoreBookRepository(AppDbContext context) => _context = context;

    #region Create
    public void AddBook(Book book)
    {
        _context.Add(book);
        _context.SaveChanges();
    }
    #endregion
    
    #region Read
    public List<Book> GetBooks()
    {
        var books = _context.Books;
        return books.ToList();

    }

    public Book GetBookById(int id)
    {
        var books = _context.Books.ToList().FirstOrDefault(x => x.Id == id) ?? new Book();
        return books;
    }

    #endregion

    #region Update
    public void UpdateBook(Book book)
    {
        _context.Update(book);
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void DeleteBook(int id)
    {
        var bookToDelete = _context.Books.ToList().FirstOrDefault(x => x.Id == id);

        _context.Books.Remove(bookToDelete);
        _context.SaveChanges(); 
    }
    #endregion


}

