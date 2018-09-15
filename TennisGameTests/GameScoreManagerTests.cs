using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Tests
{
    [TestClass()]
    public class GameScoreManagerTests
    {
        [TestMethod()]
        public void GameScoreManagerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateScore_PlayerMakesPoint_PlayerScoreIncrease()
        {
            var playerA = new Player(Players.PlayerA, "ROGER");
            var playerB = new Player(Players.PlayerB, "RAFA");
            var scoreManager = new GameScoreManager(playerA, playerB);

            scoreManager.UpdateScore(playerA.Id);
            Assert.AreEqual(Points.Fifteen, playerA.Score);
            Assert.AreEqual(Points.Love, playerB.Score);

            scoreManager.UpdateScore(playerA.Id);
            Assert.AreEqual(Points.Thirty, playerA.Score);
            Assert.AreEqual(Points.Love, playerB.Score);

            scoreManager.UpdateScore(playerA.Id);
            Assert.AreEqual(Points.Forty, playerA.Score);
            Assert.AreEqual(Points.Love, playerB.Score);


            scoreManager.UpdateScore(playerB.Id);
            Assert.AreEqual(Points.Forty, playerA.Score);
            Assert.AreEqual(Points.Fifteen, playerB.Score);

            scoreManager.UpdateScore(playerB.Id);
            Assert.AreEqual(Points.Forty, playerA.Score);
            Assert.AreEqual(playerB.Score, Points.Thirty);

            scoreManager.UpdateScore(playerB.Id);
            Assert.AreEqual(Points.Forty, playerA.Score);
            Assert.AreEqual(Points.Forty, playerB.Score);

            scoreManager.UpdateScore(playerA.Id);
            Assert.AreEqual(Points.Advantage, playerA.Score);
            Assert.AreEqual(Points.Forty, playerB.Score);

            scoreManager.UpdateScore(playerB.Id);
            Assert.AreEqual(Points.Forty, playerA.Score);
            Assert.AreEqual(Points.Forty, playerB.Score);

            scoreManager.UpdateScore(playerB.Id);
            Assert.AreEqual(Points.Forty, playerA.Score);
            Assert.AreEqual(Points.Advantage, playerB.Score);
        }

        [TestMethod()]
        public void CheckGameWinner_PlayerMakesPoint_PlayersWinsTheGame()
        {
            //var playerA = new Player(Players.PlayerA, "ROGER");
            //var playerB = new Player(Players.PlayerB, "RAFA");
            //var scoreManager = new GameScoreManager(playerA, playerB);

            //playerA.Score = Points.Fifteen;
            //playerB.Score = Points.Love;
            //var winner = scoreManager.CheckGameWinner(playerA.Id);
            //Assert.AreEqual(Players.None, winner);

            //playerA.Score = Points.Thirty;
            //playerB.Score = Points.Love;
            //winner = scoreManager.CheckGameWinner(playerA.Id);
            //Assert.AreEqual(Players.None, winner);

        }
    }
}