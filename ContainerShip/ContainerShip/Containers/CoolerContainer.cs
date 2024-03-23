using ContainerShip.Enums;

namespace ContainerShip.Containers;

public class CoolerContainer : Container
{
    public PossibleProducts Product { get; set; }
    public double Temperature { get; set; }

    public CoolerContainer(double maxCargoWeight, double height, double containerWeight, double depth, string serialNumber, PossibleProducts product) : base(maxCargoWeight, height, containerWeight, depth, serialNumber)
    {
        Product = product;
    }
}