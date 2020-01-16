using BerlinClock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Services
{
    public interface IBerlinClockService
    {
        string GetBerlinClock(BerlinClockInputModel input);
    }
}
