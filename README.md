# Wordscapes_joyglitch
 
I started by creating the project on UnityHub, using the 2D Mobile template.

When I did my first committ the project already had some things in it. Like Portrait mode forced on application use (so it always runs on vertical), canvas and some elements of it (background and placeholders for score, level and dragging area).

The game has a main menu to serve has home screen with a button. When pressed the first level loads.

To generate the letters of the dragging area into to the screen I created the GenerateLetters() method that creates the letters for the current level by instantiating a copy of the textBox game object for each letter, positioning the letters in a circular pattern around the centerDraggingArea, and adding a LetterDetection component to each letter. These letters come form the LettersForLevel() method that sets the levelLetters array to the corresponding set of letters for the level, based on the level parameter. The method also sets the numbLetters field to the length of the levelLetters array.

Then to detect the screen touch from the player to form words with the letters on the dragging area I implemented the interface IPointerEnterHandler that calls the OnPointerEnter function through the Event System every time the pointer entrs the object. And it checks if the letter is currently enabled, and if so it triggers the OnTouchEnter event, passing the text of the letter as a parameter. It then disables the letter so it can't be pressed again, and changes the background color to blue to indicate that it has been selected.

When the player releases the touch (checked on the Update()) I call the created VerifyWord() method, that checks if the currentWord string matches a word in the levelWords list, which is a list of word game objects that are hidden at the start of the level. If the word is valid, the method shows the corresponding word game object, updates the score, and checks if all the word game objects have been shown to trigger the NextLevel() method. I also call the CleanCurrWord() method so it resets the currentWord string and enables all the letters on the screen by calling the EnableLetter() method on each LetterDetection component. This method resets the letter so it can be used again, changing the background color of the letter back to white.

If all the words from the level board have been guessed the NextLevel() method is called an it increments the level value in PlayerPrefs and loads the next scene (level). If the scene loaded is the one with index 6 it loads the win screen showing the score.
