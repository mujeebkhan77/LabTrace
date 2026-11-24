
using LabTrace.Data;
using LabTrace.Models;
using Microsoft.Data.SqlClient;

namespace LabTrace.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly DbConnection _dbConnection;

        public ComplaintRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Complaint> GetAllComplaints()
        {
            List<Complaint> complaints = new List<Complaint>();

            using var connection = _dbConnection.GetConnection();

            string query = "SELECT * FROM Complaints";

            using var command = new SqlCommand(query, connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Complaint complaint = new Complaint();

                complaint.ComplaintId = Convert.ToInt32(reader["ComplaintId"]);
                complaint.ComputerId = reader["ComputerId"].ToString();
                complaint.Description = reader["Description"].ToString();
                complaint.Status = reader["Status"].ToString();

                complaints.Add(complaint);
            }

            return complaints;
        }
    }
}
