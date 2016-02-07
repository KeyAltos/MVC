using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAuthorService
    {
        IEnumerable<BLLAuthor> GetAllAuthorsEntities();
        void CreateAuthor(BLLAuthor author);
        void DeleteAuthor(int authorId);
        BLLAuthor GetById(int authorId);
        void UpdateAuthor(BLLAuthor author);
        void Dispose();
    }
        
}