namespace LibraryManager.Data.Models;

public class BorrowedBook
{
    public int BorrowerId { get; set; }
    public int BookId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}