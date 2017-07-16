using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.sonicFactor = sonicFactor;
        this.EnergyRequirement = this.EnergyRequirement / sonicFactor;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Sonic Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }
}