using AutoMapper;
using TaskInteview.Dtos;
using TaskInteview.Model;

namespace TaskInteview.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeReturnDto>();                
            

            //CreateMap<Category, ProductCategoryDto>().ReverseMap();

            //CreateMap<Product, ProductReturnDto>().ReverseMap();

        }
    }
}
