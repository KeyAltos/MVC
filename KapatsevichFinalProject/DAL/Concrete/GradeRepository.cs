using AutoMapper;
using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class GradeRepository : GenericItemConcreteRepository<Grade, DalGrade>
    {
        public GradeRepository(DbContext uow) : base(uow) { }

        public override IEnumerable<DalGrade> GetAll()
        {
            return Mapper.Map<List<Grade>, List<DalGrade>>(dbSet.Select(x => x).Include(src => src.Appreiser).Include(src=>src.Book).Include(src => src.Book.Author).ToList());
        }

        public override DalGrade GetById(int Id)
        {
            return Mapper.Map<Grade, DalGrade>(dbSet.Where(x=>x.Id==Id).Select(x => x).Include(src => src.Appreiser).Include(src => src.Book).Include(src => src.Book.Author).FirstOrDefault());
        }
    }
}
