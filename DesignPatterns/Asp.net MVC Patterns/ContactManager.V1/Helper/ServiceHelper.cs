using ContactManager.V1.Contracts;

namespace ContactManager.V1.Helper
{
    public static class ServiceHelper
    {
        public static IServiceCollection AddDependency(this IServiceCollection service)
        {
            service.AddScoped<IEmployee, Employee>();

            return service;
        }
    }
}
