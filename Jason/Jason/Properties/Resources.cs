using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Jason.Properties
{
	// Token: 0x0200000A RID: 10
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00002105 File Offset: 0x00000305
		internal Resources()
		{
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002254 File Offset: 0x00000454
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Jason.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002280 File Offset: 0x00000480
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002287 File Offset: 0x00000487
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400005E RID: 94
		private static ResourceManager resourceMan;

		// Token: 0x0400005F RID: 95
		private static CultureInfo resourceCulture;
	}
}
