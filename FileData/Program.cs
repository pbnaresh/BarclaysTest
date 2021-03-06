﻿using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        #region private members
        private const string SIZE_FORMATS="sizeArgumentFormats";
        private const string VERSION_FORMATS="versionArgumentFormats";

        private const string SIZE = "size";
        private const string VERSION = "version";
        #endregion
        public static void Main(string[] args)
        {

            #region initialzation
            string sizeOrVersion = string.Empty;
            FileDetails fileDetails = new FileDetails(); //this can be injected if DI is implemented to follow SINGLE RESPONSIBILITY PRINCIPLE 
            #endregion

          
            if (args.Length!=2)
            {
                Console.WriteLine("Please enter correct number of arguments. i.e. 2");
                Console.ReadKey();
                return;
            }
            //Format values are configured in app.config for flexibility in modifications wihout building code
            if(!validateArgSizeOrVersionFormat(args[0],out sizeOrVersion))
            {
                Console.WriteLine("Please enter first argument from any of these values –v, --v, /v, --version  or –s, --s, /s, --size");
                Console.ReadKey();
                return;
            }
                
           
            string filePath = args[1];//not validating this argument on purpose as mentioned in requirements

            Console.WriteLine(sizeOrVersion == SIZE ? 
                "Size of file : " +fileDetails.Size(filePath).ToString() : "Version of file : "+ fileDetails.Version(filePath));

            //wait until key is pressed
            Console.ReadKey();
        }
        /// <summary>
        /// Validate the first paramater against the given formats
        /// </summary>
        /// <param name="sizeOrVersionFormat">input paramater to check if format is valid</param>
        /// <param name="outSizeOrVersion"> if input format is correct then set its corresponding format(size/version)</param>
        /// <returns></returns>
        private static bool validateArgSizeOrVersionFormat(string sizeOrVersionFormat, out string outSizeOrVersion)
        {
            bool isValidated = true;
            IConfigSettings configSettings = new ConfigSettings(); //this can be injected if DI is implemented to follow SINGLE RESPONSIBILITY PRINCIPLE 

            if (Array.IndexOf(configSettings.GetConfigValuesByKey(SIZE_FORMATS),sizeOrVersionFormat)>-1)
                outSizeOrVersion = SIZE;

            else if (Array.IndexOf(configSettings.GetConfigValuesByKey(VERSION_FORMATS),sizeOrVersionFormat)>-1)
                outSizeOrVersion = VERSION;
            else
            {
                isValidated = false;
                outSizeOrVersion = null;
            }
            return isValidated;

        }
       
        
    }
}
