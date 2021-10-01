using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotFightClub_Logic.Interfaces
{
    public interface IValidator
    {
        public bool WordItem(string str);

        public bool intItem(int num);

        public bool GuidItem(Guid guid);

        public bool DateItem(DateTime date);
    }
}
