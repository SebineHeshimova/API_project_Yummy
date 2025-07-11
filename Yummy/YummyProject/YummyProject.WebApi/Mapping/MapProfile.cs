﻿using AutoMapper;
using YummyProject.WebApi.DTOs.FeatureDTOs;
using YummyProject.WebApi.DTOs.MessageDTOs;
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
        }
    }
}
