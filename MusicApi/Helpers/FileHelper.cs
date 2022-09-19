using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Helpers
{
    public static class FileHelper
    {
        /* <summary>
        //Goto Azure/StorageAccount/apikeys for connection string
        //Where images will be stored
        //Upload a file content in memory stream
        //To read a file to position 0
        //Upload a memory stream to container. */
        // <param name="file">IFormFile file</param>
        // <returns>Filepath from azure blob storage container</returns>

        public static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=songsstorageaccount;AccountKey=eALEzMMQjJPSg90SA94m5ulydgPqqlvDOSUvz36+VM4H0kJEHGoi+i4BtfxvTw4YfUaXAyPbFgOJ+ASteNjlsA==;EndpointSuffix=core.windows.net";
            string containerName = "songscover";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memorystream = new MemoryStream();
            await file.CopyToAsync(memorystream);
            memorystream.Position = 0;
            await blobClient.UploadAsync(memorystream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
