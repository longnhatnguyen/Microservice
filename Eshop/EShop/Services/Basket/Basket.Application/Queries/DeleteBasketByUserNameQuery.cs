using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries
{
    public class DeleteBasketByUserNameQuery : IRequest
    {
        public string UserName { get; set; }

        public DeleteBasketByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
