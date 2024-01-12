using AutoMapper;
using CleanArchitecture.Application.Reviews;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails
{
    public static class OrderDetailDtoMappingExtension
    {
        public static OrderDetailDTO MapToOrderDetailDto(this OrderDetail projectFrom, IMapper mapper)
          => mapper.Map<OrderDetailDTO>(projectFrom);

        public static List<OrderDetailDTO> MapToOrderDetailDtoList(this IEnumerable<OrderDetail> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToOrderDetailDto(mapper)).ToList();
    }
}
