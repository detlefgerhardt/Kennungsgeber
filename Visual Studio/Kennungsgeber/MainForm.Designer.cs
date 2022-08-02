namespace Kennungsgeber
{
	partial class MainForm
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
			this.OrgAnswerbackTextTb = new System.Windows.Forms.TextBox();
			this.OrgAnswerbackTextLbl = new System.Windows.Forms.Label();
			this.FavoriteAnswerbackTextLbl = new System.Windows.Forms.Label();
			this.FavoriteAnswerbackTextTb = new System.Windows.Forms.TextBox();
			this.GenerateBtn = new System.Windows.Forms.Button();
			this.LoadBtn = new System.Windows.Forms.Button();
			this.SaveBtn = new System.Windows.Forms.Button();
			this.PossibleAnswerbackTextTb = new System.Windows.Forms.TextBox();
			this.ToRightBtn = new System.Windows.Forms.Button();
			this.ToLeftBtn = new System.Windows.Forms.Button();
			this.OrgAnswerbackCombsLbl = new System.Windows.Forms.Label();
			this.PossibleAnswerbackCombsLbl = new System.Windows.Forms.Label();
			this.PossibleAnswerbackTextLbl = new System.Windows.Forms.Label();
			this.ExplanationGb = new System.Windows.Forms.GroupBox();
			this.LanguageBtn = new System.Windows.Forms.Button();
			this.ShowControlCharactersCb = new System.Windows.Forms.CheckBox();
			this.PossibleAnswerbackKgList = new Kennungsgeber.KgListView();
			this.OrgAnswerbackKgList = new Kennungsgeber.KgListView();
			this.SuspendLayout();
			// 
			// OrgAnswerbackTextTb
			// 
			this.OrgAnswerbackTextTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OrgAnswerbackTextTb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OrgAnswerbackTextTb.Location = new System.Drawing.Point(678, 29);
			this.OrgAnswerbackTextTb.Name = "OrgAnswerbackTextTb";
			this.OrgAnswerbackTextTb.ReadOnly = true;
			this.OrgAnswerbackTextTb.Size = new System.Drawing.Size(374, 26);
			this.OrgAnswerbackTextTb.TabIndex = 6;
			this.OrgAnswerbackTextTb.DoubleClick += new System.EventHandler(this.OrgAnswerbackTextTb_DoubleClick);
			this.OrgAnswerbackTextTb.Leave += new System.EventHandler(this.OrgAnswerbackTextTb_Leave);
			// 
			// OrgAnswerbackTextLbl
			// 
			this.OrgAnswerbackTextLbl.AutoSize = true;
			this.OrgAnswerbackTextLbl.Location = new System.Drawing.Point(675, 13);
			this.OrgAnswerbackTextLbl.Name = "OrgAnswerbackTextLbl";
			this.OrgAnswerbackTextLbl.Size = new System.Drawing.Size(127, 13);
			this.OrgAnswerbackTextLbl.TabIndex = 7;
			this.OrgAnswerbackTextLbl.Text = "Existing answerback text:";
			// 
			// FavoriteAnswerbackTextLbl
			// 
			this.FavoriteAnswerbackTextLbl.AutoSize = true;
			this.FavoriteAnswerbackTextLbl.Location = new System.Drawing.Point(675, 71);
			this.FavoriteAnswerbackTextLbl.Name = "FavoriteAnswerbackTextLbl";
			this.FavoriteAnswerbackTextLbl.Size = new System.Drawing.Size(129, 13);
			this.FavoriteAnswerbackTextLbl.TabIndex = 8;
			this.FavoriteAnswerbackTextLbl.Text = "Favorite answerback text:";
			// 
			// FavoriteAnswerbackTextTb
			// 
			this.FavoriteAnswerbackTextTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FavoriteAnswerbackTextTb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FavoriteAnswerbackTextTb.Location = new System.Drawing.Point(678, 87);
			this.FavoriteAnswerbackTextTb.Name = "FavoriteAnswerbackTextTb";
			this.FavoriteAnswerbackTextTb.Size = new System.Drawing.Size(293, 26);
			this.FavoriteAnswerbackTextTb.TabIndex = 9;
			this.FavoriteAnswerbackTextTb.TextChanged += new System.EventHandler(this.FavoriteAnswerbackTextTb_TextChanged);
			// 
			// GenerateBtn
			// 
			this.GenerateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GenerateBtn.Location = new System.Drawing.Point(977, 89);
			this.GenerateBtn.Name = "GenerateBtn";
			this.GenerateBtn.Size = new System.Drawing.Size(75, 23);
			this.GenerateBtn.TabIndex = 10;
			this.GenerateBtn.Text = "Generate";
			this.GenerateBtn.UseVisualStyleBackColor = true;
			this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
			// 
			// LoadBtn
			// 
			this.LoadBtn.Location = new System.Drawing.Point(678, 211);
			this.LoadBtn.Name = "LoadBtn";
			this.LoadBtn.Size = new System.Drawing.Size(75, 23);
			this.LoadBtn.TabIndex = 11;
			this.LoadBtn.Text = "Load";
			this.LoadBtn.UseVisualStyleBackColor = true;
			this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
			// 
			// SaveBtn
			// 
			this.SaveBtn.Location = new System.Drawing.Point(759, 211);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new System.Drawing.Size(75, 23);
			this.SaveBtn.TabIndex = 12;
			this.SaveBtn.Text = "Save";
			this.SaveBtn.UseVisualStyleBackColor = true;
			this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
			// 
			// PossibleAnswerbackTextTb
			// 
			this.PossibleAnswerbackTextTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PossibleAnswerbackTextTb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PossibleAnswerbackTextTb.Location = new System.Drawing.Point(678, 144);
			this.PossibleAnswerbackTextTb.Name = "PossibleAnswerbackTextTb";
			this.PossibleAnswerbackTextTb.ReadOnly = true;
			this.PossibleAnswerbackTextTb.Size = new System.Drawing.Size(374, 26);
			this.PossibleAnswerbackTextTb.TabIndex = 15;
			// 
			// ToRightBtn
			// 
			this.ToRightBtn.Enabled = false;
			this.ToRightBtn.Location = new System.Drawing.Point(416, 223);
			this.ToRightBtn.Name = "ToRightBtn";
			this.ToRightBtn.Size = new System.Drawing.Size(25, 23);
			this.ToRightBtn.TabIndex = 16;
			this.ToRightBtn.Text = "->";
			this.ToRightBtn.UseVisualStyleBackColor = true;
			this.ToRightBtn.Click += new System.EventHandler(this.ToRightBtn_Click);
			// 
			// ToLeftBtn
			// 
			this.ToLeftBtn.Enabled = false;
			this.ToLeftBtn.Location = new System.Drawing.Point(416, 268);
			this.ToLeftBtn.Name = "ToLeftBtn";
			this.ToLeftBtn.Size = new System.Drawing.Size(25, 23);
			this.ToLeftBtn.TabIndex = 17;
			this.ToLeftBtn.Text = "<-";
			this.ToLeftBtn.UseVisualStyleBackColor = true;
			// 
			// OrgAnswerbackCombsLbl
			// 
			this.OrgAnswerbackCombsLbl.AutoSize = true;
			this.OrgAnswerbackCombsLbl.Location = new System.Drawing.Point(9, 9);
			this.OrgAnswerbackCombsLbl.Name = "OrgAnswerbackCombsLbl";
			this.OrgAnswerbackCombsLbl.Size = new System.Drawing.Size(141, 13);
			this.OrgAnswerbackCombsLbl.TabIndex = 18;
			this.OrgAnswerbackCombsLbl.Text = "Existing answerback combs:";
			// 
			// PossibleAnswerbackCombsLbl
			// 
			this.PossibleAnswerbackCombsLbl.AutoSize = true;
			this.PossibleAnswerbackCombsLbl.Location = new System.Drawing.Point(442, 9);
			this.PossibleAnswerbackCombsLbl.Name = "PossibleAnswerbackCombsLbl";
			this.PossibleAnswerbackCombsLbl.Size = new System.Drawing.Size(168, 13);
			this.PossibleAnswerbackCombsLbl.TabIndex = 19;
			this.PossibleAnswerbackCombsLbl.Text = "New possible answerback combs:";
			// 
			// PossibleAnswerbackTextLbl
			// 
			this.PossibleAnswerbackTextLbl.AutoSize = true;
			this.PossibleAnswerbackTextLbl.Location = new System.Drawing.Point(675, 128);
			this.PossibleAnswerbackTextLbl.Name = "PossibleAnswerbackTextLbl";
			this.PossibleAnswerbackTextLbl.Size = new System.Drawing.Size(154, 13);
			this.PossibleAnswerbackTextLbl.TabIndex = 20;
			this.PossibleAnswerbackTextLbl.Text = "New possible answerback text:";
			// 
			// ExplanationGb
			// 
			this.ExplanationGb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ExplanationGb.Location = new System.Drawing.Point(678, 286);
			this.ExplanationGb.Name = "ExplanationGb";
			this.ExplanationGb.Size = new System.Drawing.Size(361, 257);
			this.ExplanationGb.TabIndex = 21;
			this.ExplanationGb.TabStop = false;
			this.ExplanationGb.Text = "Help";
			// 
			// LanguageBtn
			// 
			this.LanguageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LanguageBtn.Location = new System.Drawing.Point(963, 550);
			this.LanguageBtn.Name = "LanguageBtn";
			this.LanguageBtn.Size = new System.Drawing.Size(75, 23);
			this.LanguageBtn.TabIndex = 22;
			this.LanguageBtn.Text = "English";
			this.LanguageBtn.UseVisualStyleBackColor = true;
			this.LanguageBtn.Click += new System.EventHandler(this.LanguageBtn_Click);
			// 
			// ShowControlCharactersCb
			// 
			this.ShowControlCharactersCb.AutoSize = true;
			this.ShowControlCharactersCb.Location = new System.Drawing.Point(678, 177);
			this.ShowControlCharactersCb.Name = "ShowControlCharactersCb";
			this.ShowControlCharactersCb.Size = new System.Drawing.Size(112, 17);
			this.ShowControlCharactersCb.TabIndex = 23;
			this.ShowControlCharactersCb.Text = "Control characters";
			this.ShowControlCharactersCb.UseVisualStyleBackColor = true;
			this.ShowControlCharactersCb.Click += new System.EventHandler(this.ShowControlCharactersCb_Click);
			// 
			// PossibleAnswerbackKgList
			// 
			this.PossibleAnswerbackKgList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.PossibleAnswerbackKgList.Location = new System.Drawing.Point(445, 29);
			this.PossibleAnswerbackKgList.Name = "PossibleAnswerbackKgList";
			this.PossibleAnswerbackKgList.Size = new System.Drawing.Size(225, 545);
			this.PossibleAnswerbackKgList.TabIndex = 14;
			// 
			// OrgAnswerbackKgList
			// 
			this.OrgAnswerbackKgList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.OrgAnswerbackKgList.Location = new System.Drawing.Point(12, 29);
			this.OrgAnswerbackKgList.Name = "OrgAnswerbackKgList";
			this.OrgAnswerbackKgList.Size = new System.Drawing.Size(400, 544);
			this.OrgAnswerbackKgList.TabIndex = 13;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1065, 584);
			this.Controls.Add(this.ShowControlCharactersCb);
			this.Controls.Add(this.LanguageBtn);
			this.Controls.Add(this.ExplanationGb);
			this.Controls.Add(this.PossibleAnswerbackTextLbl);
			this.Controls.Add(this.PossibleAnswerbackCombsLbl);
			this.Controls.Add(this.OrgAnswerbackCombsLbl);
			this.Controls.Add(this.ToLeftBtn);
			this.Controls.Add(this.ToRightBtn);
			this.Controls.Add(this.PossibleAnswerbackTextTb);
			this.Controls.Add(this.PossibleAnswerbackKgList);
			this.Controls.Add(this.OrgAnswerbackKgList);
			this.Controls.Add(this.SaveBtn);
			this.Controls.Add(this.LoadBtn);
			this.Controls.Add(this.GenerateBtn);
			this.Controls.Add(this.FavoriteAnswerbackTextTb);
			this.Controls.Add(this.FavoriteAnswerbackTextLbl);
			this.Controls.Add(this.OrgAnswerbackTextLbl);
			this.Controls.Add(this.OrgAnswerbackTextTb);
			this.MinimumSize = new System.Drawing.Size(900, 540);
			this.Name = "MainForm";
			this.Text = "Kennungsgeber";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox OrgAnswerbackTextTb;
		private System.Windows.Forms.Label OrgAnswerbackTextLbl;
		private System.Windows.Forms.Label FavoriteAnswerbackTextLbl;
		private System.Windows.Forms.TextBox FavoriteAnswerbackTextTb;
		private System.Windows.Forms.Button GenerateBtn;
		private System.Windows.Forms.Button LoadBtn;
		private System.Windows.Forms.Button SaveBtn;
		private KgListView OrgAnswerbackKgList;
		private KgListView PossibleAnswerbackKgList;
		private System.Windows.Forms.TextBox PossibleAnswerbackTextTb;
		private System.Windows.Forms.Button ToRightBtn;
		private System.Windows.Forms.Button ToLeftBtn;
		private System.Windows.Forms.Label OrgAnswerbackCombsLbl;
		private System.Windows.Forms.Label PossibleAnswerbackCombsLbl;
		private System.Windows.Forms.Label PossibleAnswerbackTextLbl;
		private System.Windows.Forms.GroupBox ExplanationGb;
		private System.Windows.Forms.Button LanguageBtn;
		private System.Windows.Forms.CheckBox ShowControlCharactersCb;
	}
}

