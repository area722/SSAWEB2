using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models.DAL
{
    public class TicketTypeRepository
    {
        public static ObservableCollection<TicketType> GetTypesTickets()
        {
            ObservableCollection<TicketType> lst = new ObservableCollection<TicketType>();
            string sql = "SELECT * FROM TicketTypes";
            DbDataReader reader = Database.GetData(sql);
            while (reader.Read())
            {
                TicketType type = new TicketType()
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = (string)reader["Type"],
                    Price = (double)reader["Price"],
                    AvailableTickets = (int)reader["Aantal"]
                };
                lst.Add(type);
            }
            return lst;
        }

        public static TicketType GetById(int id)
        {
            string sql = "SELECT * FROM TicketTypes WHERE ID=@id";
            DbParameter par = Database.AddParameter("@id", id);
            DbDataReader reader = Database.GetData(sql, par);
            TicketType type = new TicketType();
            while (reader.Read())
            {
                type = new TicketType()
                {
                    Id = (int)reader["ID"],
                    Name = (string)reader["Type"],
                    Price = (double)reader["Price"],
                    AvailableTickets = (int)reader["Aantal"]
                };
            }
            return type;
        }
    }
}