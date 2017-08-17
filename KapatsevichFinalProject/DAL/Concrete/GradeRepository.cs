namespace DAL.Concrete
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using DAL.Interfacies.DTO;

    using ORM;
    using ORM.Tables;

    class GradeRepository : GenericItemConcreteRepository<Grade, DalGrade>
    {
        public GradeRepository(DbContext uow)
            : base(uow)
        {
        }

        public override IEnumerable<DalGrade> GetAll()
        {
            return
                Mapper.Map<List<Grade>, List<DalGrade>>(
                    this.dbSet.Select(x => x)
                        .Include(src => src.Appreiser)
                        .Include(src => src.Book)
                        .Include(src => src.Book.Author)
                        .ToList());
        }

        public override DalGrade GetById(int Id)
        {
            return
                Mapper.Map<Grade, DalGrade>(
                    this.dbSet.Where(x => x.Id == Id)
                        .Select(x => x)
                        .Include(src => src.Appreiser)
                        .Include(src => src.Book)
                        .Include(src => src.Book.Author)
                        .FirstOrDefault());
        }
    }
}