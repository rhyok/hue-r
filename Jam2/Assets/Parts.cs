using UnityEngine;
using System.Collections;

public abstract class Part 
{
    public string name;

    public string partInterface;
    public float aggregateScore;
    public int powerRequirement;
    public float defectiveChance;

    public abstract float calculateAggregate();
}

public class CPU : Part
{
    public int numberOfCores;
    public int clockSpeed;
    public int numberOfBits;

    public override float calculateAggregate()
    {
        //throw new System.NotImplementedException();
        aggregateScore = 0.0f;
        for (int i = 0; i < numberOfCores; i++)
        {
            aggregateScore += clockSpeed * (1 / i);
        }
        return aggregateScore;
    }
}

public class GPU : Part
{
    public int flops;
    public int memory;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class HDD : Part
{
    public int size;
    public int speed;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class RAM : Part
{
    public int size;
    public int speed;
    public int parallelism;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class PowerSupply : Part
{
    public int wattage;


    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}