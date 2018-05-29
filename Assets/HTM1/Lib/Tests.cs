using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tests {

    public bool HW1()
    {
        string dbgout = "";
        DebugLog.Log("HW1");
        InputMatrix in1 = new InputMatrix(5);
        SubZone sz1 = new SubZone(5);
        OutputMatrix out1 = new OutputMatrix(5);
        in1.setUpSubZone(sz1);
        sz1.setDownSubZones(in1);
        sz1.setUpSubZone(out1);
        out1.addInputs(sz1);
        DebugLog.Log("Learn");
        bool[][] in_p1 = new bool[][]{
                new bool[]{true, false, false, false, false},
                new bool[]{false, true, false, false, false},
                new bool[]{false, false, true, false, false},
                new bool[]{false, false, false, true, false},
                new bool[]{false, false, false, false, true},
        };
        for (int i = 0; i < in_p1.Length; i++)
        {
            in1.setBooleans(in_p1[i]);
            sz1.setColumnNeurons(i, in1.inputs);
        }
        for (int n = 0; n < in_p1.Length; n++)
        {
            out1.reset();
            DebugLog.Log("Analyse " + n + " pattern");
            in1.setBooleans(in_p1[n]);
            dbgout = "";
            for (int i = 0; i < in1.inputs.Length; i++)
            {
                dbgout += (in1.inputs[i].active > 0.8f ? "A" : "_") + " ";
            }
            DebugLog.Log("Pattern : " + dbgout);
            in1.sendSignals();
            sz1.analyze();
            dbgout = "";
            for (int i = 0; i < out1.inputs.Length; i++)
            {
                dbgout += (out1.inputs[i].active > 0.8f ? "A" : "_") + " ";
            }
            DebugLog.Log("Columns : " + dbgout);
            out1.reset();
        }
        //sz1.teach();
        return true;
    }
}
