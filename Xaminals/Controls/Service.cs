using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xaminals
{
    public static class Service
    {
		public async static Task<byte[]> DownloadFile(Uri url, CancellationToken token)
		{
			try
			{
				var httpClient = new HttpClient();
				int bufferSize = 4096;

				HttpResponseMessage fileResponse = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token);

				if (!fileResponse.IsSuccessStatusCode)
				{

					return null;
				}


				MemoryStream fileStream = null;


				fileStream = new MemoryStream();

				byte[] result = null;
				using (fileStream)
				{
					using (var stream = await fileResponse.Content.ReadAsStreamAsync())
					{
						var iTotalRead = 0L;
						var buffer = new byte[bufferSize];
						var isMoreDataToRead = true;

						do
						{
							token.ThrowIfCancellationRequested();

							int read = await stream.ReadAsync(buffer, 0, buffer.Length, token);

							if (read == 0)
							{
								isMoreDataToRead = false;
							}
							else
							{
								await fileStream.WriteAsync(buffer, 0, read);

								iTotalRead += read;

							}
						} while (isMoreDataToRead);
					}


					result = fileStream.ToArray();

				}

				return result;
			}
			catch (Exception e)
			{

				return null;
			}
			finally
			{ 
				
			}

		}
	}
}
