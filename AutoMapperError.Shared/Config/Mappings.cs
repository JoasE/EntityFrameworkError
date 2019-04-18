using System;
using System.Linq;
using AutoMapper;
using AutoMapperError.Shared.Models;

namespace AutoMapperError.Shared.Config
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            var userId = Guid.Empty;

            CreateMap<Course, Course.View>();
            CreateMap<Lab, Lab.View>();
            CreateMap<Assignment, Assignment.View>().ForMember(dto => dto.CurrentWork,
                cfg => cfg.MapFrom(model => model.UserAssignments.FirstOrDefault(x => x.UserId == userId)));
            CreateMap<UserAssignment, UserAssignment.View>();
        }
    }
}
