
namespace Inlämningsupg_3___zork
{
    partial class FrmScenario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScenario));
            this.label1 = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.movesLabel = new System.Windows.Forms.Label();
            this.roomDescriptionTxt = new System.Windows.Forms.RichTextBox();
            this.roomPicturebox = new System.Windows.Forms.PictureBox();
            this.playerLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.item1Label = new System.Windows.Forms.Label();
            this.userInputTxt = new System.Windows.Forms.TextBox();
            this.item2Label = new System.Windows.Forms.Label();
            this.TimeCounter = new System.Windows.Forms.Timer(this.components);
            this.TimerMinNSeconds = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.howToPlayBtn = new System.Windows.Forms.Button();
            this.mapBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.roomPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(0, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1496, 45);
            this.label1.TabIndex = 0;
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomNameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.roomNameLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameLabel.Location = new System.Drawing.Point(12, 6);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(294, 31);
            this.roomNameLabel.TabIndex = 1;
            this.roomNameLabel.Text = "The docks";
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timerLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.timerLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(922, 6);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(208, 31);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "Timer";
            // 
            // movesLabel
            // 
            this.movesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.movesLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.movesLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movesLabel.Location = new System.Drawing.Point(1189, 6);
            this.movesLabel.Name = "movesLabel";
            this.movesLabel.Size = new System.Drawing.Size(208, 31);
            this.movesLabel.TabIndex = 4;
            this.movesLabel.Text = "Moves: 0";
            // 
            // roomDescriptionTxt
            // 
            this.roomDescriptionTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomDescriptionTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomDescriptionTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomDescriptionTxt.Cursor = System.Windows.Forms.Cursors.No;
            this.roomDescriptionTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomDescriptionTxt.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.roomDescriptionTxt.Location = new System.Drawing.Point(354, 396);
            this.roomDescriptionTxt.Name = "roomDescriptionTxt";
            this.roomDescriptionTxt.ReadOnly = true;
            this.roomDescriptionTxt.Size = new System.Drawing.Size(759, 293);
            this.roomDescriptionTxt.TabIndex = 5;
            this.roomDescriptionTxt.Text = "";
            // 
            // roomPicturebox
            // 
            this.roomPicturebox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("roomPicturebox.Image")));
            this.roomPicturebox.Location = new System.Drawing.Point(354, 114);
            this.roomPicturebox.Name = "roomPicturebox";
            this.roomPicturebox.Size = new System.Drawing.Size(759, 257);
            this.roomPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roomPicturebox.TabIndex = 6;
            this.roomPicturebox.TabStop = false;
            // 
            // playerLabel
            // 
            this.playerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.playerLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.Location = new System.Drawing.Point(0, 797);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(113, 31);
            this.playerLabel.TabIndex = 7;
            this.playerLabel.Text = "Player:";
            this.playerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerNameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.playerNameLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.Location = new System.Drawing.Point(114, 797);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(113, 31);
            this.playerNameLabel.TabIndex = 8;
            this.playerNameLabel.Text = "Name";
            this.playerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playerNameLabel.UseCompatibleTextRendering = true;
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inventoryLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.inventoryLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryLabel.Location = new System.Drawing.Point(1258, 797);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(113, 31);
            this.inventoryLabel.TabIndex = 9;
            this.inventoryLabel.Text = "Inventory:";
            this.inventoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // item1Label
            // 
            this.item1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.item1Label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.item1Label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item1Label.Location = new System.Drawing.Point(1372, 797);
            this.item1Label.Name = "item1Label";
            this.item1Label.Size = new System.Drawing.Size(124, 31);
            this.item1Label.TabIndex = 10;
            this.item1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userInputTxt
            // 
            this.userInputTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userInputTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userInputTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userInputTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInputTxt.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.userInputTxt.Location = new System.Drawing.Point(354, 753);
            this.userInputTxt.Name = "userInputTxt";
            this.userInputTxt.Size = new System.Drawing.Size(759, 30);
            this.userInputTxt.TabIndex = 12;
            this.userInputTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userInputTxt_KeyDown);
            // 
            // item2Label
            // 
            this.item2Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.item2Label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.item2Label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item2Label.Location = new System.Drawing.Point(1372, 765);
            this.item2Label.Name = "item2Label";
            this.item2Label.Size = new System.Drawing.Size(124, 31);
            this.item2Label.TabIndex = 14;
            this.item2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeCounter
            // 
            this.TimeCounter.Enabled = true;
            this.TimeCounter.Interval = 1000;
            this.TimeCounter.Tick += new System.EventHandler(this.TimeCounter_Tick);
            // 
            // TimerMinNSeconds
            // 
            this.TimerMinNSeconds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TimerMinNSeconds.AutoSize = true;
            this.TimerMinNSeconds.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TimerMinNSeconds.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.TimerMinNSeconds.Location = new System.Drawing.Point(1005, 6);
            this.TimerMinNSeconds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimerMinNSeconds.Name = "TimerMinNSeconds";
            this.TimerMinNSeconds.Size = new System.Drawing.Size(66, 29);
            this.TimerMinNSeconds.TabIndex = 15;
            this.TimerMinNSeconds.Text = "0 : 0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(680, 724);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "Type here";
            // 
            // howToPlayBtn
            // 
            this.howToPlayBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToPlayBtn.Location = new System.Drawing.Point(1131, 622);
            this.howToPlayBtn.Name = "howToPlayBtn";
            this.howToPlayBtn.Size = new System.Drawing.Size(115, 31);
            this.howToPlayBtn.TabIndex = 17;
            this.howToPlayBtn.Text = "How to play";
            this.howToPlayBtn.UseVisualStyleBackColor = true;
            this.howToPlayBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // mapBtn
            // 
            this.mapBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapBtn.Location = new System.Drawing.Point(1131, 659);
            this.mapBtn.Name = "mapBtn";
            this.mapBtn.Size = new System.Drawing.Size(115, 31);
            this.mapBtn.TabIndex = 18;
            this.mapBtn.Text = "Map";
            this.mapBtn.UseVisualStyleBackColor = true;
            this.mapBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1496, 828);
            this.Controls.Add(this.mapBtn);
            this.Controls.Add(this.howToPlayBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimerMinNSeconds);
            this.Controls.Add(this.item2Label);
            this.Controls.Add(this.userInputTxt);
            this.Controls.Add(this.item1Label);
            this.Controls.Add(this.inventoryLabel);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.roomPicturebox);
            this.Controls.Add(this.roomDescriptionTxt);
            this.Controls.Add(this.movesLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.roomNameLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmScenario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scenario 1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScenario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.roomPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label movesLabel;
        private System.Windows.Forms.RichTextBox roomDescriptionTxt;
        private System.Windows.Forms.PictureBox roomPicturebox;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.Label item1Label;
        private System.Windows.Forms.TextBox userInputTxt;
        private System.Windows.Forms.Label item2Label;
        private System.Windows.Forms.Timer TimeCounter;
        private System.Windows.Forms.Label TimerMinNSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button howToPlayBtn;
        private System.Windows.Forms.Button mapBtn;
    }
}

