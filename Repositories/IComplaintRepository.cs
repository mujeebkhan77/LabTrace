using LabTrace.Models;

namespace LabTrace.Repositories
{
    public interface IComplaintRepository
    {
        List<Complaint> GetAllComplaints();
    }
}
