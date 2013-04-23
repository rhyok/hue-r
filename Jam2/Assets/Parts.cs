using UnityEngine;
using System.Collections;

public abstract class Part 
{
    public string name;

    public string partInterface;
    public int aggregateScore;
    public int powerRequirement;
    public float defectiveChance;

    public int calculateAggregate();
}

public class CPU : Part
{
    public int numberOfCores;
    public int clockSpeed;
    public int numberOfBits;
}

public class GPU : Part
{
    public int clockSpeed;
    public int numberOfCores;
    public int memory;
}

public class HDD : Part
{
    public int size;
    public int speed;
}

public class RAM : Part
{
    public int size;
    public int speed;
    public int parallelism;
}

public class PowerSupply : Part
{
    public int wattage;
    
}