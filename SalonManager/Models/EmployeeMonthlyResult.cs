﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalonManager.Models
{
    class EmployeeMonthlyResult
    {
        public string DateString
        {
            get
            {
                string monthstr = "" + Month;
                string daystr = ""+Day;
                if (month < 10)
                    monthstr = "0"+Month;
                if (Day < 10)
                    daystr = "0" + Day;

                return Year + "/" + monthstr + "/" + daystr;
            }
        }
        private int year = 0;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private int month = 0;
        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        private int day = 0;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        private int specify = 0;
        public int Specify
        {
            get { return specify; }
            set { specify = value; }
        }
        private int notspecify = 0;
        public int NotSpecify
        {
            get { return notspecify; }
            set { notspecify = value; }
        }
        private int servicecommission = 0;
        public int ServiceCommission
        {
            get { return servicecommission; }
            set { servicecommission = value; }
        }
        private int productcommission = 0;
        public int ProductCommission
        {
            get { return productcommission; }
            set { productcommission = value; }
        }
        private int performance = 0;
        public int Performance
        {
            get { return performance; }
            set { performance = value; }
        }
        private int actualperformance = 0;
        public int ActualPerformance
        {
            get { return actualperformance; }
            set { actualperformance = value; }
        }
    }
}
