using USC.GISResearchLab.Common.Geographics.CoordinateSystems.Projected.Cartesians;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.Projected.Screens
{
    public class ScreenCoordinateSystem : CartesianCoordinateSystem
    {
        public ScreenCoordinateSystem(double minX, double minY, double maxX, double maxY)
            : base(minX, minY, maxX, maxY)
        {
        }

        public ScreenCoordinateSystem(double width, double height)
            : base(width, height)
        {
        }

        public ScreenCoordinateSystem(double size)
            : base(size)
        {
        }
    }
}
