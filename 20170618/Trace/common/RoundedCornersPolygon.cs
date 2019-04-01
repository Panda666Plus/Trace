using System.Windows.Media;

namespace Trace
{
    internal class RoundedCornersPolygon
    {
        public int ArcRoundness { get; set; }
        public bool IsClosed { get; set; }
        public object Points { get; internal set; }
        public SolidColorBrush Stroke { get; set; }
        public int StrokeThickness { get; set; }
        public bool UseAnglePercentage { get; set; }
    }
}