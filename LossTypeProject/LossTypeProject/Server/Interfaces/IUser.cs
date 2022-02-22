using LossTypeProject.Server.Models;

namespace LossTypeProject.Server.Interfaces
{
    public interface IUser
    {
        public List<User> GetAllUsers();

        public void AddUser(User user);

        public void UpdateUser(User user);

        public User GetUserData(int id);

        public void DeleteUser(int id);

    }
}
