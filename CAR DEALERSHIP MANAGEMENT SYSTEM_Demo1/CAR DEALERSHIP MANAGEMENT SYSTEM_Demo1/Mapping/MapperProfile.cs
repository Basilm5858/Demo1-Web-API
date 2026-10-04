using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.MappingProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(
                x => x.CategoryName,
                x => x.MapFrom(v => v.Category.Name)
                );
            CreateMap<CreateVehicleDTO, Vehicle>();
            CreateMap<UpdateVehicleDTO, Vehicle>();


            CreateMap<Category, CategoryDTO>()
                .ForMember(
                x => x.VehicleCount,
                x => x.MapFrom(src => src.Vehicles.Count)

                );
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();



            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();


            CreateMap<Employee, EmployeeDTO>()
                .ForMember(
                x => x.SalesCount,
                x => x.MapFrom(src => src.Sales.Count)
                );
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<CreateSaleDTO, Sale>();
            CreateMap<UpdateSaleDTO, Sale>();

            CreateMap<Sale, SalesDTO>()
                .ForMember(
                x => x.SaleId,
                x => x.MapFrom(src => src.Id)
                ).ForMember(
                x => x.PaymentMethod,
                x => x.MapFrom(src => src.PaymentMethod)
                ).ForMember(
                x => x.EmployeeFullName,
                x => x.MapFrom(src => src.Employee.FullName)
                ).ForMember(
                x => x.CustomerFullName,
                x => x.MapFrom(src => src.Customer.FullName)
                ).ForMember(
                x => x.VehicleModel,
                x => x.MapFrom(src => src.Vehicle.Model)
                ).ForMember(
                x => x.VehicleVIN,
                x => x.MapFrom(src => src.Vehicle.VIN)
                ).ForMember(
                x => x.Notes,
                x => x.MapFrom(src => src.Notes)
                ).ForMember(
                x => x.SaleDate,
                x => x.MapFrom(src => src.SaleDate)
                ).ForMember(
                x => x.VehicleMileage,
                x => x.MapFrom(src => src.Vehicle.Mileage)
                ).ForMember(
                x => x.SalePrice,
                x => x.MapFrom(src => src.SalePrice)
                );
                //.ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.CustomerFullName,
                //opt => opt.MapFrom(src => src.Customer.FullName)
                //)
                //.ForMember(dest => dest.VehicleInfo,
                //opt => opt.MapFrom(src => $"{src.Vehicle.Year} {src.Vehicle.Make} {src.Vehicle.Model}")
                //)
                //.ForMember(dest => dest.VIN,
                //opt => opt.MapFrom(src => src.Vehicle.VIN)
                //);

            // إعداد تحويل الموظف إلى ملخص مبيعاته (Employee -> EmployeeSalesSummaryDto)
            CreateMap<Employee, EmployeeWithSalesDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.FullName))
                // حساب الإجماليات مباشرة داخل AutoMapper
                .ForMember(dest => dest.TotalRevenue, opt => opt.MapFrom(src => src.Sales.Sum(s => s.SalePrice)))
                .ForMember(dest => dest.TotalCarsSold, opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(dest => dest.Sales, opt => opt.MapFrom(src => src.Sales));

            CreateMap<CreateSaleDTO, Sale>();
            CreateMap<UpdateCategoryDTO, Sale>();
        }
    }
}
