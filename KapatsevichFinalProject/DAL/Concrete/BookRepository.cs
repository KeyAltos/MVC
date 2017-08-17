namespace DAL.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper;

    using DAL.Interfacies.DTO;
    using DAL.Interfacies.Repository;

    using ORM;
    using ORM.Tables;

    class BookRepository : GenericItemConcreteRepository<Book, DalBook>, IBookRepository
    {
        public BookRepository(DbContext uow)
            : base(uow)
        {
        }

        public void CreateBook(DalBook book, int[] selectedGenres)
        {
            var bookGenres = this.context.Set<Genre>().Where(x => selectedGenres.Contains(x.Id));
            var ormBook = Mapper.Map<DalBook, Book>(book);
            ormBook.Genres = new List<Genre>();

            foreach (var item in bookGenres)
            {
                ormBook.Genres.Add(item);
            }

            this.dbSet.Add(ormBook);
        }

        public override IEnumerable<DalBook> GetAll()
        {
            return Mapper.Map<List<Book>, List<DalBook>>(this.dbSet.Select(x => x).Include(src => src.Author).ToList());
        }

        public override DalBook GetById(int key)
        {
            return
                Mapper.Map<Book, DalBook>(
                    this.dbSet.Select(x => x).Include(src => src.Author).FirstOrDefault(item => item.Id == key));
        }

        public override IEnumerable<DalBook> GetByPredicate(Expression<Func<DalBook, bool>> predicate)
        {
            var expression = Mapper.Map<Expression<Func<Book, bool>>>(predicate);
            return
                Mapper.Map<List<Book>, List<DalBook>>(
                    this.dbSet.Where(expression).Select(x => x).Include(src => src.Author).ToList());
        }

        public void UpdateBook(DalBook book, int[] selectedGenres)
        {
            var bookFromDAL = Mapper.Map<DalBook, Book>(book);
            bookFromDAL.Genres.Clear();

            var ormBook = this.dbSet.FirstOrDefault(item => item.Id == book.Id);
            ormBook.Genres.Clear();

            this.context.Entry(ormBook).CurrentValues.SetValues(bookFromDAL);

            var bookGenres = this.context.Set<Genre>().Where(x => selectedGenres.Contains(x.Id));
            foreach (var item in bookGenres)
            {
                ormBook.Genres.Add(item);
            }

            this.context.Entry(ormBook).State = EntityState.Modified;
        }
    }
}