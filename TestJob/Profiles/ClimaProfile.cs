using AutoMapper;
using TestJob.DTO;
using TestJob.Entities;

namespace TestJob.Profiles
{
    public class ClimaProfile: Profile
    {
        public ClimaProfile()
        {
            CreateMap<ClimaDTO, Clima>().ReverseMap();
        }
    }
}
