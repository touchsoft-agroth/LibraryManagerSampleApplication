using LibraryManager.Data;
using LibraryManager.Data.Models;

namespace LibraryManager.Tests.Data;

public class MockDataContext : DataContext
{
    public MockDataContext()
    {
        AddBooks();
        AddUsers();
        AddBorrowedBooks();
    }

    private void AddBooks()
    {
        const int bookCount = 100;

        for (int i = 0; i < bookCount; i++)
        {
            var book = new Book
            {
                Title = $"Some book {i}",
                Author = $"Some author {i}",
                Id = i
            };
            
            Books.Add(book);
        }
    }

    private void AddUsers()
    {
        const int userCount = 150;

        for (int i = 0; i < userCount; i++)
        {
            var user = new User
            {
                Id = i,
                Name = $"Some name {i}"
            };
            
            Users.Add(user);
        }
    }

    private void AddBorrowedBooks()
    {
        const int booksToBorrowCount = 50;

        for (int i = 0; i < booksToBorrowCount; i++)
        {
            var borrowedBook = new BorrowedBook
            {
                BookId = i,
                BorrowerId = i,
                From = new DateTime(2000, 1, 1),
                To = new DateTime(2000, 2, 31)
            };
            
            BorrowedBooks.Add(borrowedBook);
        }
    }
}