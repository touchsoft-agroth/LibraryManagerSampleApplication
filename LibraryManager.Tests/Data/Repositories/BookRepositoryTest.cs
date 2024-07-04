using LibraryManager.Data.Repositories;

namespace LibraryManager.Tests.Data.Repositories;

public class BookRepositoryTest
{
    private BookRepository _bookRepository;

    [SetUp]
    public void Setup()
    {
        _bookRepository = new BookRepository(new MockDataContext());
    }

    [Test]
    public void Add_()
    {
        
    }
}