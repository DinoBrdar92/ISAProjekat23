using ISAProjekat23.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Repository.Appointments
{
    public interface IAppointmentsRepository
    {
        Task<List<Appointment>> GetAllAppointments();
    }
}
