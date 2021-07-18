using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Data;

namespace WebForum.Services
{
	public class UploadService : IUpload
	{
		public CloudBlobContainer GetBlobContainer(string connectionString)
		{
			var sotageAccount = CloudStorageAccount.Parse(connectionString);
			var blobClient = sotageAccount.CreateCloudBlobClient();

			return blobClient.GetContainerReference("profile-immages");
		}
	}
}
