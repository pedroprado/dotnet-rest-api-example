using System.Collections.Generic;
using System.Linq;
using web_api_example.Models;

namespace web_api_example.Repository
{
    public class UserRepository : IUserRepository
    {

        private UserDBContext _userDbContext;

        public UserRepository(UserDBContext userDbContext){
            this._userDbContext = userDbContext;
        }

        public void createUser(User user)
        {
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
        }

        public void deleteUserById(int userId)
        {
            var user = _userDbContext.Users.First(u => u.userId == userId);
            _userDbContext.Users.Remove(user);
            _userDbContext.SaveChanges();

        }

        public IEnumerable<User> getAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public User getUserById(int userId)
        {
            return _userDbContext.Users.FirstOrDefault( user=> user.userId == userId);

        }

        public void updateUser(User user)
        {
            _userDbContext.Users.Update(user);
            _userDbContext.SaveChanges();
        }
    }
}