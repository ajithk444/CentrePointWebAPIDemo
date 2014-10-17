using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAdminAPILib
{
    public interface ITestCase
    {
         Boolean HasPassed();
         void Run(string json);
    }
}
