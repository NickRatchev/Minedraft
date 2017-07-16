using System;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }
}