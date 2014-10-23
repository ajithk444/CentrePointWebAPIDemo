using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAdminAPILib
{
    public interface IAPITestCase
    {
         Task<string> Run(string jsonRequest);
         string GetJsonRequestText();
    }
}
