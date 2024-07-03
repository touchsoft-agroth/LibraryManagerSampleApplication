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

    public bool BookExists(int bookId)
    {
        return _bookRepository.GetById(bookId) != null;
    }

    public void Add(string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            return;
        }

        var book = new Book
        {
            Title = title,
            Author = author,
            Id = -1
        };
        
        _bookRepository.Add(book);
    }

    public IEnumerable<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }
}