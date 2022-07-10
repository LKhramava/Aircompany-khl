namespace Aircompany.Planes
{
	public class PassengerPlane : Plane
	{
		public int PassengersCapacity { get; set; }

		public override bool Equals(object obj)
		{
			return (obj is PassengerPlane plane && base.Equals(obj) && PassengersCapacity.Equals(plane.PassengersCapacity));
		}

		public override int GetHashCode()
		{
			var hashCode = 751774561;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + PassengersCapacity.GetHashCode();
			return hashCode;
		}

		public override string ToString()
		{
			return base.ToString().Replace("}" , $", passengersCapacity={PassengersCapacity}}}");
		}
	}
}
