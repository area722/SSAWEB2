using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models.DAL
{
    public class TicketRepository
    {
        public static ObservableCollection<Ticket> GetTickets()
        {
            string sql = "SELECT * FROM Tickets";
            DbDataReader reader = Database.GetData(sql);
            ObservableCollection<Ticket> lst = new ObservableCollection<Ticket>();
            while (reader.Read())
            {
                Ticket tick = new Ticket()
                {
                    Id = (int)reader["ID"],
                    Amount = (int)reader["Aantal"],
                    TicketHolder = (string)reader["Holder"],
                    TicketHolderEmail = (string)reader["HolderEmail"],
                    TicketType = TicketTypeRepository.GetById((int)reader["Type"]),
                    Reserved = (string)reader["Reserved"]
                };
                lst.Add(tick);
            }
            return lst;
        }

        public static ObservableCollection<Ticket> SearchTicket(String term)
        {
            ObservableCollection<Ticket> lst = new ObservableCollection<Ticket>();
            string sql = "SELECT * FROM Tickets WHERE HolderEmail LIKE @term OR Holder LIKE @term";
            DbParameter par1 = Database.AddParameter("@term", "%" + term + "%");
            DbDataReader reader = Database.GetData(sql, par1);
            while (reader.Read())
            {
                Ticket ticket = new Ticket()
                {
                    Id = (int)reader["ID"],
                    TicketHolder = (string)reader["Holder"],
                    TicketHolderEmail = (string)reader["HolderEmail"],
                    TicketType = TicketTypeRepository.GetById((int)reader["Type"]),
                    Amount = (int)reader["Aantal"],
                    Reserved = (string)reader["Reserved"]
                };
                lst.Add(ticket);
            }
            return lst;
        }

        public static ObservableCollection<Ticket> SearchType(TicketType type)
        {
            ObservableCollection<Ticket> lst = new ObservableCollection<Ticket>();
            string sql = "SELECT * FROM Tickets WHERE Type = @type";
            DbParameter par1 = Database.AddParameter("@type", type.Id);
            DbDataReader reader = Database.GetData(sql, par1);
            while (reader.Read())
            {
                Ticket ticket = new Ticket()
                {
                    Id = (int)reader["ID"],
                    TicketHolder = (string)reader["Holder"],
                    TicketHolderEmail = (string)reader["HolderEmail"],
                    TicketType = TicketTypeRepository.GetById((int)reader["Type"]),
                    Amount = (int)reader["Aantal"],
                    Reserved = (string)reader["Reserved"]
                };
                lst.Add(ticket);
            }
            return lst;
        }

        
    }
}