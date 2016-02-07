using BLL.Interface.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalGenre> GenreRepository;

        public GenreService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.GenreRepository = uow.GenreRepository;
        }

        public IEnumerable<BLLGenre> GetAllGenreEntities()
        {
            return BllEntityMapper<BLLGenre, DalGenre>.MapList(GenreRepository.GetAll().Select(x => x).ToList());
        }

        public BLLGenre GetById(int GenreId)
        {
            return BllEntityMapper<BLLGenre, DalGenre>.Map(GenreRepository.GetById(GenreId));
        }

        public void CreateGenre(BLLGenre Genre)
        {
            GenreRepository.Create(BllEntityMapper<DalGenre, BLLGenre>.Map(Genre));
            uow.Commit();
        }

        public void DeleteGenre(int GenreId)
        {
            GenreRepository.Delete(GenreId);
            uow.Commit();
        }

        public void UpdateGenre(BLLGenre Genre)
        {
            GenreRepository.Update(BllEntityMapper<DalGenre, BLLGenre>.Map(Genre));
            uow.Commit();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
