// -----------------------------------------------------------------------
// <copyright file="ImageCache.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common
{
    using System;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Image Cache
    /// </summary>
    public class ImageCache
    {
        /// <summary>
        /// The Current Image Cache
        /// </summary>
        public static readonly ImageCache Current = new ImageCache();

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The Image</returns>
        public async Task<string> GetImage(Uri uri)
        {
            string fileName = this.GetFileName(uri);
            string filePath = this.GetFilePath(uri);

            if (!this.Contains(uri))
            {
                WebClient webClient = new WebClient();
                byte[] data = await webClient.DownloadDataTaskAsync(uri);

                using (var saveStream = this.GetFileStream(fileName + ".temp"))
                {
                    saveStream.Write(data, 0, data.Length);
                    saveStream.Close();
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                File.Move(filePath + ".temp", filePath);
            }

            return filePath;
        }

        /// <summary>
        /// Determines whether [contains] [the specified URI].
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified URI]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Uri uri)
        {
            string fileName = this.GetFileName(uri);
            using (Stream imagenStream = this.GetFileStream(fileName))
            {
                bool result = imagenStream.Length > 0;
                imagenStream.Close();
                return result;
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The file path</returns>
        public string GetFilePath(Uri uri)
        {
            return Environment.CurrentDirectory + "\\images\\" + this.GetFileName(uri);
        }

        /// <summary>
        /// Gets the file stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The Stream</returns>
        private Stream GetFileStream(string fileName)
        {
            string path = Environment.CurrentDirectory + "\\images\\";
            string filePath = path + fileName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(filePath))
            {
                return File.Open(filePath, FileMode.Open);
            }
            else
            {
                return File.Create(filePath);
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The File Name</returns>
        private string GetFileName(Uri uri)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(uri.ToString()));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
