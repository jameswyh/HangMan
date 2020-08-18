# HangMan
Author: Yihui Wang
## Project Description
Hangman, literally means "the hanged man", is a game of guessing words. The computer produces a word, and the player guesses every letter in the word. The computer extracts the letters of the word, leaving only a corresponding amount of blanks and underscores.

The computer draws a gallows, and when the player guesses a letter in the word, the computer fills in all the positions where the letter exists. If the letter guessed by the player is not in the word, the computer will add a stroke to the man on the gallows until after 7 strokes, the game ends.

This program uses an English vocabulary database (about 15,000 words), and uses technologies such as database connection and reading, file reading and writing, string manipulation, image manipulation, and DirectX quoting.

## Demo
1. Start interface, click the Start button to start the game
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/Picture1.png)
2. Game interface, the left side is the display interface, and the right side is the operation interface (all keys have a key tone)
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/Picture2.png)
3. After the game starts, the countdown starts for 30 seconds, the background music is played, and the player clicks the letters in the alphabet area to guess the word
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/Picture3.png)
4. If the letter is guessed incorrectly 7 times, the game ends, the playback fails the sound effect, the background music stops, the answer is announced, click the Restart button to restart
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/Picture4.png)
5. If the countdown is 0s, the game ends, the playback fails the sound effect, the background music stops, announce the answer, click the Restart button to restart
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/Picture5.png)
6. After guessing the word correctly, the score is +10, the sound effect is successful, the background music does not stop, and the Chinese explanation is displayed. Click the Continue button to continue the game
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/Picture6.png)
## Function button
![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/buttom1.png)：Randomly display a letter in a word as a reminder, and can only be used once per round

![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/buttom2.png)：Display the Chinese explanation of the word as a reminder

![](https://github.com/jameswyh/HangMan_Game/blob/master/DemoPic/buttom3.png)：Skip current word
