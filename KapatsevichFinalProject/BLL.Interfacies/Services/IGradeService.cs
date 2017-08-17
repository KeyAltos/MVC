using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    using BLL.Interfacies.Entities;

    public interface IGradeService
    {
        IEnumerable<BLLGrade> GetAllUserGrades(int userId);
        IEnumerable<BLLGrade> GetAllBookGrades(int bookId);

        IEnumerable<int> GetAllUserGradesId(int userId);        
        
        BLLGrade GetById(int GradeId);
        void CreateGrade(BLLGrade grade);
        void DeleteGrade(int GradeId);
        void UpdateGrade(BLLGrade grade);
        void Dispose();
    }
}
