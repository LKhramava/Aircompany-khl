using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
	public class Airport
	{
		public List<Plane> Planes { get; set; }

		public List<PassengerPlane> GetPassengersPlanes()
		{
			return Planes.Where(plane => plane.GetType() == typeof(PassengerPlane)).Select(plane => plane as PassengerPlane).ToList();
		}

		public List<MilitaryPlane> GetMilitaryPlanes()
		{
			return Planes.Where(plane => plane is MilitaryPlane).Select(plane => plane as MilitaryPlane).ToList();
		}

		public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
		{
			List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
			var maxPassengerCapacity = passengerPlanes.Max(plane => plane.PassengersCapacity);
			return passengerPlanes.First(x => x.PassengersCapacity == maxPassengerCapacity);
		}

		public List<MilitaryPlane> GetTransportMilitaryPlanes()
		{
			return Planes.Where(plane => plane is MilitaryPlane && ((MilitaryPlane)plane).Type == MilitaryType.Transport).Select(plane => plane as MilitaryPlane).ToList();
		}
		public Airport SortByMaxDistance()
		{
			return new Airport
			{
				Planes = Planes.OrderBy(w => w.MaxFlightDistance).ToList(),
			};
		}

		public Airport SortByMaxSpeed()
		{
			return new Airport
			{
				Planes = Planes.OrderBy(w => w.MaxSpeed).ToList()
			};
		}

		public Airport SortByMaxLoadCapacity()
		{
			return new Airport
			{
				Planes = Planes.OrderBy(w => w.MaxLoadCapacity).ToList()
			};
		}

		public override string ToString()
		{
			var planesString = string.Join(", ", Planes.Select(x => x.Model));
			return $"Airport{{planes={planesString}}}";
		}
	}
}
