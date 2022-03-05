using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;

namespace ABV2_Updater
{
	// Token: 0x02000003 RID: 3
	internal class Program
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002126 File Offset: 0x00000326
		public static void Start()
		{
			Console.Title = "ABV2 Updater";
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("█████╗ ██████╗ ██╗   ██╗██████╗\n██╔══██╗██╔══██╗██║   ██║╚════██╗\n███████║██████╔╝██║   ██║ █████╔╝\n██╔══██║██╔══██╗╚██╗ ██╔╝██╔═══╝\n██║  ██║██████╔╝ ╚████╔╝ ███████╗\n╚═╝  ╚═╝╚═════╝   ╚═══╝  ╚══════╝");
			Console.ResetColor();
			Process.Start("https://discord.com/invite/EeUWcPsQC6");
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002154 File Offset: 0x00000354
		public static void Download()
		{
			WebClient webClient = new WebClient();
			if (!webClient.DownloadString("https://pastebin.com/raw/jX0RemHF").Contains("1.0"))
			{
				Functions.WARN("Your version of the bootsrapper is outdated! We recommend you install the most up to date one.");
				Process.Start("https://altbot.xyz");
			}
			Functions.INFO("Starting Download");
			try
			{
				webClient.DownloadFile("https://www.novaline.xyz/cdn/altbot.zip", "Altbot.zip");
			}
			catch (Exception)
			{
				Functions.ERROR("There was an error when installing the files");
			}
			Functions.SUCCESS("Files Downloaded");
			webClient.Dispose();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021DC File Offset: 0x000003DC
		public static void Extract()
		{
			Functions.INFO("Extraction Starting");
			try
			{
				ZipFile.ExtractToDirectory("Altbot.zip", ".");
			}
			catch (Exception)
			{
				Functions.ERROR("There was an error when extrating the files");
			}
			Functions.SUCCESS("Extraction Complete");
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000222C File Offset: 0x0000042C
		public static void CleanUp()
		{
			Functions.INFO("Cleaning Up");
			try
			{
				if (File.Exists("./Altbot.zip"))
				{
					File.Delete("./Altbot.zip");
				}
			}
			catch (Exception)
			{
				Functions.ERROR("There was an error when cleaning up");
			}
			Functions.SUCCESS("Clean Up Complete");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002284 File Offset: 0x00000484
		public static void Complete()
		{
			Functions.INFO("Installation Complete, Closing In 3 Secs");
			Thread.Sleep(3000);
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022A4 File Offset: 0x000004A4
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
