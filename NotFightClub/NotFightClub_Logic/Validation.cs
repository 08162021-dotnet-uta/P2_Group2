using NotFightClub_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotFightClub_Logic
{
    public class Validation : IValidator
    {
       
        public bool DateItem(DateTime date)
        {
            DateTime thisday = DateTime.Today;
            //check if date == this.day  or difference of years is greater than 13 return true
            if (date.Equals(thisday) || (thisday.Year - date.Year)> 13) return true;
            else if((thisday.Year - date.Year) == 13)
            {
                //if date year == 13 check date month is past today month return true
                if (date.Month < thisday.Month) return true;
                else if (date.Month == thisday.Month)
                {
                    if (date.Day < thisday.Day) return true;
                    else if (date.Day == thisday.Day) return true;
                    //if date month == today month check that date day is past today return true
                    else return false;

                }
                else { return false; }

            }
            else { return false; }

        }

        public bool GuidItem(Guid guid)
        {
            throw new NotImplementedException();
        }

        public bool intItem(int num)
        {
            throw new NotImplementedException();
        }

        public bool WordItem(string str)
        {
            //check that password is not password
            if (str.Equals("password") || str.Equals("PASSWORD") || str.Equals("Password")) return false;
            //check that password is at least 6 char long
            else if (str.Length < 6) return false;
            else return true;
            
        }
    }
}
