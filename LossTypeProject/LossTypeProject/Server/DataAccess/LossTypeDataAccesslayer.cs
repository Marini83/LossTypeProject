using LossTypeProject.Server.Interfaces;
using LossTypeProject.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LossTypeProject.Server.DataAccess
{
    public class LossTypeDataAccesslayer : ILossType
    {
        readonly UserDBContext _dbContext = new();

        public LossTypeDataAccesslayer(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        //Get the details of a particular user    
        public LossType GetLossTypeData(int id)
        {
            try
            {
                LossType? lossType = _dbContext.LossTypes.Find(id);

                if (lossType != null)
                {
                    return lossType;
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
        public List<LossType> GetLossType()
        {
            try
            {
                return _dbContext.LossTypes.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<LossType> GetAllLossTypes()
        {
            try
            {
                return _dbContext.LossTypes.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddLossType(LossType lossType)
        {
            try
            {
                _dbContext.LossTypes.Add(lossType);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateLossType(LossType lossType)
        {
            try
            {
                _dbContext.Entry(lossType).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteLossType(int id)
        {
            try
            {
                LossType? lossType = _dbContext.LossTypes.Find(id);

                if (lossType != null)
                {
                    _dbContext.LossTypes.Remove(lossType);
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
