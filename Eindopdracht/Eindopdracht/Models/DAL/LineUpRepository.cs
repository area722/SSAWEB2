using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models.DAL
{
    public class LineUpRepository
    {
        public static ObservableCollection<LineUp> getLineupsByStageAndDay(DateTime date)
        {
            String sql = "SELECT LineUp.ID,LineUp.Date,LineUp.EndTime,LineUp.StartTime,Stages.Name,Stages.ID AS StageID FROM LineUp INNER JOIN Stages ON LineUp.Stage=Stages.ID WHERE Date = @date ORDER BY CAST(LineUp.StartTime AS datetime) ASC";
            DbParameter par = Database.AddParameter("@date", date);
            DbDataReader reader = Database.GetData(sql, par);
            ObservableCollection<LineUp> lst = new ObservableCollection<LineUp>();
            while (reader.Read())
            {
                LineUp lineup = new LineUp()
                {
                    ID = (int)reader["ID"],
                    Date = Convert.ToDateTime(reader["Date"]),
                    Until = Convert.ToDateTime(reader["EndTime"]),
                    From = Convert.ToDateTime(reader["StartTime"]),
                };
                lineup.Stage = new Stage()
                {
                    ID = (int)reader["StageID"],
                    Name = (string)reader["Name"]
                };

                lst.Add(lineup);
            }

            ObservableCollection<LineUp> lst1 = new ObservableCollection<LineUp>();
            foreach (LineUp lu in lst)
            {
                string sql1 = "SELECT * FROM LineUpBand WHERE LineUpID = @luid";
                DbParameter par1 = Database.AddParameter("@luid", lu.ID);
                DbDataReader reader1 = Database.GetData(sql1, par1);
                while (reader1.Read())
                {
                    Band bnd = new Band() { ID = (int)reader1["BandID"] };
                    lu.Band = Band.GetBandByid(bnd);
                }
                lst1.Add(lu);
            }

            return lst1;
        }
    }
}