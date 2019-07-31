using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jason.Properties
{
	// Token: 0x0200000B RID: 11
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003A RID: 58 RVA: 0x0000228F File Offset: 0x0000048F
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002296 File Offset: 0x00000496
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000022A8 File Offset: 0x000004A8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Address
		{
			get
			{
				return (string)this["Address"];
			}
			set
			{
				this["Address"] = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000022B6 File Offset: 0x000004B6
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000022C8 File Offset: 0x000004C8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Version
		{
			get
			{
				return (string)this["Version"];
			}
			set
			{
				this["Version"] = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000022D6 File Offset: 0x000004D6
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000022E8 File Offset: 0x000004E8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string UserPassFile
		{
			get
			{
				return (string)this["UserPassFile"];
			}
			set
			{
				this["UserPassFile"] = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000022F6 File Offset: 0x000004F6
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002308 File Offset: 0x00000508
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Separator
		{
			get
			{
				return (string)this["Separator"];
			}
			set
			{
				this["Separator"] = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002316 File Offset: 0x00000516
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002328 File Offset: 0x00000528
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string OutputFolder
		{
			get
			{
				return (string)this["OutputFolder"];
			}
			set
			{
				this["OutputFolder"] = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002336 File Offset: 0x00000536
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002348 File Offset: 0x00000548
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string FromDate
		{
			get
			{
				return (string)this["FromDate"];
			}
			set
			{
				this["FromDate"] = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002356 File Offset: 0x00000556
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002368 File Offset: 0x00000568
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string ToDate
		{
			get
			{
				return (string)this["ToDate"];
			}
			set
			{
				this["ToDate"] = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002376 File Offset: 0x00000576
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002388 File Offset: 0x00000588
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string IsDateEnable
		{
			get
			{
				return (string)this["IsDateEnable"];
			}
			set
			{
				this["IsDateEnable"] = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002396 File Offset: 0x00000596
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000023A8 File Offset: 0x000005A8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string PasswordFile
		{
			get
			{
				return (string)this["PasswordFile"];
			}
			set
			{
				this["PasswordFile"] = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000023B6 File Offset: 0x000005B6
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000023C8 File Offset: 0x000005C8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string ThreadCount
		{
			get
			{
				return (string)this["ThreadCount"];
			}
			set
			{
				this["ThreadCount"] = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000023D6 File Offset: 0x000005D6
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000023E8 File Offset: 0x000005E8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Method
		{
			get
			{
				return (string)this["Method"];
			}
			set
			{
				this["Method"] = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000023F6 File Offset: 0x000005F6
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002408 File Offset: 0x00000608
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string UsernameStart
		{
			get
			{
				return (string)this["UsernameStart"];
			}
			set
			{
				this["UsernameStart"] = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002416 File Offset: 0x00000616
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002428 File Offset: 0x00000628
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string UsernameEnd
		{
			get
			{
				return (string)this["UsernameEnd"];
			}
			set
			{
				this["UsernameEnd"] = value;
			}
		}

		// Token: 0x04000060 RID: 96
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
