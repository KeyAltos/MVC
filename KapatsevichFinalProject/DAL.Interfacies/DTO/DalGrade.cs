namespace DAL.Interface.DTO
{
    public class DalGrade : IDalEntity
    {
        public int Id { get; set; }

        public int AppreiserId { get; set; }
        public DalUser Appreiser { get; set; }

        public int BookId { get; set; }
        public DalBook Book { get; set; }

        public byte GradeValue { get; set; }

        public string Comment { get; set; }

        public bool IsBookHadRead { get; set; }
    }
}