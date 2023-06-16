using AutoMapper;
using WorkFlow.Application.Dtos.PositionDtos;
using WorkFlow.Application.Dtos.RequestConditionOperatorsDtos;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Dtos.RequestFormsDtos;
using WorkFlow.Application.Dtos.RequestTypeDtos;
using WorkFlow.Application.Dtos.UserActionDto;
using WorkFlow.Application.Dtos.UserConditionDtos;
using WorkFlow.Application.Dtos.UsertypesDtos;
using WorkFlow.Domain.Entities;

namespace WorkFlow.Persistence.MappingProfiles
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<PostRequestTypeDto, RequestType>();
            CreateMap<RequestType, GetRequestTypeDto>();
            CreateMap<PostRequestFormsDto, RequestForms>();
            CreateMap<RequestForms, GetRequestFormsDto>();
            CreateMap<RequestForms, GetRequestFormShortDto>();
            CreateMap<PostRequestFormControlsDto, RequestFormControls>();
            CreateMap<RequestFormControls, GetRequestFormControlsDto>()
                .ForMember(x => x.RequestForm, s => s.MapFrom(x => x.RequestForms));
            CreateMap<PostPositionDto, Positions>();
            CreateMap<Positions,GetPositionDto>();
            CreateMap<PostUserTypeDto, UserType>();
            CreateMap<UserType, GetUserTypeDto>();
            CreateMap<PostUserActionDto, UserActions>();
            CreateMap<UserActions, GetUserActionDto>();
            CreateMap<RequestControlConditions, GetRequestFormControlConditionsDto>()
                .ForMember(x=>x.Operators, s=>s.MapFrom(x=>x.RequestConditionOperators))
                .ForMember(x=>x.GetRequestForm, s=>s.MapFrom(x=>x.RequestForms));
            CreateMap<PostRequestFormControlConditionDto, RequestControlConditions>()
                .ForMember(x=>x.RequestConditionOperators, s=>s.MapFrom(x=>x.Operators));
            CreateMap<RequestConditionOperators, GetRequestConditionOperatorsDto>()
                .ForMember(x=>x.Operator, s=>s.MapFrom(x=>x.Operator));
            CreateMap<PostRequestConditionOperatorsDto, RequestConditionOperators>();
            CreateMap<RequestConditionOperators, GetRequestConditionOperatorsDto>();
            CreateMap<ControlSelectData,SelectData>();
             CreateMap<UserConditionDto, RequestConditionUsers>();
            CreateMap<PostUserConditionDto, RequestConditionUsers>();

            CreateMap<RequestConditionUsers, GetUsersConditionDto>();

            //CreateMap<RequestFormControlConditionUserLevels, GetFormControlConditionsLevelsDto>();
            //CreateMap<PostFormControlConditionLevelsDto, RequestFormControlConditionUserLevels>();
        }
    }
}
