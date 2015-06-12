using Microsoft.SqlServer.Types;

namespace USC.GISResearchLab.Common.Core.Geographics.SqlGeographies
{
    public class SqlGeographyUtils
    {
        public static SqlGeography CreatePoint(double x, double y)
        {
            return CreatePoint(x, y, 4326);
        }

        public static SqlGeography CreatePoint(double x, double y, int srid)
        {
            SqlGeographyBuilder builder = new SqlGeographyBuilder();
            builder.SetSrid(srid);
            builder.BeginGeography(OpenGisGeographyType.Point);

            builder.BeginFigure(y, x);

            builder.EndFigure();
            builder.EndGeography();

            return builder.ConstructedGeography;

        }

        public static SqlGeography CreateBox(double[] lowerLeft, double[] upperRight)
        {
            return CreateBox(lowerLeft, upperRight, 4326);
        }

        public static SqlGeography CreateBox(double[] lowerLeftXY, double[] upperRightXY, int srid)
        {
            SqlGeographyBuilder builder = new SqlGeographyBuilder();
            builder.SetSrid(srid);
            builder.BeginGeography(OpenGisGeographyType.Polygon);

            builder.BeginFigure(lowerLeftXY[0], lowerLeftXY[1]);
            builder.AddLine(lowerLeftXY[0], upperRightXY[1]);
            builder.AddLine(upperRightXY[0], upperRightXY[1]);
            builder.AddLine(upperRightXY[0], lowerLeftXY[1]);

            builder.EndFigure();
            builder.EndGeography();

            return builder.ConstructedGeography;

        }
    }
}
