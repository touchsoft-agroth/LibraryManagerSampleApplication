using LibraryManager.Data.Models;

namespace LibraryManager.Data.Repositories;

public class UserRepository
{
    private readonly DataContext _context;

    private static int _nextId;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public void Add(User user)
    {
        if (user.Id == -1)
        {
            user.Id = _nextId++;
        }

        _context.Users.Add(user);
    }
}