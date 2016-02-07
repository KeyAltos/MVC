using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IGradeService
    {
        IEnumerable<BLLGrade> GetAllUserGrades(int userId);
        IEnumerable<BLLGrade> GetAllBookGrades(int bookId);

        IEnumerable<int> GetAllUserGradesId(int userId);
        //IEnumerable<BLLGrade> GetAllUserGrades(int userId);
        bool CheckGrade(int userId, int bookId);

        BLLGrade GetById(int GradeId);
        void CreateGrade(BLLGrade grade);
        void DeleteGrade(int GradeId);
        void UpdateGrade(BLLGrade grade);
        void Dispose();
    }
}
