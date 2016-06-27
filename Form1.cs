using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
Craig Gundacker
Assignment 3, Task 1
March 23, 2016
*/
namespace GuessAWord
{
    public partial class Form1 : Form
    {
        private String[] letters = { "A", "B", "C", "D", "E", "F", "G", "H",
            "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z"};

        private String[] words = {"complete", "aboriginal", "homely", "innocent",
            "abstracted", "bed", "spiritual", "elderly", "capable", "shiny",
            "useless", "gleaming", "better", "nippy", "guiltless", "unequaled",
            "payment", "tropical", "imagine", "measure"};

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
        public Form1()
        {
            InitializeComponent();
            SetUpGame();
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
            int index = rnd.Next(words.Length);
            wordToGuess = words[index].ToUpper();
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
