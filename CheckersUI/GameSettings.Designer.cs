namespace CheckersUI
{
    partial class GameSettings
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
            this.m_RadioButton10BoardSize = new System.Windows.Forms.RadioButton();
            this.m_RadioButton8BoardSize = new System.Windows.Forms.RadioButton();
            this.m_RadioButton6BoardSize = new System.Windows.Forms.RadioButton();
            this.m_LabelPlayerOne = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayerTwo = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayerOne = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayerTwo = new System.Windows.Forms.TextBox();
            this.m_ButtonDone = new System.Windows.Forms.Button();
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_RadioButton10BoardSize
            // 
            this.m_RadioButton10BoardSize.AutoSize = true;
            this.m_RadioButton10BoardSize.Location = new System.Drawing.Point(211, 53);
            this.m_RadioButton10BoardSize.Name = "m_RadioButton10BoardSize";
            this.m_RadioButton10BoardSize.Size = new System.Drawing.Size(89, 24);
            this.m_RadioButton10BoardSize.TabIndex = 3;
            this.m_RadioButton10BoardSize.TabStop = true;
            this.m_RadioButton10BoardSize.Tag = string.Empty;
            this.m_RadioButton10BoardSize.Text = "10 X 10";
            this.m_RadioButton10BoardSize.UseVisualStyleBackColor = true;
            // 
            // m_RadioButton8BoardSize
            // 
            this.m_RadioButton8BoardSize.AutoSize = true;
            this.m_RadioButton8BoardSize.Location = new System.Drawing.Point(122, 53);
            this.m_RadioButton8BoardSize.Name = "m_RadioButton8BoardSize";
            this.m_RadioButton8BoardSize.Size = new System.Drawing.Size(71, 24);
            this.m_RadioButton8BoardSize.TabIndex = 2;
            this.m_RadioButton8BoardSize.TabStop = true;
            this.m_RadioButton8BoardSize.Tag = string.Empty;
            this.m_RadioButton8BoardSize.Text = "8 X 8";
            this.m_RadioButton8BoardSize.UseVisualStyleBackColor = true;
            // 
            // m_RadioButton6BoardSize
            // 
            this.m_RadioButton6BoardSize.AutoSize = true;
            this.m_RadioButton6BoardSize.Checked = true;
            this.m_RadioButton6BoardSize.Location = new System.Drawing.Point(33, 53);
            this.m_RadioButton6BoardSize.Name = "m_RadioButton6BoardSize";
            this.m_RadioButton6BoardSize.Size = new System.Drawing.Size(71, 24);
            this.m_RadioButton6BoardSize.TabIndex = 1;
            this.m_RadioButton6BoardSize.TabStop = true;
            this.m_RadioButton6BoardSize.Tag = string.Empty;
            this.m_RadioButton6BoardSize.Text = "6 X 6";
            this.m_RadioButton6BoardSize.UseVisualStyleBackColor = true;
            // 
            // m_LabelPlayerOne
            // 
            this.m_LabelPlayerOne.AutoSize = true;
            this.m_LabelPlayerOne.Location = new System.Drawing.Point(54, 118);
            this.m_LabelPlayerOne.Name = "m_LabelPlayerOne";
            this.m_LabelPlayerOne.Size = new System.Drawing.Size(69, 20);
            this.m_LabelPlayerOne.TabIndex = 5;
            this.m_LabelPlayerOne.Text = "Player 1:";
            // 
            // m_CheckBoxPlayerTwo
            // 
            this.m_CheckBoxPlayerTwo.AutoSize = true;
            this.m_CheckBoxPlayerTwo.Location = new System.Drawing.Point(58, 157);
            this.m_CheckBoxPlayerTwo.Name = "m_CheckBoxPlayerTwo";
            this.m_CheckBoxPlayerTwo.Size = new System.Drawing.Size(95, 24);
            this.m_CheckBoxPlayerTwo.TabIndex = 7;
            this.m_CheckBoxPlayerTwo.Text = "Player 2:";
            this.m_CheckBoxPlayerTwo.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayerTwo.CheckedChanged += new System.EventHandler(this.m_CheckBoxPlayerTwo_CheckedChanged);
            // 
            // m_TextBoxPlayerOne
            // 
            this.m_TextBoxPlayerOne.Location = new System.Drawing.Point(162, 115);
            this.m_TextBoxPlayerOne.Name = "m_TextBoxPlayerOne";
            this.m_TextBoxPlayerOne.Size = new System.Drawing.Size(138, 26);
            this.m_TextBoxPlayerOne.TabIndex = 8;
            // 
            // m_TextBoxPlayerTwo
            // 
            this.m_TextBoxPlayerTwo.Enabled = false;
            this.m_TextBoxPlayerTwo.Location = new System.Drawing.Point(162, 155);
            this.m_TextBoxPlayerTwo.Name = "m_TextBoxPlayerTwo";
            this.m_TextBoxPlayerTwo.Size = new System.Drawing.Size(138, 26);
            this.m_TextBoxPlayerTwo.TabIndex = 9;
            this.m_TextBoxPlayerTwo.Text = "[Computer]";
            // 
            // m_ButtonDone
            // 
            this.m_ButtonDone.Location = new System.Drawing.Point(188, 192);
            this.m_ButtonDone.Name = "m_ButtonDone";
            this.m_ButtonDone.Size = new System.Drawing.Size(112, 38);
            this.m_ButtonDone.TabIndex = 10;
            this.m_ButtonDone.Text = "Done";
            this.m_ButtonDone.UseVisualStyleBackColor = true;
            this.m_ButtonDone.Click += new System.EventHandler(this.m_ButtonDone_Click);
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(29, 90);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.m_LabelPlayers.TabIndex = 11;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelBoardSize.Location = new System.Drawing.Point(29, 19);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(122, 24);
            this.m_LabelBoardSize.TabIndex = 12;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 242);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_LabelPlayers);
            this.Controls.Add(this.m_ButtonDone);
            this.Controls.Add(this.m_TextBoxPlayerTwo);
            this.Controls.Add(this.m_TextBoxPlayerOne);
            this.Controls.Add(this.m_CheckBoxPlayerTwo);
            this.Controls.Add(this.m_LabelPlayerOne);
            this.Controls.Add(this.m_RadioButton6BoardSize);
            this.Controls.Add(this.m_RadioButton8BoardSize);
            this.Controls.Add(this.m_RadioButton10BoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += GameSettings_FormClosing;
        }
        #endregion
        private System.Windows.Forms.RadioButton m_RadioButton10BoardSize;
        private System.Windows.Forms.RadioButton m_RadioButton8BoardSize;
        private System.Windows.Forms.RadioButton m_RadioButton6BoardSize;
        private System.Windows.Forms.Label m_LabelPlayerOne;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayerTwo;
        private System.Windows.Forms.TextBox m_TextBoxPlayerOne;
        private System.Windows.Forms.TextBox m_TextBoxPlayerTwo;
        private System.Windows.Forms.Button m_ButtonDone;
        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.Label m_LabelBoardSize;
    }
}