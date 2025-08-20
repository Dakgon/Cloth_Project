using System;
using Basler.Pylon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace _001_Modbus_003_ModernUI.Properties
{
    public class BaslerCamera
    {

        private Camera _camera;                 // Camera instance
        private PixelDataConverter _converter; // Converter instance to convert the image data to Bitmap format


        /// <summary>
        /// This function initializes a Camera instance and establishes the connection to the Camera
        ///     Then, the Camera settings are configured to 8-bit BRG format
        /// </summary>
        /// <returns></returns>
        public string camera_init()
        {
            try
            {
                _camera = new Camera();         // Dynamically allocating Camera instance memory
                _camera.CameraOpened += Configuration.AcquireContinuous; // Setting the acquisition mode to continous
                _camera.Open();                 // Open the Camera connection
                _camera.Parameters[PLCamera.PixelFormat].SetValue(PLCamera.PixelFormat.BGR8);
                _converter = new PixelDataConverter();
                _camera.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);


                return "Camera is successfully connected";
            }
            catch (Exception ex)
            {
                return $"Camera could not be Opened\nError: {ex.Message}";
            }
        }


        /// <summary>
        /// This function closes the camera when there's no more use
        /// </summary>
        /// <returns></returns>
        public string camera_close()
        {
            try
            {
                _camera.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return $"Camera could not be Closed\nError: {ex.Message}";
            }
        }


        /// <summary>
        /// This function prompts the camera to capture an image
        ///     If capturing is succeeded, the resulted image is stored under the path with name "captured_image"
        /// </summary>
        /// <param name="image_capture_path"></param>
        /// <returns></returns>
        public string camera_oneshot_capture(string image_capture_path, int count)
        {
            _camera.StreamGrabber.Start(1);
            IGrabResult grab_result;
            try
            {
                grab_result = _camera.StreamGrabber.RetrieveResult(2000, TimeoutHandling.ThrowException);
            }
            catch (Exception ex)
            { 
                return $"Image is not captured\nError: {ex.Message}";
            }
            
            _camera.StreamGrabber.Stop();
            using (grab_result)
            {
                if (grab_result.GrabSucceeded)
                {
                    try
                    {
                        ImagePersistence.Save(ImageFileFormat.Png, image_capture_path + "\\captured_image" + count.ToString() +".png", grab_result);
                        return "Image is captured successfully";
                    }
                    catch (Exception ex)
                    {
                        return $"Image is not captured\nError: {ex.Message}";
                    }
                }
                else
                { 
                    return $"Error {grab_result.ErrorCode}: {grab_result.ErrorDescription}";
                }
            }
        }
        public Bitmap camera_get_frame() 
        {
            try
            {
                if (!_camera.StreamGrabber.IsGrabbing)
                {
                    _camera.StreamGrabber.Start();
                }
                using (IGrabResult grabResult = _camera.StreamGrabber.RetrieveResult(2000, TimeoutHandling.ThrowException))
                {
                    if (grabResult.GrabSucceeded)
                    {
                  
                        Bitmap bmp = new Bitmap(grabResult.Width, grabResult.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        BitmapData bmpData = bmp.LockBits(
                               new Rectangle(0, 0, bmp.Width, bmp.Height),
                               ImageLockMode.WriteOnly,
                               bmp.PixelFormat);
                        _converter.OutputPixelFormat = PixelType.BGR8packed;
                        _converter.Convert(bmpData.Scan0, bmpData.Stride * bmpData.Height, grabResult);
                        bmp.UnlockBits(bmpData);
                        return bmp;
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting frame:{ex.Message}");
            }
            return null;
        }
        public bool camera_is_connected()
        {
            return _camera.IsOpen;
        }

    }
}
