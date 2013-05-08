using UnityEngine;
using System.Collections;
using System;

public class Shop {
    ArrayList moboInventory;
    ArrayList cpuInventory;
    ArrayList gpuInventory;
    ArrayList hddInventory;
    ArrayList ramInventory;
    ArrayList inputInventory;
    ArrayList outputInventory;
    ArrayList networkInventory;
    ArrayList pSupplyInventory;
    ArrayList chassisInventory;

    PartGenerator pg;
    Random rand;

    void generateInventory()
    {
        Pair<Type, Company> temp;
        int temp2;
        rand = new Random();

        pg = new PartGenerator();
        moboInventory.Clear();
        temp = (Pair<Type, Company>)(pg.MOBO_PAIRS[rand.Next(pg.MOBO_PAIRS.Count)]);
        moboInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.MOBO_PAIRS[rand.Next(pg.MOBO_PAIRS.Count)]);
            moboInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        cpuInventory.Clear();
        temp = (Pair<Type, Company>)(pg.CPU_PAIRS[rand.Next(pg.CPU_PAIRS.Count)]);
        cpuInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.CPU_PAIRS[rand.Next(pg.CPU_PAIRS.Count)]);
            cpuInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        gpuInventory.Clear();
        temp = (Pair<Type, Company>)(pg.GPU_PAIRS[rand.Next(pg.GPU_PAIRS.Count)]);
        gpuInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.GPU_PAIRS[rand.Next(pg.GPU_PAIRS.Count)]);
            gpuInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        hddInventory.Clear();
        temp = (Pair<Type, Company>)(pg.HDD_PAIRS[rand.Next(pg.HDD_PAIRS.Count)]);
        hddInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.HDD_PAIRS[rand.Next(pg.HDD_PAIRS.Count)]);
            hddInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        ramInventory.Clear();
        temp = (Pair<Type, Company>)(pg.RAM_PAIRS[rand.Next(pg.RAM_PAIRS.Count)]);
        ramInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.RAM_PAIRS[rand.Next(pg.RAM_PAIRS.Count)]);
            ramInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        inputInventory.Clear();
        temp = (Pair<Type, Company>)(pg.INPUT_PAIRS[rand.Next(pg.INPUT_PAIRS.Count)]);
        inputInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
        }

        outputInventory.Clear();
        temp = (Pair<Type, Company>)(pg.OUTPUT_PAIRS[rand.Next(pg.OUTPUT_PAIRS.Count)]);
        outputInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.OUTPUT_PAIRS[rand.Next(pg.OUTPUT_PAIRS.Count)]);
            outputInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        networkInventory.Clear();
        temp = (Pair<Type, Company>)(pg.NETWORK_PAIRS[rand.Next(pg.NETWORK_PAIRS.Count)]);
        networkInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.NETWORK_PAIRS[rand.Next(pg.NETWORK_PAIRS.Count)]);
            networkInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        pSupplyInventory.Clear();
        temp = (Pair<Type, Company>)(pg.PSU_PAIRS[rand.Next(pg.PSU_PAIRS.Count)]);
        pSupplyInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.PSU_PAIRS[rand.Next(pg.PSU_PAIRS.Count)]);
            pSupplyInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }

        chassisInventory.Clear();
        temp = (Pair<Type, Company>)(pg.CHASSIS_PAIRS[rand.Next(pg.CHASSIS_PAIRS.Count)]);
        chassisInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        temp2 = rand.Next(2);
        for (int i = 0; i < temp2; i++)
        {
            temp = (Pair<Type, Company>)(pg.CHASSIS_PAIRS[rand.Next(pg.CHASSIS_PAIRS.Count)]);
            chassisInventory.Add(pg.generatePart(temp.getLeft(), temp.getRight()));
        }
    }
}
