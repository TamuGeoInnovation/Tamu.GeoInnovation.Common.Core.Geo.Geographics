namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.Projected.Cartesians
{
    public class CartesianCoordinateSystem : ProjectedCoordinateSystems
    {
        #region Properties
        private double _MinX;
        private double _MaxX;
        private double _MinY;
        private double _MaxY;

        public double MinX
        {
            get { return _MinX; }
            set { _MinX = value; }
        }

        public double MaxX
        {
            get { return _MaxX; }
            set { _MaxX = value; }
        }

        public double MinY
        {
            get { return _MinY; }
            set { _MinY = value; }
        }

        public double MaxY
        {
            get { return _MaxY; }
            set { _MaxY = value; }
        }

        public double Height
        {
            get { return MaxY - MinY; }
        }

        public double Width
        {
            get { return MaxX - MinX; }
        }
	
        #endregion

        public CartesianCoordinateSystem(double minX, double minY, double maxX, double maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }

        public CartesianCoordinateSystem(double width, double height)
        {
            MinX = 0;
            MaxX = width;
            MinY = 0;
            MaxY = height;
        }

        public CartesianCoordinateSystem(double size)
        {
            MinX = 0;
            MaxX = size;
            MinY = 0;
            MaxY = size;
        }
    }
}
