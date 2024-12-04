using route_optimizer.api.Services;

namespace route_optmizer.tests
{
    public class ShortestPathServiceTests
    {
        [Fact]
        public void CalculateShortestPath_ShouldReturnCorrectPathAndDistance()
        {
            var service = new ShortestPathService();

            var result = service.CalculateShortestPath("A", "F");
            Assert.Equal(new List<string> { "A", "B", "F" }, result.NodeNames);
            Assert.Equal(6, result.Distance);

        }
    }
}