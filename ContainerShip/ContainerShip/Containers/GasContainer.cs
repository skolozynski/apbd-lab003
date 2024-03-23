using System.Security.AccessControl;
using ContainerShip.Interfaces;

namespace ContainerShip.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public double MaxPressure { get; set; }

    public GasContainer(double maxCargoWeight,
                        double height,
                        double containerWeight,
                        double depth,
                        string serialNumber,
                        double maxPressure) 
        : base(maxCargoWeight, height, containerWeight, depth, serialNumber)
    {
        MaxPressure = maxPressure;
    }

    public void Unload()
    {
        CargoWeight *= 0.05;
        NotifyHazard();
    }

    public void NotifyHazard()
    {
        if (CargoWeight < MaxCargoWeight * 0.05)
            Console.WriteLine(SerialNumber + "Hazardous situation detected!");
    }
}