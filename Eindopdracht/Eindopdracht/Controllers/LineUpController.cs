using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using Eindopdracht.Models;
using Eindopdracht.Models.DAL;

namespace Eindopdracht.Controllers
{
    public class LineUpController : Controller
    {
        //
        // GET: /LineUp/

        public ActionResult Index()
        {
            ObservableCollection<DateTime> lst = new ObservableCollection<DateTime>();
            Festival Fest = FestivalRepository.GetDates();
            lst.Add(Fest.StartDate);
            TimeSpan lenght = Fest.EndDate - Fest.StartDate;
            for (int i = 1; i < lenght.Days; i++)
            {
                lst.Add(Fest.StartDate.AddDays(i));
            }
            lst.Add(Fest.EndDate);

            return View("Index",lst);
        }
    }
}
