using System.Text;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems
{
    public abstract class CoordinateSystem
    {
        #region Properties


        public string Name { get; set; }
        public int Code { get; set; }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: {1}", Code, Name);
            return sb.ToString();
        }
    }
}
