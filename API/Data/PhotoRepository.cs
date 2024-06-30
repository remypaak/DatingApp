using API.Entities;
using API.Interfaces;

namespace API.Data;

public class PhotoRepository : IPhotoRepository
{
    public Photo GetPhotoByPhotoId()
    {
        throw new NotImplementedException();
    }

    public Photo[] GetUnapprovedPhotos()
    {
        throw new NotImplementedException();
    }

    public void RemovePhoto()
    {
        throw new NotImplementedException();
    }
}
