using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Guid>, ICommand
    {
        public Guid productId { get; set; }

        public DeleteProductCommand(Guid productId)
        {
            this.productId = productId;
        }

    }
}