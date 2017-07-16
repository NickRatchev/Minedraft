using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider GetProvider(List<string> providerDetails)
    {
        string type = providerDetails[0];
        string id = providerDetails[1];
        double energyOutput = double.Parse(providerDetails[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
                break;
            case "Pressure":
                return new PressureProvider(id, energyOutput);
                break;
            default:
                return null;
        }
    }
}