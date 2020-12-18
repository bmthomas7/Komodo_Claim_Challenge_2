using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository_Komodo_Claims_Repository;

namespace Repository_Claim_Test
{
    [TestClass]
    public class ClaimRepositoryTest
    {
        private ClaimContentRepository _repo;
        private ClaimContent _content;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimContentRepository();
            _content = new ClaimContent(7, "car", "fender bender", new DateTime(1997 / 5 / 30), new DateTime(1997 / 6 / 10), 560.56, true);

            _repo.AddContentToQueue(_content);

        }

        [TestMethod]
        public void AddToQueue_ShouldNotGetNull()
        {
            ClaimContent content = new ClaimContent();
            content.ClaimId = 7;
            ClaimContentRepository repository = new ClaimContentRepository();

            repository.AddContentToQueue(content);
            ClaimContent contentFromDirectory = repository.GetContentByNumber(7);

            Assert.IsNotNull(contentFromDirectory);


        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            ClaimContent newContent = new ClaimContent(7, "car", "fender bender", new DateTime(1997 - 5 - 30), new DateTime(1997 - 6 - 10), 560.56, true);

            bool updateResult = _repo.UpdateExistingContent(1, newContent);

            Assert.IsTrue(updateResult);

        }

        [DataTestMethod]
        [DataRow(7, true)]
        [DataRow(11, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalNumber, bool shouldUpdate)
        {
            ClaimContent newContent = new ClaimContent(7, "car", "fender bender", new DateTime(1997/05/30), new DateTime(1997/06/10), 560.56, true);

            bool updateResult = _repo.UpdateExistingContent(originalNumber, newContent);

            Assert.AreEqual(shouldUpdate, updateResult);
        
        
        
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveContentFromQueue(_content.ClaimId);

            Assert.IsTrue(deleteResult);
        }


    }
}
