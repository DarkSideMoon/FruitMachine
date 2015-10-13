using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RandomRouletteLibrary
{
    public class MyImage
    {
        private string _pathToFolder = "";

        #region Properties
        public string Name { get; set; }
        public string PathToFile { get; set; }

        public static int CurrentResult { get; set; }
        
        #endregion

        #region Constructors
        public MyImage() { }
        public MyImage(string name, string pathToFile)
        {
            Name = name;
            PathToFile = pathToFile;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Search images in directory with them 
        /// </summary>
        /// <returns>Return the list of images</returns>
        public List<MyImage> SearchImages()
        {
            string imageExtensions = ".png" ;
            List<MyImage> imageFiles = new List<MyImage>();

            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            _pathToFolder = wanted_path + "/Images/";

            if (Directory.Exists(_pathToFolder))
            {
                foreach (var file in Directory.GetFiles(_pathToFolder, "*.*"))
                    if (imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                    {
                        int index = file.LastIndexOf("/");
                        int extension = file.LastIndexOf(".png");
                        string nameFile = file.Substring(index + 1, extension - index - 1);

                        imageFiles.Add(new MyImage() { PathToFile = file, Name = nameFile });
                    }
                return imageFiles;
            }
            else
                throw new DirectoryNotFoundException("Current folder" + _pathToFolder + "is not exist");
        }

        /// <summary>
        /// Get random image
        /// </summary>
        /// <returns>Return random image</returns>
        public MyImage GetRandom()
        {
            MyImage img = new MyImage();
            Random random = new Random();
            List<MyImage> images = SearchImages();
            int randNumb = random.Next(images.Count);

            this.Name = images[randNumb].Name;
            this.PathToFile = images[randNumb].PathToFile;

            img.Name = images[randNumb].Name;
            img.PathToFile = images[randNumb].PathToFile;
            return img;
            
        }

        /// <summary>
        /// Check images 
        /// </summary>
        /// <param name="image1">Image 1</param>
        /// <param name="image2">Image 2</param>
        /// <param name="image3">Image 3</param>
        /// <returns>Return the total amount of points</returns>
        internal int CheckImages(string image1, string image2, string image3)
        {
            if ((image1 == image2 && image2 != image3 && image1 != image3) ||
                (image1 == image3 && image1 != image2 && image2 != image3) ||
                (image2 == image3 && image1 != image2 && image1 != image3))
                return CurrentResult = 25;
            if (image1 == image2 && image1 == image3 && image2 == image3)
                return CurrentResult = 80;
            else
                return CurrentResult = -100;
        }
        #endregion
    }
}
