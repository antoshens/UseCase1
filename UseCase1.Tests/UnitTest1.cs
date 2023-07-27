namespace UseCase1.Tests
{
    public class HomeController_Tests
    {
        private HomeController _sut;

        public HomeController_Tests()
        {
            // Assert
            var apiResponse = new List<Country>
            {
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Samoa"
                    },
                    Population = 198410
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "French Guiana"
                    },
                    Population = 254541
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Republic of Fiji"
                    },
                    Population = 896444
                },
                new Country
                {
                    Name = new CountryName
                    {
                        Common = "Republic of Korea"
                    },
                    Population = 51780579
                },
            };

            var httpClientServiceMock = new Mock<IHttpClientService>();
            httpClientServiceMock
                .Setup(_ => _.SendGetAsync<List<Country>>(It.IsAny<string>()))
                .Returns(Task.FromResult(apiResponse));

            _sut = new HomeController(httpClientServiceMock.Object);

        }

        [Fact]
        public async Task Should_Return_Limited_Records_Amount()
        {
            // Act
            var limit = 3;
            var response = await _sut.GetCountries(null, limit, null, 0);

            var okResult = response as OkObjectResult;
            var countries = okResult.Value as IEnumerable<Country>;

            Assert.NotNull(countries);
            Assert.Equal(limit, countries.Count());
        }

        [Fact]
        public async Task Should_Return_Sorted_Records_Asc()
        {
            // Act
            var response = await _sut.GetCountries(null, 0, "ascend", 0);

            var okResult = response as OkObjectResult;
            var countries = okResult.Value as IEnumerable<Country>;

            Assert.NotNull(countries);
            Assert.Equal("French Guiana", countries.First().Name.Common);
        }

        [Fact]
        public async Task Should_Return_Sorted_Records_Desc()
        {
            // Act
            var response = await _sut.GetCountries(null, 0, "descend", 0);

            var okResult = response as OkObjectResult;
            var countries = okResult.Value as IEnumerable<Country>;

            Assert.NotNull(countries);
            Assert.Equal("French Guiana", countries.Last().Name.Common);
        }

        [Fact]
        public async Task Should_Return_Filtered_Records_By_Population()
        {
            // Act
            var population = 1;
            var response = await _sut.GetCountries(null, 0, null, population);

            var okResult = response as OkObjectResult;
            var countries = okResult.Value as IEnumerable<Country>;

            Assert.NotNull(countries);
            Assert.DoesNotContain("Republic of Korea", countries.Select(x => x.Name.Common));
        }

        [Fact]
        public async Task Should_Return_Filtered_Records_By_Common_Name()
        {
            // Act
            var name = "Sam";
            var response = await _sut.GetCountries(name, 0, null, 0);

            var okResult = response as OkObjectResult;
            var countries = okResult.Value as IEnumerable<Country>;

            Assert.NotNull(countries);
            Assert.Single(countries);
            Assert.Equal("Samoa", countries.First().Name.Common);
        }
    }
}
