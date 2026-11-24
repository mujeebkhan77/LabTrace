
using Microsoft.AspNetCore.Mvc;
using LabTrace.Data;
using LabTrace.Repositories;

namespace LabTrace.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnection _dbConnection;
        private readonly IComplaintRepository _complaintRepository;

        public HomeController(
            DbConnection dbConnection,
            IComplaintRepository complaintRepository)
        {
            _dbConnection = dbConnection;
            _complaintRepository = complaintRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestConnection()
        {
            using var connection = _dbConnection.GetConnection();

            connection.Open();

            return Content("Database Connected Successfully!");
        }

        public IActionResult GetComplaints()
        {
            var complaints = _complaintRepository.GetAllComplaints();

            return View(complaints);
        }

        public IActionResult GetComplaintsData()
        {
            var complaints = _complaintRepository.GetAllComplaints();

            return Json(complaints);
        }

    }
}
