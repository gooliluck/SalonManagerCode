﻿using System;
using System.Windows.Media;
using SalonManager.Helpers;
using System.Windows.Input;
using System.Windows;

namespace SalonManager.Models
{
    public enum GENDER_TYPE
    {
        UNKNOWN = 0,
        MALE,
        FEMALE,
    }
    public class Person : BaseData
    {
        #region Ctor
        public Person():base(){}
        public Person(string name, GENDER_TYPE gender, string tel, DateTime birthDate)
            : base()
        {
            Name = name;
            GenderType = gender;
            Tel = tel;
            BirthDate = birthDate.ToShortDateString(); ;
        }
        #endregion

        #region Name
        public string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Gender
        public int gender = 0;
        public string GenderString
        {
            get 
            {
                if (GenderType == GENDER_TYPE.UNKNOWN)
                    return "未知";
                else if (GenderType == GENDER_TYPE.MALE)
                    return "男";
                else
                    return "女";
            }
        }
        public int GenderInt
        {
            get { return gender; }
            set { gender = value; }
        }
        public GENDER_TYPE GenderType
        {
            get { return (GENDER_TYPE)gender; }
            set { gender = (int)value; }
        }
        #endregion

        #region Tel
        public string tel = "";
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        #endregion

        #region BirthDate
        public DateTime birthDate = new DateTime();
        public string BirthDate
        {
            get { return birthDate.ToShortDateString(); }
            set { DateTime.TryParse(value, out birthDate); }
        }
  
        #endregion

        #region Age
        public int Age
        {
            get
            {
                DateTime nowTime = DateTime.Now;
                
                if (birthDate == null)
                    return 0;
                else
                {
                    //DateTime agebirthDate;
                    //DateTime.TryParse(birthDate, out agebirthDate);
                    int age = (nowTime - birthDate).Days / 365;
                    return age;
                }
            }
        }
        #endregion

        #region Comment
        public string comment = "";
        private string name1;
        private GENDER_TYPE gender1;
        private string tel1;
        private string birthDate1;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        #endregion

        //#region FavoriteColor
        //private SolidColorBrush _favoriteColor;
        //public SolidColorBrush FavoriteColor
        //{
        //    get { return _favoriteColor; }
        //    set
        //    {
        //        if (_favoriteColor != value)
        //        {
        //            _favoriteColor = value;
        //            RaisePropertyChanged(() => FavoriteColor);
        //        }
        //    }
        //}
        //#endregion

        public override bool checkData() 
        { 
            if(Name.Equals(""))
                return false;
            return base.checkData();
        }
    }
}
