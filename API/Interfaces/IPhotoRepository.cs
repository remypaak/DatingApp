using API.Entities;

namespace API.Interfaces;

public interface IPhotoRepository
{ 
    Photo[] GetUnapprovedPhotos();
    Photo GetPhotoByPhotoId();
    void RemovePhoto();
}
