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
    public Part viewPart;

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
        renderDebugMenu();
        if (mobo != null)
        {
            renderComputerInfoBox(600, 10, 300, 600, 50, 10, mobo);
        }
        else
        {
            GUI.TextArea(new Rect(610, 40, 280, 20), "Pls. You have no rig :(.");
        }
        if (viewPart != null)
        {
            renderPartStatistics(200, 10, 300, 200, viewPart);
        }
    }

    void renderDebugMenu()
    {
        GUI.Box(new Rect(10, 10, 200, 200), "PC Sim 2013");
        if (GUI.Button(new Rect(35, 30, 150, 20), "Give Self Debug Rig"))
        {
            mobo = fabricateDebugRig();
        }
    }
    
    void renderComputerInfoBox(float left, float top, float width, float height, float textAreaHeight, float textAreaMargin, Motherboard mobo)
    {
        GUI.Box(new Rect(left, top, width, height), "Your Rig");

        renderComputerStats(left + 10, top + 25, width - 20, textAreaHeight, textAreaMargin, mobo);
    }

    void renderPartStatistics(float left, float top, float width, float height, Part part)
    {
        float BUTTON_WIDTH = 20f;
        string contents = "";
        GUI.Box(new Rect(left, top, width, height), "");
        if (GUI.Button(new Rect(left + width - 10 - BUTTON_WIDTH, top + 5, BUTTON_WIDTH, BUTTON_WIDTH), "X"))
        {
            viewPart = null;
        }

        if (part.GetType() == typeof(CPU))
        {
            CPU cpu = (CPU) part;
            contents = cpu.name + "\n" +
                        "Interface Type: " + cpu.partInterface + "\n" +
                        "Power: " + cpu.powerRequirement + " W\n" +
                        "Cores: " + cpu.numberOfCores + "\n" +
                        cpu.numberOfBits + "-bit processor";
        }
        if (part.GetType() == typeof(GPU))
        {
            GPU gpu = (GPU) part;
            contents = gpu.name + "\n" +
                        "Interface Type: " + gpu.partInterface + "\n" +
                        "Power: " + gpu.powerRequirement + " W\n" +
                        "Flops: " + gpu.megaflops + " MFlops \n" +
                        "Internal Memory: " + gpu.memory + " MB\n";
        }
        if (part.GetType() == typeof(HDD))
        {
            HDD hdd = (HDD) part;
            contents = hdd.name + "\n" +
                        "Interface Type: " + hdd.partInterface + "\n" +
                        "Power: " + hdd.powerRequirement + " W\n" +
                        "Capacity: " + hdd.size + " MB \n" +
                        "Speed: " + hdd.speed + " RPM\n";
        }
        if (part.GetType() == typeof(RAM))
        {
            RAM ram = (RAM)part;
            contents = ram.name + "\n" +
                        "Interface Type: " + ram.partInterface + "\n" +
                        "Power: " + ram.powerRequirement + " W\n" +
                        "Memory: " + ram.size + " MB \n" +
                        "Speed: " + ram.speed + " Mb/s\n" +
                        ram.channels + " channels" + "\n";
        }
        if (part.GetType() == typeof(CompInput))
        {
            CompInput input = (CompInput) part;
            string mechanical = input.isMechanical ? "Mechanical" : "Non-Mechanical";
            contents = input.name + "\n" +
                        "Interface Type: " + input.partInterface + "\n" +
                        "Power: " + input.powerRequirement + " W\n" +
                        "Mouse DPI: " + input.mouseDPI + " DPI \n" +
                        "Mouse Polling Rate: " + input.pollingRate + " Hz\n" +
                         mechanical + " Keyboard" + "\n";
        }
        if (part.GetType() == typeof(CompOutput))
        {
            CompOutput output = (CompOutput) part;
            contents = output.name + "\n" +
                        "Interface Type: " + output.partInterface + "\n" +
                        "Power: " + output.powerRequirement + " W\n" +
                        "Monitor Refresh Rate: " + output.refreshRate + " HZ \n" +
                        "Resolution (Width): " + output.resolution + " px\n" +
                        "Sound Quality: " + output.soundQuality + "\n";
        }
        if (part.GetType() == typeof(CompNetwork))
        {
            CompNetwork network = (CompNetwork)part;
            contents = network.name + "\n" +
                        "Interface Type: " + network.partInterface + "\n" +
                        "Power: " + network.powerRequirement + " W\n" +
                        "Average Worldwide Ping " + network.ping + " ms \n" +
                        "Bandwidth: " + network.bandwidth + " Mb/s\n" +
                        "Quality of Service Rating: " + network.qualityOfService + " points\n";
        }
        if (part.GetType() == typeof(PowerSupply))
        {
            PowerSupply pSupply = (PowerSupply)part;
            contents = pSupply.name + "\n" +
                        "Interface Type: " + pSupply.partInterface + "\n" +
                        "Power Provided: " + pSupply.wattage + " W\n";
        }
        if (part.GetType() == typeof(Chassis))
        {
            Chassis chassis = (Chassis)part;
            contents = chassis.name + "\n" +
                        "Form Factor: " + chassis.partInterface + "\n";
        }
        GUI.TextArea(new Rect(left + 10, top + 30, width - 20, height - 40), contents);
        
    }

    void renderComputerStats(float left, float top, float width, float height, float margin, Motherboard mobo)
    {
        GUI.Button(new Rect(left, top                      , width, height), "MOBO: " + mobo.name);
        if (GUI.Button(new Rect(left, top + (height + margin), width, height), "CPU: " + mobo.cpu.name))
        {
            viewPart = mobo.cpu;  
        }
        if (GUI.Button(new Rect(left, top + 2 * (height + margin), width, height), "GPU: " + mobo.gpu.name))
        {
            viewPart = mobo.gpu;
        }
        if (GUI.Button(new Rect(left, top + 3 * (height + margin), width, height), "RAM: " + mobo.ram.name))
        {
            viewPart = mobo.ram;
        }
        if (GUI.Button(new Rect(left, top + 4 * (height + margin), width, height), "Power Supply: " + mobo.pSupply.name))
        {
            viewPart = mobo.pSupply;
        }
        if (GUI.Button(new Rect(left, top + 5 * (height + margin), width, height), "Input: " + mobo.input.name))
        {
            viewPart = mobo.input;
        }
        if (GUI.Button(new Rect(left, top + 6 * (height + margin), width, height), "Output: " + mobo.output.name))
        {
            viewPart = mobo.output;
        }
        if (GUI.Button(new Rect(left, top + 7 * (height + margin), width, height), "Network Service: " + mobo.network.name))
        {
            viewPart = mobo.network;
        }
        if(GUI.Button(new Rect(left, top + 8*(height + margin), width, height), "Chassis: " + mobo.chassis.name))
        {
            viewPart = mobo.chassis;
        }
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
