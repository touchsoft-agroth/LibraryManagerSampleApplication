using LibraryManager.Data.Models;

namespace LibraryManager.GUI.Views
{
    internal class BookView
    {
        public Book Book { get; }

        public BookView (Book book)
        {
            Book = book;
        }

        public override string ToString()
        {
            return $"{Book.Title} - {Book.Author}";
        }
    }
}
