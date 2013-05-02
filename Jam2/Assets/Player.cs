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
    public float funds;
    public object viewPart;
    public ArrayList storeFront;

    private Vector2 scrollPos;

    void Start()
    {
        funds = 3000.0f;
    }

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
            renderPartStatistics(250, 10, 300, 400, viewPart);
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

    void renderPartStatistics(float left, float top, float width, float height, object part)
    {
        float BUTTON_WIDTH = 20f;
        string contents = "";
        GUI.Box(new Rect(left, top, width, height), "");
        if (GUI.Button(new Rect(left + width - 10 - BUTTON_WIDTH, top + 5, BUTTON_WIDTH, BUTTON_WIDTH), "X"))
        {
            viewPart = null;
        }

        if(part.GetType() == typeof(Motherboard))
        {
            Motherboard mobo = (Motherboard) part;
            contents = mobo.name + "\n" +
                        "Form Factor: " + mobo.formFactor + "\n" + 
                        "Interfaces:\n" +
                        "   CPU: " + mobo.CPUInterface + "\n" +
                        "   GPU: " + mobo.GPUInterface + "\n" +
                        "   HDD: " + mobo.HDDInterface + "\n" +
                        "   RAM: " + mobo.RAMInterface + "\n" +
                        "   Input: " + mobo.compInputInterface + "\n" +
                        "   Output: " + mobo.compOutputInterface + "\n" +
                        "   Network: " + mobo.networkInterface + "\n" + 
                        "   Power Supply: " + mobo.powerInterface;
                        
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
                        "Bandwidth: " + network.bandwidth + " Mb/s\n";
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
        if (mobo != null)
        {
            if(GUI.Button(new Rect(left, top, width, height), "MOBO: " + mobo.name))
            {
                viewPart = mobo;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top, width, height), "MOBO: None");
        }

        if (mobo.cpu != null)
        {
            if(GUI.Button(new Rect(left, top + (height + margin), width, height), "CPU: " + mobo.cpu.name))
            {
                viewPart = mobo.cpu;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + (height + margin), width, height), "CPU: None");
        }

        if (mobo.gpu != null)
        {
            if(GUI.Button(new Rect(left, top + 2 * (height + margin), width, height), "GPU: " + mobo.gpu.name))
            {
                viewPart = mobo.gpu;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 2 * (height + margin), width, height), "GPU: None");
        }

        if (mobo.ram != null)
        {
            if(GUI.Button(new Rect(left, top + 3 * (height + margin), width, height), "RAM: " + mobo.ram.name))
            {
                viewPart = mobo.ram;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 3 * (height + margin), width, height), "RAM: None");
        }

        if (mobo.pSupply != null)
        {
            if(GUI.Button(new Rect(left, top + 4 * (height + margin), width, height), "Power Supply: " + mobo.pSupply.name))
            {
                viewPart = mobo.pSupply;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 4 * (height + margin), width, height), "Power Supply: None");
        }

        if (mobo.input != null)
        {
            if(GUI.Button(new Rect(left, top + 5 * (height + margin), width, height), "Input: " + mobo.input.name))
            {
                viewPart = mobo.input;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 5 * (height + margin), width, height), "Input: None");
        }

        if (mobo.output != null)
        {
            if(GUI.Button(new Rect(left, top + 6 * (height + margin), width, height), "Output: " + mobo.output.name))
            {
                viewPart = mobo.output;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 6 * (height + margin), width, height), "Output: None");
        }

        if (mobo.network != null)
        {
            if(GUI.Button(new Rect(left, top + 7 * (height + margin), width, height), "Network Service: " + mobo.network.name))
            {
                viewPart = mobo.network;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 7 * (height + margin), width, height), "Network Service: None");
        }

        if (mobo.chassis != null)
        {
            if (GUI.Button(new Rect(left, top + 8 * (height + margin), width, height), "Chassis: " + mobo.chassis.name))
            {
                viewPart = mobo.chassis;
            }
        }
        else
        {
            GUI.Button(new Rect(left, top + 8 * (height + margin), width, height), "Chassis: None");
        }
    }

    void buyPartsScreen()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 800));
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            GUILayout.EndScrollView();
        }
        GUILayout.EndArea();
    }
    //void renderInfoPane(float left, float top, float width, float height

    Motherboard fabricateDebugRig()
    {
        Motherboard returnMobo = new Motherboard();

        returnMobo.name = "Mother of All Boards";

        string DEBUG_INTERFACE = "Debug";

        CPU         debugCPU        = new CPU           ("Hammond DebugHammer 750XL",           Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 30, 0, 1, 6, 32);
        GPU         debugGPU        = new GPU           ("Zhu Industries Mothra 8800",          Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 20, 0, 3, 1);
        HDD         debugHDD        = new HDD           ("DataPlatter Stack 5",                 Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 2, 0, 10, 8);
        RAM         debugRAM        = new RAM           ("RYAM Interceptor 1 MB",               Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 1, 0, 1, 10, 1);
        PowerSupply debugPower      = new PowerSupply   ("ArEmEs 200W Power Supply",            Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 0, 0, 200);
        CompInput   debugInput      = new CompInput     ("Cobra Katana",                        Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 0, 0, 50, 60, false);
        CompOutput  debugOutput     = new CompOutput    ("AudiVisual AV2350",                   Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 0, 0, 320, 30, 5);
        CompNetwork debugNet        = new CompNetwork   ("Digiline Dial-up Package",            Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 0, 0, NetworkType.DIALUP, 40, 4); 
        Chassis     debugChassis    = new Chassis       ("CompuTech Tower of Power",            Company.COMPUTECH, 125.0f, DEBUG_INTERFACE, 0, 0, 10);

        GPU         badGPU          = new GPU           ("Bad GPU",                             Company.COMPUTECH, 125.0f, "Pudding Cup Interface", 20, 0, 3, 1);


        returnMobo.CPUInterface         = DEBUG_INTERFACE;
        returnMobo.GPUInterface         = DEBUG_INTERFACE;
        returnMobo.HDDInterface         = DEBUG_INTERFACE;
        returnMobo.RAMInterface         = DEBUG_INTERFACE;
        returnMobo.powerInterface       = DEBUG_INTERFACE;
        returnMobo.compInputInterface   = DEBUG_INTERFACE;
        returnMobo.compOutputInterface  = DEBUG_INTERFACE;
        returnMobo.networkInterface     = DEBUG_INTERFACE;
        returnMobo.formFactor           = DEBUG_INTERFACE;

        returnMobo.plugIn(debugCPU);
        returnMobo.plugIn(debugGPU);
        returnMobo.plugIn(debugHDD);
        returnMobo.plugIn(debugRAM);
        returnMobo.plugIn(debugInput);
        returnMobo.plugIn(debugOutput);
        returnMobo.plugIn(debugNet);
        returnMobo.plugIn(debugPower);
        returnMobo.plugIn(debugChassis);

        return returnMobo;
    }
}
