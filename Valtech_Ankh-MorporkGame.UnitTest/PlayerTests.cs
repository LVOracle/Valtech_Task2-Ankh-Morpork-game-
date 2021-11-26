using Microsoft.VisualStudio.TestTools.UnitTesting;
using Valtech_Task2_Ankh_Morpork_game_;

namespace Valtech_Ankh_MorporkGame.UnitTest
{
    [TestClass]
    public class PlayerTests
    {
        public Player player;
        [TestInitialize]
        public void SetUp()
        {
            player = new Player("Vlad");
        }

        [TestMethod]
        public void CheckMoneyBalance_IfMoneyLessOrEqualThanZero_ReturnFalse()
        {
            player.Money = -100;

            var result = player.CheckMoneyBalance();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckMoneyBalance_IfMoneyMoreThanZero_ReturnTrue()
        {
            player.Money = 100;

            var result = player.CheckMoneyBalance();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMoney_WhenSumIsCount_ReturnTrue()
        {
            player.GetMoney(10);

            Assert.AreEqual(player.Money,110);
        }

        [TestMethod]
        public void GetMoney_WhenSumIsCount_ReturnFalse()
        {
            player.LooseMoney(10);

            Assert.AreNotEqual(player.Money, 110);
        }

        [TestMethod]
        public void LooseMoney_WhenSumIsCount_ReturnTrue()
        {
            player.LooseMoney(10);

            Assert.AreEqual(player.Money, 90);
        }

        [TestMethod]
        public void LooseMoney_WhenSumIsCount_ReturnFalse()
        {
            player.GetMoney(10);

            Assert.AreNotEqual(player.Money, 90);
        }
    }
}
