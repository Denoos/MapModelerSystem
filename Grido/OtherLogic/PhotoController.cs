using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grido.OtherLogic
{
    class PhotoController
    {
        private string DefaultPath;
        private string UserPath;

        public PhotoController()
        {
            DefaultPath = Environment.CurrentDirectory + "\\Resourses/";

            if (!File.Exists(DefaultPath))
            {
                File.Create("\\Resourses/PhotoPath.txt");
                File.WriteAllText(DefaultPath, Environment.CurrentDirectory + "Resourses/Photo.txt");
            }

            UserPath = File.ReadAllText(DefaultPath);
        }

        public string GetCurrentPath()
        {
            return "C:/Users/Admin/Pictures/images.jpg";
        }

        public void ChangePhotoPath()
        {
            throw new NotImplementedException();
        }

        public void SelectPhoto()
        {
            throw new NotImplementedException();
        }
    }
}
