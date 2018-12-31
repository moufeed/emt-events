using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using EmtEvents.DirectBackendServices.UploadService.Mapper;
using TamTechSDK.Common.Services.Upload.Models;

namespace EmtEvents.DirectBackendServices.UploadService
{
    public class DirectFileStorageService : TamTechSDK.Common.Services.Upload.IUploadService
    {
        #region Props  
        private readonly TamTechBackendSDK.FileStorageService.Services.IUploadService _fileStorageService;
        #endregion


        #region Ctors
        public DirectFileStorageService(TamTechBackendSDK.FileStorageService.Services.IUploadService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        #endregion


        #region Services  
        public async Task<IRequestProviderResult<UploadModelResult>> UploadsFilesAsync(UploadModel mediafiles)
        {
            IRequestProviderResult<UploadModelResult> _result = new RequestProviderResult<UploadModelResult>();
            var v = mediafiles.MapUploadModel();
            var resultUpload = await _fileStorageService.UploadAsync(v);
            _result.Data = resultUpload.MapUploadModelResult();
            _result.Success = true;

            return _result;
        }




        public async Task<IRequestProviderResult<DeleteFilesModelResult>> DeleteFilesAsync(DeleteFilesInputModel model)
        {
            IRequestProviderResult<DeleteFilesModelResult> _result = new RequestProviderResult<DeleteFilesModelResult>();


            var resultDeleteFiles = await _fileStorageService.DeleteFilesAsync(model.MapDeleteFilesInputModel());
            _result.Data = resultDeleteFiles.MapDeleteFilesModelResult();
            _result.Success = true;
            return _result;
        }
        #endregion
    }
}
