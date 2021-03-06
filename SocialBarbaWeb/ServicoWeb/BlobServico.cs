﻿using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SocialBarbaWeb.ServicoWeb
{
    public class BlobServico
    {
        public async Task<string> UploadImageAsync(HttpPostedFileBase imageToUpload)
        {
            string imagePath = null;
            if (imageToUpload == null || imageToUpload.ContentLength == 0)
            {
                return null;
            }
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("fotoperfil");

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.InputStream);

                imagePath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return imagePath;
        }
    }
}