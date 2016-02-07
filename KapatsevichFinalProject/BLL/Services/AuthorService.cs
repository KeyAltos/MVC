using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using BLL.Mappers;

namespace BLL.Services
{
    public class AuthorService : IAuthorService, IDisposable
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalAuthor> authorRepository;

        public AuthorService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.authorRepository = uow.AuthorRepository;
        }
                

        public void CreateAuthor(BLLAuthor author)
        {
            authorRepository.Create(BllEntityMapper<DalAuthor, BLLAuthor>.Map(author));
            uow.Commit();
        }

        public void DeleteAuthor(int authorId)
        {
            authorRepository.Delete(authorId);
            uow.Commit();
        }        

        public IEnumerable<BLLAuthor> GetAllAuthorsEntities()
        {
            return BllEntityMapper<BLLAuthor, DalAuthor>.MapList(authorRepository.GetAll().Select(x => x).ToList());
        }

        public BLLAuthor GetById(int authorId)
        {
            return BllEntityMapper<BLLAuthor, DalAuthor>.Map(authorRepository.GetById(authorId));
        }

        public void UpdateAuthor(BLLAuthor author)
        {
            authorRepository.Update(BllEntityMapper<DalAuthor, BLLAuthor>.Map(author));
            uow.Commit();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
