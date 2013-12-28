using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models
{
    public class Festival
    {
        private String _festName;

        public String FestName
        {
            get { return _festName; }
            set { _festName = value; }
        }

        private DateTime _startdata;

        public DateTime StartDate
        {
            get { return _startdata; }
            set { _startdata = value; }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        //public static Festival GetDates()
        //{
        //    string sql = "SELECT * FROM Dates";
        //    DbDataReader reader = Database.GetData(sql);
        //    Festival fest = new Festival();
        //    while (reader.Read())
        //    {
        //        fest.EndDate = (DateTime)reader["EndDate"];
        //        fest.StartDate = (DateTime)reader["StartDate"];
        //    }
        //    return fest;
        //}
    }
}