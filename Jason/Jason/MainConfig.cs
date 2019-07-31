using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Exchange.WebServices.Data;

namespace Jason
{
	// Token: 0x02000003 RID: 3
	internal class MainConfig
	{
		// Token: 0x04000036 RID: 54
		public static Form1 MainFormInstase;

		// Token: 0x04000037 RID: 55
		public static StreamReader StreamPassword;

		// Token: 0x04000038 RID: 56
		public static List<UserClass> Usernames;

		// Token: 0x04000039 RID: 57
		public static Uri ExchangeUrl;

		// Token: 0x0400003A RID: 58
		public static ExchangeVersion ExchangeVersion;

		// Token: 0x0400003B RID: 59
		public static string AppLocation;

		// Token: 0x0400003C RID: 60
		public static int ThreadCount;

		// Token: 0x0400003D RID: 61
		public static int MaxTryForPass = 4;

		// Token: 0x0400003E RID: 62
		public static int DelayBetweenTrys = 0;

		// Token: 0x0400003F RID: 63
		public static string Method = "EWS";

		// Token: 0x04000040 RID: 64
		public static string UsernameStart;

		// Token: 0x04000041 RID: 65
		public static string UsernameEnd;

		// Token: 0x04000042 RID: 66
		public static int[] TryTimeIncrease = new int[]
		{
			10000,
			60000,
			900000,
			1800000
		};
	}
}
