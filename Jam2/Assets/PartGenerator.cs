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

public enum Stat 
{ 
    MOBO_DEFECTIVE,
    MOBO_CPUI,
    MOBO_GPUI,
    MOBO_HDDI,
    MOBO_RAMI,
    MOBO_PWRI,
    MOBO_INI,
    MOBO_OUTI,
    MOBO_NETI,
    MOBO_FORM,

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





        rand = new System.Random();
    }

    public Part generatePart()
    {
        CPU temp = new CPU();
        return temp;
    }
}