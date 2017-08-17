using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Mappers;

namespace BLL.Services
{
    using BLL.Interfacies.Entities;

    using DAL.Interfacies.DTO;
    using DAL.Interfacies.Repository;

    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalGrade> gradeRepository;

        public GradeService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.gradeRepository = uow.GradeRepository;
        }


        public void CreateGrade(BLLGrade grade)
        {            
            gradeRepository.Create(BllEntityMapper<DalGrade, BLLGrade>.Map(grade));            
            uow.Commit();
        }

        public void DeleteGrade(int GradeId)
        {
            gradeRepository.Delete(GradeId);
            uow.Commit();
        }

        public IEnumerable<BLLGrade> GetAllBookGrades(int bookId)
        {
            return BllEntityMapper<BLLGrade, DalGrade>.MapList(gradeRepository.GetAll().Where(x=>x.BookId== bookId).Select(x => x).ToList());
        }

        public IEnumerable<BLLGrade> GetAllUserGrades(int userId)
        {
            return BllEntityMapper<BLLGrade, DalGrade>.MapList(gradeRepository.GetAll().Where(x => x.AppreiserId == userId).Select(x => x).ToList());
        }

        public void UpdateGrade(BLLGrade grade)
        {
            gradeRepository.Update(BllEntityMapper<DalGrade, BLLGrade>.Map(grade));
            uow.Commit();
        }
        

        public BLLGrade GetById(int gradeId)
        {
            return BllEntityMapper<BLLGrade, DalGrade>.Map(gradeRepository.GetById(gradeId));
        }

        public IEnumerable<int> GetAllUserGradesId(int userId)
        {
            return gradeRepository.GetByPredicate(x => x.AppreiserId == userId).Select(x => x.BookId).ToList();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
