using System.Reflection.Metadata.Ecma335;
using ContainerShip.Containers;

namespace ContainerShip;

public class Ship
{
    public string Name { get; set; }
    private List<Container> _ContainersList = new();
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; } // weight in tons

    public Ship(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void Load(Container container)
    {
        _ContainersList.Add(container);
    }

    public void Load(List<Container> containers)
    {
        foreach (var container in containers)
            _ContainersList.Add(container);
    }

    public void UnloadContainer(Container container)
    {
        foreach (var e in _ContainersList)
        {
            if (e.SerialNumber == container.SerialNumber)
                _ContainersList.Remove(e);
        }
    }

    public void replace(Container toReplace, Container replaceTo)
    {
        _ContainersList.Remove(toReplace);
        _ContainersList.Add(replaceTo);
    }

    private double _CurrentWeight()
    {
        double weight = 0;
        foreach (var container in _ContainersList)
        {
            weight = weight + container.CargoWeight + container.ContainerWeight;
        }

        return weight / 1000;
    }

    public void Relocate(Container container, Ship ship)
    {
        foreach (var c in _ContainersList)
        {
            if (c.SerialNumber == container.SerialNumber)
            {
                _ContainersList.Remove(c);
                ship.Load(container);
            }
        }
    }
    
    public override string ToString()
    {
        return Name + " max capacity: " + MaxContainers + ", max weight: " + MaxWeight + " max speed: " + MaxSpeed
               + "\n\tCurrent: " + _ContainersList.Count + ", " + _CurrentWeight() + "t.";
    }

    public void About()
    {
        Console.WriteLine(this);
        foreach (var c in _ContainersList)
        {
            Console.WriteLine(c);
        }
    }
}