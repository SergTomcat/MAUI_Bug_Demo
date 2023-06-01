using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
using System.Threading.Tasks;
using Xaminals.Views;

namespace Xaminals.Converters
{
	public class NumberToImageConverter : IValueConverter
	{
		public static async Task<Stream> GetImageStream(string url)
		{
			Uri uri = new(url);
			Stream source = null;

			var s = await Service.DownloadFile(uri, CancellationToken.None);
			if (s != null)
			{
				source = new MemoryStream(s);
			}
			
			return source;
		}


		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			
			if (targetType == typeof(ImageSource))
			{
				if (value != null && value is Number n &&  n.ImageUrl != null) {
					return ImageSource.FromStream(() => GetImageStream(n.ImageUrl).ConfigureAwait(false).GetAwaiter().GetResult());

					//return ImageSource.FromUri(new Uri(n.ImageUrl));
				}
				else
					return ImageSource.FromFile("no_image.png");
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
