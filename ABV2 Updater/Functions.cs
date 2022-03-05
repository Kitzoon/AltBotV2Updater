using System;

namespace ABV2_Updater
{
	// Token: 0x02000002 RID: 2
	internal class Functions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static bool Write(string text)
		{
			Console.Write(text);
			Console.ResetColor();
			return true;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205E File Offset: 0x0000025E
		public static void INFO(string text)
		{
			Functions.Write("[");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Functions.Write("INFO");
			Functions.Write("] ");
			Console.WriteLine(text);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000208E File Offset: 0x0000028E
		public static void ERROR(string text)
		{
			Functions.Write("[");
			Console.ForegroundColor = ConsoleColor.Red;
			Functions.Write("ERROR");
			Functions.Write("] ");
			Console.WriteLine(text);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020BE File Offset: 0x000002BE
		public static void WARN(string text)
		{
			Functions.Write("[");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Functions.Write("WARNING");
			Functions.Write("] ");
			Console.WriteLine(text);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020EE File Offset: 0x000002EE
		public static void SUCCESS(string text)
		{
			Functions.Write("[");
			Console.ForegroundColor = ConsoleColor.Green;
			Functions.Write("SUCCESS");
			Functions.Write("] ");
			Console.WriteLine(text);
		}
	}
}
