namespace _2048_eXtendido
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pbxBoard = new System.Windows.Forms.PictureBox();
            this.gboxScore = new System.Windows.Forms.GroupBox();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.menuFile = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameCtrlGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCtrlzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gboxBoardSetting = new System.Windows.Forms.GroupBox();
            this.cboxInitialValues = new System.Windows.Forms.ComboBox();
            this.lblInitialsValues = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.cboxLevel = new System.Windows.Forms.ComboBox();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).BeginInit();
            this.gboxScore.SuspendLayout();
            this.menuFile.SuspendLayout();
            this.gboxBoardSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBoard
            // 
            this.pbxBoard.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbxBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxBoard.Location = new System.Drawing.Point(23, 27);
            this.pbxBoard.Name = "pbxBoard";
            this.pbxBoard.Size = new System.Drawing.Size(500, 500);
            this.pbxBoard.TabIndex = 0;
            this.pbxBoard.TabStop = false;
            this.pbxBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxBoard_Paint);
            this.pbxBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxBoard_MouseClick);
            // 
            // gboxScore
            // 
            this.gboxScore.Controls.Add(this.lblStep);
            this.gboxScore.Controls.Add(this.lblBest);
            this.gboxScore.Controls.Add(this.lblScore);
            this.gboxScore.Location = new System.Drawing.Point(538, 36);
            this.gboxScore.Name = "gboxScore";
            this.gboxScore.Size = new System.Drawing.Size(178, 105);
            this.gboxScore.TabIndex = 1;
            this.gboxScore.TabStop = false;
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep.Location = new System.Drawing.Point(22, 79);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(0, 18);
            this.lblStep.TabIndex = 2;
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBest.Location = new System.Drawing.Point(21, 50);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(0, 18);
            this.lblBest.TabIndex = 2;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(21, 19);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 18);
            this.lblScore.TabIndex = 2;
            // 
            // menuFile
            // 
            this.menuFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuFile.Location = new System.Drawing.Point(0, 0);
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(728, 24);
            this.menuFile.TabIndex = 4;
            this.menuFile.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameF2ToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.saveGameCtrlGToolStripMenuItem,
            this.undoCtrlzToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameF2ToolStripMenuItem
            // 
            this.newGameF2ToolStripMenuItem.Name = "newGameF2ToolStripMenuItem";
            this.newGameF2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newGameF2ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newGameF2ToolStripMenuItem.Text = "New Game";
            this.newGameF2ToolStripMenuItem.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // saveGameCtrlGToolStripMenuItem
            // 
            this.saveGameCtrlGToolStripMenuItem.Name = "saveGameCtrlGToolStripMenuItem";
            this.saveGameCtrlGToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveGameCtrlGToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveGameCtrlGToolStripMenuItem.Text = "Save Game";
            this.saveGameCtrlGToolStripMenuItem.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // undoCtrlzToolStripMenuItem
            // 
            this.undoCtrlzToolStripMenuItem.Name = "undoCtrlzToolStripMenuItem";
            this.undoCtrlzToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoCtrlzToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.undoCtrlzToolStripMenuItem.Text = "Undo";
            this.undoCtrlzToolStripMenuItem.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gboxBoardSetting
            // 
            this.gboxBoardSetting.Controls.Add(this.cboxInitialValues);
            this.gboxBoardSetting.Controls.Add(this.lblInitialsValues);
            this.gboxBoardSetting.Controls.Add(this.btnUndo);
            this.gboxBoardSetting.Controls.Add(this.btnNewGame);
            this.gboxBoardSetting.Controls.Add(this.cboxLevel);
            this.gboxBoardSetting.Controls.Add(this.nudSize);
            this.gboxBoardSetting.Controls.Add(this.lblLevel);
            this.gboxBoardSetting.Controls.Add(this.lblSize);
            this.gboxBoardSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxBoardSetting.Location = new System.Drawing.Point(532, 164);
            this.gboxBoardSetting.Name = "gboxBoardSetting";
            this.gboxBoardSetting.Size = new System.Drawing.Size(190, 243);
            this.gboxBoardSetting.TabIndex = 5;
            this.gboxBoardSetting.TabStop = false;
            this.gboxBoardSetting.Text = "Board Setting";
            // 
            // cboxInitialValues
            // 
            this.cboxInitialValues.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboxInitialValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxInitialValues.FormattingEnabled = true;
            this.cboxInitialValues.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboxInitialValues.Location = new System.Drawing.Point(128, 101);
            this.cboxInitialValues.Name = "cboxInitialValues";
            this.cboxInitialValues.Size = new System.Drawing.Size(51, 24);
            this.cboxInitialValues.TabIndex = 5;
            // 
            // lblInitialsValues
            // 
            this.lblInitialsValues.AutoSize = true;
            this.lblInitialsValues.Location = new System.Drawing.Point(13, 104);
            this.lblInitialsValues.Name = "lblInitialsValues";
            this.lblInitialsValues.Size = new System.Drawing.Size(105, 16);
            this.lblInitialsValues.TabIndex = 4;
            this.lblInitialsValues.Text = "Initials Values";
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(47, 195);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(97, 23);
            this.btnUndo.TabIndex = 3;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(47, 146);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(97, 23);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // cboxLevel
            // 
            this.cboxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLevel.FormattingEnabled = true;
            this.cboxLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cboxLevel.Location = new System.Drawing.Point(128, 57);
            this.cboxLevel.Name = "cboxLevel";
            this.cboxLevel.Size = new System.Drawing.Size(51, 24);
            this.cboxLevel.TabIndex = 2;
            // 
            // nudSize
            // 
            this.nudSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudSize.Location = new System.Drawing.Point(128, 23);
            this.nudSize.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(51, 22);
            this.nudSize.TabIndex = 1;
            this.nudSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(13, 65);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(46, 16);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(13, 29);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(38, 16);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Size";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(728, 540);
            this.Controls.Add(this.gboxBoardSetting);
            this.Controls.Add(this.gboxScore);
            this.Controls.Add(this.pbxBoard);
            this.Controls.Add(this.menuFile);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuFile;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048_eXtendido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).EndInit();
            this.gboxScore.ResumeLayout(false);
            this.gboxScore.PerformLayout();
            this.menuFile.ResumeLayout(false);
            this.menuFile.PerformLayout();
            this.gboxBoardSetting.ResumeLayout(false);
            this.gboxBoardSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBoard;
        private System.Windows.Forms.GroupBox gboxScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.MenuStrip menuFile;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameF2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameCtrlGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoCtrlzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gboxBoardSetting;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.ComboBox cboxLevel;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cboxInitialValues;
        private System.Windows.Forms.Label lblInitialsValues;
    }
}

