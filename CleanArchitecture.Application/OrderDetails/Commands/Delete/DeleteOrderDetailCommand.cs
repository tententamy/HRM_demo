
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Delete
{
    public class DeleteOrderDetailCommand: IRequest<bool>, ICommand
    {
        public DeleteOrderDetailCommand(Guid id)
        {
            this.Id= id;    
        }   
        public Guid Id { get;set; }
    }
}
