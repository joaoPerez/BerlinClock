using BerlinClock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Services
{
    public class BerlinClockService : IBerlinClockService
    {
        public string GetBerlinClock(BerlinClockInputModel input)
        {
            // Hours
            var hourDictionary = GetLampState(input.hour);
            int firstRowQuant = hourDictionary["first"];
            int secondRowQuant = hourDictionary["second"];

            // Minutes
            var minDictionary = GetLampState(input.minute);
            int thirdRowQuant = minDictionary["first"];
            int fourthRowQuant = minDictionary["second"];

            // Lamps symbols
            string second = GetSecLampState(input.second).ToString();
            string firstRow = RowConverter(firstRowQuant, 4, LampEnum.Red);
            string secondRow = RowConverter(secondRowQuant, 4, LampEnum.Red);
            string thirdRow = RowConverter(thirdRowQuant, 11, LampEnum.Yellow, LampEnum.Red);
            string fourthRow = RowConverter(fourthRowQuant, 4, LampEnum.Yellow);

            BerlinClockModel berlinClock = new BerlinClockModel
            {
                second = second,
                firstRow = firstRow,
                secondRow = secondRow,
                thirdRow = thirdRow,
                fourthRow = fourthRow
            };

            return ConcatClockCode(berlinClock);
        }

        private string ConcatClockCode(BerlinClockModel berlinClock)
        {
            var second = berlinClock.second;
            var firstRow = berlinClock.firstRow;
            var secondRow = berlinClock.secondRow;
            var thirdRow = berlinClock.thirdRow;
            var fourthRow = berlinClock.fourthRow;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(second);
            stringBuilder.AppendLine(firstRow);
            stringBuilder.AppendLine(secondRow);
            stringBuilder.AppendLine(thirdRow);
            stringBuilder.Append(fourthRow);

            return stringBuilder.ToString();
        }

        private string RowConverter(int quant, int total, LampEnum color, LampEnum color2 = LampEnum.Any)
        {
            char colorOff = (char)LampEnum.Any;
            char colorOn = (char)color;
            char colorOn2 = (char)color2;

            var array = Enumerable.Repeat(colorOff, total).ToArray();

            for (int i = 1; i <= quant; i++)
            {
                if (!color2.Equals(LampEnum.Any) && (i * 5) % 15 == 0)
                {
                    array[i - 1] = colorOn2;
                }
                else
                {
                    array[i - 1] = colorOn;
                }
            }

            return new string(array);
        }

        private Dictionary<string, int> GetLampState(int time)
        {
            int remainder = time % 5;
            int tInt = time - remainder; // Time without remainder.

            // Quant of lamps.
            int firstRowQuant = tInt > 0 ? tInt / 5 : 0;
            int secondRowQuant = remainder;

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                { "first", firstRowQuant },
                { "second", secondRowQuant }
            };

            return dictionary;
        }

        private char GetSecLampState(int time)
        {
            LampEnum color = time % 2 == 0 ? LampEnum.Yellow : LampEnum.Any;

            return (char)color;
        }
    }
}
