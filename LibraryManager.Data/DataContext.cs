using LibraryManager.Data.Models;

namespace LibraryManager.Data;

public class DataContext
{
    public List<Book> Books { get; } = new();
    public List<User> Users { get; } = new();
    public List<BorrowedBook> BorrowedBooks { get; } = new();
}