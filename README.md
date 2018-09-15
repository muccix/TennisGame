# Tennis Game

A simple C# console application, where two tennis players try to win a game

The rules are:

- A game is won by the first player to have won at least four points in total and at least two points more than the opponent.
- The running score of each game is described in a manner peculiar to tennis: scores from zero to three points are described as "Love", "Fifteen", "Thirty", and "Forty" respectively.
- If at least three points have been scored by each player, and the scores are equal, the score is "Deuce".
- If at least three points have been scored by each side and a player has one more point than his opponent, the score of the game is "Advantage" for the player in the lead.

You need only report the score for the current game. Sets and Matches are out of scope.

## NOTES:

The application was developed trying to follow some SOLID principles such as Single Responsibility and Open/Closed to make it testable and extensible.

Some Interfaces were used to allow dependency injection:

- IPointResultEngine: at the moment the implementation gives the point to a player randomly; it will be possible to add a new point result algorithm;
- IGameScoreManager: in some tournament when the score is at deuce (40-40), the next player to win a point will also win the game. We may want to extend the application with this rule;
- IUserInterface: the application can be extended with a different UI than console.