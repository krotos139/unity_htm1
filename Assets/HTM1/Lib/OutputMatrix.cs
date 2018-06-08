using System.Collections;
using System.Collections.Generic;

public class OutputMatrix : ISubZone
{
    public float[] inputsActives;
    public INeuron[] inputs;
    private LinkedList<ISubZone> downSubZones;

    public OutputMatrix(int count)
    {
        inputs = new INeuron[count];
        inputsActives = new float[count];
        downSubZones = new LinkedList<ISubZone>();
    }

    public void setDownSubZones(ISubZone zone)
    {
        downSubZones.AddLast(zone);
    }

    public void addInput(int i, INeuron inNeuron)
    {
        inputs[i] = inNeuron;
        inputsActives[i] = 0;
    }

    public void addInputs(SubZone zone)
    {
        if (zone.getColumns().Length != inputs.Length)
        {
            DebugLog.Log("ERROR: addInputs invalid input");
            return;
        }
        for (int i = 0; i < zone.getColumns().Length; i++)
        {
            inputs[i] = zone.getColumns()[i];
            inputsActives[i] = 0;
        }

    }

    public override void inSignalActive(INeuron input)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i] == input)
            {
                inputsActives[i] = 1;
                break;
            }
        }
    }

    public void outSignalForecast(int column)
    {
        outSignalForecast(inputs[column]);
    }

    public void outSignalForecast(INeuron outNeuron)
    {
        foreach (ISubZone sz in downSubZones)
        {
            sz.inSignalForecast(outNeuron);
        }
    }

    public void outSignalMotor(int column)
    {
        outSignalMotor(inputs[column]);
    }

    public void outSignalMotor(INeuron outNeuron)
    {
        foreach (ISubZone sz in downSubZones)
        {
            sz.inSignalMotor(outNeuron);
        }
    }

    // DEBUG
    public void reset()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputsActives[i] = 0;
        }
    }
}
