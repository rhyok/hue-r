using UnityEngine;
using System.Collections;
using System;

public enum Company { 
    LASUS,
    EDVI,
    MPI,
    MAURADER,
    COMPUTECH,
    PINTEL,
    AND,
    GIGAFLOP,
    QUEENSTON,
    ANT_TECH,
    MACROSOFT,
    ORANGE,
    ESSENTIAL,
    EASTERN,
    LOGIBLAT,
    PHAZER,
    SINGULAR,
    CHRONO,
    BOMBAST
}

public enum PartType
{
    MOBO,
    CPU,
    GPU,
    RAM,
    HDD,
    PSU,
    CHASSIS,
    INPUT,
    OUTPUT,
    NETWORK
}

public enum Interfaces
{
    TYPE1,
    TYPE2,
    TYPE3,
    TYPE4,
    TYPE5,
    TYPE6
}

public class PartGenerator {

    public Hashtable MOBO = new Hashtable();
    public Hashtable CPU = new Hashtable();
    public Hashtable GPU = new Hashtable();
    public Hashtable RAM = new Hashtable();
    public Hashtable HDD = new Hashtable();
    public Hashtable PSU = new Hashtable();
    public Hashtable CHASSIS = new Hashtable();
    public Hashtable INPUT = new Hashtable();
    public Hashtable OUTPUT = new Hashtable();
    public Hashtable NETWORK = new Hashtable();

    public ArrayList MOBO_PAIRS = new ArrayList();
    public ArrayList CPU_PAIRS = new ArrayList();
    public ArrayList GPU_PAIRS = new ArrayList();
    public ArrayList RAM_PAIRS = new ArrayList();
    public ArrayList HDD_PAIRS = new ArrayList();
    public ArrayList PSU_PAIRS = new ArrayList();
    public ArrayList CHASSIS_PAIRS = new ArrayList();
    public ArrayList INPUT_PAIRS = new ArrayList();
    public ArrayList OUTPUT_PAIRS = new ArrayList();
    public ArrayList NETWORK_PAIRS = new ArrayList();

    Era currentEra;
    System.Random rand;
    Eras ranges;

    public PartGenerator()
    {
        MOBO[Company.EDVI] = 1.0f;
        MOBO_PAIRS.Add(new Pair<Type,Company>(typeof(Motherboard),Company.EDVI));
        MOBO[Company.MPI] = 0.95f;
        MOBO_PAIRS.Add(new Pair<Type,Company>(typeof(Motherboard), Company.MPI));
        MOBO[Company.AND] = 0.9f;
        MOBO_PAIRS.Add(new Pair<Type,Company>(typeof(Motherboard), Company.AND));
        MOBO[Company.PINTEL] = 0.85f;
        MOBO_PAIRS.Add(new Pair<Type,Company>(typeof(Motherboard), Company.PINTEL));
        MOBO[Company.GIGAFLOP] = 0.8f;
        MOBO_PAIRS.Add(new Pair<Type,Company>(typeof(Motherboard), Company.GIGAFLOP));

        CPU[Company.PINTEL] = 1.0f;
        CPU_PAIRS.Add(new Pair<Type,Company>(typeof(CPU), Company.PINTEL));
        CPU[Company.AND] = 0.95f;
        CPU_PAIRS.Add(new Pair<Type,Company>(typeof(CPU), Company.AND));
        CPU[Company.MACROSOFT] = 0.9f;
        CPU_PAIRS.Add(new Pair<Type,Company>(typeof(CPU), Company.MACROSOFT));
        CPU[Company.EASTERN] = 0.85f;
        CPU_PAIRS.Add(new Pair<Type,Company>(typeof(CPU), Company.EASTERN));
        CPU[Company.COMPUTECH] = 0.8f;
        CPU_PAIRS.Add(new Pair<Type,Company>(typeof(CPU), Company.COMPUTECH));

        GPU[Company.EDVI] = 1.0f;
        GPU_PAIRS.Add(new Pair<Type,Company>(typeof(GPU), Company.EDVI));
        GPU[Company.MPI] = 0.95f;
        GPU_PAIRS.Add(new Pair<Type,Company>(typeof(GPU), Company.MPI));
        GPU[Company.GIGAFLOP] = 0.95f;
        GPU_PAIRS.Add(new Pair<Type,Company>(typeof(GPU), Company.GIGAFLOP));
        GPU[Company.LASUS] = 0.9f;
        GPU_PAIRS.Add(new Pair<Type,Company>(typeof(GPU), Company.LASUS));
        GPU[Company.AND] = 0.85f;
        GPU_PAIRS.Add(new Pair<Type,Company>(typeof(GPU), Company.AND));
        GPU[Company.LOGIBLAT] = 0.8f;
        GPU_PAIRS.Add(new Pair<Type,Company>(typeof(GPU), Company.LOGIBLAT));

        RAM[Company.QUEENSTON] = 1.0f;
        RAM_PAIRS.Add(new Pair<Type,Company>(typeof(RAM), Company.QUEENSTON));
        RAM[Company.MAURADER] = 0.95f;
        RAM_PAIRS.Add(new Pair<Type,Company>(typeof(RAM), Company.MAURADER));
        RAM[Company.ESSENTIAL] = 0.9f;
        RAM_PAIRS.Add(new Pair<Type,Company>(typeof(RAM), Company.ESSENTIAL));
        RAM[Company.EASTERN] = 0.85f;
        RAM_PAIRS.Add(new Pair<Type,Company>(typeof(RAM), Company.EASTERN));
        RAM[Company.ORANGE] = 0.8f;
        RAM_PAIRS.Add(new Pair<Type,Company>(typeof(RAM), Company.ORANGE));

        HDD[Company.QUEENSTON] = 1.0f;
        HDD_PAIRS.Add(new Pair<Type,Company>(typeof(HDD), Company.QUEENSTON));
        HDD[Company.EASTERN] = 1.0f;
        HDD_PAIRS.Add(new Pair<Type,Company>(typeof(HDD), Company.EASTERN));
        HDD[Company.PINTEL] = 0.95f;
        HDD_PAIRS.Add(new Pair<Type,Company>(typeof(HDD), Company.PINTEL));
        HDD[Company.ESSENTIAL] = 0.9f;
        HDD_PAIRS.Add(new Pair<Type,Company>(typeof(HDD), Company.ESSENTIAL));
        HDD[Company.ORANGE] = 0.85f;
        HDD_PAIRS.Add(new Pair<Type,Company>(typeof(HDD), Company.ORANGE));
        HDD[Company.LASUS] = 0.8f;
        HDD_PAIRS.Add(new Pair<Type,Company>(typeof(HDD), Company.LASUS));

        PSU[Company.ANT_TECH] = 1.0f;
        PSU_PAIRS.Add(new Pair<Type,Company>(typeof(PowerSupply), Company.ANT_TECH));
        PSU[Company.MPI] = 0.95f;
        PSU_PAIRS.Add(new Pair<Type,Company>(typeof(PowerSupply), Company.MPI));
        PSU[Company.MAURADER] = 0.9f;
        PSU_PAIRS.Add(new Pair<Type,Company>(typeof(PowerSupply), Company.MAURADER));
        PSU[Company.ESSENTIAL] = 0.85f;
        PSU_PAIRS.Add(new Pair<Type,Company>(typeof(PowerSupply), Company.ESSENTIAL));
        PSU[Company.GIGAFLOP] = 0.8f;
        PSU_PAIRS.Add(new Pair<Type,Company>(typeof(PowerSupply), Company.GIGAFLOP));

        CHASSIS[Company.ANT_TECH] = 1.0f;
        CHASSIS_PAIRS.Add(new Pair<Type,Company>(typeof(Chassis), Company.ANT_TECH));
        CHASSIS[Company.MAURADER] = 0.95f;
        CHASSIS_PAIRS.Add(new Pair<Type,Company>(typeof(Chassis), Company.MAURADER));
        CHASSIS[Company.MPI] = 0.9f;
        CHASSIS_PAIRS.Add(new Pair<Type,Company>(typeof(Chassis), Company.MPI));
        CHASSIS[Company.GIGAFLOP] = 0.85f;
        CHASSIS_PAIRS.Add(new Pair<Type,Company>(typeof(Chassis), Company.GIGAFLOP));
        CHASSIS[Company.COMPUTECH] = 0.8f;
        CHASSIS_PAIRS.Add(new Pair<Type,Company>(typeof(Chassis), Company.COMPUTECH));

        INPUT[Company.PHAZER] = 1.0f;
        INPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompInput), Company.PHAZER));
        INPUT[Company.LOGIBLAT] = 0.95f;
        INPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompInput), Company.LOGIBLAT));
        INPUT[Company.MACROSOFT] = 0.9f;
        INPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompInput), Company.MACROSOFT));
        INPUT[Company.ORANGE] = 0.85f;
        INPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompInput), Company.ORANGE));
        INPUT[Company.MAURADER] = 0.8f;
        INPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompInput), Company.MAURADER));

        OUTPUT[Company.PHAZER] = 1.0f;
        OUTPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompOutput), Company.PHAZER));
        OUTPUT[Company.ORANGE] = 0.95f;
        OUTPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompOutput), Company.ORANGE));
        OUTPUT[Company.LASUS] = 0.95f;
        OUTPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompOutput), Company.LASUS));
        OUTPUT[Company.EDVI] = 0.9f;
        OUTPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompOutput), Company.EDVI));
        OUTPUT[Company.LOGIBLAT] = 0.85f;
        OUTPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompOutput), Company.LOGIBLAT));
        OUTPUT[Company.COMPUTECH] = 0.8f;
        OUTPUT_PAIRS.Add(new Pair<Type,Company>(typeof(CompOutput), Company.COMPUTECH));

        NETWORK[Company.CHRONO] = 1.0f;
        NETWORK_PAIRS.Add(new Pair<Type,Company>(typeof(CompNetwork), Company.CHRONO));
        NETWORK[Company.SINGULAR] = 0.95f;
        NETWORK_PAIRS.Add(new Pair<Type,Company>(typeof(CompNetwork), Company.SINGULAR));
        NETWORK[Company.BOMBAST] = 0.9f;
        NETWORK_PAIRS.Add(new Pair<Type,Company>(typeof(CompNetwork), Company.BOMBAST));

        ranges = new Eras();
        rand = new System.Random();
    }

    public object generatePart(Type partType, Company company)
    {
        object returnPart = null;
        if (partType == typeof(CPU))
        {
            /*
            CPU = new CPU(
                generatePartName(partType, company),
                companyToString(company),
                499.0f,
                "Generic Interface",
                100,
                1
                )
             * */

            returnPart = new CPU(generatePartName(partType, company),
                company,
                500.0f * (float)CPU[company] * (float)CPU[company],
                "Debug",
                100 * (int)((float)CPU[company] * 100.0f) / 100, 
                1.0f,
                rand.Next(ranges.PE1980.cpu_CoresRange.getLeft(), ranges.PE1980.cpu_CoresRange.getRight() + 1),
                rand.Next(ranges.PE1980.cpu_ClockRange.getLeft(), ranges.PE1980.cpu_ClockRange.getRight() + 1),
                rand.Next(ranges.PE1980.cpu_BitsRange.getLeft(), ranges.PE1980.cpu_BitsRange.getRight() + 1)
                );

            //returnPart = new CPU(generatePartName(partType, company), 
            //    company, 
            //    500.0f * (float)CPU[company] * (float)CPU[company], 
            //    "Debug", 
            //    100 * (int)((float)CPU[company] * 100.0f) / 100, 
            //    1.0f,
            //    rand.Next(ranges.PE1980.cpu_CoresRange.getLeft(), ranges.PE1980.cpu_CoresRange.getRight() + 1), 1, 1);

        }
        else if (partType == typeof(GPU))
        {
            returnPart = new GPU(generatePartName(partType, company),
                company,
                 500.0f * (float)GPU[company] * (float)GPU[company],
                "Debug",
                200 * (int)((float)GPU[company] * 100.0f) / 100, 
                1.0f,
                rand.Next(ranges.PE1980.gpu_MegaflopsRange.getLeft(), ranges.PE1980.gpu_MegaflopsRange.getRight() + 1),
                rand.Next(ranges.PE1980.gpu_MemoryRange.getLeft(), ranges.PE1980.gpu_MemoryRange.getRight() + 1)
                );
        }
        else if (partType == typeof(HDD))
        {
            returnPart = new HDD(generatePartName(partType, company),
                company,
                 500.0f * (float)HDD[company] * (float)HDD[company],
                "Debug",
                5 * (int)((float)HDD[company] * 100.0f) / 100,
                1.0f,
                rand.Next(ranges.PE1980.hdd_SizeRange.getLeft(), ranges.PE1980.hdd_SizeRange.getRight() + 1),
                rand.Next(ranges.PE1980.hdd_SpeedRange.getLeft(), ranges.PE1980.hdd_SpeedRange.getRight() + 1)
                );
        }
        else if (partType == typeof(RAM))
        {
            returnPart = new RAM(generatePartName(partType, company),
                company,
                 500.0f * (float)RAM[company] * (float)RAM[company],
                "Debug",
                5 * (int)((float)RAM[company] * 100.0f) / 100,
                1.0f,
                rand.Next(ranges.PE1980.ram_SizeRange.getLeft(), ranges.PE1980.ram_SizeRange.getRight() + 1),
                rand.Next(ranges.PE1980.ram_SpeedRange.getLeft(), ranges.PE1980.ram_SpeedRange.getRight() + 1),
                rand.Next(ranges.PE1980.ram_ChannelsRange.getLeft(), ranges.PE1980.ram_ChannelsRange.getRight() + 1)
                );
        }
        else if (partType == typeof(CompInput))
        {
            returnPart = new CompInput(generatePartName(partType, company),
                company,
                 500.0f * (float)INPUT[company] * (float)INPUT[company],
                "Debug",
                5 * (int)((float)INPUT[company] * 100.0f) / 100,
                1.0f,
                rand.Next(ranges.PE1980.input_DPIRange.getLeft(), ranges.PE1980.input_DPIRange.getRight() + 1),
                rand.Next(ranges.PE1980.input_PollingRange.getLeft(), ranges.PE1980.input_PollingRange.getRight() + 1),
                rand.Next(10) <= 7 ? false : true
                );
        }
        else if (partType == typeof(CompOutput))
        {
            returnPart = new CompOutput(generatePartName(partType, company),
                company,
                 500.0f * (float)OUTPUT[company] * (float)OUTPUT[company],
                "Debug",
                50 * (int)((float)OUTPUT[company] * 100.0f) / 100,
                1.0f,
                rand.Next(ranges.PE1980.output_ResolutionRange.getLeft(), ranges.PE1980.output_ResolutionRange.getRight() + 1),
                rand.Next(ranges.PE1980.output_RefreshRange.getLeft(), ranges.PE1980.output_RefreshRange.getRight() + 1),
                rand.Next(ranges.PE1980.output_SQRange.getLeft(), ranges.PE1980.output_SQRange.getRight() + 1)
                );
        }
        else if (partType == typeof(CompNetwork))
        {
            returnPart = new CompNetwork(generatePartName(partType, company),
                company,
                 500.0f * (float)NETWORK[company] * (float)NETWORK[company],
                "Debug",
                0,
                1.0f,
                rand.Next(2) == 0 ? ranges.PE1980.network_TypeRange.getLeft() : ranges.PE1980.network_TypeRange.getRight(),
                rand.Next(ranges.PE1980.network_PingRange.getLeft(), ranges.PE1980.network_PingRange.getRight() + 1),
                rand.Next(ranges.PE1980.network_BandwidthRange.getLeft(), ranges.PE1980.network_BandwidthRange.getRight() + 1)
                );
        }
        else if (partType == typeof(PowerSupply))
        {
            returnPart = new PowerSupply(generatePartName(partType, company),
                company,
                 500.0f * (float)PSU[company] * (float)PSU[company],
                "Debug",
                0,
                1.0f,
                rand.Next(ranges.PE1980.pSupply_WattageRange.getLeft(), ranges.PE1980.pSupply_WattageRange.getRight() + 1)
                );
        }
        else if (partType == typeof(Chassis))
        {
            returnPart = new Chassis(generatePartName(partType, company),
                company,
                 500.0f * (float)CHASSIS[company] * (float)CHASSIS[company],
                "Debug",
                0,
                1.0f,
                rand.Next(ranges.PE1980.chassis_CoolRange.getLeft(), ranges.PE1980.chassis_CoolRange.getRight() + 1)
                );
        }
        else if (partType == typeof(Motherboard))
        {
            returnPart = new Motherboard(generatePartName(partType, company),
                500.0f * (float)MOBO[company] * (float)MOBO[company],
                1.0f,
                "Debug",
                "Debug",
                "Debug",
                "Debug",
                "Debug",
                "Debug",
                "Debug",
                "Debug",
                "Debug",
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
                );
        }
        return returnPart;
    }

    public string generatePartName(Type partType, Company company)
    {
        string companyName = companyToString(company);

        string partName = "";

        if (partType == typeof(CPU))
        {
            partName = "CPU";
        }
        else if (partType == typeof(GPU))
        {
            partName = "GPU";
        }
        else if (partType == typeof(HDD))
        {
            partName = "HDD";
        }
        else if (partType == typeof(RAM))
        {
            partName = "RAM";
        }
        else if (partType == typeof(CompInput))
        {
            partName = "Input Device";
        }
        else if (partType == typeof(CompOutput))
        {
            partName = "Monitor/Speaker Combo";
        }
        else if (partType == typeof(CompNetwork))
        {
            partName = "Network";
        }
        else if (partType == typeof(PowerSupply))
        {
            partName = "Power Supply";
        }
        else if (partType == typeof(Chassis))
        {
            partName = "Chassis";
        }
        else if (partType == typeof(Motherboard))
        {
            partName = "Motherboard";
        }

        return companyName + " " + partName;
    }

    public string companyToString(Company company)
    {
        string companyName = "";
        if (company == Company.AND)
        {
            companyName = "AND";
        }
        if (company == Company.ANT_TECH)
        {
            companyName = "Ant-Tech";
        }
        if (company == Company.BOMBAST)
        {
            companyName = "Bombast";
        }
        if (company == Company.CHRONO)
        {
            companyName = "Chrono Alarm";
        }
        if (company == Company.COMPUTECH)
        {
            companyName = "CompuTech";
        }
        if (company == Company.EASTERN)
        {
            companyName = "Eastern Digital";
        }
        if (company == Company.EDVI)
        {
            companyName = "EDVI";
        }
        if (company == Company.ESSENTIAL)
        {
            companyName = "Essential";
        }
        if (company == Company.GIGAFLOP)
        {
            companyName = "GigaFlop";
        }
        if (company == Company.LASUS)
        {
            companyName = "Lasus";
        }
        if (company == Company.LOGIBLAT)
        {
            companyName = "LogiBlat";
        }
        if (company == Company.MACROSOFT)
        {
            companyName = "Macrosoft";
        }
        if (company == Company.MAURADER)
        {
            companyName = "Maurader";
        }
        if (company == Company.MPI)
        {
            companyName = "Micro-Planet International";
        }
        if (company == Company.ORANGE)
        {
            companyName = "Orange";
        }
        if (company == Company.PHAZER)
        {
            companyName = "Phazer";
        }
        if (company == Company.PINTEL)
        {
            companyName = "Pintel";
        }
        if (company == Company.QUEENSTON)
        {
            companyName = "Queenston";
        }
        if (company == Company.SINGULAR)
        {
            companyName = "Singular";
        }
        return companyName;
    }
}