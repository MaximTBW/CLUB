using CLUB.SERVICES.Automappers;
using AutoMapper;
using Xunit;

namespace CLUB.SERVICES.Tests
{
    public class MapperTest
    {
        /// <summary>
        /// ����� �� ������
        /// </summary>
        [Fact]
        public void TestMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });

            config.AssertConfigurationIsValid();
        }
    }
}