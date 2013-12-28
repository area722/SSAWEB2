using Eindopdracht.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using Eindopdracht.Models;

namespace Eindopdracht.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Ticket/

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetTypes()
        {
            ObservableCollection<TicketType> lst = new ObservableCollection<TicketType>();
            lst = TicketTypeRepository.GetTypesTickets();
            return PartialView("GetTypes",lst);
        }
    }
}
