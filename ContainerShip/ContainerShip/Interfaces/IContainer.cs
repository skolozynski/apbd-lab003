﻿namespace ContainerShip.Interfaces;

public interface IContainer
{
    void Unload();
    void Load(double cargoWeight);
}