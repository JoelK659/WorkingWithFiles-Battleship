namespace WorkingWithFiles_Battleship
{
    partial class Battleship
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Battleship));
            SendBomb = new Button();
            ColBox = new TextBox();
            RowBox = new TextBox();
            RowLabel = new Label();
            ColumnLabel = new Label();
            Tutorial = new TextBox();
            label1 = new Label();
            NumofTries = new TextBox();
            RestartButton = new Button();
            label2 = new Label();
            NumofShipsHit = new TextBox();
            SuspendLayout();
            // 
            // SendBomb
            // 
            SendBomb.Location = new Point(622, 385);
            SendBomb.Name = "SendBomb";
            SendBomb.Size = new Size(132, 53);
            SendBomb.TabIndex = 0;
            SendBomb.Text = "Bomb's Away!";
            SendBomb.UseVisualStyleBackColor = true;
            SendBomb.Click += SendBomb_Click;
            // 
            // ColBox
            // 
            ColBox.Location = new Point(715, 341);
            ColBox.Name = "ColBox";
            ColBox.Size = new Size(39, 27);
            ColBox.TabIndex = 1;
            // 
            // RowBox
            // 
            RowBox.Location = new Point(622, 341);
            RowBox.Name = "RowBox";
            RowBox.Size = new Size(39, 27);
            RowBox.TabIndex = 2;
            // 
            // RowLabel
            // 
            RowLabel.AutoSize = true;
            RowLabel.Location = new Point(622, 302);
            RowLabel.Name = "RowLabel";
            RowLabel.Size = new Size(38, 20);
            RowLabel.TabIndex = 3;
            RowLabel.Text = "Row";
            // 
            // ColumnLabel
            // 
            ColumnLabel.AutoSize = true;
            ColumnLabel.Location = new Point(706, 302);
            ColumnLabel.Name = "ColumnLabel";
            ColumnLabel.Size = new Size(60, 20);
            ColumnLabel.TabIndex = 4;
            ColumnLabel.Text = "Column";
            // 
            // Tutorial
            // 
            Tutorial.Location = new Point(12, 83);
            Tutorial.Multiline = true;
            Tutorial.Name = "Tutorial";
            Tutorial.ReadOnly = true;
            Tutorial.Size = new Size(200, 331);
            Tutorial.TabIndex = 5;
            Tutorial.Text = resources.GetString("Tutorial.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(463, 385);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 6;
            label1.Text = "Tries:";
            // 
            // NumofTries
            // 
            NumofTries.Location = new Point(527, 382);
            NumofTries.Name = "NumofTries";
            NumofTries.ReadOnly = true;
            NumofTries.Size = new Size(39, 27);
            NumofTries.TabIndex = 7;
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(638, 213);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(94, 29);
            RestartButton.TabIndex = 8;
            RestartButton.Text = "Restart";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(434, 341);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 9;
            label2.Text = "Ships Hit:";
            // 
            // NumofShipsHit
            // 
            NumofShipsHit.Location = new Point(527, 338);
            NumofShipsHit.Name = "NumofShipsHit";
            NumofShipsHit.ReadOnly = true;
            NumofShipsHit.Size = new Size(39, 27);
            NumofShipsHit.TabIndex = 10;
            // 
            // Battleship
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(NumofShipsHit);
            Controls.Add(label2);
            Controls.Add(RestartButton);
            Controls.Add(NumofTries);
            Controls.Add(label1);
            Controls.Add(Tutorial);
            Controls.Add(ColumnLabel);
            Controls.Add(RowLabel);
            Controls.Add(RowBox);
            Controls.Add(ColBox);
            Controls.Add(SendBomb);
            Name = "Battleship";
            Text = "Battleship";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SendBomb;
        private TextBox ColBox;
        private TextBox RowBox;
        private Label RowLabel;
        private Label ColumnLabel;
        private TextBox Tutorial;
        private Label label1;
        private TextBox NumofTries;
        private Button RestartButton;
        private Label label2;
        private TextBox NumofShipsHit;
    }
}
