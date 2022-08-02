namespace Kennungsgeber
{
	partial class KgListView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.KgView = new System.Windows.Forms.DataGridView();
			this.SwapVertBtn = new Kennungsgeber.NoPaddingButton();
			this.SwapHorizBtn = new Kennungsgeber.NoPaddingButton();
			this.UpBtn = new Kennungsgeber.NoPaddingButton();
			this.DownBtn = new Kennungsgeber.NoPaddingButton();
			this.InsBtn = new Kennungsgeber.NoPaddingButton();
			this.DelBtn = new Kennungsgeber.NoPaddingButton();
			this.ClearBtn = new Kennungsgeber.NoPaddingButton();
			((System.ComponentModel.ISupportInitialize)(this.KgView)).BeginInit();
			this.SuspendLayout();
			// 
			// KgView
			// 
			this.KgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.KgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.KgView.Location = new System.Drawing.Point(0, 0);
			this.KgView.Name = "KgView";
			this.KgView.Size = new System.Drawing.Size(400, 308);
			this.KgView.TabIndex = 0;
			this.KgView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KgView_CellClick);
			this.KgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KgView_CellDoubleClick);
			// 
			// SwapVertBtn
			// 
			this.SwapVertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SwapVertBtn.Location = new System.Drawing.Point(233, 316);
			this.SwapVertBtn.Name = "SwapVertBtn";
			this.SwapVertBtn.Size = new System.Drawing.Size(39, 23);
			this.SwapVertBtn.TabIndex = 8;
			this.SwapVertBtn.Text = "VS";
			this.SwapVertBtn.UseVisualStyleBackColor = true;
			this.SwapVertBtn.Click += new System.EventHandler(this.SwapVertBtn_Click);
			// 
			// SwapHorizBtn
			// 
			this.SwapHorizBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SwapHorizBtn.Location = new System.Drawing.Point(188, 316);
			this.SwapHorizBtn.Name = "SwapHorizBtn";
			this.SwapHorizBtn.Size = new System.Drawing.Size(39, 23);
			this.SwapHorizBtn.TabIndex = 9;
			this.SwapHorizBtn.Text = "HS";
			this.SwapHorizBtn.UseVisualStyleBackColor = true;
			this.SwapHorizBtn.Click += new System.EventHandler(this.SwapHorizBtn_Click);
			// 
			// UpBtn
			// 
			this.UpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.UpBtn.Location = new System.Drawing.Point(313, 316);
			this.UpBtn.Name = "UpBtn";
			this.UpBtn.Size = new System.Drawing.Size(39, 23);
			this.UpBtn.TabIndex = 10;
			this.UpBtn.Text = "Up";
			this.UpBtn.UseVisualStyleBackColor = true;
			this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
			// 
			// DownBtn
			// 
			this.DownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DownBtn.Location = new System.Drawing.Point(358, 316);
			this.DownBtn.Name = "DownBtn";
			this.DownBtn.Size = new System.Drawing.Size(39, 23);
			this.DownBtn.TabIndex = 11;
			this.DownBtn.Text = "Down";
			this.DownBtn.UseVisualStyleBackColor = true;
			this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
			// 
			// InsBtn
			// 
			this.InsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.InsBtn.Location = new System.Drawing.Point(4, 316);
			this.InsBtn.Name = "InsBtn";
			this.InsBtn.Size = new System.Drawing.Size(46, 23);
			this.InsBtn.TabIndex = 12;
			this.InsBtn.Text = "Ins";
			this.InsBtn.UseVisualStyleBackColor = true;
			this.InsBtn.Click += new System.EventHandler(this.InsBtn_Click);
			// 
			// DelBtn
			// 
			this.DelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DelBtn.Location = new System.Drawing.Point(56, 316);
			this.DelBtn.Name = "DelBtn";
			this.DelBtn.Size = new System.Drawing.Size(46, 23);
			this.DelBtn.TabIndex = 13;
			this.DelBtn.Text = "Del";
			this.DelBtn.UseVisualStyleBackColor = true;
			this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
			// 
			// ClearBtn
			// 
			this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ClearBtn.Location = new System.Drawing.Point(108, 316);
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(46, 23);
			this.ClearBtn.TabIndex = 14;
			this.ClearBtn.Text = "Clr";
			this.ClearBtn.UseVisualStyleBackColor = true;
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// KgListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ClearBtn);
			this.Controls.Add(this.DelBtn);
			this.Controls.Add(this.InsBtn);
			this.Controls.Add(this.DownBtn);
			this.Controls.Add(this.UpBtn);
			this.Controls.Add(this.SwapHorizBtn);
			this.Controls.Add(this.SwapVertBtn);
			this.Controls.Add(this.KgView);
			this.Name = "KgListView";
			this.Size = new System.Drawing.Size(400, 339);
			((System.ComponentModel.ISupportInitialize)(this.KgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView KgView;
		private NoPaddingButton SwapVertBtn;
		private NoPaddingButton SwapHorizBtn;
		private NoPaddingButton UpBtn;
		private NoPaddingButton DownBtn;
		private NoPaddingButton InsBtn;
		private NoPaddingButton DelBtn;
		private NoPaddingButton ClearBtn;
	}
}
