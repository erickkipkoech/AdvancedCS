using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
     class Students
    {
        public string name;
        public string course;
        public double gpa;

        public Students(string aName,string aCourse,double aGpa) 
        {
            name = aName;
            course = aCourse;
            gpa = aGpa;
        }
        public bool HasHonors() 
        {
            switch(gpa)
            {
                case >3.5:
                    return true;
                break;
                default: return false;
                break;
            }
            
        }
    }
}
