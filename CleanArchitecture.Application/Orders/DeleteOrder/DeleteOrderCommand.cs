using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<string>, ICommand
    {
        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
