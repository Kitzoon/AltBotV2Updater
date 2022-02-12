using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;

namespace ABV2_Updater
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Start()
		{
			Console.Title = "AltBotV2 Updater";
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("\r\n   _____  .__   __ __________        __ ____   ____________  \r\n  /  _  \\ |  |_/  |\\______   \\ _____/  |\\   \\ /   /\\_____  \\ \r\n /  /_\\  \\|  |\\   __\\    |  _//  _ \\   __\\   Y   /  /  ____/ \r\n/    |    \\  |_|  | |    |   (  <_> )  |  \\     /  /       \\ \r\n\\____|__  /____/__| |______  /\\____/|__|   \\___/   \\_______ \\\r\n        \\/                 \\/                              \\/\r\n");
			bool flag = File.Exists("altbot.exe");
			if (flag)
			{
				File.Delete("altbot.exe");
			}
			bool flag2 = File.Exists("./altbot");
			if (flag2)
			{
				File.Delete("./altbot");
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B4 File Offset: 0x000002B4
		public static void Download()
		{
			WebClient webClient = new WebClient();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Starting download");
			webClient.DownloadFile("https://altbot-files.000webhostapp.com/Files/altbot.zip", "Altbot.zip");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[SUCCESS] Files downloaded");
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002100 File Offset: 0x00000300
		public static void Extract()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Extraction starting");
			ZipFile.ExtractToDirectory("Altbot.zip", "altbot");
			File.Move("./altbot/altbot.exe", "altbot.exe");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[SUCCESS] Extraction complete");
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002154 File Offset: 0x00000354
		public static void CleanUp()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Cleaning up unnecessary files");
			bool flag = File.Exists("Altbot.zip");
			bool flag2 = flag;
			if (flag2)
			{
				File.Delete("Altbot.zip");
			}
			bool flag3 = File.Exists("altbot");
			bool flag4 = flag3;
			if (flag4)
			{
				File.Delete("altbot");
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[SUCCESS] Clean up complete");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021C2 File Offset: 0x000003C2
		public static void Complete()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Installation complete, closing in 3 secs");
			Thread.Sleep(3000);
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021EE File Offset: 0x000003EE
		private static void Main(string[] args)
		{
			Program.Start();
			Program.Download();
			Program.Extract();
			Program.CleanUp();
			Program.Complete();
		}
	}
}
