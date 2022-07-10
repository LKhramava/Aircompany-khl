using Aircompany.Models;

namespace Aircompany.Planes
{
	public class MilitaryPlane : Plane
	{
		public MilitaryType Type { get; set; }

		public override bool Equals(object obj)
		{
			return (obj is MilitaryPlane plane && base.Equals(obj) && Type.Equals(plane.Type));
		}

		public override int GetHashCode()
		{
			var hashCode = 1701194404;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + Type.GetHashCode();
			return hashCode;
		}


		public override string ToString()
		{
			return base.ToString().Replace("}", $", type={Type}}}");
		}
	}
}
