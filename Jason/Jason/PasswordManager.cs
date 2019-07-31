using System;
using System.Collections.Generic;
using System.IO;

namespace Jason
{
	// Token: 0x02000005 RID: 5
	internal class PasswordManager
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000213B File Offset: 0x0000033B
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002142 File Offset: 0x00000342
		private static string PasswordPattern { get; set; }

		// Token: 0x06000019 RID: 25 RVA: 0x00004DC4 File Offset: 0x00002FC4
		public static bool GetNext(out string password)
		{
			bool result = false;
			password = PasswordManager.PasswordPattern;
			string newValue = string.Empty;
			if (PasswordManager.Patterns != null)
			{
				foreach (PasswordManager.Pattern pattern in PasswordManager.Patterns)
				{
					if (pattern.IsFile)
					{
						if ((newValue = pattern.StreamFile.ReadLine()) != null)
						{
							result = true;
							password = password.Replace(pattern.PatternString, newValue);
						}
					}
					else if (!pattern.IsUser)
					{
						password = password.Replace(pattern.PatternString, pattern.PatternValue);
					}
					if (pattern.IsFirstTime)
					{
						result = true;
						pattern.IsFirstTime = false;
					}
				}
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004E84 File Offset: 0x00003084
		public static void SetPassword(string passwordPattern)
		{
			PasswordManager.PasswordPattern = passwordPattern;
			if (PasswordManager.Patterns == null)
			{
				PasswordManager.Patterns = new List<PasswordManager.Pattern>();
			}
			else
			{
				PasswordManager.Patterns.Clear();
			}
			int num = -1;
			int num2;
			while ((num = PasswordManager.PasswordPattern.IndexOf('[', num + 1)) >= 0 && (num2 = PasswordManager.PasswordPattern.IndexOf(']', num)) >= 0)
			{
				PasswordManager.Pattern pattern = new PasswordManager.Pattern(PasswordManager.PasswordPattern.Substring(num, num2 - num + 1), num, num2);
				if (pattern.IsOk)
				{
					PasswordManager.Patterns.Add(pattern);
				}
				if (pattern.IsUser)
				{
					PasswordManager.HasUser = true;
				}
				num = num2;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000214A File Offset: 0x0000034A
		public static bool HasPattern(string pattern)
		{
			return pattern.Contains("[");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004F1C File Offset: 0x0000311C
		public static string CheckUser(string password, UserClass username)
		{
			string text = password;
			if (PasswordManager.HasUser)
			{
				foreach (PasswordManager.Pattern pattern in PasswordManager.Patterns)
				{
					if (pattern.IsUser)
					{
						if (pattern.IsFirstChar)
						{
							string text2 = username.Username.ToLower()[0].ToString();
							if (pattern.IsUpper || pattern.IsFirstUpper)
							{
								text2 = text2.ToUpper();
							}
							text = text.Replace(pattern.PatternString, text2);
						}
						else
						{
							string text3 = username.Username.ToLower();
							if (pattern.Part > 0 && pattern.Part <= username.UserParts.Count)
							{
								text3 = username.UserParts[pattern.Part - 1].ToLower();
							}
							if (pattern.IsUpper)
							{
								text3 = text3.ToUpper();
							}
							else if (pattern.IsFirstUpper)
							{
								text3 = text3[0].ToString().ToUpper() + text3.Substring(1);
							}
							text = text.Replace(pattern.PatternString, text3);
						}
					}
				}
			}
			return text;
		}

		// Token: 0x04000043 RID: 67
		private static List<PasswordManager.Pattern> Patterns;

		// Token: 0x04000044 RID: 68
		private static bool HasUser;

		// Token: 0x04000046 RID: 70
		private static string KeywordUser = "[user@";

		// Token: 0x04000047 RID: 71
		private static string KeywordDomain = "[domain@";

		// Token: 0x04000048 RID: 72
		private static string KeywordFile = "[file@";

		// Token: 0x0200000E RID: 14
		private class Pattern
		{
			// Token: 0x06000060 RID: 96 RVA: 0x0000588C File Offset: 0x00003A8C
			public Pattern(string pattern, int iStart, int iEnd)
			{
				this.IsUser = false;
				this.IsLower = false;
				this.IsFirstUpper = false;
				this.IsUpper = false;
				this.IndexStart = iStart;
				this.IndexEnd = iEnd;
				this.IsOk = false;
				this.StreamFile = null;
				this.FileName = string.Empty;
				this.IsFile = false;
				this.PatternValue = string.Empty;
				this.IsFirstChar = false;
				this.IsFirstTime = true;
				this.PatternString = pattern;
				int num;
				if ((num = this.PatternString.IndexOf('@')) >= 0)
				{
					if (int.TryParse(this.PatternString.Substring(num + 1, this.PatternString.Length - num - 2), out this.Part))
					{
						this.IsOk = true;
					}
					else if (this.PatternString.StartsWith(PasswordManager.KeywordFile))
					{
						this.IsFile = true;
						string text = this.PatternString.Substring(num + 1, this.PatternString.Length - num - 2);
						text = MainConfig.AppLocation + "PasswordPatterns\\" + text + ".txt";
						if (File.Exists(text))
						{
							this.IsOk = true;
							this.StreamFile = new StreamReader(text);
						}
					}
					else if (this.PatternString.ToLower().StartsWith(PasswordManager.KeywordUser) && this.PatternString.Split(new char[]
					{
						'@'
					})[1].ToLower() == "first]")
					{
						this.IsOk = true;
						this.IsFirstChar = true;
					}
				}
				if (char.IsLower(this.PatternString[1]))
				{
					this.IsLower = true;
				}
				else if (char.IsUpper(this.PatternString[2]))
				{
					this.IsUpper = true;
				}
				else
				{
					this.IsFirstUpper = true;
				}
				if (this.PatternString.ToLower().StartsWith(PasswordManager.KeywordUser))
				{
					this.IsUser = true;
				}
				else if (this.PatternString.ToLower().StartsWith(PasswordManager.KeywordDomain))
				{
					if (this.Part == 0)
					{
						this.PatternValue = MainConfig.ExchangeUrl.Authority.ToLower();
					}
					else
					{
						this.PatternValue = MainConfig.ExchangeUrl.Authority.Split(new char[]
						{
							'.'
						})[this.Part - 1].ToLower();
					}
				}
				if (!this.IsUser)
				{
					if (this.IsUpper)
					{
						this.PatternValue = this.PatternValue.ToUpper();
						return;
					}
					if (this.IsFirstUpper)
					{
						this.PatternValue = this.PatternValue[0].ToString().ToUpper() + this.PatternValue.Substring(1);
					}
				}
			}

			// Token: 0x0400006A RID: 106
			public bool IsUser;

			// Token: 0x0400006B RID: 107
			public string PatternString;

			// Token: 0x0400006C RID: 108
			public int Part;

			// Token: 0x0400006D RID: 109
			public string PatternValue;

			// Token: 0x0400006E RID: 110
			public bool IsLower;

			// Token: 0x0400006F RID: 111
			public bool IsFirstUpper;

			// Token: 0x04000070 RID: 112
			public bool IsUpper;

			// Token: 0x04000071 RID: 113
			public int IndexStart;

			// Token: 0x04000072 RID: 114
			public int IndexEnd;

			// Token: 0x04000073 RID: 115
			public bool IsFile;

			// Token: 0x04000074 RID: 116
			public StreamReader StreamFile;

			// Token: 0x04000075 RID: 117
			public string FileName;

			// Token: 0x04000076 RID: 118
			public bool IsFirstChar;

			// Token: 0x04000077 RID: 119
			public bool IsFirstTime;

			// Token: 0x04000078 RID: 120
			public bool IsOk;
		}
	}
}
