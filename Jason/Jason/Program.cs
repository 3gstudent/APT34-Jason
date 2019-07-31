using System;
using System.Windows.Forms;

namespace Jason
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x0600001F RID: 31 RVA: 0x0000217C File Offset: 0x0000037C
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
