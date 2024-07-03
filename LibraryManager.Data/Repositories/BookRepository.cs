using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories;

public class BookRepository
{
    private static int _nextId;
    
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
        if (book.Id == -1)
        {
            book.Id = _nextId++;
        }
        
        _context.Books.Add(book);
    }
}