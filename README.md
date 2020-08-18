# HangMan 
## Project Description
Hangman, literally means "the hanged man", is a game of guessing words. The computer produces a word, and the player guesses every letter in the word. The computer extracts the letters of the word, leaving only a corresponding amount of blanks and underscores.

The computer draws a gallows, and when the player guesses a letter in the word, the computer fills in all the positions where the letter exists. If the letter guessed by the player is not in the word, the computer will add a stroke to the man on the gallows until after 7 strokes, the game ends.

This program uses an English vocabulary database (about 15,000 words), and uses technologies such as database connection and reading, file reading and writing, string manipulation, image manipulation, and DirectX quoting.

## Demo
1. Start interface, click the Start button to start the game
![pic1](blob:https://stackedit.io/33a6a9a3-f7a6-41e6-9d4b-00adf0e31650)
2. Game interface, the left side is the display interface, and the right side is the operation interface (all keys have a key tone)
![](blob:https://stackedit.io/23a24673-4adf-4325-b72f-02766a8d7fd3)
3. After the game starts, the countdown starts for 30 seconds, the background music is played, and the player clicks the letters in the alphabet area to guess the word
![](blob:https://stackedit.io/c2c28f5c-87f0-4898-b061-69343c4a7d53)
4. If the letter is guessed incorrectly 7 times, the game ends, the playback fails the sound effect, the background music stops, the answer is announced, click the Restart button to restart
![](blob:https://stackedit.io/16412be6-717e-4b9a-aee5-910fc6e70d40)
5. If the countdown is 0s, the game ends, the playback fails the sound effect, the background music stops, announce the answer, click the Restart button to restart
![](blob:https://stackedit.io/db0648e7-6cc3-49d0-beb2-33af7188d35e)
6. After guessing the word correctly, the score is +10, the sound effect is successful, the background music does not stop, and the Chinese explanation is displayed. Click the Continue button to continue the game
![](blob:https://stackedit.io/db785afd-c7f5-47a6-8ac4-d626e50eb23a)
## Function button
![](blob:https://stackedit.io/4e48b0b2-38fa-4ed9-bd96-942b353d72da)：Randomly display a letter in a word as a reminder, and can only be used once per round

![](blob:https://stackedit.io/4455c931-8238-4da5-9d45-45787a887d3b)：Display the Chinese explanation of the word as a reminder

![](blob:https://stackedit.io/a4999909-986a-4f61-b825-62eba1f81426)：Skip current word
