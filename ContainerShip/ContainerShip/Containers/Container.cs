using System.Runtime.InteropServices;
using ContainerShip.Exceptions;
using ContainerShip.Interfaces;

namespace ContainerShip.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double MaxCargoWeight { get; set; }
    public double Height { get; set; }
    public double ContainerWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; } // KON-C-1
    private static int _serialNumberCounter = 1;


    protected Container(double maxCargoWeight, double height, double containerWeight, double depth, string serialNumber)
    {
        MaxCargoWeight = maxCargoWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = serialNumber;
    }

    public virtual void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double cargoWeight)
    {
        if (CargoWeight > MaxCargoWeight)
            throw new OverfillException("Max weight overfilled!");
        CargoWeight = cargoWeight;
    }
}