using PineconeGames.Core.Patterns;
using PineconeGames.Core.Zippers;
using System;
using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace PineconeGames.CoreUnity.Zippers.SystemIOCompression
{
    public class SystemIOCompressionZipper : Singleton<SystemIOCompressionZipper>, IZipper
    {
        #region Zipper Functions

        public bool ExtractZip(string zipFilePath)
        {
            bool result = false;

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(zipFilePath);
                string currentDirectory = Path.GetDirectoryName(zipFilePath);
                string folderPath = Path.Combine(currentDirectory, fileName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                ZipFile.ExtractToDirectory(zipFilePath, folderPath);

                result = true;
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("SystemIOCompressionZipper.ExtractZip({0}) failed. Reason: {1}", zipFilePath, ex.Message));
            }

            return result;
        }

        public bool ZipFolder(string folderPath)
        {
            bool result = false;

            try
            {
                string folderName = Path.GetFileName(folderPath);
                string upperFolderPath = Path.GetDirectoryName(folderPath);
                string zipFilePath = Path.Combine(upperFolderPath, folderName + ".zip");

                ZipFile.CreateFromDirectory(folderPath, zipFilePath);

                result = true;
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("SystemIOCompressionZipper.ZipFolder({0}) failed. Reason: {1}", folderPath, ex.Message));
            }

            return result;
        }

        #endregion
    }
}