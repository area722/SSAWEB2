using DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models.DAL
{
    public class UserRepository
    {
        public static string GetFisrstName(string name)
        {
            string sql = "SELECT * FROM UserProfile WHERE UserName = @id";
            DbParameter par = Database.AddParameter("@id",name);
            DbDataReader reader = Database.GetData(sql,par);
            reader.Read();
            return (string)reader["FirstName"];
        }
    }
}