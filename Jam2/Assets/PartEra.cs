using UnityEngine;
using System.Collections;

public class PartEra {
    public Era era;
    public int yearStart;
    public int yearEnd;

    public Pair<int, int> cpu_CoresRange;
    public Pair<int, int> cpu_ClockRange;
    public Pair<int, int> cpu_BitsRange;

    public Pair<int, int> gpu_MegaflopsRange;
    public Pair<int, int> gpu_MemoryRange;

    public Pair<int, int> hdd_SizeRange;
    public Pair<int, int> hdd_SpeedRange;

    public Pair<int, int> ram_SizeRange;
    public Pair<int, int> ram_SpeedRange;
    public Pair<int, int> ram_ChannelsRange;

    public Pair<int, int> input_DPIRange;
    public Pair<int, int> input_PollingRange;

    public Pair<int, int> output_ResolutionRange; //May want to make this a vector of discrete values
    public Pair<int, int> output_RefreshRange; //May want to make this a vector of discrete values
    public Pair<int, int> output_SQRange;

    public Pair<NetworkType, NetworkType> network_TypeRange;
    public Pair<int, int> network_PingRange;
    public Pair<int, int> network_BandwidthRange;

    public Pair<int, int> pSupply_wattageRange;

    public Pair<int, int> chassis_CoolRange;

    public PartEra(Era era, int yearStart, int yearEnd)
    {
        this.era = era;
        this.yearStart = yearStart;
        this.yearEnd = yearEnd;
    }
}

public class Eras
{
    private ArrayList eraList = new ArrayList();
    public Eras()
    {
        //1980
        PartEra PE1980 = new PartEra(Era.E1980, 1980, 1990);
        PE1980.cpu_CoresRange           = new Pair<int, int>(1,2);
        PE1980.cpu_ClockRange           = new Pair<int, int>(6,50);
        PE1980.cpu_BitsRange            = new Pair<int, int>(32,32);

        PE1980.gpu_MegaflopsRange       = new Pair<int, int>(1,4); //Floats?
        PE1980.gpu_MemoryRange          = new Pair<int, int>(1,2); //Floats

        PE1980.hdd_SizeRange            = new Pair<int, int>(1,2); //Floats?
        PE1980.hdd_SpeedRange           = new Pair<int, int>(600,3200);

        PE1980.ram_SizeRange            = new Pair<int, int>(1,2); //Floats?
        PE1980.ram_SpeedRange           = new Pair<int, int>(1,3);
        PE1980.ram_ChannelsRange        = new Pair<int, int>(1,4);

        PE1980.input_DPIRange           = new Pair<int, int>(200,300);
        PE1980.input_PollingRange       = new Pair<int, int>(10,60);

        PE1980.output_ResolutionRange   = new Pair<int, int>(320,640); //May want to make this a vector of discrete values
        PE1980.output_RefreshRange      = new Pair<int, int>(20, 60); ; //May want to make this a vector of discrete values
        PE1980.output_SQRange           = new Pair<int, int>(1,3);

        PE1980.network_TypeRange        = new Pair<NetworkType, NetworkType>(NetworkType.DIALUP, NetworkType.FIFTYSIXK);
        PE1980.network_PingRange        = new Pair<int, int>(100,300);
        PE1980.network_BandwidthRange   = new Pair<int, int>(1, 2);

        PE1980.pSupply_wattageRange     = new Pair<int, int>(100, 200);

        PE1980.chassis_CoolRange        = new Pair<int, int>(1,2);

        eraList.Add(PE1980);
    }
}