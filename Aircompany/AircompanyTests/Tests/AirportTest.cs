using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
	[TestFixture]
	public class AirportTest
	{
		private List<Plane> planes = new List<Plane>(){
			new PassengerPlane
			{
				Model ="Boeing-737",
				MaxSpeed = 900,
				MaxFlightDistance = 12000,
				MaxLoadCapacity = 60500,
				PassengersCapacity = 164
			},
			new PassengerPlane
			{
				Model ="Boeing-737-800",
				MaxSpeed = 940,
				MaxFlightDistance = 12300,
				MaxLoadCapacity = 63870,
				PassengersCapacity = 192
			},
			new PassengerPlane
			{
				Model ="Boeing-747",
				MaxSpeed = 980,
				MaxFlightDistance = 16100,
				MaxLoadCapacity = 70500,
				PassengersCapacity = 242
			},
			new PassengerPlane
			{
				Model ="Airbus A320",
				MaxSpeed = 930,
				MaxFlightDistance = 11800,
				MaxLoadCapacity = 65500,
				PassengersCapacity = 188
			},
			new PassengerPlane
			{
				Model ="Airbus A330",
				MaxSpeed = 990,
				MaxFlightDistance = 14800,
				MaxLoadCapacity = 80500,
				PassengersCapacity = 222
			},
			new PassengerPlane
			{
				Model ="Embraer 190",
				MaxSpeed = 870,
				MaxFlightDistance = 8100,
				MaxLoadCapacity = 30800,
				PassengersCapacity = 64
			},
			new PassengerPlane
			{
				Model ="Sukhoi Superjet 100",
				MaxSpeed = 870,
				MaxFlightDistance = 11500,
				MaxLoadCapacity = 50500,
				PassengersCapacity = 140
			},
			new PassengerPlane
			{
				Model ="Bombardier CS300",
				MaxSpeed = 920,
				MaxFlightDistance = 11000,
				MaxLoadCapacity = 60700,
				PassengersCapacity = 196
			},
			new MilitaryPlane
			{
				Model ="B-1B Lancer",
				MaxSpeed = 1050,
				MaxFlightDistance = 21000,
				MaxLoadCapacity = 80000,
				Type = MilitaryType.Bomber
			},
			new MilitaryPlane
			{
				Model ="B-2 Spirit",
				MaxSpeed = 1030,
				MaxFlightDistance = 22000,
				MaxLoadCapacity = 70000,
				Type = MilitaryType.Bomber
			},
			new MilitaryPlane
			{
				Model ="B-52 Stratofortress",
				MaxSpeed = 1000,
				MaxFlightDistance = 20000,
				MaxLoadCapacity = 80000,
				Type = MilitaryType.Bomber
			},
			new MilitaryPlane
			{
				Model ="F-15",
				MaxSpeed = 1500,
				MaxFlightDistance = 12000,
				MaxLoadCapacity = 10000,
				Type = MilitaryType.Fighter
			},
			new MilitaryPlane
			{
				Model ="F-22",
				MaxSpeed = 1550,
				MaxFlightDistance = 13000,
				MaxLoadCapacity = 11000,
				Type = MilitaryType.Fighter
			},
			new MilitaryPlane
			{
				Model ="C-130 Hercules",
				MaxSpeed = 650,
				MaxFlightDistance = 5000,
				MaxLoadCapacity = 110000,
				Type = MilitaryType.Transport
			}
	};

		private PassengerPlane planeWithMaxPassengerCapacity = new PassengerPlane()
		{
			Model = "Boeing-747",
			MaxSpeed = 980,
			MaxFlightDistance = 16100,
			MaxLoadCapacity = 70500,
			PassengersCapacity = 242
		};

		[Test]
		public void VerifyHasMilitaryTransportPlane()
		{
			Airport airport = new Airport
			{
				Planes = planes
			};
			List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();
			var hasMilitaryTransportPlane = transportMilitaryPlanes.Any(x => x.Type.Equals(MilitaryType.Transport));

			Assert.IsTrue(hasMilitaryTransportPlane);
		}

		[Test]
		public void VerifyPassengerPlaneWithMaxPassengersCapacity()
		{
			Airport airport = new Airport()
			{
				Planes = planes
			};

			PassengerPlane actualPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();
			Assert.AreEqual(planeWithMaxPassengerCapacity, actualPlaneWithMaxPassengersCapacity);
		}

		[Test]
		public void VerifyNextPlaneMaxLoadCapacityIsHigherThanCurrent()
		{
			Airport airport = new Airport
			{
				Planes = planes
			};
			airport = airport.SortByMaxLoadCapacity();
			List<Plane> planesSortedByMaxLoadCapacity = airport.Planes.ToList();

			bool nextPlaneMaxLoadCapacityIsHigherThanCurrent = true;
			for (int i = 0; i < planesSortedByMaxLoadCapacity.Count - 1; i++)
			{
				if (planesSortedByMaxLoadCapacity[i].MaxLoadCapacity > planesSortedByMaxLoadCapacity[i + 1].MaxLoadCapacity)
					nextPlaneMaxLoadCapacityIsHigherThanCurrent = false;
			}
			Assert.IsTrue(nextPlaneMaxLoadCapacityIsHigherThanCurrent);
		}
	}
}
