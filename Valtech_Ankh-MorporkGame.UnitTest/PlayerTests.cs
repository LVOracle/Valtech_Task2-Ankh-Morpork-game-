using System.ComponentModel;
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
    }
}
