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
			this.OrgKennungTb = new System.Windows.Forms.TextBox();
			this.OrgKennungLbl = new System.Windows.Forms.Label();
			this.WunschKennungLbl = new System.Windows.Forms.Label();
			this.WunschKennungTb = new System.Windows.Forms.TextBox();
			this.GenWunschKennungBtn = new System.Windows.Forms.Button();
			this.LoadBtn = new System.Windows.Forms.Button();
			this.SaveBtn = new System.Windows.Forms.Button();
			this.NewKennungTb = new System.Windows.Forms.TextBox();
			this.ToRightBtn = new System.Windows.Forms.Button();
			this.ToLeftBtn = new System.Windows.Forms.Button();
			this.KaemmeLbl = new System.Windows.Forms.Label();
			this.WunschKgLbl = new System.Windows.Forms.Label();
			this.KgNew = new Kennungsgeber.KgListView();
			this.KgOrg = new Kennungsgeber.KgListView();
			this.SuspendLayout();
			// 
			// OrgKennungTb
			// 
			this.OrgKennungTb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OrgKennungTb.Location = new System.Drawing.Point(678, 29);
			this.OrgKennungTb.Name = "OrgKennungTb";
			this.OrgKennungTb.ReadOnly = true;
			this.OrgKennungTb.Size = new System.Drawing.Size(374, 26);
			this.OrgKennungTb.TabIndex = 6;
			// 
			// OrgKennungLbl
			// 
			this.OrgKennungLbl.AutoSize = true;
			this.OrgKennungLbl.Location = new System.Drawing.Point(675, 13);
			this.OrgKennungLbl.Name = "OrgKennungLbl";
			this.OrgKennungLbl.Size = new System.Drawing.Size(73, 13);
			this.OrgKennungLbl.TabIndex = 7;
			this.OrgKennungLbl.Text = "Existing code:";
			// 
			// WunschKennungLbl
			// 
			this.WunschKennungLbl.AutoSize = true;
			this.WunschKennungLbl.Location = new System.Drawing.Point(675, 71);
			this.WunschKennungLbl.Name = "WunschKennungLbl";
			this.WunschKennungLbl.Size = new System.Drawing.Size(73, 13);
			this.WunschKennungLbl.TabIndex = 8;
			this.WunschKennungLbl.Text = "Desired code:";
			// 
			// WunschKennungTb
			// 
			this.WunschKennungTb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WunschKennungTb.Location = new System.Drawing.Point(678, 87);
			this.WunschKennungTb.Name = "WunschKennungTb";
			this.WunschKennungTb.Size = new System.Drawing.Size(374, 26);
			this.WunschKennungTb.TabIndex = 9;
			this.WunschKennungTb.TextChanged += new System.EventHandler(this.WunschKennungTb_TextChanged);
			// 
			// GenWunschKennungBtn
			// 
			this.GenWunschKennungBtn.Location = new System.Drawing.Point(678, 151);
			this.GenWunschKennungBtn.Name = "GenWunschKennungBtn";
			this.GenWunschKennungBtn.Size = new System.Drawing.Size(75, 23);
			this.GenWunschKennungBtn.TabIndex = 10;
			this.GenWunschKennungBtn.Text = "Generate";
			this.GenWunschKennungBtn.UseVisualStyleBackColor = true;
			this.GenWunschKennungBtn.Click += new System.EventHandler(this.GenWunschKennungBtn_Click);
			// 
			// LoadBtn
			// 
			this.LoadBtn.Location = new System.Drawing.Point(678, 268);
			this.LoadBtn.Name = "LoadBtn";
			this.LoadBtn.Size = new System.Drawing.Size(75, 23);
			this.LoadBtn.TabIndex = 11;
			this.LoadBtn.Text = "Load";
			this.LoadBtn.UseVisualStyleBackColor = true;
			this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
			// 
			// SaveBtn
			// 
			this.SaveBtn.Location = new System.Drawing.Point(759, 268);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new System.Drawing.Size(75, 23);
			this.SaveBtn.TabIndex = 12;
			this.SaveBtn.Text = "Save";
			this.SaveBtn.UseVisualStyleBackColor = true;
			this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
			// 
			// NewKennungTb
			// 
			this.NewKennungTb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NewKennungTb.Location = new System.Drawing.Point(678, 119);
			this.NewKennungTb.Name = "NewKennungTb";
			this.NewKennungTb.ReadOnly = true;
			this.NewKennungTb.Size = new System.Drawing.Size(374, 26);
			this.NewKennungTb.TabIndex = 15;
			// 
			// ToRightBtn
			// 
			this.ToRightBtn.Location = new System.Drawing.Point(418, 223);
			this.ToRightBtn.Name = "ToRightBtn";
			this.ToRightBtn.Size = new System.Drawing.Size(27, 23);
			this.ToRightBtn.TabIndex = 16;
			this.ToRightBtn.Text = "->";
			this.ToRightBtn.UseVisualStyleBackColor = true;
			// 
			// ToLeftBtn
			// 
			this.ToLeftBtn.Location = new System.Drawing.Point(418, 268);
			this.ToLeftBtn.Name = "ToLeftBtn";
			this.ToLeftBtn.Size = new System.Drawing.Size(27, 23);
			this.ToLeftBtn.TabIndex = 17;
			this.ToLeftBtn.Text = "<-";
			this.ToLeftBtn.UseVisualStyleBackColor = true;
			// 
			// KaemmeLbl
			// 
			this.KaemmeLbl.AutoSize = true;
			this.KaemmeLbl.Location = new System.Drawing.Point(9, 9);
			this.KaemmeLbl.Name = "KaemmeLbl";
			this.KaemmeLbl.Size = new System.Drawing.Size(174, 13);
			this.KaemmeLbl.TabIndex = 18;
			this.KaemmeLbl.Text = "Existing answerback code (combs):";
			// 
			// WunschKgLbl
			// 
			this.WunschKgLbl.AutoSize = true;
			this.WunschKgLbl.Location = new System.Drawing.Point(448, 9);
			this.WunschKgLbl.Name = "WunschKgLbl";
			this.WunschKgLbl.Size = new System.Drawing.Size(134, 13);
			this.WunschKgLbl.TabIndex = 19;
			this.WunschKgLbl.Text = "Desired answerback code:";
			// 
			// KgNew
			// 
			this.KgNew.Location = new System.Drawing.Point(451, 26);
			this.KgNew.Name = "KgNew";
			this.KgNew.Size = new System.Drawing.Size(217, 548);
			this.KgNew.TabIndex = 14;
			// 
			// KgOrg
			// 
			this.KgOrg.Location = new System.Drawing.Point(12, 26);
			this.KgOrg.Name = "KgOrg";
			this.KgOrg.Size = new System.Drawing.Size(400, 548);
			this.KgOrg.TabIndex = 13;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1065, 584);
			this.Controls.Add(this.WunschKgLbl);
			this.Controls.Add(this.KaemmeLbl);
			this.Controls.Add(this.ToLeftBtn);
			this.Controls.Add(this.ToRightBtn);
			this.Controls.Add(this.NewKennungTb);
			this.Controls.Add(this.KgNew);
			this.Controls.Add(this.KgOrg);
			this.Controls.Add(this.SaveBtn);
			this.Controls.Add(this.LoadBtn);
			this.Controls.Add(this.GenWunschKennungBtn);
			this.Controls.Add(this.WunschKennungTb);
			this.Controls.Add(this.WunschKennungLbl);
			this.Controls.Add(this.OrgKennungLbl);
			this.Controls.Add(this.OrgKennungTb);
			this.Name = "MainForm";
			this.Text = "Kennungsgeber";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox OrgKennungTb;
		private System.Windows.Forms.Label OrgKennungLbl;
		private System.Windows.Forms.Label WunschKennungLbl;
		private System.Windows.Forms.TextBox WunschKennungTb;
		private System.Windows.Forms.Button GenWunschKennungBtn;
		private System.Windows.Forms.Button LoadBtn;
		private System.Windows.Forms.Button SaveBtn;
		private KgListView KgOrg;
		private KgListView KgNew;
		private System.Windows.Forms.TextBox NewKennungTb;
		private System.Windows.Forms.Button ToRightBtn;
		private System.Windows.Forms.Button ToLeftBtn;
		private System.Windows.Forms.Label KaemmeLbl;
		private System.Windows.Forms.Label WunschKgLbl;
	}
}

