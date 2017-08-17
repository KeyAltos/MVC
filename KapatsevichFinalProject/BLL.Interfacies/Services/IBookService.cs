namespace BLL.Interfacies.Services
{
    using System.Collections.Generic;

    using BLL.Interfacies.Entities;

    public interface IBookService
    {
        IEnumerable<BLLBook> GetAllBookEntities();
        IEnumerable<BLLBook> SearchBook(string title,string authorFirstName,string authorLastName);
        

        void CreateBook(BLLBook book, int[] selectedGenres);
        void DeleteBook(int bookId);
        BLLBook GetById(int bookId);
        void UpdateBook(BLLBook book, int[] selectedGenres);
        void Dispose();
    }
        
}