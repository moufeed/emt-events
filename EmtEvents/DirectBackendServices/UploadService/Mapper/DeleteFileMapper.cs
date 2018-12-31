using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmtEvents.DirectBackendServices.UploadService.Mapper
{
    public static class DeleteFileMapper
    {

        public static TamTechBackendSDK.FileStorageService.Models.DeleteFileInputModel MapDeleteFileInputModel(this TamTechSDK.Common.Services.Upload.Models.DeleteFileInputModel common)
        {
            return new TamTechBackendSDK.FileStorageService.Models.DeleteFileInputModel
            {
                FilePath = common.FilePath,
                Type = common.Type
            };
        }

        public static TamTechBackendSDK.FileStorageService.Models.DeleteFilesInputModel MapDeleteFilesInputModel(this TamTechSDK.Common.Services.Upload.Models.DeleteFilesInputModel common)
        {
            return new TamTechBackendSDK.FileStorageService.Models.DeleteFilesInputModel
            {
                DeleteFiles = common.DeletedFiles.Select(f => f.MapDeleteFileInputModel()).ToList()
            };
        }



        public static TamTechSDK.Common.Services.Upload.Models.DeleteFileResult MapDeleteFileResult(this TamTechBackendSDK.FileStorageService.Models.DeleteFileResult nuget)
        {
            return new TamTechSDK.Common.Services.Upload.Models.DeleteFileResult
            {
                FilePath = nuget.FilePath,
                Result = switchEnum((int)nuget.Result),
                Type = nuget.Type
            };
        }

        public static TamTechSDK.Common.Services.Upload.Models.DeleteFilesModelResult MapDeleteFilesModelResult(this TamTechBackendSDK.FileStorageService.Models.DeleteFilesModelResult nuget)
        {
            return new TamTechSDK.Common.Services.Upload.Models.DeleteFilesModelResult
            {

                Results = nuget.Results.Select(d => d.MapDeleteFileResult()).ToList()
            };
        }





        public static TamTechSDK.Common.Services.Upload.Models.DeleteResult switchEnum(int p1)
        {
            switch (p1)
            {
                case 1:
                    return TamTechSDK.Common.Services.Upload.Models.DeleteResult.Deleted;

                case 2:
                    return TamTechSDK.Common.Services.Upload.Models.DeleteResult.NotExist;

                case 0:
                    return TamTechSDK.Common.Services.Upload.Models.DeleteResult.NotDeleted;
                default:
                    return TamTechSDK.Common.Services.Upload.Models.DeleteResult.NotDeleted;
            }

        }


    }
}
