using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalonManager.Models
{
    public class MonthlyConsumption :BaseData
    {
        public MonthlyConsumption() : base() { }

        public int year = 0;
        public int month = 0;
        public int day = 0;
        public void setDate(int Year, int Month, int Day)
        {
            year = Year;
            month = Month;
            day = Day;
        }
        private string dataString = "";
        public string DateString
        {
            get
            {
                if (dataString.Equals("") && day != 0)
                {
                    DateTime datestr = new DateTime(year, month, day);
                    return datestr.ToString("yyyy/MM/dd");
                }
                else if(dataString.Equals("")&& day == 0)
                {
                    string monthint = month + "";
                    
                    string monthstr = monthint.PadLeft(2, '0');
                    return year+"/"+monthstr;
                }
                    
                return dataString;
            }
            set { dataString = value; }
        }

        public int isSpecifycount = 0;
        public int IsSpecifyCount
        {
            get { return isSpecifycount; }
            set { isSpecifycount = value; }
        }

        public int unSpecifycount = 0;
        public int UnSpecifyCount
        {
            get { return unSpecifycount; }
            set { unSpecifycount = value; }
        }
        
        public int servicedailytotal = 0;
        /**
         * 當月日期服務總業積
         */
        public int ServiceDailyTotal
        {
            get { return servicedailytotal; }
            set { servicedailytotal = value; }
        }

        public int goodsdailytotal = 0;
        /**
         * 當月日期產品總業積
         */
        public int GoodsDailyTotal
        {
            get { return goodsdailytotal; }
            set { goodsdailytotal = value; }
        }
        public int Day
        {
            get { return day; }
        }

        public int cost = 0;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int goodcost = 0;
        public int GoodCost
        {
            get { return goodcost; }
            set { goodcost = value; }
        }

    }
            
}
