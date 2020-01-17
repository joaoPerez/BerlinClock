using BerlinClock.Models;
using BerlinClock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IBerlinClockService berlinClockService = new BerlinClockService();

        public string convertTime(string aTime)
        {
            string[] timeSplit = aTime.Split(':');

            var berlinClockInputModel = new BerlinClockInputModel
            {
                hour = Convert.ToInt32(timeSplit[0]),
                minute = Convert.ToInt32(timeSplit[1]),
                second = Convert.ToInt32(timeSplit[2])
            };

            var clock = berlinClockService.GetBerlinClock(berlinClockInputModel);

            return clock;
        }
    }
}
