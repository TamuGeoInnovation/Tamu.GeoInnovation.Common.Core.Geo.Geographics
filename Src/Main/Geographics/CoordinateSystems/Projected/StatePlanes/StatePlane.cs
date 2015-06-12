using USC.GISResearchLab.Common.Geographics.CoordinateSystems.Projected;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.StatePlanes
{
    public abstract class StatePlane : ProjectedCoordinateSystems
    {
        #region Properties

        private double _LongitudeOrigin;
        private double _NorthingGridBase;
        private double _EastingGridBase;
        private double _LatitudeOrigin;
        private double _SinLatitudeOrigin;
        private double _MappingRadius;
        private double _RadiusEllipsion;
        private double _NorthtingOrigin;
        private double[] _PolynomialCoeffients;
        private double[] _PolynomialCoeffientsInverse;

        // central longitude of meridian
        public double LongitudeOrigin
        {
            get { return _LongitudeOrigin; }
            set { _LongitudeOrigin = value; }
        }
        // northing of grid base
        public double NorthingGridBase
        {
            get { return _NorthingGridBase; }
            set { _NorthingGridBase = value; }
        }
        // easting of grid base
        public double EastingGridBase
        {
            get { return _EastingGridBase; }
            set { _EastingGridBase = value; }
        }
        // latitiude of central parallel
        public double LatitudeOrigin
        {
            get { return _LatitudeOrigin; }
            set { _LatitudeOrigin = value; }
        }
        // sine of latitiude of central parallel (ratio between lambda and longitude)
        public double SinLatitudeOrigin
        {
            get { return _SinLatitudeOrigin; }
            set { _SinLatitudeOrigin = value; }
        }
        // mapping radius through grid base
        public double MappingRadius
        {
            get { return _MappingRadius; }
            set { _MappingRadius = value; }
        }
        // radius of ellipsoid
        public double RadiusEllipsion
        {
            get { return _RadiusEllipsion; }
            set { _RadiusEllipsion = value; }
        }
        // northing of the projection origin
        public double NorthtingOrigin
        {
            get { return _NorthtingOrigin; }
            set { _NorthtingOrigin = value; }
        }
        // polynomial coefficient, size = 4
        public double[] PolynomialCoeffients
        {
            get { return _PolynomialCoeffients; }
            set { _PolynomialCoeffients = value; }
        }
        // polynomial coefficient of inverse, size = 4
        public double[] PolynomialCoeffientsInverse
        {
            get { return _PolynomialCoeffientsInverse; }
            set { _PolynomialCoeffientsInverse = value; }
        }
        #endregion
    }
}
