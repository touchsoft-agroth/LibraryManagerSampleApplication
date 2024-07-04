using LibraryManager.Data;
using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;

namespace LibraryManager.Tests.Data.Repositories;

public class BorrowedBookRepositoryTest
{
    private BorrowedBookRepository _borrowedBookRepository;
    private DataContext _dataContext;

    [SetUp]
    public void Setup()
    {
        _dataContext = new DataContext();
        _borrowedBookRepository = new BorrowedBookRepository(_dataContext);
    }

    [Test]
    public void GetAll_ReturnsAllInstances()
    {
        const int borrowedBookCount = 10;
        for (var i = 0; i < borrowedBookCount; i++)
        {
            var borrowedBook = new BorrowedBook
            {
                BookId = i,
                BorrowerId = i,
                From = DateTime.Now,
                To = DateTime.Now.AddDays(i)
            };
                    
            _borrowedBookRepository.Add(borrowedBook);
        }
        
        var allBorrowedBookCount = _borrowedBookRepository.GetAll();
                
        Assert.That(allBorrowedBookCount.Count(), Is.EqualTo(borrowedBookCount));
    }

    [Test]
    public void Add_AddsBorrowedBookToContext()
    {
        var initialCount = _dataContext.BorrowedBooks.Count;
        
        var borrowedBook = new BorrowedBook
        {
            BookId = 0,
            BorrowerId = 0,
            From = DateTime.Now,
            To = DateTime.Now.AddDays(1)
        };
        _borrowedBookRepository.Add(borrowedBook);
        
        Assert.That(_dataContext.BorrowedBooks, Has.Count.GreaterThan(initialCount));
    }

    [Test]
    public void Remove_WithBorrowedBookPresent_RemovesEntry()
    {
        var borrowedBook = new BorrowedBook
        {
            BookId = 0,
            BorrowerId = 0,
            From = DateTime.Now,
            To = DateTime.Now.AddDays(1)
        };
        _borrowedBookRepository.Add(borrowedBook);

        var countAfterAdding = _borrowedBookRepository.GetAll().Count();
        _borrowedBookRepository.Remove(borrowedBook);

        Assert.That(countAfterAdding, Is.GreaterThan(_borrowedBookRepository.GetAll().Count()));
    }
}