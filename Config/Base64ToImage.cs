using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPUCENM.Config
{
    public class Base64ToImage : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ImageSource imageSource = null;
            
            if (value != null)
            {
                String Base64Image = (String)value;
                byte[] fotobyte = System.Convert.FromBase64String(Base64Image);
                var stream = new MemoryStream(fotobyte);

                imageSource = ImageSource.FromStream(() => stream);

                return imageSource;
            }

            return imageSource;

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
