using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SalonManager.Models;
using SalonManager.Helpers;
using System.ComponentModel;
using SalonManager.ViewModels;
using System.Collections.ObjectModel;

namespace SalonManager.Views
{
    /// <summary>
    /// Interaction logic for EmployeeDetailWindow.xaml
    /// </summary>
    public partial class EmployeeDetailWindow : Window
    {
        List<EmployeeSalaryListResult> salaryview;
        public EmployeeDetailWindow()
        {
            InitializeComponent();
            
        }
        private void SetMonthlyResultView(Employee employee, DateTime date, List<DailyConsumption> list)
        {
            int days = DateTime.DaysInMonth(date.Year, date.Month);
            string employeeId = employee.DBID.ToString();
            List<EmployeeMonthlyResult> employeeMonth = new List<EmployeeMonthlyResult>();
            for (int month = 0; month < days; month++)
            {
                EmployeeMonthlyResult monthresult = new EmployeeMonthlyResult();
                monthresult.Year = date.Year;
                monthresult.Month = date.Month;
                monthresult.Day = month+1;
                employeeMonth.Add(monthresult);
            }
            foreach (DailyConsumption dailyConsumption in list)
            {
                int bonus = 0;
                int day = 0;
                int leftCost = dailyConsumption.Cost;
                string[] supportList = dailyConsumption.supporterId.Split(',');
                List<string> tempList = new List<string>(supportList);
                if (!tempList.Contains(employeeId) && !employeeId.Equals(dailyConsumption.employeeId))
                {
                    continue;
                }
                if (dailyConsumption.month.Equals(date.Month))
                {
                    for (int cn = 0; cn < employeeMonth.Count; cn++)
                    {
                        if (employeeMonth[cn].Day == dailyConsumption.day)
                        {
                            day = cn;
                        }
                    }
                    string[] goodsList = dailyConsumption.consumerGoodsId.Split(',');
                    foreach (string tempStr in goodsList)
                    {
                        string goodsId = tempStr;
                        string providerId = "";
                        int goodsPrice = 0;
                        int goodsBonus = 0;
                        string[] strs = tempStr.Split('-');
                        if (strs.Length >= 4)
                        {
                            goodsId = strs[0];
                            providerId = strs[1];
                            Int32.TryParse(strs[2], out goodsPrice);
                            Int32.TryParse(strs[3], out goodsBonus);
                        }
                        if (providerId.Equals(employeeId))
                        {
                            employeeMonth[day].ProductCommission += goodsBonus;
                        }
                        leftCost -= goodsPrice;
                    }

                    string[] serviceList = dailyConsumption.serviceId.Split(',');
                    foreach (string tempStr in serviceList)
                    {
                        string serviceId = tempStr;
                        string providerId = "";
                        int servicePrice = 0;
                        int servicBonus = 0;
                        string[] strs = tempStr.Split('-');
                        if (strs.Length >= 4)
                        {
                            serviceId = strs[0];
                            providerId = strs[1];
                            Int32.TryParse(strs[2], out servicePrice);
                            Int32.TryParse(strs[3], out servicBonus);
                        }
                        if (providerId.Equals(employeeId))
                        {
                            employeeMonth[day].ServiceCommission += servicBonus;
                        }
                        leftCost -= servicBonus;
                    }
                    if (employeeId.Equals(dailyConsumption.employeeId))
                    {
                        if (dailyConsumption.IsSpecify)
                        {
                            employeeMonth[day].Specify += 1;
                        }
                        else if (!dailyConsumption.IsSpecify)
                        {
                            employeeMonth[day].NotSpecify += 1;
                        }
                        
                        employeeMonth[day].Performance += dailyConsumption.Cost;
                        employeeMonth[day].ActualPerformance += leftCost;
                    }
                }
            }
            System.Console.WriteLine("day " + employeeMonth[1].Day);
            System.Console.WriteLine("actual performance " + employeeMonth[1].ActualPerformance);
            System.Console.WriteLine("product " + employeeMonth[1].ProductCommission);
            System.Console.WriteLine("service " + employeeMonth[1].ServiceCommission);
            
            for (int cn = 0; cn < employeeMonth.Count; cn++)
            {
                employeeMonth[cn].ActualPerformance = (int)(employeeMonth[cn].ActualPerformance * 0.9 * employee.Commission / 100) + employeeMonth[cn].ServiceCommission + employeeMonth[cn].ProductCommission;
            }
            ICollectionView monthlyView = CollectionViewSource.GetDefaultView(employeeMonth);

            this.MonthlyServicesGrid.ItemsSource = monthlyView;
        }
        private void SetYearlyResultView(Employee employee, DateTime date, List<DailyConsumption> list)
        {
            string employeeId = employee.DBID.ToString();
            List<EmployeeYearlyResult> employeeyear = new List<EmployeeYearlyResult>();
            for (int month = 1; month < 13; month++)
            {
                EmployeeYearlyResult monthresult = new EmployeeYearlyResult();
                monthresult.Year = date.Year;
                monthresult.Month = month;
                employeeyear.Add(monthresult);
            }
            foreach (DailyConsumption dailyConsumption in list)
            {
                int leftCost = dailyConsumption.Cost;
                int AllIncome = 0;
                int month = 0;
                string[] supportList = dailyConsumption.supporterId.Split(',');
                List<string> tempList = new List<string>(supportList);
                if (!tempList.Contains(employeeId) && !employeeId.Equals(dailyConsumption.employeeId))
                {
                    continue;
                }
                
                for(int cn = 0;cn < employeeyear.Count ; cn++)
                {
                    if (employeeyear[cn].Month == dailyConsumption.month)
                    {
                        month = cn;
                    }
                }
                string[] goodsList = dailyConsumption.consumerGoodsId.Split(',');
                foreach (string tempStr in goodsList)
                {
                    string goodsId = tempStr;
                    string providerId = "";
                    int goodsPrice = 0;
                    int goodsBonus = 0;
                    string[] strs = tempStr.Split('-');
                    if (strs.Length >= 4)
                    {
                        goodsId = strs[0];
                        providerId = strs[1];
                        Int32.TryParse(strs[2], out goodsPrice);
                        Int32.TryParse(strs[3], out goodsBonus);
                    }
                    if (providerId.Equals(employeeId))
                    {
                        employeeyear[month].ProductCommission += goodsBonus;
                    }
                    leftCost -= (goodsBonus + goodsPrice);
                }

                string[] serviceList = dailyConsumption.serviceId.Split(',');
                foreach (string tempStr in serviceList)
                {
                    string serviceId = tempStr;
                    string providerId = "";
                    int servicePrice = 0;
                    int servicBonus = 0;
                    string[] strs = tempStr.Split('-');
                    if (strs.Length >= 4)
                    {
                        serviceId = strs[0];
                        providerId = strs[1];
                        Int32.TryParse(strs[2], out servicePrice);
                        Int32.TryParse(strs[3], out servicBonus);
                    }
                    if (providerId.Equals(employeeId))
                    {
                        employeeyear[month].ServiceCommission += servicBonus;
                    }
                    leftCost -= servicBonus;
                }
                if (employeeId.Equals(dailyConsumption.employeeId))
                {
                    if (dailyConsumption.IsSpecify)
                    {
                        employeeyear[month].Specify += 1;
                    }
                    else if (!dailyConsumption.IsSpecify)
                    {
                        employeeyear[month].NotSpecify += 1;
                    }
                    employeeyear[month].Performance += dailyConsumption.Cost;
                    employeeyear[month].ActualPerformance += leftCost;
                }
            }
            for (int cn = 0; cn < employeeyear.Count; cn++)
            {
                employeeyear[cn].ActualPerformance = (int)(employeeyear[cn].ActualPerformance * 0.9 * employee.Commission / 100) + employeeyear[cn].ServiceCommission + employeeyear[cn].ProductCommission;
            }

            ICollectionView yearlyView = CollectionViewSource.GetDefaultView(employeeyear);
            this.YearlyServicesGrid.ItemsSource = yearlyView;


        }
        public void setData(Employee data,List<DailyConsumption> list)
        {
            DateTime date = MainWindowViewModel.ins().ChooseDate;
            List<DailyConsumption> monthlyList = new List<DailyConsumption>();
            Dictionary<string, ServiceResult> serviceResultDic = new Dictionary<string, ServiceResult>();
            List<ServiceResult> serviceResultList = new List<ServiceResult>();
            double totalBonus = 0;
            string employeeId = data.DBID.ToString();
            SetYearlyResultView(data, date, list);
            SetMonthlyResultView(data, date, list);
            ServiceResult specifyService = new ServiceResult();
            specifyService.ServiceId = "specify";
            specifyService.ServiceName = "指定設計";
            serviceResultDic.Add(specifyService.ServiceId, specifyService);
            ServiceResult notspecifyService = new ServiceResult();
            notspecifyService.ServiceId = "notspecify";
            notspecifyService.ServiceName = "非指定設計";
            serviceResultDic.Add(notspecifyService.ServiceId, notspecifyService);
            ObservableCollection<Service> serviceCollection = MainWindowViewModel.ins().ServiceCollection;
            foreach (Service service in serviceCollection)
            {
                ServiceResult sr = new ServiceResult();
                sr.ServiceId = service.DBID.ToString();
                sr.ServiceName = service.Name;
                serviceResultDic.Add(sr.ServiceId, sr);
            }

            foreach (DailyConsumption dailyConsumption in list)
            {
                double bonus = 0.0f;
                string[] supportList = dailyConsumption.supporterId.Split(',');
                List<string> tempList = new List<string>(supportList);
                if (!tempList.Contains(employeeId) && !employeeId.Equals(dailyConsumption.employeeId))
                {
                    continue;
                }
                if (dailyConsumption.month.Equals(date.Month))
                {
                    int leftCost = dailyConsumption.Cost;
                    string[] goodsList = dailyConsumption.consumerGoodsId.Split(',');
                    foreach (string tempStr in goodsList)
                    {
                        string goodsId = tempStr;
                        string providerId = "";
                        int goodsPrice = 0;
                        int goodsBonus = 0;
                        string[] strs = tempStr.Split('-');
                        if (strs.Length >= 4)
                        {
                            goodsId = strs[0];
                            providerId = strs[1];
                            Int32.TryParse(strs[2], out goodsPrice);
                            Int32.TryParse(strs[3], out goodsBonus);
                        }
                        if (providerId.Equals(employeeId))
                        {
                            bonus += goodsBonus;
                        }
                        leftCost -= goodsPrice;
                    }

                    string[] serviceList = dailyConsumption.serviceId.Split(',');
                    foreach (string tempStr in serviceList)
                    {
                        string serviceId = tempStr;
                        string providerId = "";
                        int servicePrice = 0;
                        int servicBonus = 0;
                        string[] strs = tempStr.Split('-');
                        if (strs.Length >= 4)
                        {
                            serviceId = strs[0];
                            providerId = strs[1];
                            Int32.TryParse(strs[2], out servicePrice);
                            Int32.TryParse(strs[3], out servicBonus);
                        }
                        if (employeeId.Equals(dailyConsumption.employeeId))
                        {
                            if (serviceResultDic.ContainsKey(serviceId))
                            {
                                serviceResultDic[serviceId].DesignerMonthly += 1;
                                serviceResultDic[serviceId].DesignerYearly += 1;
                            }
                        }
                        if (providerId.Equals(employeeId))
                        {
                            
                            bonus += servicBonus;
                            if(serviceResultDic.ContainsKey(serviceId)){
                                serviceResultDic[serviceId].MonthlyNumber += 1;
                                serviceResultDic[serviceId].YearlyNumber += 1;
                            }     
                        }
                        leftCost -= servicBonus;
                    }
                    if (employeeId.Equals(dailyConsumption.employeeId))
                    {
                        if (dailyConsumption.IsSpecify && serviceResultDic.ContainsKey("specify"))
                        {
                            serviceResultDic["specify"].DesignerMonthly += 1;
                            serviceResultDic["specify"].DesignerYearly += 1;
                        }
                        else if (!dailyConsumption.IsSpecify && serviceResultDic.ContainsKey("notspecify"))
                        {
                            serviceResultDic["notspecify"].DesignerMonthly += 1;
                            serviceResultDic["notspecify"].DesignerYearly += 1;
                        }
                        
                        if(leftCost > 0)
                            bonus += leftCost * data.Commission / 100 * 0.9;
                    }
                    totalBonus += bonus;
                    dailyConsumption.EmployeeBonus = (int)bonus;
                    monthlyList.Add(dailyConsumption);
                }
                else {
                    string[] serviceList = dailyConsumption.serviceId.Split(',');
                    foreach (string tempStr in serviceList)
                    {
                        string serviceId = tempStr;
                        string providerId = "";
                        string[] strs = tempStr.Split('-');
                        if (strs.Length >= 4)
                        {
                            serviceId = strs[0];
                            providerId = strs[1];
                        }
                        if (employeeId.Equals(dailyConsumption.employeeId))
                        {
                            if (serviceResultDic.ContainsKey(serviceId))
                            {
                                serviceResultDic[serviceId].DesignerYearly += 1;
                            }
                        }
                        if (providerId.Equals(employeeId))
                        {
                            if (serviceResultDic.ContainsKey(serviceId))
                            {
                                serviceResultDic[serviceId].YearlyNumber += 1;
                            }
                        }
                    }
                    if (employeeId.Equals(dailyConsumption.employeeId))//設計師
                    {
                        if (dailyConsumption.IsSpecify && serviceResultDic.ContainsKey("specify"))
                        {
                            serviceResultDic["specify"].DesignerYearly += 1;
                        }
                        else if (!dailyConsumption.IsSpecify && serviceResultDic.ContainsKey("notspecify"))
                        {
                            serviceResultDic["notspecify"].DesignerYearly += 1;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, ServiceResult> pair in serviceResultDic) {
                serviceResultList.Add(pair.Value);
            }

            ICollectionView monthlyView = CollectionViewSource.GetDefaultView(monthlyList);
            ICollectionView resultsView = CollectionViewSource.GetDefaultView(serviceResultList);
            
            this.ResultsGrid.ItemsSource = monthlyView;
            this.ServicesGrid.ItemsSource = resultsView;
            this.EmployeeName.Text = data.Name;
            this.CaculateText.Text = data.BasicSalary + " + " + (int)totalBonus + " = ";
            this.TotalSalaryText.Text = (data.BasicSalary + (int)totalBonus).ToString();

            SetSalaryView(data, (int)totalBonus);
            ICollectionView Salarylistview = CollectionViewSource.GetDefaultView(salaryview);
            this.SalaryListGrid.ItemsSource = Salarylistview;
        }
        
        private void SetSalaryView(Employee data,int totalBonus)
        {
            salaryview = new List<EmployeeSalaryListResult>();
            EmployeeSalaryListResult employeeline1 = new EmployeeSalaryListResult();
            employeeline1.Line = 0;
            List<string> employeelist1 = new List<string>();
            employeelist1.Add(data.Name);
            employeelist1.Add("業績薪資");
            employeelist1.Add("獎金");
            employeelist1.Add("");
            employeelist1.Add("");
            employeelist1.Add("");
            employeelist1.Add("");
            employeelist1.Add("");
            employeeline1.ListName = employeelist1;
            salaryview.Add(employeeline1);
            EmployeeSalaryListResult employeeline2 = new EmployeeSalaryListResult();
            employeeline2.Line = 1;
            List<string> employeelist2 = new List<string>();
            employeelist2.Add("+");
            employeelist2.Add((data.BasicSalary + totalBonus).ToString());
            employeelist2 = addempty(employeelist2, 6);
            employeeline2.ListName = employeelist2;
            salaryview.Add(employeeline2);
            EmployeeSalaryListResult employeeline3 = new EmployeeSalaryListResult();
            employeeline3.Line = 2;
            List<string> employeelist3 = new List<string>();
            employeelist3.Add("");
            employeelist3.Add("遲到");
            employeelist3.Add("請假");
            employeelist3 = addempty(employeelist3, 5);
            employeeline3.ListName = employeelist3;
            salaryview.Add(employeeline3);
            EmployeeSalaryListResult employeeline4 = new EmployeeSalaryListResult();
            employeeline4.Line = 3;
            List<string> employeelist4 = new List<string>();
            employeelist4.Add("-");
            employeelist4.Add("");
            employeelist4 = addempty(employeelist4, 6);
            employeeline4.ListName = employeelist4;
            salaryview.Add(employeeline4);
        }
        private List<string> addempty(List<string> list,int count)
        {
            for (int cn = 0; cn < count; cn++)
            {
                list.Add("");
            }
            return list;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Printer.print(ResultsGrid);
        }

        private void PrintServicesButton_Click(object sender, RoutedEventArgs e)
        {
            Printer.print(ServicesGrid);
        }

        private void RecountButton_Click(object sender, RoutedEventArgs e)
        {
            CountSalary();
            ICollectionView Salarylistview = CollectionViewSource.GetDefaultView(salaryview);
            this.SalaryListGrid.ItemsSource = null;
            this.SalaryListGrid.ItemsSource = Salarylistview;
        }
        private void CountSalary()
        {
            int addition = 0;
            int subtion = 0;
            int addtionline = 1;
            int subline = 3;
            for (int cn = 0; cn < 8; cn++)
            {
                string add = salaryview[addtionline].ListName[cn];
                int thisadd = 0;
                if (Int32.TryParse(add, out thisadd))
                {
                    addition += thisadd;
                }
            }
            for (int cn = 0; cn < 7; cn++)
            {
                string sub = salaryview[subline].ListName[cn];
                int thissub = 0;
                if (Int32.TryParse(sub, out thissub))
                {
                    subtion -= thissub;
                }
            }
            salaryview[subline].ListName[7] = (addition + subtion).ToString();

        }
    }
}
