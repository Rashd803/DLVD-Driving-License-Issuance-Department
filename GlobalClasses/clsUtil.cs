using System;
using System.IO;


namespace BusinessLayer
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public static bool CreateFolderIfNotExist(ref string destinationFolder)
        {
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
                Console.WriteLine($"Folder '{destinationFolder}' has been created.");
                return false;
            }
            else 
            { 
                Console.WriteLine($"Folder '{destinationFolder}' already exists.");
                return true;
            }
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo FI = new FileInfo(FileName);
            string extn = FI.Extension;
            
            return GenerateGUID() + extn;
        }


        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Iamges\";
            if(!CreateFolderIfNotExist(ref DestinationFolder))
            {
                return false;
            }

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch(IOException iox)
            {
                Console.WriteLine(iox.ToString());
                return false;
            }

            SourceFile = DestinationFile;

            return true;
        }


    }
}
