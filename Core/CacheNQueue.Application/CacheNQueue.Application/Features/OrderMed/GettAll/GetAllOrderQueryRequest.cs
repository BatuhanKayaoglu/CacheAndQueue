using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed
{
    public class GetAllOrderQueryRequest : IRequest<List<GetAllOrderQueryrResponse>>
    {

    }
}