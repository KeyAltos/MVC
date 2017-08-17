using BLL.Mappers;

using DAL.Interfacies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;

    using DAL.Interfacies.DTO;

    public class BookService: IBookService
    {
        private readonly IUnitOfWork uow;
        private readonly IBookRepository bookRepository;

        public BookService(IUnitOfWork uow)
        {
            this.uow = uow;
            this.bookRepository = uow.BookRepository;
        }

        public IEnumerable<BLLBook> GetAllBookEntities()
        {
            return BllEntityMapper<BLLBook, DalBook>.MapList(bookRepository.GetAll().Select(x => x).ToList());
        }

        public BLLBook GetById(int bookId)
        {
            return BllEntityMapper<BLLBook, DalBook>.Map(bookRepository.GetById(bookId));
        }

        public void CreateBook(BLLBook book, int[] selectedGenres)
        {
            bookRepository.CreateBook(BllEntityMapper<DalBook, BLLBook>.Map(book), selectedGenres);
            uow.Commit();
        }

        public void DeleteBook(int bookId)
        {
            bookRepository.Delete(bookId);
            uow.Commit();
        }

        public void UpdateBook(BLLBook book, int[] selectedGenres)
        {
            bookRepository.UpdateBook(BllEntityMapper<DalBook, BLLBook>.Map(book), selectedGenres);
            uow.Commit();
        }
                

        public IEnumerable<BLLBook> SearchBook(string title, string authorFirstName, string authorLastName)
        {

            IEnumerable<DalBook> listOfBooks = bookRepository.GetAll();

            if (title == ""&& authorFirstName==""&& authorLastName=="")
            {
                return BllEntityMapper<BLLBook, DalBook>.MapList(listOfBooks);
            }

            if (title!="")
            {
                listOfBooks = bookRepository.GetByPredicate(x => x.Name == title).Select(x => x);
            }           

            if (authorFirstName != "")
            {
                listOfBooks = listOfBooks.Where(x => x.Author.FirstName == authorFirstName).Select(x => x);
            }

            if (authorLastName != "")
            {
                listOfBooks = listOfBooks.Where(x => x.Author.LastName == authorLastName).Select(x => x);
            }

            return BllEntityMapper<BLLBook, DalBook>.MapList(listOfBooks);
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
