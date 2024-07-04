using LibraryManager.Data.Models;
using LibraryManager.GUI.Dialogs;
using LibraryManager.GUI.Dialogs.Borrowing;
using LibraryManager.GUI.Views;
using LibraryManager.Service.Services;

namespace LibraryManager.GUI;

public partial class LibraryManagementGui : Form
{
    private readonly BookService _bookService;
    private readonly BorrowingService _borrowingService;
    private readonly UserService _userService;
    private readonly BookSearchService _bookSearchService;

    public LibraryManagementGui(BookService bookService, BorrowingService borrowingService, UserService userService, BookSearchService bookSearchService)
    {
        _bookService = bookService;
        _borrowingService = borrowingService;
        _userService = userService;
        _bookSearchService = bookSearchService;

        InitializeComponent();
    }

    private void RootForm_Load(object sender, EventArgs e)
    {
        LoadAllBooks();
    }

    private void LoadAllBooks()
    {
        SetBookList(_bookService.GetAll());
    }

    private void SetBookList(IEnumerable<Book> books)
    {
        bookListBox.DataSource = books.Select(book => new BookView(book)).ToList();
    }

    private void bookListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            SetBookForEdit(selectedBook);
        }
    }

    private void SetBookForEdit(Book book)
    {
        bookEditAuthorTextBox.Text = book.Author;
        bookEditTitleTextBox.Text = book.Title;

        bool isBorrowed = _borrowingService.IsBorrowed(book.Id);
        UpdateCurrentStatusLabel(isBorrowed);
        UpdateStatusButtons(isBorrowed);
    }

    private void UpdateStatusButtons(bool isBorrowed)
    {
        statusBorrowButton.Enabled = !isBorrowed;
        statusReturnButton.Enabled = isBorrowed;
    }

    private void UpdateCurrentStatusLabel(bool isBorrowed)
    {
        var color = isBorrowed ? Color.Red : Color.Green;
        var text = isBorrowed ? "Borrowed" : "Available";

        statusCurrentStatusLabel.Text = text;
        statusCurrentStatusLabel.ForeColor = color;
    }

    private void bookEditSaveButton_Click(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            selectedBook.Title = bookEditTitleTextBox.Text;
            selectedBook.Author = bookEditAuthorTextBox.Text;

            LoadAllBooks();
        }
    }

    private bool TryGetSelectedBook(out Book book)
    {
        book = null;

        if (bookListBox.SelectedItem is BookView selectedBookView)
        {
            book = selectedBookView.Book;
            return true;
        }

        return false;
    }

    private void statusBorrowButton_Click(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            new BorrowBookDialog(selectedBook, _userService, _borrowingService).ShowDialog();

            SetBookForEdit(selectedBook);
        }
    }

    private void statusReturnButton_Click(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            if (!_borrowingService.IsBorrowed(selectedBook.Id))
            {
                return;
            }

            _borrowingService.Return(selectedBook.Id);

            SetBookForEdit(selectedBook);
        }
    }

    private void bookTitleSearchTextBox_TextChanged(object sender, EventArgs e)
    {
        var searchTerm = bookTitleSearchTextBox.Text;

        var searchResult = _bookSearchService.Search(searchTerm);

        SetBookList(searchResult);
    }
}