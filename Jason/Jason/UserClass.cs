using System;
using System.Collections.Generic;

namespace Jason
{
	// Token: 0x02000009 RID: 9
	internal class UserClass
	{
		// Token: 0x06000035 RID: 53 RVA: 0x000057F8 File Offset: 0x000039F8
		public UserClass(string username)
		{
			this.IsDone = false;
			this.Username = username;
			this.UserParts = new List<string>(this.Username.Split(new string[]
			{
				this.Seprator1
			}, StringSplitOptions.None));
			if (this.UserParts.Count == 1)
			{
				this.UserParts = new List<string>(this.Username.Split(new string[]
				{
					this.Seprator2
				}, StringSplitOptions.None));
			}
		}

		// Token: 0x04000059 RID: 89
		public string Username;

		// Token: 0x0400005A RID: 90
		public List<string> UserParts;

		// Token: 0x0400005B RID: 91
		private string Seprator1 = ".";

		// Token: 0x0400005C RID: 92
		private string Seprator2 = "_";

		// Token: 0x0400005D RID: 93
		public bool IsDone;
	}
}
