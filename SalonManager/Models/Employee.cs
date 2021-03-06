﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalonManager.Views;
using System.Windows.Input;
using SalonManager.ViewModels;
using SalonManager.Helpers;

namespace SalonManager.Models
{
    public class Employee : Person
    {
        public Employee():base(){}
        public Employee(string name, GENDER_TYPE gender, string tel, string post, int basicSalary, int commission, DateTime birthdate)
            : base(name, gender, tel, birthdate)
        {
            Post = post;
            BasicSalary = basicSalary;
            Commission = commission;
        }

        #region Post
        public string post = "";
        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        #endregion

        #region Salary
        public int basicSalary = 0;
        public int BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }
        public int monthlyBonus = 0;
        public int salary = 0;
        public int Salary
        {
            get { return basicSalary + monthlyBonus; }
        }

        private int startSalary = 0;
        public int StartSalary
        {
            get { return startSalary; }
            set { startSalary = value; }
        }

        private int payedSalary = 0;
        public int PayedSalary
        {
            get { return payedSalary; }
            set { payedSalary = value; }
        }
        #endregion

        #region Commission
        public int commission = 0;
        public int Commission
        {
            get { return commission; }
            set { commission = value; }
        }
        public string CommissionString
        {
            get
            {
                return string.Format("{0} %", Commission);
            }
        }
        #endregion

        public override bool checkData()
        {
            //if (BasicSalary == 0)
            //    return false;
            return base.checkData();
        }
        public ICommand SalaryDetailCommand { get { return new DelegateCommand(OnSalaryDetailCommand); } }
        private void OnSalaryDetailCommand()
        {
            EmployeeDetailWindow window = new EmployeeDetailWindow();
            Dictionary<string,string> filter = new Dictionary<string,string>();
            DateTime date = MainWindowViewModel.ins().ChooseDate;
            filter.Add("year",date.Year.ToString());
            //filter.Add("month",date.Month.ToString());
            //filter.Add("employeeId", this.DBID.ToString());
            List<DailyConsumption> resultsList = DBConnection.ins().queryData<DailyConsumption>(filter);

            window.setData(this, resultsList);
            window.ShowDialog();
        }
    }

    
}
