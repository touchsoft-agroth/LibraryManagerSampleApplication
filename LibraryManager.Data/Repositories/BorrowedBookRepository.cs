using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories;

public class BorrowedBookRepository
{
    private readonly DataContext _context;
    
    public BorrowedBookRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<BorrowedBook> GetAll()
    {
        return _context.BorrowedBooks;
    }

    public void Add(BorrowedBook borrowedBook)
    {
        _context.BorrowedBooks.Add(borrowedBook);
        Console.WriteLine(_context.BorrowedBooks.Count);
    }

    public void Remove(BorrowedBook borrowedBook)
    {
        _context.BorrowedBooks.Remove(borrowedBook);
    }
}