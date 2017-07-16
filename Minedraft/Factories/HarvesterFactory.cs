using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester GetHarvester(List<string> harvesterDetails)
    {
        string type = harvesterDetails[0];
        string id = harvesterDetails[1];
        double oreOutput = double.Parse(harvesterDetails[2]);
        double energyRequirement = double.Parse(harvesterDetails[3]);

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
                break;
            case "Sonic":
                int sonicFactor = int.Parse(harvesterDetails[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                break;
            default:
                return null;
        }
    }
}