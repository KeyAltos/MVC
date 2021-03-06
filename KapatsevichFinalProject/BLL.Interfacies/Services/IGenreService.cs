﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    using BLL.Interfacies.Entities;

    public interface IGenreService
    {
        IEnumerable<BLLGenre> GetAllGenreEntities();
        void CreateGenre(BLLGenre Genre);
        void DeleteGenre(int GenreId);
        BLLGenre GetById(int GenreId);
        void UpdateGenre(BLLGenre Genre);
        void Dispose();
    }
}
