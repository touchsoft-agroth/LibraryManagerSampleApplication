using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using LibraryManager.Data;
using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;
using LibraryManager.Service.Services;

namespace LibraryManager.GUI;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var dataContext = new DataContext();
        var bookRepository = new BookRepository(dataContext);
        var bookService = new BookService(bookRepository);
        
        var borrowedBookRepository = new BorrowedBookRepository(dataContext);
        var borrowingService = new BorrowingService(borrowedBookRepository);

        var userRepository = new UserRepository(dataContext);
        var userService = new UserService(userRepository);
        
        var bookSearchService = new BookSearchService(bookService);
        
        LoadMockData(bookRepository, userRepository);
        Application.Run(new LibraryManagementGui(bookService, borrowingService, userService, bookSearchService));
    }

    /// <summary>
    /// This is a method that should not be considered part of the application, but is used in order to load in
    /// randomly generated books and create some users into the program.
    /// </summary>
    private static void LoadMockData(BookRepository bookRepository, UserRepository userRepository)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDirectory,"../../..", "MockData", "books.csv");
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var records = csv.GetRecords<Book>();
            foreach (var record in records)
            {
                bookRepository.Add(record);
            }
        }

        var user1 = new User
        {
            Id = 0,
            Name = "First user"
        };

        var user2 = new User
        {
            Id = 1,
            Name = "Second User"
        };

        var user3 = new User
        {
            Id = 2,
            Name = "Third user"
        };
        
        userRepository.Add(user1);
        userRepository.Add(user2);
        userRepository.Add(user3);
    }
}