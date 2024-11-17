namespace ContactManager.V1.Models.Creational.Factory
{
    public interface IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<string> YData { get; set; }
        public void GenerateChart();
    }

    public interface IChartProvider
    {
        public void GetChart();
    }

    public class BarChart : IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<string> YData { get; set; }
        public void GenerateChart()
        {
            throw new NotImplementedException();
        }
    }
}
