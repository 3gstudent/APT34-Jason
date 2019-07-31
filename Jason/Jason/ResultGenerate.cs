using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Jason
{
	// Token: 0x02000007 RID: 7
	public partial class ResultGenerate : Form
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002193 File Offset: 0x00000393
		public ResultGenerate(string listPassword)
		{
			this.InitializeComponent();
			this.textBox1.Text = listPassword;
		}
	}
}
