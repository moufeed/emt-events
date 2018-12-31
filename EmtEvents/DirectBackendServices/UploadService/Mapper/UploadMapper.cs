using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmtEvents.DirectBackendServices.UploadService.Mapper
{
    public static class UploadMapper
    {
        public static TamTechBackendSDK.FileStorageService.Models.UploadFileModel MapUploadFileModel(this TamTechSDK.Common.Services.Upload.Models.UploadFileInfo common)
        {
            return new TamTechBackendSDK.FileStorageService.Models.UploadFileModel
            {

                FileNamePrefix = common.FileNamePrefix,
                Type = common.type,
                Stream = common.Stream,
                FileName = common.FileName
            };
        }


        public static TamTechBackendSDK.FileStorageService.Models.UploadModel MapUploadModel(this TamTechSDK.Common.Services.Upload.Models.UploadModel common)
        {
            var ret = new TamTechBackendSDK.FileStorageService.Models.UploadModel
            {
                UploadFiles = common.UploadFile.Select(f => f.MapUploadFileModel()).ToList()
            };
            return ret;
        }




        public static TamTechBackendSDK.FileStorageService.Models.UploadedFileURL MapUploadedFileURL(this TamTechSDK.Common.Services.Upload.Models.UploadedFileURL common)
        {
            return new TamTechBackendSDK.FileStorageService.Models.UploadedFileURL
            {
                UploadedDate = common.UploadedDate,
                URL = common.URL
            };
        }



        public static TamTechBackendSDK.FileStorageService.Models.UploadModelResult MapUploadModelResult(this TamTechSDK.Common.Services.Upload.Models.UploadModelResult common)
        {
            return new TamTechBackendSDK.FileStorageService.Models.UploadModelResult
            {
                UploadPatchId = common.UploadPatchId,
                URLs = common.URLs.Select(u => u.MapUploadedFileURL()).ToList()
            };
        }



        public static TamTechSDK.Common.Services.Upload.Models.UploadedFileURL MapUploadedFileURL(this TamTechBackendSDK.FileStorageService.Models.UploadedFileURL nuget)
        {
            return new TamTechSDK.Common.Services.Upload.Models.UploadedFileURL
            {
                Type = nuget.Type,
                UploadedDate = nuget.UploadedDate,
                URL = nuget.URL,
                Success = nuget.URL.Length > 0
            };
        }



        public static TamTechSDK.Common.Services.Upload.Models.UploadModelResult MapUploadModelResult(this TamTechBackendSDK.FileStorageService.Models.UploadModelResult nuget)
        {
            return new TamTechSDK.Common.Services.Upload.Models.UploadModelResult
            {
                UploadPatchId = nuget.UploadPatchId,
                URLs = nuget.URLs.Select(u => u.MapUploadedFileURL()).ToList()
            };
        }



    }
}
