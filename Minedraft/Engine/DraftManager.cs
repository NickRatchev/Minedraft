using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.harvesters.Add(arguments[1], HarvesterFactory.GetHarvester(arguments));
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.providers.Add(arguments[1], ProviderFactory.GetProvider(arguments));
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }
    public string Day()
    {
        double summedEnergyOutput = this.providers.Values.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += summedEnergyOutput;
        double requiredEnergy = GetRequredEnergy();
        double summedOreOutput = GetOreOutput();

        if (requiredEnergy <= this.totalStoredEnergy)
        {
            this.totalStoredEnergy -= requiredEnergy;
            this.totalMinedOre += summedOreOutput;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.Append($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString();
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        if (harvesters.ContainsKey(id))
        {
            return harvesters[id].ToString();
        }

        if (providers.ContainsKey(id))
        {
            return providers[id].ToString();
        }

        return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }


    private double GetOreOutput()
    {
        if (this.mode == "Full")
        {
            return this.harvesters.Values.Sum(h => h.OreOutput);
        }

        if (this.mode == "Half")
        {
            return this.harvesters.Values.Sum(h => h.OreOutput) * 0.5;
        }

        return 0;
    }

    private double GetRequredEnergy()
    {
        double totalRequiredEnergy = this.harvesters.Values.Sum(h => h.EnergyRequirement);
        if (this.mode == "Full")
        {
            return totalRequiredEnergy;
        }

        if (this.mode == "Half")
        {
            return totalRequiredEnergy * 0.6;
        }

        return 0;
    }
}