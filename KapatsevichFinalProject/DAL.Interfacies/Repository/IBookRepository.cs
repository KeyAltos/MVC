using DAL.Interface.DTO;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.Repository
{
    public interface IBookRepository : IRepository<DalBook>
    {        
        void CreateBook(DalBook book, int[] selectedGenres);
        void UpdateBook(DalBook book, int[] selectedGenres);
    }
}
