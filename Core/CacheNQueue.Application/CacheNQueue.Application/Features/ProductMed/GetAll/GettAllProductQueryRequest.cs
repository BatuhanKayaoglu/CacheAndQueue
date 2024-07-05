using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.GetAll
{
    public class GettAllProductQueryRequest : IRequest<List<GettAllProductQueryResponse>>
    {


    }
}
