
using AutoMapper;
using product.model2.Models;
using product.model2.ViewModels;

namespace product.model2.Mapping
{
   public class ViewModelMapping:Profile
    {
        public ViewModelMapping() { 
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
