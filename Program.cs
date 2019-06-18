using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace AttributeBasedMapping
{
    class Program
    {
        static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var sp = services.BuildServiceProvider();
            var mapper = sp.GetRequiredService<IMapper>();
            var model = mapper.Map<ViewModel>(new Company { Id = 1, Name = "Straight Mapping" });
            Console.WriteLine("ViewModel.Id: {0}", model.Id);
            Console.WriteLine("ViewModel.Name: {0}", model.CompanyName);
            var company = mapper.Map<Company>(new ViewModel { Id = 1, CompanyName = "Reverse Mapping" });
            Console.WriteLine("Company.Id: {0}", company.Id);
            Console.WriteLine("Company.Name: {0}", company.Name); // expected: 'Reverse Mapping' but is empty
        }
    }
}
