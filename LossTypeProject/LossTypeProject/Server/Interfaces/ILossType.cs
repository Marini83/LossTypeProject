using LossTypeProject.Server.Models;

namespace LossTypeProject.Server.Interfaces
{
    public interface ILossType
    {
        public List<LossType> GetAllLossTypes();

        public void AddLossType(LossType lossType);

        public void UpdateLossType(LossType lossType);

        public LossType GetLossTypeData(int id);

        public void DeleteLossType(int id);

    }
}
