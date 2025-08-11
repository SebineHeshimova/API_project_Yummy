using AutoMapper;
using System.Runtime.InteropServices;
using YummyProject.WebApi.DTOs.CategoryDTOs;
using YummyProject.WebApi.DTOs.ChefDTOs;
using YummyProject.WebApi.DTOs.FeatureDTOs;
using YummyProject.WebApi.DTOs.FeedbackDTOs;
using YummyProject.WebApi.DTOs.MessageDTOs;
using YummyProject.WebApi.DTOs.NotificationDTOs;
using YummyProject.WebApi.DTOs.ProductDTOs;
using YummyProject.WebApi.DTOs.ServiceDTOs;
using YummyProject.WebApi.DTOs.YummyEventDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();

            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, GetMessageDTO>().ReverseMap();
            CreateMap<Message, GetByIdFeatureDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetProductWithCategoryDTO>().ForMember(x=>x.CategoryName, y=>y.MapFrom(z=>z.Categories.CategoryName)).ReverseMap();

            CreateMap<Service, CreateServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, GetServiceDto>().ReverseMap();
            CreateMap<Service, GetByIdServiceDTO>().ReverseMap();

            CreateMap<Chef, CreateChefDTO>().ReverseMap();
            CreateMap<Chef,UpdateChefDTO>().ReverseMap();
            CreateMap<Chef, GetChefDTO>().ReverseMap();
            CreateMap<Chef, GetByIdChefDTO>().ReverseMap();

            CreateMap<Feedback, CreateFeedbackDTO>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackDTO>().ReverseMap();
            CreateMap<Feedback, GetFeedbackDTO>().ReverseMap();
            CreateMap<Feedback, GetByIdChefDTO>().ReverseMap();

            CreateMap<YummyEvent, CreateYummyEventDTO>().ReverseMap();
            CreateMap<YummyEvent, UpdateYummyEventDTO>().ReverseMap();
            CreateMap<YummyEvent, GetYummyEventDto>().ReverseMap();
            CreateMap<YummyEvent, GetByIdYummyEventDTO>().ReverseMap();

            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();
            CreateMap<Notification, GetNotificationDTO>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDTO>().ReverseMap();

            CreateMap<Category, CreateCagetoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

        }
    }
}
