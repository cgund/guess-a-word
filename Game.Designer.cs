namespace GuessAWord
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flLetterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.flLettersInWord = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGuesses = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flLetterPanel
            // 
            this.flLetterPanel.Location = new System.Drawing.Point(114, 76);
            this.flLetterPanel.Name = "flLetterPanel";
            this.flLetterPanel.Size = new System.Drawing.Size(247, 176);
            this.flLetterPanel.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(95, 346);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New Game";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(198, 346);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(80, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show Answer";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // flLettersInWord
            // 
            this.flLettersInWord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flLettersInWord.Location = new System.Drawing.Point(31, 271);
            this.flLettersInWord.Name = "flLettersInWord";
            this.flLettersInWord.Size = new System.Drawing.Size(460, 69);
            this.flLettersInWord.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(136, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Guesses Left";
            // 
            // lblGuesses
            // 
            this.lblGuesses.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblGuesses.Location = new System.Drawing.Point(225, 37);
            this.lblGuesses.Name = "lblGuesses";
            this.lblGuesses.Size = new System.Drawing.Size(92, 23);
            this.lblGuesses.TabIndex = 5;
            this.lblGuesses.Text = "1";
            this.lblGuesses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(304, 346);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameStatus.Location = new System.Drawing.Point(357, 37);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(104, 23);
            this.lblGameStatus.TabIndex = 7;
            this.lblGameStatus.Text = "PlaceHolder";
            this.lblGameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboLevel
            // 
            this.cboLevel.DisplayMember = "None";
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Location = new System.Drawing.Point(394, 131);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(97, 21);
            this.cboLevel.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Difficulty Level";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 396);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLevel);
            this.Controls.Add(this.lblGameStatus);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblGuesses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flLettersInWord);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.flLetterPanel);
            this.Name = "Game";
            this.Text = "Guess A Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flLetterPanel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.FlowLayoutPanel flLettersInWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGuesses;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label label2;
    }
}

