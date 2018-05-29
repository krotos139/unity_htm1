using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubZone : ISubZone {
    private Column[] columns;
    private LinkedList<INeuron> inputActive;
    private LinkedList<INeuron> inputForecast;
    //private LinkedList<INeuron> inputMotor;
    private LinkedList<Column> activeColumns;
    private ISubZone upSubZone;
    private LinkedList<ISubZone> downSubZones;

    private INeuron upOutput;
    private float upOutputActive;
    private LinkedList<INeuron> upOutputs;
    private LinkedList<INeuron> downOutputs;

    public SubZone(int numColumns)
    {
        columns = new Column[numColumns];
        for (int i = 0; i < numColumns; i++)
        {
            columns[i] = new Column(this);
        }
        inputActive = new LinkedList<INeuron>();
        inputForecast = new LinkedList<INeuron>();
        //inputMotor = new LinkedList<>();
        activeColumns = new LinkedList<Column>();
        upSubZone = null;
        downSubZones = new LinkedList<ISubZone>();
        downOutputs = new LinkedList<INeuron>();
        upOutputActive = 0.0f;
        upOutputs = new LinkedList<INeuron>();
    }

    public override void inSignalActive(INeuron inputNeuron)
    {
        inputActive.AddLast(inputNeuron);
    }

    public override void inSignalForecast(INeuron inputNeuron)
    {
        inputForecast.AddLast(inputNeuron);
    }

    public override void inSignalMotor(INeuron inputNeuron)
    {
        //inputMotor.add(inputNeuron);
        ((Column)inputNeuron).onMotor();

    }

    public void setDownSubZones(ISubZone zone)
    {
        downSubZones.AddLast(zone);
    }
    public void setUpSubZone(ISubZone zone)
    {
        if (upSubZone != null)
        {
            DebugLog.Log("ERROR setUpSubZone: upSubZone is set already");
        }
        upSubZone = zone;
    }

    public void analyze()
    {
        if (inputForecast.Count > 0)
        {
            foreach (INeuron s in inputForecast)
            {
                ((Column)s).onForecast();
            }
        }
        inputForecast.Clear();

        upOutput = null;

        foreach (Column c in columns)
        {
            c.pushInput(inputActive);
            c.onDegradation();
        }
        inputActive.Clear();

        if (upSubZone != null && upOutput != null)
        {
            upSubZone.inSignalActive(upOutput);
        }

        foreach (Column c in columns)
        {
            if (!upOutputs.Contains(c))
            {
                c.onDeactive();
            }
        }
        upOutputs.Clear();
        //        if (downOutputs.size() >0) {
        //            for (ISubZone z : downSubZones) {
        //                for (InputSignal i : downOutputs) {
        //                    z.inSignal(i);
        //                }
        //            }
        //        }
    }


    public void outSignalActive(INeuron outNeuron, float active)
    {
        if (upOutput == null)
        {
            upOutput = outNeuron;
            upOutputActive = active;
        }
        else if (active > upOutputActive)
        {
            upOutput = outNeuron;
            upOutputActive = active;
        }
        upOutputs.AddLast(outNeuron);
        //        if (signal.type == SignalType.Forecast || signal.type == SignalType.Motor) {
        //            downOutputs.add(signal);
        //        }
    }

    public void outSignalForecast(INeuron outNeuron)
    {
        foreach (ISubZone sz in downSubZones)
        {
            sz.inSignalForecast(outNeuron);
        }
    }

    public void outSignalMotor(INeuron outNeuron)
    {
        foreach (ISubZone sz in downSubZones)
        {
            sz.inSignalMotor(outNeuron);
        }
    }

    public void onDeactive()
    {
        foreach (Column c in columns)
        {
            c.onDeactive();
        }
    }

    // DEBUG
    public void setColumnNeurons(int column, INeuron[] inNeurons)
    {
        Column c = columns[column];
        c.addNeurons(inNeurons);
    }

    public Column[] getColumns()
    {
        return columns;
    }
}
