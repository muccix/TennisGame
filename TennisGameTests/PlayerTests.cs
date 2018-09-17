using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Players name can not be empty, null or white spaces only")]

        public void Player_PLayerNameIsEmpty_ThrowExceptiopm()
        {
            var playerA = new Player("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Players name can not be empty, null or white spaces only")]

        public void Player_PLayerNameIsNull_ThrowExceptiopm()
        {
            var playerA = new Player(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Players name can not be empty, null or white spaces only")]

        public void Player_PLayerNameIsWhiteSplaces_ThrowExceptiopm()
        {
            var playerA = new Player("   ");
        }
    }
}