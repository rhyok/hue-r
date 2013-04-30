using UnityEngine;
using System.Collections;

public enum PlayerGUIState
{
    MAIN_SCREEN,
    BUY_PARTS_SCREEN,
    
}



public class Player : MonoBehaviour 
{
    public Motherboard mobo;

    void OnGUI()
    {
        PlayerGUIState gameState = PlayerGUIState.MAIN_SCREEN;

        switch (gameState)
        {
            case PlayerGUIState.MAIN_SCREEN:
                mainScreen();
                break;
            case PlayerGUIState.BUY_PARTS_SCREEN:
                break;
            default:
                break;
        }
    }

    void mainScreen()
    {
        GUI.Box(new Rect(10, 10, 400, 400), "PC Sim 2013");
        if(GUI.Button(new Rect(15, 15, 100, 20), "Give Self Debug Rig"))
        {
            mobo = fabricateDebugRig(); 
        }
    }

    Motherboard fabricateDebugRig()
    {
        Motherboard returnMobo = new Motherboard();

        string DEBUG_INTERFACE = "Debug";

        CPU debugCPU            = new CPU("Hammond DebugHammer 750XL", DEBUG_INTERFACE, 30, 0, 1, 6, 32);
        GPU debugGPU            = new GPU("Zhu Industries Mothra 8800", DEBUG_INTERFACE, 20, 0, 3, 1);
        HDD debugHDD            = new HDD("DataPlatter Stack 5", DEBUG_INTERFACE, 2, 0, 10, 8);
        RAM debugRAM            = new RAM("RYAM Interceptor 1 MB", DEBUG_INTERFACE, 1, 0, 1, 10, 1);

        returnMobo.CPUInterface         = DEBUG_INTERFACE;
        returnMobo.GPUInterface         = DEBUG_INTERFACE;
        returnMobo.HDDInterface         = DEBUG_INTERFACE;
        returnMobo.RAMInterface         = DEBUG_INTERFACE;
        returnMobo.powerInterface       = DEBUG_INTERFACE;
        returnMobo.compInputInterface   = DEBUG_INTERFACE;
        returnMobo.compOutputInterface  = DEBUG_INTERFACE;
        returnMobo.networkInterface     = DEBUG_INTERFACE;
        returnMobo.formFactor           = DEBUG_INTERFACE;

        //returnMobo.cpu;
        //returnMobo.gpu;
        //returnMobo.hdd;
        //returnMobo.ram;
        //returnMobo.input;
        //returnMobo.output;
        //returnMobo.network;
        //returnMobo.pSupply;
        //returnMobo.chassis;

        return returnMobo;
    }
}
