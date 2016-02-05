using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Contract
{
    public interface IMedicalServiceRabbitRepository
    {
        IList<MedicalServiceRabbit> GetListForMales(int rabbitId);

    }
}
