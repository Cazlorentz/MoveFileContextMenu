using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


public class MoveTo : Form 
{

	public static string current_file_path;
	public static string new_file_path;
	public static string file_name;

	[STAThread]
	public static void Main(string[] args){
		if (args.Length > 0)
		{
			current_file_path = (string) args[0];
			file_name = (string) current_file_path.Replace(Path.GetDirectoryName(Environment.GetCommandLineArgs()[1]), "");
			var browser = new FolderBrowserDialog();

			if (browser.ShowDialog()==DialogResult.OK)
			{
				new_file_path = browser.SelectedPath + file_name;
			}else
			{
				Environment.Exit(1);
			}
			try
			{
				File.Move(current_file_path, new_file_path);	
			}catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}	
	}
}
