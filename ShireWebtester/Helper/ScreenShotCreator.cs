using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester.Helper
{
    public class ScreenShotCreator
    {
        //Define the filepath
        String fileLocation = String.Empty;
        String scriptId = String.Empty;
        String filename = string.Empty;
        private static ScreenShotCreator screenshot= null;
        public static ScreenShotCreator GetInstance(String fileLocation, String scriptId,string filename)
        {
            if (screenshot == null) {
                screenshot = new ScreenShotCreator(filename, scriptId, filename);
            }
            return screenshot;
        }
        int count = 1;
        /// <summary>
        /// This constructor is used to create the ScreenShotCreator for the particularTestCase
        /// </summary>
        /// <param name="obj"></param>
        private ScreenShotCreator(String fileLocation, String scriptId,string filename)
        {
            if (!Directory.Exists(fileLocation))
            {
                Directory.CreateDirectory(fileLocation);
            }
            fileLocation = GetPath(scriptId, fileLocation);
            if (!Directory.Exists(fileLocation))
            {
                Directory.CreateDirectory(fileLocation);
            }
            this.filename = filename;
            this.fileLocation = fileLocation;
        }

        /// <summary>
        /// This method is used to take screen shot for the page
        /// </summary>
        /// <param name="browser"></param>
        public void TakeScreenShot(RemoteWebDriver browser)
        {
            try
            {
                String picturePath = fileLocation + @"\" + filename + "image" + count.ToString() + ".jpg";
                browser.GetScreenshot().SaveAsFile(picturePath, ImageFormat.Png);
                count++;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String GetPath(String scriptId, String fileLocation)
        {
            String filePath = fileLocation + "/" + scriptId + string.Format("{0}{1:yyyyMMdd_HHmmfff}", "", DateTime.Now);
            return filePath;
        }

    }
}
