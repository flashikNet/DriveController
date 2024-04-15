using UssJuniorTest.Application.Models.Requests;
using UssJuniorTest.Application.Models.Responses;

namespace UssJuniorTest.Application.Interfaces
{
    public interface IDriveService
    {
        public GetDrivesRes[] GetDrives(GetDrivesReq req);
    }
}
