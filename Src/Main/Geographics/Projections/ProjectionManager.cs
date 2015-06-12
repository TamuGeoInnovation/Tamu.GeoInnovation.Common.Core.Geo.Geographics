using System;

namespace USC.GISResearchLab.Common.Geographics.Projections
{
    public class ProjectionManager
    {

        public static string BuildProjectionString(
            string projectCS,
            string geogCS,
            string datum,
            string spheriod1,
            string spheriod2,
            string spheriod3,
            string primeMeridian1,
            string primeMeridian2,
            string unit1,
            string unit2,
            string projection,
            string parameters)
        {
            string ret = "";

            try
            {
                ret += "PROJCS["
                    + "'" + projectCS + "'" + ","
                    + "GEOGCS["
                    + "'" + geogCS + "'" + ","
                    + "DATUM["
                    + "'" + datum + "'" + ","
                    + "SPHEROID["
                    + "'" + spheriod1 + "'" + ","
                    + spheriod2 + ","
                    + spheriod3
                    + "]]" + ","
                    + "PRIMEM[" + "'" + primeMeridian1 + "'"
                    + "," + primeMeridian2
                    + "]" + ","
                    + "UNIT["
                    + "'" + unit1 + "'" + ","
                    + unit2 + "]]" + ","
                    + "PROJECTION[" + "'" + projection + "'" + "]";

                string[] parametersArray = parameters.Split(',');
                for (int i = 0; i < parametersArray.Length; i++)
                {
                    string[] parameter = parametersArray[i].Split(':');
                    ret += "," + "PARAMETER[" + "'" + parameter[0];
                    ret += "'" + "," + parameter[1].Trim() + "]";
                }

                ret += ",UNIT[" + "'" + "Foot_US" + "'" + ",0.304800609601219241]]";
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred building the projection string ", e);
            }

            return ret;
        }

    }
}
