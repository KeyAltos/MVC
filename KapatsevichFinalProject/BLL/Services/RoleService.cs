using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Mappers;

namespace BLL.Services
{
    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;

    using DAL.Interfacies.DTO;
    using DAL.Interfacies.Repository;

    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalRole> roleRepository;

        public RoleService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.roleRepository = uow.RoleRepository;
        }

        public IEnumerable<BLLRole> GetAllRoleEntities()
        {
            return BllEntityMapper<BLLRole, DalRole>.MapList(roleRepository.GetAll().Select(x => x).ToList());
        }

        public BLLRole GetById(int roleId)
        {
            return BllEntityMapper<BLLRole, DalRole>.Map(roleRepository.GetById(roleId));
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
