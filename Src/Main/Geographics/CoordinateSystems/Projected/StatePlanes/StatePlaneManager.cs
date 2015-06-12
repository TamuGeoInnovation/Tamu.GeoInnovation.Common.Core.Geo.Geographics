using System;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems.StatePlanes
{
    public class StatePlaneManager
    {
        public const int COORDINATE_SYSTEM_CODE_STATE_PLANE_0405 = 0405;
        public const int COORDINATE_SYSTEM_CODE_STATE_PLANE_0406 = 0406;

        public static string COORDINATE_SYSTEM_NAME_STATE_PLANE_0405 = "STATE_PLANE_0405";
        public static string COORDINATE_SYSTEM_NAME_STATE_PLANE_0406 = "STATE_PLANE_0406";


        public static StatePlane FromCode(int code)
        {
            StatePlane ret = null;
            switch (code)
            {
                case COORDINATE_SYSTEM_CODE_STATE_PLANE_0405:
                    ret = new StatePlane0405();
                    break;
                case COORDINATE_SYSTEM_CODE_STATE_PLANE_0406:
                    ret = new StatePlane0406();
                    break;
                default:
                    throw new Exception("Error creating state plane - unsupported code encountered: " + code);
            }
            return ret;
        }
    }
}
