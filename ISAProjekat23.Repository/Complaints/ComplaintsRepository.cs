using ISAProjekat23.Model.Domain.Enums;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISAProjekat23.Database;

namespace ISAProjekat23.Repository.Complaints
{
    public class ComplaintsRepository : IComplaintsRepository
    {

        private DatabaseContext databaseContext;

        public ComplaintsRepository(DatabaseContext dc)
        {
            databaseContext = dc;
        }
        public async Task<bool> AddComplaint(Complaint complaint)
        {
            databaseContext.Complaints.Add(CreateEntityFromDomain(complaint));
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public Complaint CreateDomainFromEntity(ComplaintDto complaintDto)
        {
            Complaint complaint = new Complaint()
            {
                Subject = complaintDto.Subject,
                Description = complaintDto.Description,
            };

            return complaint;
        }

        public ComplaintDto CreateEntityFromDomain(Complaint complaint)
        {
            ComplaintDto complaintDto = new ComplaintDto()
            {
                Subject = complaint.Subject,
                Description = complaint.Description,
                UserId = complaint.User.Id,
                ComplaintObject = complaint.ComplaintObject != 0,
            };

            return complaintDto;
        }
    }
}
