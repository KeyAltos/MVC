namespace DAL.Interfacies.Repository
{
    using DAL.Interfacies.DTO;

    public interface IBookRepository : IRepository<DalBook>
    {
        void CreateBook(DalBook book, int[] selectedGenres);

        void UpdateBook(DalBook book, int[] selectedGenres);
    }
}