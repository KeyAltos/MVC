namespace BLL.Interface.Entities
{
    public class BLLGrade
    {
        public int Id { get; set; }

        public int AppreiserId { get; set; }
        public BLLUser Appreiser { get; set; }

        public int BookId { get; set; }
        public BLLBook Book { get; set; }

        public byte GradeValue { get; set; }

        public string Comment { get; set; }

        public bool IsBookHadRead { get; set; }
    }
}