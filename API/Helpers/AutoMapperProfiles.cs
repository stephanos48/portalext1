using System;
using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                    src.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => 
                    src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src => 
                    src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<TxQohForCreationDto, TxQoh>();
            CreateMap<TxQohForReturnDto, TxQoh>().ReverseMap();
            CreateMap<TxQohForUpdateDto, TxQoh>();
            CreateMap<PoPlanForCreationDto, PoPlan>();
            CreateMap<PoPlanForReturnDto, PoPlan>().ReverseMap();
            CreateMap<PoPlanForUpdateDto, PoPlan>();
            CreateMap<SoPlanForCreationDto, SoPlan>();
            CreateMap<SoPlanForReturnDto, SoPlan>().ReverseMap();
            CreateMap<SoPlanForUpdateDto, SoPlan>();
            CreateMap<SupplierForCreationDto, Supplier>();
            CreateMap<SupplierForReturnDto, Supplier>().ReverseMap();
            CreateMap<SupplierForUpdateDto, Supplier>();
            CreateMap<QuoteForCreationDto, Quote>();
            CreateMap<QuoteForReturnDto, Quote>().ReverseMap();
            CreateMap<QuoteForUpdateDto, Quote>();
            CreateMap<QuoteDetailForCreationDto, QuoteDetail>();
            CreateMap<QuoteDetailForReturnDto, QuoteDetail>().ReverseMap();
            CreateMap<QuoteDetailForUpdateDto, QuoteDetail>();
        }

    }
}