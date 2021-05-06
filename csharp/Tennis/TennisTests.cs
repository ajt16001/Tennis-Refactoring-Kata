  
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tennis
{
	public class TennisGameTest
	{
		private ITennisGame _sut;
		public static IEnumerable<TestCaseData> TieTestCases
        {
			get
			{
				yield return new TestCaseData(0, 0, "Love-All").SetDescription("Tie, 0-0");
				yield return new TestCaseData(1, 1, "Fifteen-All").SetDescription("Tie, 1-1");
				yield return new TestCaseData(2, 2, "Thirty-All").SetDescription("Tie, 2-2");
				yield return new TestCaseData(3, 3, "Deuce").SetDescription("Tie, 3-3");
				yield return new TestCaseData(4, 4, "Deuce").SetDescription("Tie, 4-4");
				
			}
        }

		public static IEnumerable<TestCaseData> WinTestCases
        {
            get
            {
				yield return new TestCaseData(4, 0, "Win for player1").SetDescription("Win 1");
				yield return new TestCaseData( 0,  4, "Win for player2").SetDescription("Win 2");
				yield return new TestCaseData(4, 1, "Win for player1").SetDescription("Win 1");
				yield return new TestCaseData(1, 4, "Win for player2").SetDescription("Win 2");
				yield return new TestCaseData(4, 2, "Win for player1").SetDescription("Win 1");
				yield return new TestCaseData(2, 4, "Win for player2").SetDescription("Win 2");
				yield return new TestCaseData(6, 4, "Win for player1").SetDescription("Win 1");
				yield return new TestCaseData(4, 6, "Win for player2").SetDescription("Win 2");
				yield return new TestCaseData(16, 14, "Win for player1").SetDescription("Win 1");
				yield return new TestCaseData(14, 16, "Win for player2").SetDescription("Win 2");
				
				
			}
        }

		public static IEnumerable<TestCaseData> AdvantageTestCases
        {
            get
            {
				yield return new TestCaseData(4, 3, "Advantage player1").SetDescription("Advantage 4-3");
				yield return new TestCaseData(3, 4, "Advantage player2").SetDescription("Advantage 3-4");
				yield return new TestCaseData(5, 4, "Advantage player1").SetDescription("Advantage 5-4");
				yield return new TestCaseData(4, 5, "Advantage player2").SetDescription("Advantage 4-5");
				yield return new TestCaseData(15, 14, "Advantage player1").SetDescription("Advantage 15-14");
				yield return new TestCaseData(14, 15, "Advantage player2").SetDescription("Advantage 14-15");
			}
        }
		
		public static IEnumerable<TestCaseData> OtherTestCases
        {
            get
            {
				yield return new TestCaseData(1, 0, "Fifteen-Love").SetDescription("Win 1");
				yield return new TestCaseData(0, 1, "Love-Fifteen").SetDescription("Win 1");
				yield return new TestCaseData(2, 0, "Thirty-Love").SetDescription("Win 1");
				yield return new TestCaseData(0, 2, "Love-Thirty").SetDescription("Win 1");
				yield return new TestCaseData(3, 0, "Forty-Love").SetDescription("Win 1");
				yield return new TestCaseData(0, 3, "Love-Forty").SetDescription("Win 1");
				yield return new TestCaseData(2, 1, "Thirty-Fifteen").SetDescription("Win 1");
				yield return new TestCaseData(1, 2, "Fifteen-Thirty").SetDescription("Win 1");
				yield return new TestCaseData(3, 1, "Forty-Fifteen").SetDescription("Win 1");
				yield return new TestCaseData(1, 3, "Fifteen-Forty").SetDescription("Win 1");
				yield return new TestCaseData(3, 2, "Forty-Thirty").SetDescription("Win 1");
				yield return new TestCaseData(2, 3, "Thirty-Forty").SetDescription("Win 1");
			}
        }

		[Test, TestCaseSource("TieTestCases")]
		[TestCaseSource("WinTestCases")]
		[TestCaseSource("AdvantageTestCases")]
		[TestCaseSource("OtherTestCases")]
		public void CheckTennisGame(int player1Score, int player2Score, string expectedScore)
		{
			var game = new TennisGame("player1", "player2");

			var highestScore = Math.Max(player1Score, player2Score);
			for (var i = 0; i < highestScore; i++)
			{
				if (i < player1Score)
					game.PointScored(game.PlayerOne);
				if (i < player2Score)
					game.PointScored(game.PlayerTwo);
			}
			Assert.AreEqual(expectedScore, game.GetGameScore());
		}

        [Test]
        public void CheckRealisticGame()
        {
            var game = new TennisGame("player1", "player2");

            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            string[] expectedScores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for player1" };

            for (var i = 0; i < 6; i++)
            {
				game.PointScored(points[i] == "player1" ? game.PlayerOne : game.PlayerTwo);
				Assert.AreEqual(expectedScores[i], game.GetGameScore());
            }
        }
    }
}
