using LossTypeProject.Server.Interfaces;
using LossTypeProject.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LossTypeProject.Server.DataAccess
{
    public class UserDataAccessLayer : IUser
    {
        readonly UserDBContext _dbContext = new();

        public UserDataAccessLayer(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        //Get the details of a particular user    
        public User GetUserData(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

       
        // To get the list of LossTypes
        //public List<LossType> GetLossType()
        //{
        //    try
        //    {
        //        return _dbContext.LossTypes.ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public List<User> GetAllUsers()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteUser(int id) /*No Permission to Delete */
        {
            try
            {
                User? user = _dbContext.Users.Find(id);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
