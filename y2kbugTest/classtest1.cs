using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace y2kbugTest
{
    [TestClass]
    public class classtest1
    {
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void gesDates_verifDates{
            
            using (ShimsContext.Create())
            
            { 
            ShimDateTime.NowGet=()=>new DateTime(2000,1,1);
                y2kbug.Check();
            }

        }
    
        
        
    }
}
