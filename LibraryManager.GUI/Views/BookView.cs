using LibraryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
