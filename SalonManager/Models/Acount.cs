using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalonManager.Models
{
    public class Acount : BaseData
    {
        #region Ctor
        public Acount():base(){}
        public Acount(string pwd)
            : base()
        {
            dbpassword = pwd;
        }
        #endregion

        #region Password
        public string dbpassword = "";
        public string DBpassword
        {
            get { return dbpassword; }
            set { dbpassword = value; }
        }
        #endregion
    }
}
