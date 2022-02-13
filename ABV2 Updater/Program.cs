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
			if (File.Exists("altbot.exe"))
			{
				File.Delete("altbot.exe");
			}
			if (Directory.Exists("altbot"))
			{
				Directory.Delete("altbot");
			}
			if (Directory.Exists("altbot.zip"))
			{
				Directory.Delete("altbot.zip");
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020BA File Offset: 0x000002BA
		public static void Download()
		{
			WebClient webClient = new WebClient();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Starting download");
			webClient.DownloadFile("https://www.novaline.xyz/cdn/altbot.zip", "Altbot.zip");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[SUCCESS] Files downloaded");
			webClient.Dispose();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020F8 File Offset: 0x000002F8
		public static void Extract()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Extraction starting");
			ZipFile.ExtractToDirectory("Altbot.zip", "altbot");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[SUCCESS] Extraction complete");
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000212C File Offset: 0x0000032C
		public static void CleanUp()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Cleaning up unnecessary files");
			if (Directory.Exists("Altbot.zip"))
			{
				Directory.Delete("Altbot.zip");
			}
			if (Directory.Exists("altbot"))
			{
				Directory.Delete("altbot");
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[SUCCESS] Clean up complete");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002187 File Offset: 0x00000387
		public static void Complete()
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("[INFO] Installation complete, closing in 3 secs");
			Thread.Sleep(3000);
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021AE File Offset: 0x000003AE
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
