using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eindopdracht.Models
{
    public class Ticket
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _ticketHolder;

        public String TicketHolder
        {
            get { return _ticketHolder; }
            set { _ticketHolder = value; }
        }

        private String _ticketHolderEmail;

        public String TicketHolderEmail
        {
            get { return _ticketHolderEmail; }
            set { _ticketHolderEmail = value; }
        }

        private TicketType _ticketType;

        public TicketType TicketType
        {
            get { return _ticketType; }
            set { _ticketType = value; }
        }

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private String _reserved;

        public String Reserved
        {
            get { return _reserved; }
            set { _reserved = value; }
        }


       
    }
}