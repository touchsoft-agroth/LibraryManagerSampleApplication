using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories;

namespace LibraryManager.Service.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }
}