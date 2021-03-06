﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Tests
{
    [TestClass]
    public class GameScoreManagerTests
    {
        [TestMethod]
        public void UpdateScore_PlayerMakesPoint_PlayerScoreIncrease()
        {
            var playerA = new Player("ROGER");
            var playerB = new Player("RAFA");
            var scoreManager = new GameScoreManager();

            scoreManager.UpdateScore(playerA, playerB, playerA.Name);
            Assert.AreEqual(Points.Fifteen, playerA.Score);

            scoreManager.UpdateScore(playerA, playerB, playerA.Name);
            Assert.AreEqual(Points.Thirty, playerA.Score);

            scoreManager.UpdateScore(playerA, playerB, playerA.Name);
            Assert.AreEqual(Points.Forty, playerA.Score);

            scoreManager.UpdateScore(playerA, playerB, playerB.Name);
            Assert.AreEqual(Points.Fifteen, playerB.Score);

            scoreManager.UpdateScore(playerA, playerB, playerB.Name);
            Assert.AreEqual(Points.Forty, playerA.Score);

            scoreManager.UpdateScore(playerA, playerB, playerB.Name);
            Assert.AreEqual(Points.Forty, playerB.Score);

            scoreManager.UpdateScore(playerA, playerB, playerA.Name);
            Assert.AreEqual(Points.Forty, playerB.Score);

            scoreManager.UpdateScore(playerA, playerB, playerB.Name);
            Assert.AreEqual(Points.Forty, playerB.Score);

            scoreManager.UpdateScore(playerA, playerB, playerB.Name);
            Assert.AreEqual(Points.Advantage, playerB.Score);

            scoreManager.UpdateScore(playerA, playerB, playerB.Name);
            Assert.AreEqual(Points.Game, playerB.Score);

            playerB.Score = Points.Forty;
            playerA.Score = Points.Advantage;
            scoreManager.UpdateScore(playerA, playerB, playerA.Name);
            Assert.AreEqual(Points.Game, playerA.Score);
        }

        [TestMethod]
        public void CheckGameWinner_PlayerMakesPoint_PlayersWinsTheGame()
        {
            var playerA = new Player("ROGER");
            var playerB = new Player("RAFA");
            var scoreManager = new GameScoreManager();

            playerA.Score = Points.Fifteen;
            playerB.Score = Points.Love;
            var winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Thirty;
            playerB.Score = Points.Love;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Forty;
            playerB.Score = Points.Love;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Love;
            playerB.Score = Points.Fifteen;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Love;
            playerB.Score = Points.Thirty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Love;
            playerB.Score = Points.Forty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Love;
            playerB.Score = Points.Love;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Fifteen;
            playerB.Score = Points.Fifteen;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Thirty;
            playerB.Score = Points.Thirty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Forty;
            playerB.Score = Points.Forty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Advantage;
            playerB.Score = Points.Forty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Forty;
            playerB.Score = Points.Advantage;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual("", winner);

            playerA.Score = Points.Game;
            playerB.Score = Points.Love;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerA.Name, winner);

            playerA.Score = Points.Game;
            playerB.Score = Points.Fifteen;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerA.Name, winner);

            playerA.Score = Points.Game;
            playerB.Score = Points.Thirty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerA.Name, winner);

            playerA.Score = Points.Game;
            playerB.Score = Points.Forty;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerA.Name, winner);

            playerA.Score = Points.Love;
            playerB.Score = Points.Game;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerB.Name, winner);

            playerA.Score = Points.Fifteen;
            playerB.Score = Points.Game;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerB.Name, winner);

            playerA.Score = Points.Thirty;
            playerB.Score = Points.Game;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerB.Name, winner);

            playerA.Score = Points.Forty;
            playerB.Score = Points.Game;
            winner = scoreManager.GetGameWinnerName(playerA, playerB);
            Assert.AreEqual(playerB.Name, winner);
        }
    }
}