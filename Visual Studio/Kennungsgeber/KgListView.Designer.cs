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
			this.AddBtn = new System.Windows.Forms.Button();
			this.InsBtn = new System.Windows.Forms.Button();
			this.DelBtn = new System.Windows.Forms.Button();
			this.UpBtn = new System.Windows.Forms.Button();
			this.DownBtn = new System.Windows.Forms.Button();
			this.SwapHorizBtn = new System.Windows.Forms.Button();
			this.SwapVertBtn = new System.Windows.Forms.Button();
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
			// AddBtn
			// 
			this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddBtn.Location = new System.Drawing.Point(0, 316);
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(50, 23);
			this.AddBtn.TabIndex = 1;
			this.AddBtn.Text = "Add";
			this.AddBtn.UseVisualStyleBackColor = true;
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
			// 
			// InsBtn
			// 
			this.InsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.InsBtn.Location = new System.Drawing.Point(56, 316);
			this.InsBtn.Name = "InsBtn";
			this.InsBtn.Size = new System.Drawing.Size(50, 23);
			this.InsBtn.TabIndex = 2;
			this.InsBtn.Text = "Ins";
			this.InsBtn.UseVisualStyleBackColor = true;
			this.InsBtn.Click += new System.EventHandler(this.InsBtn_Click);
			// 
			// DelBtn
			// 
			this.DelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DelBtn.Location = new System.Drawing.Point(112, 316);
			this.DelBtn.Name = "DelBtn";
			this.DelBtn.Size = new System.Drawing.Size(50, 23);
			this.DelBtn.TabIndex = 3;
			this.DelBtn.Text = "Del";
			this.DelBtn.UseVisualStyleBackColor = true;
			this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
			// 
			// UpBtn
			// 
			this.UpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.UpBtn.Location = new System.Drawing.Point(294, 316);
			this.UpBtn.Name = "UpBtn";
			this.UpBtn.Size = new System.Drawing.Size(50, 23);
			this.UpBtn.TabIndex = 4;
			this.UpBtn.Text = "Up";
			this.UpBtn.UseVisualStyleBackColor = true;
			this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
			// 
			// DownBtn
			// 
			this.DownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DownBtn.Location = new System.Drawing.Point(350, 316);
			this.DownBtn.Name = "DownBtn";
			this.DownBtn.Size = new System.Drawing.Size(50, 23);
			this.DownBtn.TabIndex = 5;
			this.DownBtn.Text = "Down";
			this.DownBtn.UseVisualStyleBackColor = true;
			this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
			// 
			// SwapHorizBtn
			// 
			this.SwapHorizBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SwapHorizBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SwapHorizBtn.Location = new System.Drawing.Point(183, 316);
			this.SwapHorizBtn.Name = "SwapHorizBtn";
			this.SwapHorizBtn.Size = new System.Drawing.Size(40, 23);
			this.SwapHorizBtn.TabIndex = 6;
			this.SwapHorizBtn.Text = "HS";
			this.SwapHorizBtn.UseVisualStyleBackColor = true;
			this.SwapHorizBtn.Click += new System.EventHandler(this.SwapHorizBtn_Click);
			// 
			// SwapVertBtn
			// 
			this.SwapVertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SwapVertBtn.Location = new System.Drawing.Point(229, 316);
			this.SwapVertBtn.Name = "SwapVertBtn";
			this.SwapVertBtn.Size = new System.Drawing.Size(40, 23);
			this.SwapVertBtn.TabIndex = 7;
			this.SwapVertBtn.Text = "VS";
			this.SwapVertBtn.UseVisualStyleBackColor = true;
			this.SwapVertBtn.Click += new System.EventHandler(this.SwapVertBtn_Click);
			// 
			// KgListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SwapVertBtn);
			this.Controls.Add(this.SwapHorizBtn);
			this.Controls.Add(this.DownBtn);
			this.Controls.Add(this.UpBtn);
			this.Controls.Add(this.DelBtn);
			this.Controls.Add(this.InsBtn);
			this.Controls.Add(this.AddBtn);
			this.Controls.Add(this.KgView);
			this.Name = "KgListView";
			this.Size = new System.Drawing.Size(400, 339);
			((System.ComponentModel.ISupportInitialize)(this.KgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView KgView;
		private System.Windows.Forms.Button AddBtn;
		private System.Windows.Forms.Button InsBtn;
		private System.Windows.Forms.Button DelBtn;
		private System.Windows.Forms.Button UpBtn;
		private System.Windows.Forms.Button DownBtn;
		private System.Windows.Forms.Button SwapHorizBtn;
		private System.Windows.Forms.Button SwapVertBtn;
	}
}
