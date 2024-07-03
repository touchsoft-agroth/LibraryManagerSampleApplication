using LibraryManager.Data;
using LibraryManager.Data.Repositories;
using LibraryManager.Service.Services;

namespace LibraryManager.Tests.Business.Services;

public class BorrowingServiceTest
{
    private BorrowingService _borrowingService;
    
    [SetUp]
    public void Setup()
    {
        var dataContext = new DataContext();
        var borrowedBookRepository = new BorrowedBookRepository(dataContext);

        _borrowingService = new BorrowingService(borrowedBookRepository);
    }

    [Test]
    public void Borrow_BorrowsBook()
    {
        var bookId = 1;
        var userId = 1;
        var startDate = new DateTime(2000, 1, 1);
        var endDate = new DateTime(2000, 2, 1);
        
        _borrowingService.Borrow(bookId, userId, startDate, endDate);

        Assert.That(_borrowingService.IsBorrowed(bookId), Is.True);
    }

    [Test]
    public void Return_ReturnsBook()
    {
        _borrowingService.Borrow(1, 1, DateTime.Now, DateTime.Now);
        
        _borrowingService.Return(1);
        
        Assert.That(_borrowingService.IsBorrowed(1), Is.False);
    }
}