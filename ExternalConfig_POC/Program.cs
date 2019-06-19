using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExternalConfig_POC
{
    class Program
    {
        static void Main(string[] args)
        {
               SetConfigFileAtRuntime(@"C:\Users\Md.Javed\Downloads\ExternalConfig.config");

            string Web_App_Name = ConfigurationManager.AppSettings["Web_App_Name"];
            string Web_App_Id = ConfigurationManager.AppSettings["Web_App_ID"];

            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings.Remove("demo");
            //config.AppSettings.Settings.Add("Username", "dd");
            //config.Save(ConfigurationSaveMode.Modified);
            ////config.AppSettings.Settings.Add("OS", "Linux");
            ////config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");
            //config.AppSettings.SectionInformation.ForceSave = true;
            ////  ConfigurationManager.RefreshSection("appSettings");
            
            ////Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);


            //AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");


            //appSettings.Settings.Clear();


            //appSettings.Settings.Add("name", "bar");
            //appSettings.Settings.Add("age", "30");
            //appSettings.Settings.Add("location", "Canada");


            //ConfigurationManager.RefreshSection("appSettings");
            //config.Save();

            string str = string.Empty;

            str = ConfigurationManager.AppSettings.Get("name");
            var str2 = ConfigurationManager.AppSettings.Get("age");
            var str3 = ConfigurationManager.AppSettings.Get("location");


        }

        protected static void SetConfigFileAtRuntime(string configFilePath)
        {

            if (File.Exists(configFilePath))
            {
                string runtimeconfigfile;

                if (configFilePath.Length == 0)
                {
                    Console.WriteLine("Please specify a config file to read from ");
                    Console.Write("> "); // prompt
                    runtimeconfigfile = Console.ReadLine();
                }
                else
                {
                    runtimeconfigfile = configFilePath;
                }

                // Specify config settings at runtime.
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //Similarly you can apply for other sections like SMTP/System.Net/System.Web etc..
                //But you have to set the File Path for each of these
                config.AppSettings.File = runtimeconfigfile;
                config.AppSettings.Settings.Add("test", "test2");
                //This doesn't actually going to overwrite you Exe App.Config file.
                //Just refreshing the content in the memory.
                config.Save(ConfigurationSaveMode.Modified);

                //Refreshing Config Section
               // ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                Console.WriteLine("No file present");
            }
        }
    }
}
