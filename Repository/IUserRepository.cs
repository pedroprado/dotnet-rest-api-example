using System.Collections.Generic;
using web_api_example.Models;

namespace web_api_example.Repository
{
    public interface IUserRepository
    {
         void createUser(User user);
         IEnumerable<User> getAllUsers();
         User getUserById(int userId);
         void deleteUserById(int userId);
         void updateUser(User user);

    }
}