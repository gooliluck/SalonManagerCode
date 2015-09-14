using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalonManager.Models
{
    class EmployeeYearlyResult
    {
        public string DateString
        {
            get 
            {
                if (month < 10)
                {
                    return Year + "/0" + Month;
                }else
                    return Year + "/" + Month; 
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
