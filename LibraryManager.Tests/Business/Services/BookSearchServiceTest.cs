using LibraryManager.Data;
using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;
using LibraryManager.Service.Services;

namespace LibraryManager.Tests.Business.Services;

public class BookSearchServiceTest
{
    private BookSearchService _bookSearchService;

    [SetUp]
    public void Setup()
    {
        var dataContext = new DataContext();
        var bookRepository = new BookRepository(dataContext);
        AddBooks(bookRepository);
        var bookService = new BookService(bookRepository);

        _bookSearchService = new BookSearchService(bookService);
    }

    [Test]
    public void Search_WithEmptySearchTerm_ReturnsAllBooks()
    {
        var searchTerm = string.Empty;

        var searchResult = _bookSearchService.Search(searchTerm);
        
        Assert.That(searchResult.Count(), Is.EqualTo(3));
    }

    [Test]
    public void Search_WithMultipleMatching_ReturnsAllMatching()
    {
        var searchTerm = "second";

        var searchResult = _bookSearchService.Search(searchTerm);

        var bookTitles = searchResult.Select(book => book.Title).ToList();
        Assert.That(bookTitles, Does.Contain("second"));
        Assert.That(bookTitles, Does.Contain("second2"));
        Assert.That(bookTitles, Has.Count.EqualTo(2));
    }

    [Test]
    public void Search_WithOnlyOneMatching_ReturnsSingleInstance()
    {
        var searchTerm = "first";

        var searchResult = _bookSearchService.Search(searchTerm);

        var bookTitles = searchResult.Select(book => book.Title).ToList();
        Assert.That(bookTitles, Does.Contain("first"));
        Assert.That(bookTitles, Has.Count.EqualTo(1));
    }

    private static void AddBooks(BookRepository bookRepository)
    {
        var book1 = new Book
        {
            Title = "first",
            Author = "some author",
            Id = 0
        };
        bookRepository.Add(book1);

        var book2 = new Book
        {
            Title = "second",
            Author = "some author",
            Id = 1
        };
        bookRepository.Add(book2);

        var book3 = new Book
        {
            Title = "second2",
            Author = "some author",
            Id = 2
        };
        bookRepository.Add(book3);
    }
}