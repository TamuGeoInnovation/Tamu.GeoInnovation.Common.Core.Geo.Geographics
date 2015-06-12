using System;
using USC.GISResearchLab.Common.Geographics.Units;
using USC.GISResearchLab.Common.Geometries;
using USC.GISResearchLab.Common.Geometries.Lines;
using USC.GISResearchLab.Common.Geometries.Points;
using USC.GISResearchLab.Common.Geometries.Polygons;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.Conversions
{
    public class GeometryConverter
    {
        public static Geometry ConvertGeometry(Geometry inputGeometry, CoordinateSystem inputCS, Unit inputUnit, CoordinateSystem outputCS, Unit outputUnit)
        {
            Geometry ret = null;
            if (inputGeometry.GetType().Equals(typeof(Polygon)))
            {
                ret = ConvertPolygon((Polygon) inputGeometry, inputCS, inputUnit, outputCS, outputUnit);
            }
            else if (inputGeometry.GetType().Equals(typeof(PolyLine)))
            {
                ret = ConvertPolyLine((PolyLine)inputGeometry, inputCS, inputUnit, outputCS, outputUnit);
            }
            else if (inputGeometry.GetType().Equals(typeof(Line)))
            {
                ret = ConvertLine((Line)inputGeometry, inputCS, inputUnit, outputCS, outputUnit);
            }
            else if (inputGeometry.GetType().Equals(typeof(Point)))
            {
                ret = ConvertPoint((Point)inputGeometry, inputCS, inputUnit, outputCS, outputUnit);
            }
            else
            {
                throw new Exception("ConvertGeometry() encountered unexpected geometry type: " + inputGeometry.GetType());
            }

            ret.CoordinateUnits = outputUnit;
            return ret;
        }

        public static Polygon ConvertPolygon(Polygon inputPolyLine, CoordinateSystem inputCS, Unit inputUnit, CoordinateSystem outputCS, Unit outputUnit)
        {
            Polygon ret = null;

            for (int i = 0; i < inputPolyLine.Points.Length; i++)
            {
                if (ret == null)
                {
                    ret = new Polygon();
                }
                ret.AddPoint(ConvertPoint(inputPolyLine.Points[i], inputCS, inputUnit, outputCS, outputUnit));
            }
            return ret;
        }

        public static PolyLine ConvertPolyLine(PolyLine inputPolyLine, CoordinateSystem inputCS, Unit inputUnit, CoordinateSystem outputCS, Unit outputUnit)
        {
            PolyLine ret = null;

            for (int i = 0; i < inputPolyLine.Points.Length; i++)
            {
                if (ret == null)
                {
                    ret = new PolyLine();
                }

                ret.AddPoint(ConvertPoint(inputPolyLine.Points[i], inputCS, inputUnit, outputCS, outputUnit));
            }

            return ret;
        }

        public static Line ConvertLine(Line inputLine, CoordinateSystem inputCS, Unit inputUnit, CoordinateSystem outputCS, Unit outputUnit)
        {
            Point newStart = new Point(
                CoordinateSystemConverter.ConvertCoordinates(
                inputLine.Start.X, inputLine.Start.Y,
                inputCS, inputUnit,
                outputCS, outputUnit));

            Point newEnd = new Point(
                CoordinateSystemConverter.ConvertCoordinates(
               inputLine.End.X, inputLine.End.Y,
               inputCS, inputUnit,
               outputCS, outputUnit));

            return new Line(newStart, newEnd);
        }

        public static Point ConvertPoint(Point inputPoint, CoordinateSystem inputCS, Unit inputUnit, CoordinateSystem outputCS, Unit outputUnit)
        {
            return new Point(
                CoordinateSystemConverter.ConvertCoordinates(
                inputPoint.X, inputPoint.Y,
                inputCS, inputUnit,
                outputCS, outputUnit));
        }
    }
}
