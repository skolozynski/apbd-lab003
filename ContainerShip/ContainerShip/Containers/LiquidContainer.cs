namespace ContainerShip.Containers;
using ContainerShip.Interfaces;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _Hazardous { get; set; }
    public LiquidContainer(double maxCargoWeight,
                            double height, 
                            double containerWeight, 
                            double depth, 
                            string serialNumber,
                            bool hazardous
                            ) 
        : base(maxCargoWeight, height, containerWeight, depth, serialNumber)
    {
        _Hazardous = hazardous;
    }

    public override void Load(double cargoWeight)
    {
        if (_Hazardous)
        {
            if (CargoWeight > MaxCargoWeight / 2)
                NotifyHazard();
            else
                base.Load(cargoWeight);
        }
        else
        {
            if(CargoWeight > MaxCargoWeight * 0.9 )
                NotifyHazard();
            else
                base.Load(cargoWeight);
        }
        
    }

    public void NotifyHazard()
    {
        Console.WriteLine(SerialNumber + " Hazardous situation detected!");
    }
}