using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using DeliManager.Models;
using System.Diagnostics;

namespace DeliManager.Common
{
    public class ImageHandler
    {

        public static string baseFolder = "ClientApp\\build";
        public static string UserImagePath = "static\\upload\\profile";
        public static string SponsorImagePath = "static\\upload\\sponsor_images";
        public static string GroupImagePath = "static\\upload\\group_images";
        public static string GolfCourseImagePath = "static\\upload\\golfcourse_images";
        public static string MatchImagePath = "static\\upload\\match_images";



        public static void InitDevImagePath()
        {
            baseFolder = "ClientApp\\public";
            UserImagePath = "static\\upload\\usrimg";
        }

        public static void InitProductionImagePath()
        {
            baseFolder = "ClientApp/build";
            UserImagePath = "static/upload/usrimg";
        }

        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }

        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

        public static bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return GetImageFormat(fileBytes) != ImageFormat.unknown;
        }

        public static ResultStatus WriteImage(string base64string, string relativeFileDir, string oldFileName)
        {
            ResultStatus result = new ResultStatus();
            base64string = base64string.Remove(0, base64string.IndexOf(',') + 1);
            var fileBytes = Convert.FromBase64String(base64string);// a.base64image 
            ImageFormat fileFormat = GetImageFormat(fileBytes);
            if (fileFormat == ImageFormat.unknown)
            {
                result.Status = false;
                result.Message = "Invalid file format.";
                return result;
            }
          if(oldFileName!=null && oldFileName.Split('.').Length == 1){
            oldFileName = $"{oldFileName}.{fileFormat.ToString()}";
          }
            string fileName = oldFileName != null ? oldFileName : Guid.NewGuid().ToString() + "." + fileFormat.ToString(); //Create a new Name for the file due to security reasons.
            string fileDir = Path.Combine(Directory.GetCurrentDirectory(), baseFolder, relativeFileDir);
            string savePath = Path.Combine(fileDir, fileName);

            if (!Directory.Exists(fileDir))
            { //check if the folder exists;
                Directory.CreateDirectory(fileDir);
            }
            Debug.WriteLine(savePath);
            try
            {
                if (fileBytes.Length > 0)
                {
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        stream.Write(fileBytes, 0, fileBytes.Length);
                        stream.Flush();
                    }
                }
            }
            catch (Exception exp)
            {
                result.Status = false;
                result.Message = exp.Message;
                return result;
            }
            string dbFilePath = Path.Combine("/", relativeFileDir, fileName);
            dbFilePath = dbFilePath.Replace('\\', '/');
            result.Data = dbFilePath;
            return result;
        }

        public static ResultStatus CompleteDelete(string[] ImagesToDelete)
        {
            ResultStatus result = new ResultStatus();
            if (ImagesToDelete != null)
            {
                foreach (string imgPath in ImagesToDelete)
                {
                    if (string.IsNullOrEmpty(imgPath) || imgPath.IndexOf("static/") == -1) continue;
                    string basePath = Path.Combine(Directory.GetCurrentDirectory(), baseFolder);
                    basePath = basePath.Replace("\\", "/");
                    System.IO.File.Delete(basePath + imgPath);
                }
            }
            return result;
        }

        public static ResultStatus DeleteImage(string[] Images, string[] ImagesToDelete, string path, bool isMobile)
        {
            String existingFileName = Guid.NewGuid().ToString();

            if (isMobile && ImagesToDelete[0] != "")
            {
                string[] tempStr = ImagesToDelete[0].Split('/');
                existingFileName = tempStr[tempStr.Length - 1];
            }

            ResultStatus result1 = new ResultStatus();
            if (ImagesToDelete != null)
            {
                foreach (string imgPath in ImagesToDelete)
                {
                    if (string.IsNullOrEmpty(imgPath) || imgPath.IndexOf("static/") == -1) continue;
                    string basePath = Path.Combine(Directory.GetCurrentDirectory(), baseFolder);
                    basePath = basePath.Replace("\\", "/");
                    System.IO.File.Delete(basePath + imgPath);
                }
            }
            List<string> ImagePaths = new List<string>();
            foreach (string imgStr in Images)
            {
                if (string.IsNullOrEmpty(imgStr)) continue;
                if (imgStr.IndexOf("static/") != -1)
                {
                    ImagePaths.Add(imgStr);
                }
                else
                {
                    ResultStatus result = WriteImage(imgStr, path, oldFileName: isMobile ? existingFileName : null);
                    if (result.Status)
                        ImagePaths.Add(result.Data.ToString());
                }
            }
            result1.Status = true;
            result1.Data = String.Join(';', ImagePaths.ToArray());
            return result1;
        }

    }
}
