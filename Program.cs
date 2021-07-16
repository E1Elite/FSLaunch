using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace FSLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
			string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
			string syringe = "syringe.exe";
			string fsExe = "FinalSun.exe";
			string fsDat = "FinalSun.dat";
			string fsTIExe = "FinalTI.exe";
			string fsTIDat = "FinalTI.dat";
			string fsDTAExe = "FinalSun_DTA.exe";
			string fsDTADat = "FinalSun_DTA.dat";
			string param = "";

			if (File.Exists(appPath + fsDTADat))
				param = fsDTADat;
			if (File.Exists(appPath + fsDTAExe))
				param = fsDTAExe;
			if (File.Exists(appPath + fsTIDat))
				param = fsTIDat;
			if (File.Exists(appPath + fsTIExe))
				param = fsTIExe;
			if (File.Exists(appPath + fsDat))
				param = fsDat;
			if (File.Exists(appPath + fsExe))
				param = fsExe;
			if (!string.IsNullOrEmpty(param))
				param = "\"" + param + "\"";

			StringBuilder sb = new StringBuilder();
			sb.Append(param);
			foreach (string value in args)
			{
				if (!string.IsNullOrEmpty(value.Trim()))
				{
					sb.Append(" ");
					sb.Append(value);
				}
			}
			string arguments = sb.ToString();

            try
		    {
				Process proc = new Process();
				proc.StartInfo.WorkingDirectory = appPath;
				proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				proc.StartInfo.FileName = syringe;
				proc.StartInfo.Arguments = arguments;
				proc.Start();
		    }
		    catch (Exception ) {   }
        }
    }
}
