using System;
using USC.GISResearchLab.Common.Geographics.CoordinateSystems.Geographic;
using USC.GISResearchLab.Common.Geographics.CoordinateSystems.Projected.Cartesians;
using USC.GISResearchLab.Common.Geographics.CoordinateSystems.Projected.Screens;
using USC.GISResearchLab.Common.Geographics.CoordinateSystems.StatePlanes;
using USC.GISResearchLab.Common.Geographics.Units;
using USC.GISResearchLab.Common.Geographics.Units.Linears;
using USC.GISResearchLab.Common.Geographics.Units.NonLinears;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.Conversions
{
    public class CoordinateSystemConverter
    {

        public static double[] ConvertCoordinates(double x, double y, CoordinateSystem inputCS, Unit inputUnit, CoordinateSystem outputCS, Unit outputUnit)
        {
            double[] ret = null;
            if (inputCS.GetType().Equals(typeof(StatePlane)))
            {
                if (outputCS.GetType().Equals(typeof(GeographicCoordinateSystem)))
                {
                    ret = StatePlaneToDD(x, y, (StatePlane) inputCS, (LinearUnit) inputUnit);
                }
                else
                {
                    throw new NotImplementedException("ConvertCoordinates() does not yet implement from StatePlane to:" + outputCS);
                }
            }
            else if (inputCS.GetType().Equals(typeof(GeographicCoordinateSystem)))
            {
                if (outputCS.GetType().Equals(typeof(StatePlane)))
                {
                    ret = DDToStatePlane(x, y, (StatePlane)outputCS, (LinearUnit)outputUnit);
                }
                else if (outputCS.GetType().Equals(typeof(ScreenCoordinateSystem)))
                {
                    ret = DDToScreen(x, y, (GeographicCoordinateSystem)inputCS, (ScreenCoordinateSystem)outputCS, (LinearUnit) outputUnit);
                }
                else
                {
                    throw new NotImplementedException("ConvertCoordinates() does not yet implement from Geographic to:" + outputCS);
                }
            }
            else if (inputCS.GetType().Equals(typeof(ScreenCoordinateSystem)))
            {
                if (outputCS.GetType().Equals(typeof(GeographicCoordinateSystem)))
                {
                    ret = ScreenToDD(x, y, (ScreenCoordinateSystem) inputCS, (GeographicCoordinateSystem) outputCS, (NonLinearUnit)outputUnit);
                }
                else if (outputCS.GetType().Equals(typeof(StatePlane)))
                {
                    ret = ScreenToStatePlane(x, y, (ScreenCoordinateSystem) inputCS, (StatePlane)outputCS, (LinearUnit)outputUnit);
                }
                else
                {
                    throw new NotImplementedException("ConvertCoordinates() does not yet implement from Screen to:" + outputCS);
                }
            }
            else
            {
                throw new NotImplementedException("ConvertCoordinates() does not yet implement from " + inputCS + " to anything ");
            }
            return ret;
        }

        public static double[] ScreenToStatePlane(double x, double y, ScreenCoordinateSystem inputCS, StatePlane outputCS, LinearUnit outputUnit)
        {
            double[] ret = new double[2];
            return ret;
        }

        public static double[] ScreenToDD(double x, double y, ScreenCoordinateSystem inputCS, GeographicCoordinateSystem outputCS, NonLinearUnit outputUnit)
        {
            throw new NotImplementedException("Screen to Decimal Degrees is not yet implemented");
        }

        public static double[] ScreenToCartesian(double x, double y, ScreenCoordinateSystem inputCS, CartesianCoordinateSystem outputCS, LinearUnit outputUnit)
        {
            double[] ret = new double[2];

            double percentageX = x / inputCS.Width ;
            double percentageY = y / inputCS.Height;
            ret[0] = outputCS.MinX + (percentageX * outputCS.Width);
            ret[1] = outputCS.MinY + (percentageY * outputCS.Height);
            return ret;
        }

        public static double[] DDToScreen(double x, double y, GeographicCoordinateSystem inputCS, ScreenCoordinateSystem outputCS, LinearUnit outputUnit)
        {
            double[] ret = new double[2];
            return ret;
        }

        public static double[] DDToStatePlane(double lon, double lat, StatePlane statePlane, LinearUnit outputUnit)
        {
            double[] ret = new double[2];
            lat = System.Math.Abs(lat);
            lon = System.Math.Abs(lon);

            // state plane derived values

            // North geodedic point of station (point)
            double B = lat;

            // West geodedic point of station (point)
            double L = lon;

            double deltaB = B - statePlane.LatitudeOrigin;

            // radial distance on projection from station (point) to central parallel 
            double u =
                statePlane.PolynomialCoeffients[0] *
                deltaB +
                statePlane.PolynomialCoeffients[1] *
                (System.Math.Pow(deltaB, 2)) + statePlane.PolynomialCoeffients[2] * (System.Math.Pow(deltaB, 3)) +
                statePlane.PolynomialCoeffients[3] * (System.Math.Pow(deltaB, 4));

            // Mapping radius through a station 
            double R = statePlane.RadiusEllipsion - u;

            // plane convergence angle (mapping angle)
            double lambda = (statePlane.LongitudeOrigin - L) * statePlane.SinLatitudeOrigin;

            double[] lDegrees = UnitConverter.DDToDMS(lambda);

            // easting of station
            double e = statePlane.EastingGridBase + (R * System.Math.Sin(lambda * (System.Math.PI / 180)));

            // northing of station
            double n = statePlane.NorthtingOrigin + u + ((R * System.Math.Sin(lambda * (System.Math.PI / 180))) * System.Math.Tan(lambda * (System.Math.PI / 180) / 2));

            double factor = UnitConverter.GetLengthConversionFactorFromMeters(outputUnit.LinearUnitTypes);
            ret[0] = e * factor;
            ret[1] = n * factor;

            return ret;
        }

        public static double[] StatePlaneToDD(double easting, double northing, StatePlane statePlane, LinearUnit inputUnit)
        {

            double factor = UnitConverter.GetLengthConversionFactorToMeters(inputUnit.LinearUnitTypes);
            northing = northing * factor;
            easting = easting * factor;

            double[] ret = new double[2];
            // plane convergence angle (mapping angle)
            double lambda =
                System.Math.Atan(
                (easting - statePlane.EastingGridBase) /
                (statePlane.MappingRadius - northing + statePlane.NorthingGridBase)
                ) * 
                180 / System.Math.PI;

            // west longitude of station (point)
            double L = statePlane.LongitudeOrigin - (lambda / statePlane.SinLatitudeOrigin);

            // radial distance on projection from station (point) to central parallel 
            double u =
                northing - statePlane.NorthingGridBase -
                ((easting - statePlane.EastingGridBase) *
                System.Math.Atan((easting - statePlane.EastingGridBase) / 
                (statePlane.MappingRadius - northing + statePlane.NorthingGridBase)) / 2);

            // north latitude of station (point)
            double
                B = statePlane.LatitudeOrigin + statePlane.PolynomialCoeffientsInverse[0] *
                u + statePlane.PolynomialCoeffientsInverse[1] *
                System.Math.Pow(u, 2) + statePlane.PolynomialCoeffientsInverse[2] *
                System.Math.Pow(u, 3) + statePlane.PolynomialCoeffientsInverse[3] * System.Math.Pow(u, 4);

            ret[0] = L;
            ret[1] = B;

            return ret;
        }


        ///////////////////////////////////
        // Original StatePlane Calculations
        ///////////////////////////////////

        //public static GeoPointDecimalDegrees sp2dd(string northing, string easting, string zone)
        //{
        //    //GeoPointDegreesMinutesSeconds geoPointDegreesMinutesSeconds = CoordinateAgentUtils.getDegreesMinutesSeconds(northing, easting, zone, agentServerUrl);


        //    double e = Convert.ToDouble(easting);
        //    double n = Convert.ToDouble(northing);

        //    double lambda;								// plane convergence angle (mapping angle)
        //    lambda = System.Math.Atan((e - Eo) / (Rb - n + Nb)) * 180 / System.Math.PI;


        //    double L;									// west longitude of station (point)
        //    L = Lo - (lambda/SinBo);

        //    double[] lDegrees = UnitConverter.DDToDMS(L);

        //    double u;									// radial distance on projection from station (point) to central parallel 
        //    //u = n - No - ((e - Eo) * (System.Math.Tan(lambda/2)));
        //    u = n - No - ((e - Eo) * System.Math.Atan((e - Eo)/(Rb - n + Nb)) / 2);


        //    double B;									// north latitude of station (point)
        //    //B = Bo + u*(G1 + u*(G2 + u*(G3 + G4*u)));
        //    B = Bo + G1 * u + G2 * System.Math.Pow(u, 2) + G3 * System.Math.Pow(u, 3) + G4 * System.Math.Pow(u, 4);

        //    double[] bDegrees = UnitConverter.DDToDMS(B);

        //    GeoPointDecimalDegrees geoPointDecimalDegrees = new GeoPointDecimalDegrees();

        //    geoPointDecimalDegrees.Longitude.Degrees = L;
        //    geoPointDecimalDegrees.Latitude.Degrees = B;


        //    return geoPointDecimalDegrees;
        //}

        //public static GeoPointStatePlane dd2spFeet(string lat, string lon, string zone)
        //{
        //    return dd2sp(lat, lon, zone, false);
        //}

        //public static GeoPointStatePlane dd2spMeters(string lat, string lon, string zone)
        //{
        //    return dd2sp(lat, lon, zone, true);
        //}

        //public static GeoPointStatePlane dd2sp(string lat, string lon, string zone, bool isMeters)
        //{
        //    double latDouble = System.Math.Abs(Convert.ToDouble(lat));
        //    double lonDouble = System.Math.Abs(Convert.ToDouble(lon));

        //    // state plane derived values
        //    double B;									// North geodedic point of station (point)
        //    B = latDouble;

        //    double L;									// West geodedic point of station (point)
        //    L = lonDouble;

        //    double deltaB;
        //    deltaB = B - Bo;

        //    double u;									// radial distance on projection from station (point) to central parallel 
        //    u = L1*deltaB + L2*(System.Math.Pow(deltaB,2)) + L3*(System.Math.Pow(deltaB,3)) + L4*(System.Math.Pow(deltaB,4));

        //    double R;									// Mapping radius through a station 
        //    R = Ro - u;


        //    double lambda;								// plane convergence angle (mapping angle)
        //    lambda = (Lo - L) * SinBo;

        //    double[] lDegrees = UnitConverter.DDToDMS(lambda);

        //    double e;									// easting of station
        //    e = Eo + (R * System.Math.Sin(lambda * (System.Math.PI / 180)));

        //    double n;									// northing of station
        //    n = No + u + ((R * System.Math.Sin(lambda * (System.Math.PI / 180))) * System.Math.Tan(lambda * (System.Math.PI / 180) / 2));

        //    GeoPointStatePlane geoPointStatePlane = new GeoPointStatePlane();
        //    if (isMeters)
        //    {
        //        geoPointStatePlane.Easting.Coordinate = e.ToString();
        //        geoPointStatePlane.Northing.Coordinate = n.ToString();
        //    }
        //    else
        //    {
        //        geoPointStatePlane.Easting.Coordinate = (e * LengthConversionConstants.FEET_PER_METER).ToString();
        //        geoPointStatePlane.Northing.Coordinate = (n * LengthConversionConstants.FEET_PER_METER).ToString();
        //    }
        //    geoPointStatePlane.Zone = zone;

        //    return geoPointStatePlane;
        //}

    }
}
