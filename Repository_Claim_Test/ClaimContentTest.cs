using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository_Komodo_Claims_Repository;

namespace Repository_Claim_Test
{
    //third to make, first in test,  #3 to write in
    [TestClass]
    public class ClaimContentTest
    {
        [TestMethod]
        public void SetClaimId_ShouldGetCorrectNumber()
        {
            ClaimContent content = new ClaimContent();

            content.ClaimId = 7;

            int expected = 7;
            int actual = content.ClaimId;

            Assert.AreEqual(expected, actual);
        }
    }
}
