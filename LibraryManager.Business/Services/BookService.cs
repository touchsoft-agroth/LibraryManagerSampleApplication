using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;

namespace LibraryManager.Service.Services;

public class BookService
{
    private readonly BookRepository _bookRepository;
    
    public BookService(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IEnumerable<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }
}