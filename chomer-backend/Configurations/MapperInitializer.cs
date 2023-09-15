using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;

namespace chomer_backend.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<Reward, RewardDTO>().ReverseMap();
            CreateMap<Reward, CreateRewardDTO>().ReverseMap();
            CreateMap<Reward, UpdateRewardDTO>().ReverseMap();
            CreateMap<HouseUser, HouseUserDTO>().ReverseMap();
            CreateMap<HouseUser, CreateHouseUserDTO>().ReverseMap();
            CreateMap<HouseUser, UpdateHouseUserDTO>().ReverseMap();
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<House, CreateHouseDTO>().ReverseMap();
            CreateMap<House, UpdateHouseDTO>().ReverseMap();
            CreateMap<Chore, ChoreDTO>().ReverseMap();
            CreateMap<Chore, CreateChoreDTO>().ReverseMap();
            CreateMap<Chore, UpdateChoreDTO>().ReverseMap();
        }
    }
}
