﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Logger
{
    public static class LoggerFactory
    {
        public static string Directory_ = string.Empty;
        public static string File_ = string.Empty;

        public static void AddFile(string directory = "", string file = "")
        {
            if (directory != "")
            {
                Directory_ = directory;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
                
            if (file != "")
            {
                File_ = file;
            }
                
        }

        public static async Task LogInformation(string info)
        {
            string path = Path.Combine(Directory_, File_);
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                await sw.WriteLineAsync(DateTime.Now.ToString() + " - [INF]: " + info);
            }
        }

        public static async Task LogError(Exception e)
        {
            string path = Path.Combine(Directory_, File_);
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                await sw.WriteLineAsync(DateTime.Now.ToString() + " - [ERR]: " + e.GetType().FullName);
                await sw.WriteLineAsync(e.Message);
                while(e.InnerException != null)
                {
                    e = e.InnerException;
                    await sw.WriteLineAsync(Environment.NewLine + e.GetType().FullName + 
                                      Environment.NewLine + e.Message);
                }
            }
        }


    }
}