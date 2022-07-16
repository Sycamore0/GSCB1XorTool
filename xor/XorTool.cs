using System;
using System.IO;
using System.Text;
using xor.Properties;

namespace xor
{
	internal class XorTool
	{
		public static void DecryptFolder(string path)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] files = directoryInfo.GetFiles();
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (FileInfo fileInfo in files)
			{
				if (fileInfo.Extension == ".asb")
				{
					XorTool.Decrypt(fileInfo.FullName);
				}
			}
			DirectoryInfo[] array2 = directories;
			for (int i = 0; i < array2.Length; i++)
			{
				XorTool.DecryptFolder(array2[i].FullName);
			}
		}

		public static void Decrypt(string path)
		{
			byte[] array = new byte[612];
			int[] array2 = new int[] { 612, 612, 612, 612, 112 };
			int num = 0;
			byte[] key = Resources.key64;
			FileStream fileStream = File.OpenRead(path);
			FileStream fileStream2 = new FileStream(path + ".decrypted", FileMode.Create);
			byte[] array3 = new byte[4];
			fileStream.Read(array3, 0, 4);
			if (!(Encoding.ASCII.GetString(array3) == "mark"))
			{
				XorTool.SetText(Path.GetFileName(path) + " Not an encrypted file.Skip...");
				return;
			}
			for (;;)
			{
				int num2 = fileStream.Read(array, 0, array2[num]);
				int num3 = (int)(fileStream2.Position % 64L);
				for (int i = 0; i < num2; i++)
				{
					byte[] array4 = array;
					int num4 = i;
					array4[num4] ^= key[(num3 + i) % 64];
				}
				fileStream2.Write(array, 0, num2);
				if (num2 < array2[num])
				{
					break;
				}
				fileStream.Position += 4L;
				num = (num + 1) % 5;
			}
			XorTool.SetText(Path.GetFileName(path) + " Decryption complete!");
			fileStream.Close();
			fileStream2.Close();
		}

		public static void Encrypt(string path)
		{
			byte[] array = new byte[616];
			int[] array2 = new int[] { 612, 612, 612, 612, 112 };
			int num = 0;
			byte[] key = Resources.key64;
			FileStream fileStream = new FileStream(path, FileMode.Open);
			if (path.EndsWith(".decrypted"))
			{
				path = path.Replace(".decrypted", string.Empty);
			}
			FileStream fileStream2 = new FileStream(path + ".encrypted", FileMode.Create);
			fileStream2.Write(Encoding.Default.GetBytes("mark"), 0, 4);
			while (fileStream.Position < fileStream.Length)
			{
				long position = fileStream.Position;
				int num2 = fileStream.Read(array, 0, array2[num]);
				for (int i = 0; i < num2; i++)
				{
					byte[] array3 = array;
					int num3 = i;
					checked
					{
						array3[num3] ^= key[(int)((IntPtr)(unchecked(position + (long)i) % 64L))];
					}
				}
				fileStream2.Write(array, 0, num2);
				if (num2 == array2[num])
				{
					fileStream2.Write(array, 0, 4);
				}
				else if (num2 < array2[num])
				{
					break;
				}
				num = (num + 1) % 5;
			}
			XorTool.SetText(Path.GetFileName(path) + " Encryption complete");
			fileStream.Close();
			fileStream2.Close();
		}

		public static Action<string> SetText;

		public static Action enablebutton;
	}
}
