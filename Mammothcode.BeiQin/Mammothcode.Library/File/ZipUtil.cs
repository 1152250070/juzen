using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Mammothcode.Library.File
{
    /// <summary>
    /// 为zip操作提供文件式和流式操作
    /// </summary>
    public static class ZipUtil
    {

        #region 基于文件压缩
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
        }
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory);
        }
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory, Encoding entryNameEncoding)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory, entryNameEncoding);
        }
        #endregion

        #region 基于文件解压
        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName)
        {
            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
        }
        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding entryNameEncoding)
        {
            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName, entryNameEncoding);
        }
        #endregion

        #region 基于流压缩
        public static MemoryStream CreateFromStream(FileName[] sourceFileNames)
        {
            var stream = new MemoryStream();
            using (ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Create))
            {
                foreach (var item in sourceFileNames)
                {
                    var entry = zipArchive.CreateEntry(Path.GetFileName(item.FullName));
                    using (var ems = entry.Open())
                    {
                        ems.Write(item.FileBytes, 0, item.FileBytes.Length);
                    }
                }
            }
            return stream;
        }
        #endregion

        #region 基于流解压缩
        public static FileName[] ExtractToStrem(Stream stream)
        {
            var fileNames = new List<FileName>();
            using (ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                foreach (var item in zipArchive.Entries)
                {
                    var strem = item.Open();
                    using (var ms = new MemoryStream())
                    {
                        strem.CopyTo(ms);
                        fileNames.Add(new FileName()
                        {
                            FileBytes=ms.ToArray(),
                            FullName = item.FullName
                        });
                    }
                }
            }
            return fileNames.ToArray();
        }

        #endregion

    }

    #region 文件模型
    public class FileName
    {
        /// <summary>
        /// 文件流
        /// </summary>
        public byte[] FileBytes { get; set; }
        /// <summary>
        /// 文件名（包括扩展名，但不含路径）
        /// </summary>
        public string FullName { get; set; }
    }
    #endregion
}
