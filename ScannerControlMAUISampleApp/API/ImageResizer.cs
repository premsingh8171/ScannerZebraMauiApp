#if __IOS__
using System.Drawing;
using UIKit;
using CoreGraphics;
#endif

#if __ANDROID__
using Android.Graphics;
#endif
namespace ScannerControlMAUISampleApp.API
{
    //Responsible for resizing the image
    public class ImageResizer
    {
        public ImageResizer()
        {
        }

        /// <summary>
        /// Resize the image for given devices
        /// </summary>
        /// <param name="imageData">The image data</param>
        /// <param name="width">The expect width of the image</param>
        /// <param name="height">The expect height of the image</param>
        /// <returns>The resize image data byte</returns>
/*        public static byte[] ResizeImage(byte[] imageData, float width, float height)
        {
#if __IOS__
            return ResizeImageIOS(imageData, width, height);
#endif
#if __ANDROID__
            return ResizeImageAndroid(imageData, width, height);
#endif
#if WINDOWS_UWP
            return await ResizeImageWindows(imageData, width, height);
#endif
        }
*/

#if __IOS__
        /// <summary>
        /// Resize the image for given image data for iOS device
        /// </summary>
        /// <param name="imageData">The image data</param>
        /// <param name="width">The expect width of the image</param>
        /// <param name="height">The expect height of the image</param>
        /// <returns>The resize image data byte</returns>
        public static byte[] ResizeImageIOS(byte[] imageData, float width, float height)
        {
            UIImage originalImage = ImageFromByteArray(imageData);
            UIImageOrientation orientation = originalImage.Orientation;

            //create a 24bit RGB image
            using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
                                                 (int)width, (int)height, 8,
                                                 4 * (int)width, CGColorSpace.CreateDeviceRGB(),
                                                 CGImageAlphaInfo.PremultipliedFirst))
            {

                RectangleF imageRect = new RectangleF(0, 0, width, height);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

                UIKit.UIImage resizedImage = UIKit.UIImage.FromImage(context.ToImage(), 0, orientation);

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }

        /// <summary>
        /// A image create from byte array
        /// </summary>
        /// <param name="data">The image data</param>
        /// <returns>The image</returns>
        public static UIKit.UIImage ImageFromByteArray(byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            UIKit.UIImage image;
            try
            {
                image = new UIKit.UIImage(Foundation.NSData.FromArray(data));
            }
            catch (Exception e)
            {
                Console.WriteLine("Image load failed: " + e.Message);
                return null;
            }
            return image;
        }
#endif

#if __ANDROID__
        /// <summary>
        /// Resize the image for given image data for android device
        /// </summary>
        /// <param name="imageData">The image data</param>
        /// <param name="width">The expect width of the image</param>
        /// <param name="height">The expect height of the image</param>
        /// <returns>The resize image data byte</returns>
        public static byte[] ResizeImageAndroid(byte[] imageData, float width, float height)
        {
            // Load the bitmap
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }

#endif
    }
}
