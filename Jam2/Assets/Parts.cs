using UnityEngine;
using System.Collections;

public class Motherboard
{
    public Motherboard() { }
    public Motherboard(string name, float price, float defectiveChance, string CPUI, string GPUI, string HDDI, string RAMI, 
        string powerI, string compInputI, string compOutputI, string networkI, string formFactor,
        CPU cpu, GPU gpu, HDD hdd, RAM ram, CompInput input, CompOutput output, CompNetwork network,
        PowerSupply pSupply, Chassis chassis)
    {
        this.name                   = name;
        this.price                  = price;
        this.defectiveChance        = defectiveChance;
        this.CPUInterface           = CPUI;
        this.GPUInterface           = GPUI;
        this.HDDInterface           = HDDI;
        this.RAMInterface           = RAMI;
        this.powerInterface         = powerI;
        this.compInputInterface     = compInputI;
        this.compOutputInterface    = compOutputI;
        this.networkInterface       = networkI;
        this.formFactor             = formFactor;
        this.cpu                    = cpu;
        this.gpu                    = gpu;
        this.hdd                    = hdd;
        this.ram                    = ram;
        this.input                  = input;
        this.output                 = output;
        this.network                = network;
        this.pSupply                = pSupply;
        this.chassis                = chassis;
    }


    public string name;
    public Company company;
    public float price;
    public float defectiveChance;

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

    public bool plugIn(Part part)
    {
        bool returnValue = false;

        if (part.GetType() == typeof(CPU))
        {
            if (part.partInterface == CPUInterface)
            {
                this.cpu = (CPU) part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(GPU))
        {
            if (part.partInterface == GPUInterface)
            {
                this.gpu = (GPU)part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(HDD))
        {
            if (part.partInterface == HDDInterface)
            {
                this.hdd = (HDD)part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(RAM))
        {
            if (part.partInterface == RAMInterface)
            {
                this.ram = (RAM)part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(CompInput))
        {
            if (part.partInterface == compInputInterface)
            {
                this.input = (CompInput)part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(CompOutput))
        {
            if (part.partInterface == compOutputInterface)
            {
                this.output = (CompOutput)part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(CompNetwork))
        {
            if (part.partInterface == networkInterface)
            {
                this.network = (CompNetwork) part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(PowerSupply))
        {
            if (part.partInterface == powerInterface)
            {
                this.pSupply = (PowerSupply)part;
                returnValue = true;
            }
        }
        if (part.GetType() == typeof(Chassis))
        {
            if (part.partInterface == formFactor)
            {
                this.chassis = (Chassis)part;
                returnValue = true;
            }
        }

        return returnValue;
    }
}

public abstract class Part 
{
    public Part() { }
    public Part(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance)
    {
        this.name = name;
        this.company = company;
        this.price = price;
        this.partInterface = partInterface;
        this.powerRequirement = powerRequirement;
        this.defectiveChance = defectiveChance;
    }

    public string name;
    public Company company;
    public float price;

    public string partInterface;
    public float aggregateScore;
    public int powerRequirement;
    public float defectiveChance;

    public abstract float calculateAggregate();
}

public class CPU : Part
{
    public CPU() { }

    public CPU(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int numberOfCores, int clockSpeed, int numberOfBits)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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
    public GPU(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int megaflops, int memory)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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

    public HDD(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int size, int speed)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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

    public RAM(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int size, int speed, int channels)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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

    public CompInput(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int mouseDPI, int pollingRate, bool isMechanical)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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

    public CompOutput(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int resolution, int refreshRate, int soundQuality)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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

    public CompNetwork(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, NetworkType networkType, int ping, int bandwidth)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
    {
        this.networkType = networkType;
        this.ping = ping;
        this.bandwidth = bandwidth;
    }

    public NetworkType networkType;
    public int ping;
    public int bandwidth;

    public override float calculateAggregate()
    {
 	    throw new System.NotImplementedException();
    }
}

public class PowerSupply : Part
{
    public PowerSupply() { }

    public PowerSupply(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int wattage)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
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
    public Chassis(string name, Company company, float price, string partInterface, int powerRequirement, float defectiveChance, int coolFactor)
        : base(name, company, price, partInterface, powerRequirement, defectiveChance)
    {
        this.coolFactor = coolFactor;
    }

    public int coolFactor;

    public override float calculateAggregate()
    {
        throw new System.NotImplementedException();
    }
}