﻿using System.Text;

namespace StringGenerator.Benchmark
{
    public static class ToShamsi
    {
        /// <summary>
        /// Get Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string OldToShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShamsiYearToString(dateTime) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime) + "/" + persianDateShamsi.GetShamsiDayString(dateTime);
        }
        /// <summary>
        /// Get Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string NewToShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            var sb = new StringBuilder();
            sb.Append(persianDateShamsi.GetShamsiYearToString(dateTime));
            sb.Append('/');
            sb.Append(persianDateShamsi.GetShamsiMonthString(dateTime));
            sb.Append('/');
            sb.Append(persianDateShamsi.GetShamsiDayString(dateTime));

            return sb.ToString();
        }

        /// <summary>
        /// Get Short Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string ToShortShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShortShamsiYear(dateTime) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime) + "/" + persianDateShamsi.GetShamsiDayString(dateTime);
        }
        /// <summary>
        /// Get Long Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string ToLongShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShamsiDayName(dateTime) + " " + persianDateShamsi.GetShamsiDay(dateTime) + " " + persianDateShamsi.GetShamsiMonthName(dateTime) + " " + persianDateShamsi.GetShamsiYear(dateTime);
        }
    }
}