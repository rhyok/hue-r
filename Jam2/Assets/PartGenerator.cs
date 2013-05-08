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

public class PartGenerator : MonoBehaviour {

    Hashtable MOBO = new Hashtable();
    Hashtable CPU = new Hashtable();
    Hashtable GPU = new Hashtable();
    Hashtable RAM = new Hashtable();
    Hashtable HDD = new Hashtable();
    Hashtable PSU = new Hashtable();
    Hashtable CHASSIS = new Hashtable();
    Hashtable INPUT = new Hashtable();
    Hashtable OUTPUT = new Hashtable();
    Hashtable NETWORK = new Hashtable();

    Hashtable RANGE = new Hashtable();
    Hashtable E1980 = new Hashtable();
    Hashtable E1990 = new Hashtable();
    Hashtable E2000 = new Hashtable();
    Hashtable E2010 = new Hashtable();
    Hashtable E2020 = new Hashtable();
    Hashtable E2030 = new Hashtable();

    Hashtable PRICE = new Hashtable();

    Era currentEra;
    System.Random rand;

    void Start()
    {
        MOBO[Company.EDVI] = 1.0f;
        MOBO[Company.MPI] = 0.95f;
        MOBO[Company.AND] = 0.9f;
        MOBO[Company.PINTEL] = 0.85f;
        MOBO[Company.GIGAFLOP] = 0.8f;

        CPU[Company.PINTEL] = 1.0f;
        CPU[Company.AND] = 0.95f;
        CPU[Company.MACROSOFT] = 0.9f;
        CPU[Company.EASTERN] = 0.85f;
        CPU[Company.COMPUTECH] = 0.8f;

        GPU[Company.EDVI] = 1.0f;
        GPU[Company.MPI] = 0.95f;
        GPU[Company.GIGAFLOP] = 0.95f;
        GPU[Company.LASUS] = 0.9f;
        GPU[Company.AND] = 0.85f;
        GPU[Company.LOGIBLAT] = 0.8f;

        RAM[Company.QUEENSTON] = 1.0f;
        RAM[Company.MAURADER] = 0.95f;
        RAM[Company.ESSENTIAL] = 0.9f;
        RAM[Company.EASTERN] = 0.85f;
        RAM[Company.ORANGE] = 0.8f;

        HDD[Company.QUEENSTON] = 1.0f;
        HDD[Company.EASTERN] = 1.0f;
        HDD[Company.PINTEL] = 0.95f;
        HDD[Company.ESSENTIAL] = 0.9f;
        HDD[Company.ORANGE] = 0.85f;
        HDD[Company.LASUS] = 0.8f;

        PSU[Company.ANT_TECH] = 1.0f;
        PSU[Company.MPI] = 0.95f;
        PSU[Company.MAURADER] = 0.9f;
        PSU[Company.ESSENTIAL] = 0.85f;
        PSU[Company.GIGAFLOP] = 0.8f;

        CHASSIS[Company.ANT_TECH] = 1.0f;
        CHASSIS[Company.MAURADER] = 0.95f;
        CHASSIS[Company.MPI] = 0.9f;
        CHASSIS[Company.GIGAFLOP] = 0.85f;
        CHASSIS[Company.COMPUTECH] = 0.8f;

        INPUT[Company.PHAZER] = 1.0f;
        INPUT[Company.LOGIBLAT] = 0.95f;
        INPUT[Company.MACROSOFT] = 0.9f;
        INPUT[Company.ORANGE] = 0.85f;
        INPUT[Company.MAURADER] = 0.8f;

        OUTPUT[Company.PHAZER] = 1.0f;
        OUTPUT[Company.ORANGE] = 0.95f;
        OUTPUT[Company.LASUS] = 0.95f;
        OUTPUT[Company.EDVI] = 0.9f;
        OUTPUT[Company.LOGIBLAT] = 0.85f;
        OUTPUT[Company.COMPUTECH] = 0.8f;

        NETWORK[Company.CHRONO] = 1.0f;
        NETWORK[Company.SINGULAR] = 0.95f;
        NETWORK[Company.BOMBAST] = 0.9f;
    }

    public Part generatePart(Type partType, Company company)
    {
        Part returnPart = null;
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
        }
        else if (partType == typeof(GPU))
        {
        }
        else if (partType == typeof(HDD))
        {
        }
        else if (partType == typeof(RAM))
        {
        }
        else if (partType == typeof(CompInput))
        {
        }
        else if (partType == typeof(CompOutput))
        {
        }
        else if (partType == typeof(CompNetwork))
        {
        }
        else if (partType == typeof(PowerSupply))
        {
        }
        else if (partType == typeof(Chassis))
        {
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
            companyName = "Ant Tech";
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