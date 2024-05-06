using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API
{
    public class CargarImagenService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public CargarImagenService(IConfiguration configuration, IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
            _bucketName = configuration.GetValue<string>("AWS:BucketName");
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = fileStream
            };

            try
            {

                var transferUtility = new TransferUtility(_s3Client);

                await transferUtility.UploadAsync(fileStream, _bucketName, fileName);


            }
            catch (AmazonS3Exception e)
            {
                return (e.Message);

            }


            return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
        }
    }
}
