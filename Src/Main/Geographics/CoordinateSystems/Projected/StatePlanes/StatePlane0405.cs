namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.StatePlanes
{
    public class StatePlane0405 : StatePlane
    {

        public StatePlane0405()
        {
            Name = CoordinateSystemManager.COORDINATE_SYSTEM_NAME_STATE_PLANE_0405;
            Code = CoordinateSystemManager.COORDINATE_SYSTEM_CODE_STATE_PLANE_0405;

            LongitudeOrigin = 118.00;			// central longitude of meridian
            NorthingGridBase = 500000.0000;		// northing of grid base
            EastingGridBase = 2000000.0000;		// easting of grid base
            LatitudeOrigin = 34.7510553142;	// latitiude of central parallel
            SinLatitudeOrigin = 0.570011896174;// sine of latitiude of central parallel (ratio between lambda and longitude)
            MappingRadius = 9341756.1389;		// mapping radius through grid base
            RadiusEllipsion = 9202983.1099;		// radius of ellipsoid
            NorthtingOrigin = 638773.0290;		// northing of the projection origin

            PolynomialCoeffients = new double[4];
            PolynomialCoeffients[0] = 110927.3840;		// polynomial coefficient
            PolynomialCoeffients[1] = 9.12439;			// polynomial coefficient
            PolynomialCoeffients[2] = 5.64805;			// polynomial coefficient
            PolynomialCoeffients[3] = 0.017445;			// polynomial coefficient

            PolynomialCoeffientsInverse = new double[4];
            PolynomialCoeffientsInverse[0] = 9.014906468E-06;	// polynomial coefficient of inverse
            PolynomialCoeffientsInverse[1] = -6.68534E-15;		// polynomial coefficient of inverse
            PolynomialCoeffientsInverse[2] = -3.72796E-20;		// polynomial coefficient of inverse
            PolynomialCoeffientsInverse[3] = -8.6394E-28;		// polynomial coefficient of inverse
        }

        //////////////////////////////////
        // Original Stateplane 0405 constants
        ///////////////////////////////////
        ////state plane 0405 constants
        //public static double Lo = 118.00;			// central longitude of meridian
        //public static double Nb = 500000.0000;		// northing of grid base
        //public static double Eo = 2000000.0000;		// easting of grid base
        //public static double Bo = 34.7510553142;	// latitiude of central parallel
        //public static double SinBo = 0.570011896174;// sine of latitiude of central parallel (ratio between lambda and longitude)
        //public static double Rb = 9341756.1389;		// mapping radius through grid base
        //public static double Ro = 9202983.1099;		// radius of ellipsoid
        //public static double No = 638773.0290;		// northing of the projection origin

        //public static double L1 = 110927.3840;		// polynomial coefficient
        //public static double L2 = 9.12439;			// polynomial coefficient
        //public static double L3 = 5.64805;			// polynomial coefficient
        //public static double L4 = 0.017445;			// polynomial coefficient

        //public static double G1 = 9.014906468E-06;	// polynomial coefficient of inverse
        //public static double G2 = -6.68534E-15;		// polynomial coefficient of inverse
        //public static double G3 = -3.72796E-20;		// polynomial coefficient of inverse
        //public static double G4 = -8.6394E-28;		// polynomial coefficient of inverse

        
    }
}
