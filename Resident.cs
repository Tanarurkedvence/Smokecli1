using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Smokecli1
{
    internal class Resident
    {
        static int residents = 1;
        public Resident(string l)
        {
            var r = l.Split(";");

            Age = int.Parse(r[0]);
            AmtWeekdays = r[1] == "NA" ? 0 : int.Parse(r[1]);
            AmtWeekends = r[2] == "NA" ? 0 : int.Parse(r[2]);

            Ethnicity = new Ethnicity()
            {
                EthnicityID = int.Parse(r[3]),
                EthnicityName = r[4]
            };
            Gender = r[5];
            GrossIncome = r[6];
            MaritalStatus = r[7];
            Nationality = new Nationality()
            {
                NationalityID = int.Parse(r[8]),
                NationalityName = r[9]
            };
            Qualification = r[10];
            Region = r[11];
            ResidentId = residents++;
            Smoke = r[12];
            Type = r[13];
        }

        public int Age { get; set; }
        public int AmtWeekdays { get; set; }
        public int AmtWeekends { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public  string Gender { get; set; }
        public string GrossIncome { get; set; }
        public string MaritalStatus { get; set; }
        public Nationality Nationality { get; set; }
        public string Qualification { get; set; }
        public string Region { get; set; }
        public int ResidentId { get; set; }
        public string Smoke { get; set; }
        public string? Type { get; set; }


        public double avg(int AmtWeekdays, int AmtWeekends)
        {
            if (AmtWeekdays != 0 || AmtWeekends != 0)
            {
                return Math.Round(((double)AmtWeekdays * 5 + AmtWeekends * 2) / 7, 2);
                 
            }
            else
            {
                return double.NaN;
            }
            

        }


        public override string ToString()
        {
            return $"Resident ID: {ResidentId}\n" +
                   $"\tAge: {Age}\n" +
                   $"\tAmtWeekdays: {(AmtWeekdays == 0 ? "NA" : AmtWeekdays.ToString())}\n" +
                   $"\tAmtWeekends: {(AmtWeekends == 0 ? "NA" : AmtWeekends.ToString())}\n" +
                   $"\tEthnicity: {Ethnicity.EthnicityName}\n" +
                   $"\tGender: {Gender}\n" +
                   $"\tGross Income: {GrossIncome}\n" +
                   $"\tMarital Status: {MaritalStatus}\n" +
                   $"\tNationality: {Nationality.NationalityName}\n" +
                   $"\tQualification: {Qualification}\n" +
                   $"\tRegion: {Region}\n" +
                   $"\tSmoke: {Smoke}\n" +
                   $"\tType: {Type}\n" +
                   $"\tAverage: {avg(AmtWeekdays, AmtWeekends)}";
            


        }

    }
}
