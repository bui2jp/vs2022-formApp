// <copyright file="SampleAWSS3.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfApp1
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Amazon.S3;
    using Amazon.S3.Model;

    /// <summary>
    /// Example base class.
    /// </summary>
    public class SampleAWSS3
    {
        /// <summary>
        /// Example base class.
        /// </summary>
        public static async Task ListFilesAsync(string bucketName, string? prefix = null)
        {
            try
            {

                var s3Client = new AmazonS3Client(); // 環境変数が自動的に読み込まれます

                var response2 = await s3Client.ListBucketsAsync();

                Debug.WriteLine("バケット一覧:");
                foreach (var bucket in response2.Buckets)
                {
                    Debug.WriteLine($"- {bucket.BucketName}");
                }

                Debug.WriteLine("s3 done4");

                // my-iot-data
                var request = new ListObjectsV2Request
                {
                    // BucketName = bucketName,
                    BucketName = "my-iot-data",
                    Prefix = prefix ?? string.Empty, // フォルダを指定する場合
                };

                var response = await s3Client.ListObjectsV2Async(request);

                Debug.WriteLine($"バケット '{bucketName}' 内のファイル一覧:");

                foreach (var obj in response.S3Objects)
                {
                    Debug.WriteLine($"- {obj.Key}");
                }

                // ページネーション処理 (ファイルが多い場合)
                while (response.IsTruncated)
                {
                    request.ContinuationToken = response.NextContinuationToken;
                    response = await s3Client.ListObjectsV2Async(request);

                    foreach (var obj in response.S3Objects)
                    {
                        Debug.WriteLine($"--- {obj.Key}");
                    }
                }
            }
            catch (AmazonS3Exception ex)
            {
                Debug.WriteLine($"S3 エラー: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"エラー: {ex.Message}");
            }
        }
    }
}
