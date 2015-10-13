using System.Threading.Tasks;
using System.Web;


namespace Persistence
{
    public interface IPhotoService
    {
        void CreateAndConfigureAsync();
        Task<string> UploadPhotoAsync(HttpPostedFileBase photoToUpload);
    }
}
