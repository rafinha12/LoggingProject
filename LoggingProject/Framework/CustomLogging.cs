using System;
using System.IO;
using System.Reflection;

namespace Framework
{
    public class CustomLogging
    {   //Outputs for the logs
        private Boolean file;
        private Boolean console;
        private string path;
        //Session ID
        private int session;
        public enum code {USER = 0, APPLICATION = 1};

        public CustomLogging() 
        {
            this.file = false;
            this.console = true;
            this.path = "";
            this.session = new Random().Next(1, int.MaxValue);
        }

        public CustomLogging(Boolean file, Boolean console)
        {
            this.file = file;
            this.console = console;
            this.path = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"\\log.txt");
            this.session = new Random().Next(1, int.MaxValue);
        }
       
        public CustomLogging(Boolean file, Boolean console, String path)
        {
            this.file = file;
            this.console = console;
            this.path = path;
            this.session = new Random().Next(1, int.MaxValue);
        }

        public void Error(code errorCode, String msg)
        {
            writeLog(DateTime.Now.ToString() + "|| " + this.session + " Error " + (int)errorCode + ": "  + msg);

        }
        public void Warning(code errorCode, String msg)
        {
            writeLog(DateTime.Now.ToString() + "|| " + this.session + " Warning " + (int)errorCode + ": " + msg);
        }

        public void Fatal(code errorCode, String msg)
        {
            writeLog(DateTime.Now.ToString() + "|| " + this.session + " FATAL " + (int)errorCode + ": " + msg);
        }

        public void Info(String msg)
        {
            writeLog(DateTime.Now.ToString() + "|| " + this.session + " INFO: " + msg);
        }

        private void consoleLog(String msg)
        {
            Console.WriteLine(msg);
        }

        private void fileLog(String msg)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(msg);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(msg);
                }
            }
        }

        private void writeLog(String msg)
        {
            if (this.file == true) 
            {
                fileLog(msg);
            }
            if (this.console == true) 
            {
                consoleLog(msg);
            }
        }

    }
}
