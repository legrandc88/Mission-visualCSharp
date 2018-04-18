using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Fakes;//D'où vient System.Fakes?
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
            //jour 21 pour tester le repérage de la campagne de remboursement
            System.Fakes.ShimDateTime.NowGet= () => {return new DateTime(2018,4,21);
              
            PPE_GSB_MISSION.GesDates.verifDates();//pour signaler la méthode concernée
            }

        }
    
        
        
    }
}
