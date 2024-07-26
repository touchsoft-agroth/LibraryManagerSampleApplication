using LibraryManager.Data.Models;

namespace LibraryManager.Data;

/// <summary>
/// This is an in-memory substitute for a database and should be considered to match the tables in a database.
/// </summary>
public class DataContext
{
    public List<Book> Books { get; } = new();
    public List<User> Users { get; } = new();
    public List<BorrowedBook> BorrowedBooks { get; } = new();
}