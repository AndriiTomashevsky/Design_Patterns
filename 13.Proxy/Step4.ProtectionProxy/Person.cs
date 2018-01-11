using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step4.ProtectionProxy
{
    class Person : IPerson
    {
        private string name;
        private string gender;
        private string interest;
        private int rating;
        private int ratingCount = 0;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public string Interest
        {
            get
            {
                return interest;
            }
            set
            {
                interest = value;
            }
        }

        public int HotOrNotRating
        {
            get
            {
                if (ratingCount == 0)
                {
                    return 0;
                }
                else
                {
                    return rating / ratingCount;
                }
            }
            set
            {
                rating += value;
                ratingCount++;
            }
        }
    }
}
