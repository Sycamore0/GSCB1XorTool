using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace xor.Properties
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000028FA File Offset: 0x00000AFA
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002902 File Offset: 0x00000B02
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("xor.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000012 RID: 18 RVA: 0x0000292E File Offset: 0x00000B2E
		// (set) Token: 0x06000013 RID: 19 RVA: 0x00002935 File Offset: 0x00000B35
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

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000293D File Offset: 0x00000B3D
		internal static byte[] key64
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("key64", Resources.resourceCulture);
			}
		}

		// Token: 0x0400000B RID: 11
		private static ResourceManager resourceMan;

		// Token: 0x0400000C RID: 12
		private static CultureInfo resourceCulture;
	}
}
