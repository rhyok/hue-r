using UnityEngine;
using System.Collections;

public enum Genre
{
    RTS,
    FPS,
    RPG,
    SIM,
    FIGHING,
    RACING,
    CASUAL
}
public enum NetworkType
{
    NONE,
    DIALUP,
    FIFTYSIXK,
    DSL,
    CABLE,
    T1,
    T3,
    FIBEROPTIC,
    QUANTUM
}

public enum Era
{
    E1980,
    E1990,
    E2000,
    E2010,
    E2020,
    E2030
}

public class Game {

    public string name;
    public Genre genre;
    public Era era;

    //Minimum requirement for game to run
    public int CPURequirement;      
    public int GPURequirement;      
    public int RAMRequirement;
    public int HDDRequirement;
    public string OSRequirement;
    public int InputRequirement;
    public NetworkType networkRequirement;

    //Scalars if computer exceeds requirement
    public int CPUScalar;
    public int GPUScalar;
    public int RAMScalar;
    public int HDDScalar;
    public int InputScalar;
    public int outputScalar;
}
