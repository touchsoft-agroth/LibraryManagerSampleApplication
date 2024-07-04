using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories;

public class BookRepository
{
    private readonly DataContext _context;
    
    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Books;
    }
    
    public Book? GetById(int bookId)
    {
        return _context.Books.FirstOrDefault(book => book.Id == bookId);
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
    }
}