namespace BLL.Interfacies.Services
{
    using System.Collections.Generic;

    using BLL.Interfacies.Entities;

    public interface IRoleService
    {
        IEnumerable<BLLRole> GetAllRoleEntities();        
        BLLRole GetById(int userId);
        void Dispose();
    }
        
}