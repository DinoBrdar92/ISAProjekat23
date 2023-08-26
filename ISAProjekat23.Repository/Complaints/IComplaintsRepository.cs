using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Repository.Complaints
{
    public interface IComplaintsRepository
    {
        Task<bool> AddComplaint(Model.Domain.Complaint complaint);
    }
}
