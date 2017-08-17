namespace BLL.Interfacies.Services
{
    using System.Collections.Generic;

    using BLL.Interfacies.Entities;

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