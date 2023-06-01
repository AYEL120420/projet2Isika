using System;

namespace _001JIMCV.Models.Classes
{
    public class DateAndTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

        public DateAndTime()
        {
            // Constructeur par défaut sans paramètres
        }

        public DateAndTime(DateTime date, string time)
        {
            Date = date;
            Time = time;
        }

        public static implicit operator DateAndTime(Microsoft.VisualBasic.DateAndTime v)
        {
            throw new NotImplementedException();
        }
    }
}