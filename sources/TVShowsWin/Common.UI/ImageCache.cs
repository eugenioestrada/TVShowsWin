// -----------------------------------------------------------------------
// <copyright file="ImageCache.cs" company="TVShowsWin">
// GNU General Public License see http://www.gnu.org.
// </copyright>
// -----------------------------------------------------------------------

namespace TVShowsWin.Common.UI
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using TVShowsWin.Common.Helpers;

    /// <summary>
    /// The Image Cache
    /// </summary>
    public class ImageCache
    {
        /// <summary>
        /// The Source Attached Property
        /// </summary>
        public static readonly DependencyProperty CacheSourceProperty
            = DependencyProperty.RegisterAttached(
                "CacheSource",
                typeof(Uri),
                typeof(Image),
                new FrameworkPropertyMetadata(null, OnCacheSourceChanged));

        /// <summary>
        /// The Current Image Cache
        /// </summary>
        private static readonly ImageCache Current = new ImageCache();

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The Image</returns>
        public ImageSource GetImage(Uri uri)
        {
            string fileName = this.GetFileName(uri);

            if (!this.Contains(uri))
            {
                WebClient webClient = new WebClient();
                byte[] data = webClient.DownloadData(uri);
                using (var saveStream = this.GetFileStream(fileName))
                {
                    saveStream.Write(data, 0, data.Length);
                    saveStream.Close();
                }
            }

            BitmapImage bitmap = new BitmapImage();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            using (var imageStream = this.GetFileStream(fileName))
            {
                bitmap.BeginInit();
                bitmap.DecodePixelWidth = 30;
                bitmap.StreamSource = imageStream;
                bitmap.EndInit();
            }

            return bitmap;
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
            using (IsolatedStorageFileStream imagenStream = this.GetFileStream(fileName))
            {
                return imagenStream.Length > 0;
            }
        }

        /// <summary>
        /// Called when [cache source changed].
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnCacheSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Image image = dependencyObject as Image;
            if (image != null)
            {
                Task.Factory.StartNew(() =>
                {
                    var uri = args.NewValue as Uri;
                    if (uri != null)
                    {
                        var source = Current.GetImage(uri);
                        DispatcherHelper.InvokeInDispatcher(() =>
                        {
                            image.Source = source;
                        });
                    }
                });
            }
        }

        /// <summary>
        /// Gets the file stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The Stream</returns>
        private IsolatedStorageFileStream GetFileStream(string fileName)
        {
            return new IsolatedStorageFileStream("images\\" + fileName, FileMode.OpenOrCreate);
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
