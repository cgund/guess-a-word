using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuessAWord.Properties;
/*
Craig Gundacker
Assignment 3, Task 1
March 23, 2016
*/
namespace GuessAWord
{
    public partial class Game : Form
    {
        private ResourceManager resources = new ResourceManager("GuessAWord.Properties.Resources", typeof(Resources).Assembly);
        private String[] letters = { "A", "B", "C", "D", "E", "F", "G", "H",
            "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z"};

        private List<String> list = new List<String>();

        private const int CONTROL_WIDTH = 40;
        private Color DEFAULT_COLOR = Color.Black;
        private Color SELECTED_COLOR = Color.Red;
        private Random rnd = new Random();
        //Each Label object corresponds to letter in word
        private List<Label> labels = new List<Label>();
        private const int MAX_GUESSES = 6;
        private int numGuessesRemaining;
        private String wordToGuess;
        private int wordToGuessLength;
        private int numLettersGuessedCorrectly;

        //Uninitialized class variables are initialized in constructor
        public Game()
        {
            String dict = GetDictString();
            CreateWordBank(dict);
            InitializeComponent();
            InitGameLevels();
            SetUpGame();
        }

        private void InitGameLevels()
        {
            cboLevel.Items.Add(new GameLevel("Easy", 2, 4));
            cboLevel.Items.Add(new GameLevel("Moderate", 5, 7));
            cboLevel.Items.Add(new GameLevel("Difficult", 8, Int16.MaxValue));
            cboLevel.SelectedIndex = 0;
        }

        private String GetDictString()
        {
            return resources.GetString("dictionary");
        }

        private void CreateWordBank(String dict)
        {
            int indexLineStart = 0;
            int counter = 0;
            foreach (Char c in dict)
            {
                if (c.Equals('\n'))
                {
                    int lineLength = counter - indexLineStart;
                    if (!lineLength.Equals(0))
                    {
                        String line = dict.Substring(indexLineStart, lineLength);
                        String[] parts = line.Split(' ');
                        list.Add(parts[0]);
                        indexLineStart = counter + 1;
                    }
                }
                counter++;
            }
        }

        private void SetUpGame()
        {
            SetUpLetterPanel();
            SetUpWordPanel();
        }

        /*
        For each letter of the alphabet array, create a button object, set button
        text field to letter, register click handler, add button to flowlayout panel
        */
        private void SetUpLetterPanel()
        {
            for (int i = 0; i < letters.Length; i++)
            {
                Button btn = new Button();
                btn.Width = CONTROL_WIDTH;
                btn.BackColor = Color.LightBlue;
                btn.ForeColor = DEFAULT_COLOR;
                btn.FlatStyle = FlatStyle.Standard;
                btn.Text = letters[i];
                btn.Click += (s, e) => //Registers event handler
                {
                    String letter = btn.Text;
                    Color foreColor = btn.ForeColor;
                    if (foreColor.Equals(DEFAULT_COLOR)) //color is set to default
                    {
                        btn.ForeColor = SELECTED_COLOR;
                        CheckForLetter(letter);
                        if (!GameWon())
                        {
                            if (GameOver())
                            {
                                lblGameStatus.Text = "Game Over.";
                                LockLetterPanel();
                            }
                        }
                        else
                        {
                            lblGameStatus.Text = "You won!";
                            LockLetterPanel();
                        }
                    }
                };
                flLetterPanel.Controls.Add(btn);
            }
        }

        /*
        For each control in flow layout panel control collection, set the forecolor
        property to default
        */
        private void ResetLetterPanel()
        {
            foreach (Control control in flLetterPanel.Controls)
            {
                control.ForeColor = DEFAULT_COLOR;
            }
        }

        /*
        Accepts the letter guessed by the user as a parameter.  If the hidden word
        contains the letter, then retrieve a reference to each label object that
        corresponds to the specified letter.  Set the label Text property to
        specified letter.  Otherwise, decrease the number of available guesses
        remaining.  Returns boolean indicating whether letter was found in word
        */
        private Boolean CheckForLetter(String letter)
        {
            Boolean letterFound = false;
            if (wordToGuess.Contains(letter))
            {
                char ltr = letter[0];
                int index = 0;
                foreach (char c in wordToGuess)
                {
                    if (c.Equals(ltr))
                    {
                        Label lblLetter = labels.ElementAt(index);
                        lblLetter.Text = Convert.ToString(ltr);
                        numLettersGuessedCorrectly += 1;
                    }
                    index++;
                }
                letterFound = true;
            }
            else
            {
                DecrementGuesses();
            }
            return letterFound;
        }

        private Boolean GameWon()
        {
            Boolean gameWon = false;
            if (numLettersGuessedCorrectly == wordToGuessLength)
            {
                gameWon = true;
            }
            return gameWon;
        }

        private Boolean GameOver()
        {
            Boolean gameOver = false;
            if (numGuessesRemaining < 1)
            {
                gameOver = true;
            }
            return gameOver;
        }

        /*
        Sets number guesses to word length, unless number guesses is greater than constant
        */
        private void SetUpScoreBoard(int wordLength)
        {
            if (wordLength < MAX_GUESSES)
            {
                numGuessesRemaining = wordLength;
            }
            else
            {
                numGuessesRemaining = MAX_GUESSES;
            }
            lblGuesses.Text = Convert.ToString(numGuessesRemaining);
            numLettersGuessedCorrectly = 0;
            lblGameStatus.Text = String.Empty;
        }

        private void DecrementGuesses()
        {
            numGuessesRemaining--;
            lblGuesses.Text = Convert.ToString(numGuessesRemaining);
        }
        
        /*
        Clears both collections that contain references to the hidden word letter labels.
        Randomnly selects word from array.  Creates a label object that corresponds to 
        each letter in hidden word.  Adds label object to the collections mentioned above.
        */
        private void SetUpWordPanel()
        {
            flLettersInWord.Controls.Clear();
            labels.Clear();
            wordToGuess = SelectWord();
            wordToGuessLength = wordToGuess.Length;
            for (int i = 0; i < wordToGuessLength; i++)
            {
                Label lblLetter = new Label();
                lblLetter.TextAlign = ContentAlignment.MiddleCenter;
                lblLetter.Width = CONTROL_WIDTH;
                lblLetter.BorderStyle = BorderStyle.Fixed3D;
                lblLetter.BackColor = Color.Beige;
                labels.Add(lblLetter);
                flLettersInWord.Controls.Add(lblLetter);
            }

            SetUpScoreBoard(wordToGuessLength);
        }

        private String SelectWord()
        {
            GameLevel gameLevel = (GameLevel)cboLevel.SelectedItem;
            Int16 minLetters = gameLevel.MinLetters;
            Int16 maxLetters = gameLevel.MaxLetters;
            String modifiedWord;
            int wordLength;
            do
            {
                int index = rnd.Next(list.Count);
                String unModifiedWord = list.ElementAt(index);
                modifiedWord = CleanUpWord(unModifiedWord);
                wordLength = modifiedWord.Length;
            }
            while (wordLength < minLetters || wordLength > maxLetters);

            return modifiedWord;
        }

        private String CleanUpWord(String word)
        {
            word = word.Trim();
            Char startLetter = word.ElementAt(0);
            Char endLetter = word.ElementAt(word.Length - 1);
            if (!Char.IsLetter(startLetter))
            {
                word = word.Substring(1);
            }

            if (!Char.IsLetter(endLetter))
            {
                word = word.Substring(0, word.Length - 1);
            }
            return word.ToUpper();
        }

        /*
        Starts a new game
        */
        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetLetterPanel();
            UnLockLetterPanel();
            SetUpWordPanel();
        }
        
        /*
        Displays hidden word to user
        */
        private void btnShow_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                Label lbl = labels.ElementAt(i);
                lbl.Text = Convert.ToString(wordToGuess[i]);
            }
            LockLetterPanel();
        }

        /*
        Prevents each button in flowlayout panel from responding to click events
        */
        private void LockLetterPanel()
        {
            foreach(Control control in flLetterPanel.Controls)
            {
                control.Enabled = false;
            }
        }

        /*
        Allows each button in flowlayout panel to respond to click events
        */
        private void UnLockLetterPanel()
        {
            foreach (Control control in flLetterPanel.Controls)
            {
                control.Enabled = true;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
