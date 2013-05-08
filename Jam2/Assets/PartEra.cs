using UnityEngine;
using System.Collections;

public class PartEra {
    public Era era;
    public int yearStart;
    public int yearEnd;

    public Pair<int,int> cpu_CoresRange { get; set; }
    public Pair<int,int> cpu_ClockRange { get; set; }
    public Pair<int,int> cpu_BitsRange { get; set; }

    public Pair<int,int> gpu_MegaflopsRange { get; set; }
    public Pair<int,int> gpu_MemoryRange { get; set; }

    public Pair<int,int> hdd_SizeRange { get; set; }
    public Pair<int,int> hdd_SpeedRange { get; set; }

    public Pair<int,int> ram_SizeRange { get; set; }
    public Pair<int,int> ram_SpeedRange { get; set; }
    public Pair<int,int> ram_ChannelsRange { get; set; }

    public Pair<int,int> input_DPIRange { get; set; }
    public Pair<int,int> input_PollingRange { get; set; }

    public Pair<int,int> output_ResolutionRange { get; set; }
    public Pair<int,int> output_RefreshRange { get; set; }
    public Pair<int,int> output_SQRange { get; set; }

    public Pair<NetworkType,NetworkType> network_TypeRange { get; set; }
    public Pair<int,int> network_PingRange { get; set; }
    public Pair<int, int> network_BandwidthRange { get; set; }

    public Pair<int,int> pSupply_WattageRange { get; set; }

    public Pair<int, int> chassis_CoolRange { get; set; }

    public PartEra(Era era, int yearStart, int yearEnd)
    {
        this.era = era;
        this.yearStart = yearStart;
        this.yearEnd = yearEnd;
    }
}

public class Eras
{
    public ArrayList eraList = new ArrayList();
    public PartEra PE1980 = new PartEra(Era.E1980, 1980, 1990);

    public Eras()
    {
        //1980
        PE1980 = new PartEra(Era.E1980, 1980, 1990);
        PE1980.cpu_CoresRange           = new Pair<int, int>(1,2);
        PE1980.cpu_ClockRange           = new Pair<int, int>(6,50);
        PE1980.cpu_BitsRange            = new Pair<int, int>(32,32);

        PE1980.gpu_MegaflopsRange       = new Pair<int, int>(1,4);
        PE1980.gpu_MemoryRange          = new Pair<int, int>(1,2);

        PE1980.hdd_SizeRange            = new Pair<int, int>(1,2);
        PE1980.hdd_SpeedRange           = new Pair<int, int>(600,3200);

        PE1980.ram_SizeRange            = new Pair<int, int>(1,2);
        PE1980.ram_SpeedRange           = new Pair<int, int>(1,3);
        PE1980.ram_ChannelsRange        = new Pair<int, int>(1,4);

        PE1980.input_DPIRange           = new Pair<int, int>(200,300);
        PE1980.input_PollingRange       = new Pair<int, int>(10,60);

        PE1980.output_ResolutionRange   = new Pair<int, int>(205, 480); //May want to make this a vector of discrete values
        PE1980.output_RefreshRange      = new Pair<int, int>(20, 60); ; //May want to make this a vector of discrete values
        PE1980.output_SQRange           = new Pair<int, int>(1,3);

        PE1980.network_TypeRange        = new Pair<NetworkType, NetworkType>(NetworkType.DIALUP, NetworkType.FIFTYSIXK);
        PE1980.network_PingRange        = new Pair<int, int>(100,300);
        PE1980.network_BandwidthRange   = new Pair<int, int>(1, 2);

        PE1980.pSupply_WattageRange     = new Pair<int, int>(100, 200);

        PE1980.chassis_CoolRange        = new Pair<int, int>(1,2);

        eraList.Add(PE1980);
    }
}