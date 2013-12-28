using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models.DAL
{
    public class FestivalRepository
    {
        public static String GetFestName()
        {
            string sql = "SELECT * FROM FestName";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                return (string)reader["FestName"];
            }
            return "";
        }

        public static Festival GetDates()
        {
            string sql = "SELECT * FROM Dates";
            DbDataReader reader = Database.GetData(sql);
            Festival fest = new Festival();
            while (reader.Read())
            {
                fest.EndDate = (DateTime)reader["EndDate"];
                fest.StartDate = (DateTime)reader["StartDate"];
            }
            return fest;
        }
    }
}