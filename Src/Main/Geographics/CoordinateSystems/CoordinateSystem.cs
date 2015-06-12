using System.Text;

namespace USC.GISResearchLab.Common.Geographics.CoordinateSystems
{
    public abstract class CoordinateSystem
    {
        #region Properties
        private int _Code;
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: {1}", Code, Name);
            return sb.ToString();
        }
    }
}
