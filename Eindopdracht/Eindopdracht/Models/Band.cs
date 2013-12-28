using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models
{
    public class Band
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

        private String _phone;

        public String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private String _fax;

        public String Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private Byte[] _photo;

        public Byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private String _description;

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _twitter;

        public String Twitter
        {
            get { return _twitter; }
            set { _twitter = value; }
        }

        private String _facebook;

        public String Facebook
        {
            get { return _facebook; }
            set { _facebook = value; }
        }

        private ObservableCollection<Genre> _genres;

        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set { _genres = value; }
        }

        public static ObservableCollection<Band> GetBands()
        {
            ObservableCollection<Band> lst = new ObservableCollection<Band>();
            string sql = "SELECT * FROM Bands";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                Band band = new Band()
                {
                    ID = (int)reader[0],
                    Name = (string)reader[1],
                    Phone = (string)reader[2],
                    Fax = (string)reader[3],
                    Email = (string)reader[4],
                    Photo = (Byte[])reader[5],
                    Description = (string)reader[6],
                    Twitter = (string)reader[7],
                    Facebook = (string)reader[8],
                };
                band.Genres = getGenresByBandId(band);
                lst.Add(band);
            }
            return lst;
        }

        public static ObservableCollection<Genre> getGenresByBandId(Band band)
        {
            ObservableCollection<Genre> lst = new ObservableCollection<Genre>();
            string sql = "SELECT GenreBand.IdBand, Genres.Name, GenreBand.IdGenre FROM GenreBand INNER JOIN Genres ON GenreBand.IdGenre=Genres.ID WHERE GenreBand.IdBand = @idBand";
            DbParameter idBand = Database.AddParameter("@idBand", band.ID);
            DbDataReader reader = Database.GetData(sql, idBand);
            while (reader.Read())
            {
                Genre genre = new Genre()
                {
                    ID = (int)reader["IdGenre"],
                    Name = (string)reader["Name"]
                };
                lst.Add(genre);
            }
            return lst;
        }      

        public static Band GetBandByid(Band band)
        {
            string sql = "SELECT * FROM Bands WHERE ID=@id";
            DbParameter par1 = Database.AddParameter("@id", band.ID);
            DbDataReader reader = Database.GetData(sql, par1);
            Band bnd = new Band();
            while (reader.Read())
            {
                bnd.ID = (int)reader["ID"];
                bnd.Name = (string)reader["Name"];
                bnd.Phone = (string)reader["Phone"];
                bnd.Fax = (string)reader["Fax"];
                bnd.Email = (string)reader["Email"];
                bnd.Photo = (Byte[])reader["Photo"];
                bnd.Description = (string)reader["Description"];
                bnd.Twitter = (string)reader["Twitter"];
                bnd.Facebook = (string)reader["Facebook"];
                bnd.Genres = getGenresByBandId(band);
            }
            return bnd;
        }

        public static ObservableCollection<Band> SearchBand(string term)
        {
            ObservableCollection<Band> lst = new ObservableCollection<Band>();
            string sql = "SELECT * FROM Bands WHERE Name LIKE @term";
            DbParameter termPar = Database.AddParameter("@term", "%" + term + "%");
            DbDataReader reader = Database.GetData(sql, termPar);
            while (reader.Read())
            {
                Band bnd = new Band();
                bnd.ID = (int)reader["ID"];
                bnd.Name = (string)reader["Name"];
                bnd.Phone = (string)reader["Phone"];
                bnd.Fax = (string)reader["Fax"];
                bnd.Email = (string)reader["Email"];
                bnd.Photo = (Byte[])reader["Photo"];
                bnd.Description = (string)reader["Description"];
                bnd.Twitter = (string)reader["Twitter"];
                bnd.Facebook = (string)reader["Facebook"];
                bnd.Genres = getGenresByBandId(bnd);
                lst.Add(bnd);
            }
            return lst;
        }
    }
}