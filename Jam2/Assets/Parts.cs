using UnityEngine;
using System.Collections;

public class Motherboard
{
    public string CPUInterface;
    public string GPUInterface;
    public string HDDInterface;
    public string RAMInterface;
    public string powerInterface;
    public string compInputInterface;
    public string compOutputInterface;
    public string networkInterface;
    public string formFactor;

    public CPU cpu;
    public GPU gpu;
    public HDD hdd;
    public RAM ram;
    public CompInput input;
    public CompOutput output;
    public CompNetwork network;
    public PowerSupply pSupply;
    public Chassis chassis;

    public float defectiveChance;
}

public abstract class Part 
{
    public Part() { }
    public Part(string name, string partInterface, int powerRequirement, float defectiveChance)
    {
        this.partInterface = partInterface;
        this.powerRequirement = powerRequirement;
        this.defectiveChance = defectiveChance;
    }

    public string name;

    public string partInterface;
    public float aggregateScore;
    public int powerRequirement;
    public float defectiveChance;

    public abstract float calculateAggregate();
}

public class CPU : Part
{
    public CPU() { }

    public CPU(string name, string partInterface, int powerRequirement, float defectiveChance, int numberOfCores, int clockSpeed, int numberOfBits) 
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.numberOfCores = numberOfCores;
        this.clockSpeed = clockSpeed;
        this.numberOfBits = numberOfBits;
    }

    public int numberOfCores;
    public int clockSpeed;
    public int numberOfBits;

    public override float calculateAggregate()
    {
        //throw new System.NotImplementedException();
        aggregateScore = 0.0f;
        for (int i = 0; i < numberOfCores; i++)
        {
            aggregateScore += (float) clockSpeed * (1.0f / (float) i);
        }
        return aggregateScore;
    }
}

public class GPU : Part
{
    public GPU() { }
    public GPU(string name, string partInterface, int powerRequirement, float defectiveChance, int megaflops, int memory)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.megaflops  = megaflops;
        this.memory = memory; 
    }

    public int megaflops;
    public int memory;

    public override float calculateAggregate()
    {
        //(megamegaflops + (1000 * memory in MB))/[something]
        throw new System.NotImplementedException();
    }
}

public class HDD : Part
{
    public HDD() { }

    public HDD(string name, string partInterface, int powerRequirement, float defectiveChance, int size, int speed)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.size   = size;
        this.speed  = speed;
    }

    public int size;
    public int speed;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class RAM : Part
{
    public RAM() { }

    public RAM(string name, string partInterface, int powerRequirement, float defectiveChance, int size, int speed, int channels)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.size = size;
        this.speed = speed;
        this.channels = channels;
    }

    public int size;
    public int speed;
    public int channels;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class CompInput : Part
{
    public CompInput() { }

    public CompInput(string name, string partInterface, int powerRequirement, float defectiveChance, int mouseDPI, int pollingRate, bool isMechanical)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.mouseDPI       = mouseDPI;
        this.pollingRate    = pollingRate;
        this.isMechanical   = isMechanical;
    }

    public int mouseDPI;
    public int pollingRate;
    public bool isMechanical;

    public override float calculateAggregate()
    {
 	    throw new System.NotImplementedException();
    }
}

public class CompOutput : Part
{
    public CompOutput() { }

    public CompOutput(string name, string partInterface, int powerRequirement, float defectiveChance, int resolution, int refreshRate, int soundQuality)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.resolution     = resolution;
        this.refreshRate    = refreshRate;
        this.soundQuality   = soundQuality;
    }

    public int resolution;
    public int refreshRate;
    public int soundQuality;

    public override float calculateAggregate()
    {
 	    throw new System.NotImplementedException();
    }
}

public class CompNetwork : Part
{
    public CompNetwork() { }

    public CompNetwork(string name, string partInterface, int powerRequirement, float defectiveChance, NetworkType networkType, int ping, int bandwidth, int qualityOfService)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.networkType = networkType;
        this.ping = ping;
        this.bandwidth = bandwidth;
        this.qualityOfService = qualityOfService;
    }

    public NetworkType networkType;
    public int ping;
    public int bandwidth;
    public int qualityOfService;

    public override float calculateAggregate()
    {
 	    throw new System.NotImplementedException();
    }
}

public class PowerSupply : Part
{
    public PowerSupply() { }

    public PowerSupply(string name, string partInterface, int powerRequirement, float defectiveChance, int wattage)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.wattage = wattage;
    }
    public int wattage;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}

public class Chassis : Part
{
    public Chassis() { }
    public Chassis(string name, string partInterface, int powerRequirement, float defectiveChance, int coolFactor)
        : base(name, partInterface, powerRequirement, defectiveChance)
    {
        this.coolFactor = coolFactor;
    }

    public int coolFactor;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}