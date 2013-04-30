using UnityEngine;
using System.Collections;

public abstract class Part 
{
    public string name;

    public string partInterface;
    public int aggregateScore;
    public int powerRequirement;
    public float defectiveChance;

    public abstract int calculateAggregate();
}

public class CPU : Part
{
    public int numberOfCores;
    public int clockSpeed;
    public int numberOfBits;

    public override int calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class GPU : Part
{
    public int flops;
    public int memory;

    public override int calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class HDD : Part
{
    public int size;
    public int speed;

    public override int calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class RAM : Part
{
    public int size;
    public int speed;
    public int parallelism;

    public override int calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class PowerSupply : Part
{
    public int wattage;


    public override int calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}