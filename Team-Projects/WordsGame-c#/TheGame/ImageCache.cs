using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheGame
{
    class ImageCache
    {
        static byte[] _logoBytes;
        
        public static byte[] Logo
        {
            get
            {
                // Returns logo image bytes.
                if (_logoBytes == null)
                {
                    _logoBytes = File.ReadAllBytes("../../files/SpeedyMind-Logo.png");  // не съм сигурна за точния път тука.. w papka files e
                }
                return _logoBytes;
            }
        }
    }
}
