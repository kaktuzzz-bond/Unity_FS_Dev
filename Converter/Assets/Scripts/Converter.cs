using System;


public sealed class Converter<TLoad, TUnload> where TLoad : class
                                              where TUnload : class
{
    private int _loadCapacity;
    private int _unloadCapacity;
    private int _capacity;

    public bool IsActive { get; private set; }
    public float Efficiency { get; private set; }


    public bool SetEfficiency(float efficiencyValue)
    {
        if (efficiencyValue is < 0 or > 1) 
            throw new ArgumentOutOfRangeException(nameof(SetEfficiency), efficiencyValue, "Value must be in 0..1 range.");

        Efficiency = efficiencyValue;

        return true;
    }

    public bool SetCapacity(int capacity)
    {
        if (capacity < 0) 
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Value must be greater than or equal to zero.");

        _capacity = capacity;

        return true;
    }

    public void Activate(bool isActive)
    {
        IsActive = isActive;
    }


    public bool SetUnloadAreaCapacity(int capacity)
    {
        if (capacity < 0) 
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Value must be greater than or equal to zero.");

        _unloadCapacity = capacity;

        return true;
    }


    public bool SetLoadAreaCapacity(int capacity)
    {
        if (capacity < 0) 
            throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Value must be greater than or equal to zero.");

        _loadCapacity = capacity;

        return true;
    }
}