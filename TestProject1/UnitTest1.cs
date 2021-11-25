using NUnit.Framework;
using Valtech_Task2_Ankh_Morpork_game_;

namespace TestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var some = new Vlad("Vlad");

            var result = some.IsVlad();

            Assert.That(result,Is.True);
        }
    }
}
