using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<BLLRole> GetAllRoleEntities();        
        BLLRole GetById(int userId);
        void Dispose();
    }
        
}