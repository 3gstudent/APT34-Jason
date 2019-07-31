namespace Jason
{
	// Token: 0x02000007 RID: 7
	public partial class ResultGenerate : global::System.Windows.Forms.Form
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000021AD File Offset: 0x000003AD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00005074 File Offset: 0x00003274
		private void InitializeComponent()
		{
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox1.HideSelection = false;
			this.textBox1.Location = new global::System.Drawing.Point(12, 12);
			this.textBox1.MaxLength = 0;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new global::System.Drawing.Size(631, 530);
			this.textBox1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(655, 554);
			base.Controls.Add(this.textBox1);
			base.Name = "ResultGenerate";
			this.Text = "ResultGenerate";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000049 RID: 73
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.TextBox textBox1;
	}
}
