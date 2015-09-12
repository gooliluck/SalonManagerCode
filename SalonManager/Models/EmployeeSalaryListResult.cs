using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalonManager.Models
{
    class EmployeeSalaryListResult
    {
        public int line = 0;
        public int Line
        {
            get
            {
                return line;
            }
            set
            {
                line = value;
            }
        }
        private List<string> listname = new List<string>();
        public List<string> ListName
        {
            get
            {
                return listname;
            }
            set
            {
                listname = value;
            }
        }
    }
}
