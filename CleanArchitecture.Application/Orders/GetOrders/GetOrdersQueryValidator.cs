using FluentValidation;

namespace CleanArchitecture.Application.Orders.GetOrders
{
    public class GetAllOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        public GetAllOrdersQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            //Không có quy tắc.
        }
    }
}
