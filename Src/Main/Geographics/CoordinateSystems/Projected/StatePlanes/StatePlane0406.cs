namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.StatePlanes
{
    public class StatePlane0406 : StatePlane
    {
        public StatePlane0406()
        {
            
            Name = CoordinateSystemManager.COORDINATE_SYSTEM_NAME_STATE_PLANE_0406;
            Code = CoordinateSystemManager.COORDINATE_SYSTEM_CODE_STATE_PLANE_0406;

            LongitudeOrigin = 116.25;			// central longitude of meridian
            NorthingGridBase = 500000.0000;		// northing of grid base
            EastingGridBase = 2000000.0000;		// easting of grid base
            LatitudeOrigin = 33.3339229447;	// latitiude of central parallel
            SinLatitudeOrigin = 0.549517575763;// sine of latitiude of central parallel (ratio between lambda and longitude)
            MappingRadius = 9836091.7896;		// mapping radius through grid base
            RadiusEllipsion = 9706640.0762;		// radius of ellipsoid
            NorthtingOrigin = 629451.7134;		// northing of the projection origin

            PolynomialCoeffients = new double[4];
            PolynomialCoeffients[0] = 110905.3274;		// polynomial coefficient
            PolynomialCoeffients[1] = 8.94188;			// polynomial coefficient
            PolynomialCoeffients[2] = 5.65087;			// polynomial coefficient
            PolynomialCoeffients[3] = 0.016171;			// polynomial coefficient

            PolynomialCoeffientsInverse = new double[4];
            PolynomialCoeffientsInverse[0] = 9.016699372E-06;	// polynomial coefficient of inverse
            PolynomialCoeffientsInverse[1] = -6.55499E-15;		// polynomial coefficient of inverse
            PolynomialCoeffientsInverse[2] = -3.73318E-20;		// polynomial coefficient of inverse
            PolynomialCoeffientsInverse[3] = -8.2753E-28;		// polynomial coefficient of inverse
        }

        //////////////////////////////////
        // Original Stateplane 0406 constants
        ///////////////////////////////////
        //		public static double Lo = 116.25;			// central longitude of meridian
        //		public static double Nb = 500000.0000;		// northing of grid base
        //		public static double Eo = 2000000.0000;		// easting of grid base
        //		public static double Bo = 33.3339229447;	// latitiude of central parallel
        //		public static double SinBo = 0.549517575763;// sine of latitiude of central parallel (ratio between lambda and longitude)
        //		public static double Rb = 9836091.7896;		// mapping radius through grid base
        //		public static double Ro = 9706640.0762;		// radius of ellipsoid
        //		public static double No = 629451.7134;		// northing of the projection origin
        //
        //		public static double L1 = 110905.3274;		// polynomial coefficient
        //		public static double L2 = 8.94188;			// polynomial coefficient
        //		public static double L3 = 5.65087;			// polynomial coefficient
        //		public static double L4 = 0.016171;			// polynomial coefficient
        //
        //		public static double G1 = 9.016699372E-06;	// polynomial coefficient of inverse
        //		public static double G2 = -6.55499E-15;		// polynomial coefficient of inverse
        //		public static double G3 = -3.73318E-20;		// polynomial coefficient of inverse
        //		public static double G4 = -8.2753E-28;		// polynomial coefficient of inverse
    }
}
