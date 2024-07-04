using LibraryManager.Data.Models;

namespace LibraryManager.Service.Services;

public class BookSearchService
{
    private readonly BookService _bookService;
    
    public BookSearchService(BookService bookService)
    {
        _bookService = bookService;
    }

    public IEnumerable<Book> Search(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return _bookService.GetAll();
        }
        
        return _bookService.GetAll().Where(book => book.Title.Contains(searchTerm));
    }
}