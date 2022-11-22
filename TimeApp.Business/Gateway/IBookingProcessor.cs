using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApp.Business.Gateway
{
    public interface IBookingProcessor
    {
        bool Create(int employeeId, DateTime Date, decimal duration);
    }
}
