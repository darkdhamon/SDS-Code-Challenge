using System;
using DeveloperSample.ClassRefactoring.Model.Enums;

namespace DeveloperSample.ClassRefactoring.Model;

public class Swallow
{
    // Rename Type to SwallowType to no interfere with C# Type Class.
    public SwallowType SwallowType { get; }
    public SwallowLoad Load { get; private set; }

    public Swallow(SwallowType swallowType)
    {
        SwallowType = swallowType;
    }

    public void ApplyLoad(SwallowLoad load)
    {
        Load = load;
    }

    public double GetAirspeedVelocity()
    {
        // Convert if statements to switch for more readable code.
        return SwallowType switch
        {
            SwallowType.African when Load == SwallowLoad.None => 22,
            SwallowType.African when Load == SwallowLoad.Coconut => 18,
            SwallowType.European when Load == SwallowLoad.None => 20,
            SwallowType.European when Load == SwallowLoad.Coconut => 16,
            _ => throw new InvalidOperationException()
        };
    }
}