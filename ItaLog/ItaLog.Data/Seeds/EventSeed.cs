using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItaLog.Data.Seeds
{
    public class EventSeed
    {
        private readonly ItaLogContext _context;

        public EventSeed(ItaLogContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (_context.Events.Any())
                return;

            Event e1 = new Event {  Detail = "Client exceeded the maximum timeout value of 60 seconds", ErrorDate = DateTime.Parse("10-03-2019"), LogId = 1 };
            Event e2 = new Event {  Detail = "Maximum upload size of 25MB was exceeded", ErrorDate = DateTime.Parse("12-08-2019"), LogId = 2 };
            Event e3 = new Event {  Detail = "Maximum upload size of 25MB was exceededs", ErrorDate = DateTime.Parse("22-11-2019"), LogId = 2 };
            Event e4 = new Event {  Detail = "Maximum upload size of 25MB was exceeded", ErrorDate = DateTime.Parse("13-09-2019"), LogId = 2 };
            Event e5 = new Event {  Detail = "Client Disconnected due to flooding", ErrorDate = DateTime.Parse("09-06-2019"), LogId = 3 };
            Event e6 = new Event {  Detail = "Cache revalidation could not reach the origin server", ErrorDate = DateTime.Parse("03-04-2019"), LogId = 4 };
            Event e7 = new Event {  Detail = "Must be added by any intermediate application, such as a proxy", ErrorDate = DateTime.Parse("27-02-2019"), LogId = 5 };
            Event e8 = new Event {  Detail = "BreakPoints removed from the test code file: /Dev/RepTest07", ErrorDate = DateTime.Parse("19-08-2019"), LogId = 6 };

            _context.AddRange(e1, e2, e3, e4, e5, e6, e7, e8);
            _context.SaveChanges();

        }
    }
}






