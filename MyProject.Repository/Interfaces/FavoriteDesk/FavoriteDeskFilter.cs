﻿using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.FavoriteDesk
{
    public class FavoriteDeskFilter
    {
        public SqlInt32? UserId { get; set; }
        public SqlInt32? DeskId { get; set; }
        public SqlBoolean? IsFavorite { get; set; }
    }
}
