using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;

namespace LibraryManager.Service.Services;

public class BorrowingService
{
    private readonly BorrowedBookRepository _borrowedBookRepository;

    public BorrowingService(BorrowedBookRepository borrowedBookRepository)
    {
        _borrowedBookRepository = borrowedBookRepository;
    }

    public void Borrow(int bookId, int userId, DateTime from, DateTime to)
    {
        var borrowedBook = new BorrowedBook
        {
            BookId = bookId,
            BorrowerId = userId,
            From = from,
            To = to
        };
        
        _borrowedBookRepository.Add(borrowedBook);
    }

    public void Return(int bookId)
    {
        var borrowedBook = _borrowedBookRepository.GetAll().FirstOrDefault(borrowed => borrowed.BookId == bookId);

        if (borrowedBook == null)
        {
            return;
        }

        _borrowedBookRepository.Remove(borrowedBook);
    }

    public bool IsBorrowed(int bookId)
    {
        return _borrowedBookRepository.GetAll().Any(borrowedBook => borrowedBook.BookId == bookId);
    }
}