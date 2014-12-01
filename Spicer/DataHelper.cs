using AutoMapper;
using Spicer.Model;
using Spicer.ViewModel;

namespace Spicer
{
    static class DataHelper
    {
        static DataHelper()
        {
            Mapper.CreateMap<UserModel, LoginViewModel>()
               .ForMember(x => x.Username, a => a.MapFrom(x => x.Username))
               .ForMember(x => x.Password, a => a.MapFrom(x => x.Password));

            Mapper.CreateMap<FantasyModel, FantasyViewModel>()
                .ForMember(x => x.Title, a => a.MapFrom(x => x.Title))
                .ForMember(x => x.ImgUrl, a => a.MapFrom(x => x.ImgUrl));
        }

        public static void Start() { }
    }
}
