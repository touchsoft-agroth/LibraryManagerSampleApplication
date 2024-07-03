using LibraryManager.Data;
using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;
using LibraryManager.Service.Services;

namespace LibraryManager.Tests.Business.Services;

public class BookServiceTest
{
    private BookService _bookService;
    private BookRepository _bookRepository;

    [SetUp]
    public void Setup()
    {
        var dataContext = new DataContext();

        _bookRepository = new BookRepository(dataContext);
        _bookService = new BookService(_bookRepository);
    }

    [Test]
    public void BookExists_WithExistingBook_ReturnsTrue()
    {
        _bookRepository.Add(new Book
        {
            Author = "some author",
            Title = "some title",
            Id = 1
        });

        var exists = _bookService.BookExists(1);
        
        Assert.That(exists, Is.True);
    }

    [Test]
    public void BookExists_WithoutExistingBook_ReturnsFalse()
    {
        var exists = _bookService.BookExists(1);

        Assert.That(exists, Is.False);
    }

    [Test]
    public void Add_WithInvalidParameters_DoesNotCreateNew()
    {
        string title = null;
        string author = string.Empty;
        
        _bookService.Add(title, author);

        var entityCount = _bookRepository.GetAll().Count();
        Assert.That(entityCount, Is.EqualTo(0));
    }

    [Test]
    public void Add_WithValidParameters_CreatesNewBook()
    {
        string title = "some book";
        string author = "some author";
        
        _bookService.Add(title, author);
        
        var entityCount = _bookRepository.GetAll().Count();
        Assert.That(entityCount, Is.EqualTo(1));
    }
}