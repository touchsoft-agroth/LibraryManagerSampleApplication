using LibraryManager.Data;
using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;

namespace LibraryManager.Tests.Data.Repositories;

public class BookRepositoryTest
{
    private BookRepository _bookRepository;
    private DataContext _dataContext;

    [SetUp]
    public void Setup()
    {
        _dataContext = new DataContext();
        _bookRepository = new BookRepository(_dataContext);
    }

    [Test]
    public void Add_AddsBook_ToDataContext()
    {
        var originalBookCount = _dataContext.Books.Count;
        
        var book = new Book
        {
            Author = "some author",
            Id = 5,
            Title = "some title"
        };
        _bookRepository.Add(book);
        
        Assert.That(_dataContext.Books, Has.Count.GreaterThan(originalBookCount));
    }

    [Test]
    public void GetAll_ReturnsAll()
    {
        const int bookCount = 10;
        for (var i = 0; i < bookCount; i++)
        {
            var book = new Book
            {
                Author = "some author",
                Id = i,
                Title = "some title"
            };
            
            _bookRepository.Add(book);
        }

        var allBooksResult = _bookRepository.GetAll();
        
        Assert.That(allBooksResult.Count(), Is.EqualTo(bookCount));
    }

    [Test]
    public void GetById_WithExistingBookId_ReturnsBook()
    {
        var book = new Book
        {
            Author = "some author",
            Id = 5,
            Title = "some title"
        };
        _bookRepository.Add(book);

        var bookResult = _bookRepository.GetById(5);
        
        Assert.That(bookResult, Is.Not.Null);
    }

    [Test]
    public void GetById_WithoutExistingBookId_ReturnsNull()
    {
        var bookResult = _bookRepository.GetById(5);
        
        Assert.That(bookResult, Is.Null);
    }
}