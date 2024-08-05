using NSubstitute;

namespace CandidateAssignment.Api.SmallTests.CustomerControllerTests
{
    [TestClass]
    public class Get : AssemblyTestBase
    {
        [TestMethod]
        public void Get_Should_Call_Repository_GetAsync()
        {
            Controller.Get();

            CustomerRepo.Received().GetAll();
        }
    }
}