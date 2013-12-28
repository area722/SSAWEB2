using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models
{
    public class Genre
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public static ObservableCollection<Genre> GetGenres()
        {
            string sql = "SELECT * FROM Genres ORDER BY ID";
            ObservableCollection<Genre> lst = new ObservableCollection<Genre>();
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                Genre genre = new Genre()
                {
                    ID = (int)reader[0],
                    Name = (string)reader[1]
                };
                lst.Add(genre);
            }
            return lst;
        }

        public static void EditGenre(Genre genre)
        {
            Console.WriteLine(genre.ID);
            string sql = "UPDATE Genres SET Name=@Name WHERE ID=@Id";
            DbParameter par = Database.AddParameter("@Name", genre.Name);
            DbParameter par1 = Database.AddParameter("@Id", genre.ID);
            Database.ModifyData(sql, par, par1);
        }
    }
}