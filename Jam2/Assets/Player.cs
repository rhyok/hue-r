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

        if(mobo != null)
        {
            renderComputerInfoBox(600, 10, 300, 600, 50, 10, mobo);
        }
        else
        {
            GUI.TextArea(new Rect(610, 40, 280, 20), "Pls. You have no rig :(.");
        }

        if(GUI.Button(new Rect(102, 30, 200, 20), "Give Self Debug Rig"))
        {
            mobo = fabricateDebugRig(); 
        }
    }

    void renderComputerInfoBox(float left, float top, float width, float height, float textAreaHeight, float textAreaMargin, Motherboard mobo)
    {
        GUI.Box(new Rect(left, top, width, height), "Your Rig");

        renderComputerStats(left + 10, top + 25, width - 20, textAreaHeight, textAreaMargin, mobo);
    }

    void renderComputerStats(float left, float top, float width, float height, float margin, Motherboard mobo)
    {
        GUI.Button(new Rect(left, top                      , width, height), "MOBO: " + mobo.name);
        GUI.Button(new Rect(left, top +   (height + margin), width, height), "CPU: " + mobo.cpu.name);
        GUI.Button(new Rect(left, top + 2*(height + margin), width, height), "GPU: " + mobo.gpu.name);
        GUI.Button(new Rect(left, top + 3*(height + margin), width, height), "RAM: " + mobo.ram.name);
        GUI.Button(new Rect(left, top + 4*(height + margin), width, height), "Power Supply: " + mobo.pSupply.name);
        GUI.Button(new Rect(left, top + 5*(height + margin), width, height), "Input: " + mobo.input.name);
        GUI.Button(new Rect(left, top + 6*(height + margin), width, height), "Output: " + mobo.output.name);
        GUI.Button(new Rect(left, top + 7*(height + margin), width, height), "Network Service: " + mobo.network.name);
        GUI.Button(new Rect(left, top + 8*(height + margin), width, height), "Chassis: " + mobo.chassis.name);
    }

    //void renderInfoPane(float left, float top, float width, float height

    Motherboard fabricateDebugRig()
    {
        Motherboard returnMobo = new Motherboard();

        returnMobo.name = "Mother of All Boards";

        string DEBUG_INTERFACE = "Debug";

        CPU         debugCPU        = new CPU           ("Hammond DebugHammer 750XL",           125.0f, DEBUG_INTERFACE, 30, 0, 1, 6, 32);
        GPU         debugGPU        = new GPU           ("Zhu Industries Mothra 8800",          125.0f, DEBUG_INTERFACE, 20, 0, 3, 1);
        HDD         debugHDD        = new HDD           ("DataPlatter Stack 5",                 125.0f, DEBUG_INTERFACE, 2, 0, 10, 8);
        RAM         debugRAM        = new RAM           ("RYAM Interceptor 1 MB",               125.0f, DEBUG_INTERFACE, 1, 0, 1, 10, 1);
        PowerSupply debugPower      = new PowerSupply   ("ArEmEs 200W Power Supply",            125.0f, DEBUG_INTERFACE, 0, 0, 200);
        CompInput   debugInput      = new CompInput     ("Cobra Katana",                        125.0f, DEBUG_INTERFACE, 0, 0, 50, 60, false);
        CompOutput  debugOutput     = new CompOutput    ("AudiVisual AV2350",                   125.0f, DEBUG_INTERFACE, 0, 0, 320, 30, 5);
        CompNetwork debugNet        = new CompNetwork   ("Digiline Dial-up Package",            125.0f, DEBUG_INTERFACE, 0, 0, NetworkType.DIALUP, 40, 4, 2); 
        Chassis     debugChassis    = new Chassis       ("CompuTech Tower of Power",            125.0f, DEBUG_INTERFACE, 0, 0, 10);


        returnMobo.CPUInterface         = DEBUG_INTERFACE;
        returnMobo.GPUInterface         = DEBUG_INTERFACE;
        returnMobo.HDDInterface         = DEBUG_INTERFACE;
        returnMobo.RAMInterface         = DEBUG_INTERFACE;
        returnMobo.powerInterface       = DEBUG_INTERFACE;
        returnMobo.compInputInterface   = DEBUG_INTERFACE;
        returnMobo.compOutputInterface  = DEBUG_INTERFACE;
        returnMobo.networkInterface     = DEBUG_INTERFACE;
        returnMobo.formFactor           = DEBUG_INTERFACE;

        returnMobo.cpu      = debugCPU;
        returnMobo.gpu      = debugGPU;
        returnMobo.hdd      = debugHDD;
        returnMobo.ram      = debugRAM;
        returnMobo.input    = debugInput;
        returnMobo.output   = debugOutput;
        returnMobo.network  = debugNet;
        returnMobo.pSupply  = debugPower;
        returnMobo.chassis  = debugChassis;

        return returnMobo;
    }
}
