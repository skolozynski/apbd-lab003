using ContainerShip;
using ContainerShip.Containers;
using ContainerShip.Enums;



Ship ship = new Ship("Falcon", 70, 150, 150*5);
var c1 = new LiquidContainer(200, 10,1,6,"KON-L", false);
var c2 = new GasContainer(200, 10,1,6,"KON-G", 21);
var c3 = new CoolerContainer(200, 10,1,6,"KON-C", PossibleProducts.Bananas);
c1.Load(150);
c2.Load(300);
c3.Load(200);

List<Container> list = new ();
list.Add(c2);
list.Add(c3);

ship.Load(c1);
ship.Load(list);

Console.WriteLine(ship);