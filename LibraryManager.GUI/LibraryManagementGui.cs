using LibraryManager.Data.Models;
using LibraryManager.GUI.Dialogs;
using LibraryManager.GUI.Views;
using LibraryManager.Service.Services;

namespace LibraryManager.GUI;

public partial class LibraryManagementGui : Form
{
    private readonly BookService _bookService;
    private readonly BorrowingService _borrowingService;
    private readonly UserService _userService;

    public LibraryManagementGui(BookService bookService, BorrowingService borrowingService, UserService userService)
    {
        _bookService = bookService;
        _borrowingService = borrowingService;
        _userService = userService;

        InitializeComponent();
    }

    private void RootForm_Load(object sender, EventArgs e)
    {
        PopulateBookList(_ => true);
    }

    private void PopulateBookList(Predicate<Book> filter)
    {
        bookListBox.DataSource = _bookService.GetAll()
            .Where(book => filter(book))
            .Select(book => new BookView(book))
            .ToList();
    }

    private void bookListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            SetBookForEdit(selectedBook.Book);
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
            var bookModel = selectedBook.Book;
            bookModel.Title = bookEditTitleTextBox.Text;
            bookModel.Author = bookEditAuthorTextBox.Text;

            PopulateBookList(_ => true);
        }
    }

    private bool TryGetSelectedBook(out BookView bookView)
    {
        bookView = null;

        if (bookListBox.SelectedItem is BookView selectedBookView)
        {
            bookView = selectedBookView;
            return true;
        }

        return false;
    }

    private void statusBorrowButton_Click(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            var bookModel = selectedBook.Book;

            new BorrowBookDialog(bookModel, _userService, _borrowingService).ShowDialog();

            SetBookForEdit(bookModel);
        }
    }

    private void statusReturnButton_Click(object sender, EventArgs e)
    {
        if (TryGetSelectedBook(out var selectedBook))
        {
            var bookModel = selectedBook.Book;

            _borrowingService.Return(bookModel.Id);

            SetBookForEdit(bookModel);
        }
    }

    private void bookTitleSearchTextBox_TextChanged(object sender, EventArgs e)
    {
        var searchText = bookTitleSearchTextBox.Text;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            PopulateBookList(_ => true);
        }

        else
        {
            PopulateBookList(book => book.Title.Contains(searchText));
        }
    }
}