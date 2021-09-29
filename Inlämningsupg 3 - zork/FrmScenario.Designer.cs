
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScenario));
            this.label1 = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.movesLabel = new System.Windows.Forms.Label();
            this.roomDescriptionTxt = new System.Windows.Forms.RichTextBox();
            this.roomPicturebox = new System.Windows.Forms.PictureBox();
            this.playerLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.item1Label = new System.Windows.Forms.Label();
            this.pickUpItemBtn = new System.Windows.Forms.Button();
            this.userInputTxt = new System.Windows.Forms.TextBox();
            this.keyOnDoorBtn = new System.Windows.Forms.Button();
            this.item2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roomPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(0, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1496, 45);
            this.label1.TabIndex = 0;
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.roomNameLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameLabel.Location = new System.Drawing.Point(12, 6);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(208, 31);
            this.roomNameLabel.TabIndex = 1;
            this.roomNameLabel.Text = "The docks";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.scoreLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(922, 6);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(208, 31);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score: 0";
            // 
            // movesLabel
            // 
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
            this.roomDescriptionTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomDescriptionTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomDescriptionTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomDescriptionTxt.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.roomDescriptionTxt.Location = new System.Drawing.Point(354, 396);
            this.roomDescriptionTxt.Name = "roomDescriptionTxt";
            this.roomDescriptionTxt.ReadOnly = true;
            this.roomDescriptionTxt.Size = new System.Drawing.Size(759, 177);
            this.roomDescriptionTxt.TabIndex = 5;
            this.roomDescriptionTxt.Text = resources.GetString("roomDescriptionTxt.Text");
            // 
            // roomPicturebox
            // 
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
            this.playerNameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.playerNameLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.Location = new System.Drawing.Point(114, 797);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(113, 31);
            this.playerNameLabel.TabIndex = 8;
            this.playerNameLabel.Text = "Name";
            this.playerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.inventoryLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryLabel.Location = new System.Drawing.Point(1269, 797);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(113, 31);
            this.inventoryLabel.TabIndex = 9;
            this.inventoryLabel.Text = "Inventory:";
            this.inventoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // item1Label
            // 
            this.item1Label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.item1Label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item1Label.Location = new System.Drawing.Point(1383, 797);
            this.item1Label.Name = "item1Label";
            this.item1Label.Size = new System.Drawing.Size(113, 31);
            this.item1Label.TabIndex = 10;
            this.item1Label.Text = "Item";
            this.item1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pickUpItemBtn
            // 
            this.pickUpItemBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickUpItemBtn.Location = new System.Drawing.Point(553, 770);
            this.pickUpItemBtn.Name = "pickUpItemBtn";
            this.pickUpItemBtn.Size = new System.Drawing.Size(141, 32);
            this.pickUpItemBtn.TabIndex = 11;
            this.pickUpItemBtn.Text = "Pick up item";
            this.pickUpItemBtn.UseVisualStyleBackColor = true;
            // 
            // userInputTxt
            // 
            this.userInputTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userInputTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInputTxt.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.userInputTxt.Location = new System.Drawing.Point(553, 595);
            this.userInputTxt.Multiline = true;
            this.userInputTxt.Name = "userInputTxt";
            this.userInputTxt.Size = new System.Drawing.Size(345, 169);
            this.userInputTxt.TabIndex = 12;
            // 
            // keyOnDoorBtn
            // 
            this.keyOnDoorBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyOnDoorBtn.Location = new System.Drawing.Point(757, 770);
            this.keyOnDoorBtn.Name = "keyOnDoorBtn";
            this.keyOnDoorBtn.Size = new System.Drawing.Size(141, 32);
            this.keyOnDoorBtn.TabIndex = 13;
            this.keyOnDoorBtn.Text = "Use key on door";
            this.keyOnDoorBtn.UseVisualStyleBackColor = true;
            // 
            // item2Label
            // 
            this.item2Label.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.item2Label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item2Label.Location = new System.Drawing.Point(1383, 766);
            this.item2Label.Name = "item2Label";
            this.item2Label.Size = new System.Drawing.Size(113, 31);
            this.item2Label.TabIndex = 14;
            this.item2Label.Text = "Item";
            this.item2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1496, 828);
            this.Controls.Add(this.item2Label);
            this.Controls.Add(this.keyOnDoorBtn);
            this.Controls.Add(this.userInputTxt);
            this.Controls.Add(this.pickUpItemBtn);
            this.Controls.Add(this.item1Label);
            this.Controls.Add(this.inventoryLabel);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.roomPicturebox);
            this.Controls.Add(this.roomDescriptionTxt);
            this.Controls.Add(this.movesLabel);
            this.Controls.Add(this.scoreLabel);
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
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label movesLabel;
        private System.Windows.Forms.RichTextBox roomDescriptionTxt;
        private System.Windows.Forms.PictureBox roomPicturebox;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.Label item1Label;
        private System.Windows.Forms.Button pickUpItemBtn;
        private System.Windows.Forms.TextBox userInputTxt;
        private System.Windows.Forms.Button keyOnDoorBtn;
        private System.Windows.Forms.Label item2Label;
    }
}

