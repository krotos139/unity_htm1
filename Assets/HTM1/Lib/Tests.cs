using System.Collections;
using System.Collections.Generic;
using System;

public class Tests {

    public bool HW1()
    {
        string dbgout = "";
        DebugLog.Log("HW1 - Simple");
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
                dbgout += (out1.inputsActives[i] > 0.8f ? "A" : "_") + " ";
            }
            DebugLog.Log("Columns : " + dbgout);
            out1.reset();
        }
        //sz1.teach();
        return true;
    }

    public void HW2()
    {
        string dbgout = "";
        DebugLog.Log("HW2 - Sequence");
        InputMatrix in1 = new InputMatrix(5);
        SubZone sz1 = new SubZone(5);
        OutputMatrix out1 = new OutputMatrix(5);
        in1.setUpSubZone(sz1);
        sz1.setDownSubZones(in1);
        sz1.setUpSubZone(out1);
        out1.addInputs(sz1);
        DebugLog.Log("Learn");
        bool[][] in_p1 = new bool[][]{
                new bool[]{true, true, false, false, false},
                new bool[]{false, true, true, false, false},
        };
        for (int i = 0; i < in_p1.Length; i++)
        {
            in1.setBooleans(in_p1[i]);
            sz1.setColumnNeurons(0, in1.inputs);
        }
        bool[][] in_p2 = new bool[][]{
                new bool[]{false, false, true, true, false},
                new bool[]{false, false, false, true, true},
        };
        for (int i = 0; i < in_p2.Length; i++)
        {
            in1.setBooleans(in_p2[i]);
            sz1.setColumnNeurons(1, in1.inputs);
        }
        bool[][] in_p3 = new bool[][]{
                new bool[]{false, false, true, true, false},
                new bool[]{false, true, true, false, false},
                new bool[]{true, true, false, false, false},
        };
        for (int i = 0; i < in_p3.Length; i++)
        {
            in1.setBooleans(in_p3[i]);
            sz1.setColumnNeurons(2, in1.inputs);
        }
        bool[][] in_p4 = new bool[][]{
                new bool[]{true, false, false, false, true},
                new bool[]{false, true, false, true, false},
                new bool[]{false, false, true, false, false},
        };
        for (int i = 0; i < in_p4.Length; i++)
        {
            in1.setBooleans(in_p4[i]);
            sz1.setColumnNeurons(3, in1.inputs);
        }
        bool[][] in_p5 = new bool[][]{
                new bool[]{true, false, false, false, false},
                new bool[]{false, true, false, false, false},
                new bool[]{false, false, true, false, false},
                new bool[]{false, false, false, true, false},
                new bool[]{false, false, false, false, true},
        };
        for (int i = 0; i < in_p5.Length; i++)
        {
            in1.setBooleans(in_p5[i]);
            sz1.setColumnNeurons(4, in1.inputs);
        }
        bool[][] in_p = new bool[][]{
                new bool[]{true, false, false, false, false},// 5
                new bool[]{false, true, false, false, false},// 5
                new bool[]{false, false, true, false, false},// 5
                new bool[]{false, false, false, true, false},// 5
                new bool[]{false, false, false, false, true},// 5
                new bool[]{false, false, false, true, true}, // _
                new bool[]{false, false, true, true, false}, // 2, 3
                new bool[]{false, true, true, false, false}, // 3
                new bool[]{true, true, false, false, false}, // 3, 1
                new bool[]{false, true, true, false, false}, // 1
                new bool[]{false, false, true, true, false}, // 2
                new bool[]{false, false, false, true, true}, // 2
                new bool[]{true, false, false, false, true}, // 4
                new bool[]{false, true, false, true, false}, // 4
                new bool[]{false, false, true, false, false}, // 4
                new bool[]{false, false, false, true, false}, // _
                new bool[]{false, false, false, false, true}, // _
                new bool[]{true, false, false, false, false}, // 5
                new bool[]{false, true, false, false, false}, // 5
                new bool[]{false, false, true, false, false}, // 5
                new bool[]{true, false, false, false, true}, // 4
                new bool[]{false, true, false, true, false}, // 4
                new bool[]{false, false, true, true, false}, // 3
                new bool[]{false, true, true, false, false}, // 3
                new bool[]{true, true, false, false, false}, // 3
                new bool[]{true, false, false, false, true}, // 4
                new bool[]{true, true, false, false, false}, // 1
                new bool[]{false, true, true, false, false}, // 1
                new bool[]{false, false, true, true, false}, // 3
                new bool[]{false, false, false, true, true}, // _
        };
        bool[][] in_e = new bool[][]{
                new bool[]{false, false, false, false, true},// 5
                new bool[]{false, false, false, false, true},// 5
                new bool[]{false, false, false, false, true},// 5
                new bool[]{false, false, false, false, true},// 5
                new bool[]{false, false, false, false, true},// 5
                new bool[]{false, false, false, false, false}, // _
                new bool[]{false, true, true, false, false}, // 2, 3
                new bool[]{false, false, true, false, false}, // 3
                new bool[]{true, false, true, false, false}, // 3, 1
                new bool[]{true, false, false, false, false}, // 1
                new bool[]{false, true, false, false, true}, // 2, 5
                new bool[]{false, true, false, false, false}, // 2
                new bool[]{false, false, false, true, false}, // 4
                new bool[]{false, false, false, true, false}, // 4
                new bool[]{false, false, false, true, false}, // 4
                new bool[]{false, false, false, false, false}, // _
                new bool[]{false, false, false, false, false}, // _
                new bool[]{false, false, false, false, true}, // 5
                new bool[]{false, false, false, false, true}, // 5
                new bool[]{false, false, false, false, true}, // 5
                new bool[]{false, false, false, true, false}, // 4
                new bool[]{false, false, false, true, false}, // 4
                new bool[]{false, true, true, false, false}, // 3, 2
                new bool[]{false, false, true, false, false}, // 3
                new bool[]{false, false, true, false, false}, // 3
                new bool[]{false, false, false, true, false}, // 4
                new bool[]{true, false, false, false, false}, // 1
                new bool[]{true, false, false, false, false}, // 1
                new bool[]{false, true, false, false, false}, // 2
                new bool[]{false, true, false, false, false}, // 2
        };
        for (int n = 0; n < in_p.Length; n++)
        {
            DebugLog.Log("Analyse " + n + " pattern");
            in1.setBooleans(in_p[n]);
            dbgout = "";
            for (int i = 0; i < in1.inputs.Length; i++)
            {
                dbgout += (in1.inputs[i].active > 0.8f ? "A" : "_") + " ";
            }
            DebugLog.Log("Pattern : " + dbgout);
            dbgout = "";
            for (int i = 0; i < in1.inputs.Length; i++)
            {
                dbgout += (in_e[n][i] ? "A" : "_") + " ";
            }
            DebugLog.Log("Etalon : " + dbgout);
            in1.sendSignals();
            sz1.analyze();
            dbgout = "";
            for (int i = 0; i < out1.inputs.Length; i++)
            {
                dbgout += (out1.inputsActives[i] > 0.8f ? "A" : "_") + " ";
            }
            DebugLog.Log("Columns : " + dbgout);
            dbgout = "";
            for (int i = 0; i < out1.inputs.Length; i++)
            {
                dbgout += (in1.inputs[i].prediction >= 0.5f ? "A" : "_") + " ";
            }
            DebugLog.Log("Prediction : " + dbgout);
            out1.reset();
        }
        //sz1.teach();

    }
    
    public void HW3()
    {
        string dbgout = "";
        DebugLog.Log("HW3 - Forecasts");
        InputMatrix in1 = new InputMatrix(5);
        SubZone sz1 = new SubZone(5);
        OutputMatrix out1 = new OutputMatrix(5);
        in1.setUpSubZone(sz1);
        sz1.setDownSubZones(in1);
        sz1.setUpSubZone(out1);
        out1.setDownSubZones(sz1);
        out1.addInputs(sz1);
        DebugLog.Log("Learn");

        bool[][] in_p2 = new bool[][]{
                new bool[]{false, false, true, true, false},
                new bool[]{false, false, false, true, true},
        };
        for (int i = 0; i < in_p2.Length; i++)
        {
            in1.setBooleans(in_p2[i]);
            sz1.setColumnNeurons(1, in1.inputs);
        }
        bool[][] in_p3 = new bool[][]{
                new bool[]{false, false, true, true, false},
                new bool[]{false, true, true, false, false},
                new bool[]{true, true, false, false, false},
        };
        for (int i = 0; i < in_p3.Length; i++)
        {
            in1.setBooleans(in_p3[i]);
            sz1.setColumnNeurons(2, in1.inputs);
        }

        bool[][] in_p = new bool[][]{
                new bool[]{false, false, false, true, false},// _
                new bool[]{false, false, true, true, false},// 2,3
        };

        for (int p = 0; p < 5; p++)
        {
            DebugLog.Log("Forecast " + p + " pattern");
            out1.outSignalForecast(p);
            for (int n = 0; n < in_p.Length; n++)
            {
                DebugLog.Log("Analyse " + n + " pattern");
                in1.setBooleans(in_p[n]);
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
                    dbgout += (out1.inputsActives[i] > 0.8f ? "A" : "_") + " ";
                }
                DebugLog.Log("Columns : " + dbgout);
                dbgout = "";
                for (int i = 0; i < out1.inputs.Length; i++)
                {
                    dbgout += (in1.inputs[i].prediction >= 0.5f ? "A" : "_") + " ";
                }
                DebugLog.Log("Prediction : " + dbgout);
                out1.reset();
            }
            sz1.onDeactive();
        }

    }
    
    public void HW4()
    {
        string dbgout = "";
        DebugLog.Log("HW4 - Motor");
        InputMatrix in1 = new InputMatrix(5);
        SubZone sz1 = new SubZone(5);
        OutputMatrix out1 = new OutputMatrix(5);
        in1.setUpSubZone(sz1);
        sz1.setDownSubZones(in1);
        sz1.setUpSubZone(out1);
        out1.setDownSubZones(sz1);
        out1.addInputs(sz1);
        DebugLog.Log("Learn");

        bool[][] in_p2 = new bool[][]{
                new bool[]{false, false, true, true, false},
                new bool[]{false, false, false, true, true},
        };
        for (int i = 0; i < in_p2.Length; i++)
        {
            in1.setBooleans(in_p2[i]);
            sz1.setColumnNeurons(1, in1.inputs);
        }
        bool[][] in_p3 = new bool[][]{
                new bool[]{false, false, true, true, false},
                new bool[]{false, true, true, false, false},
                new bool[]{true, true, false, false, false},
        };
        for (int i = 0; i < in_p3.Length; i++)
        {
            in1.setBooleans(in_p3[i]);
            sz1.setColumnNeurons(2, in1.inputs);
        }

        bool[][] in_p = new bool[][]{
                new bool[]{false, false, false, true, false},// _
                new bool[]{false, false, true, true, false},// 2,3
        };

        for (int n = 0; n < in_p.Length; n++)
        {
            DebugLog.Log("Analyse " + n + " pattern");
            in1.setBooleans(in_p[n]);
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
                dbgout += (out1.inputsActives[i] > 0.8f ? "A" : "_") + " ";
            }
            DebugLog.Log("Columns : " + dbgout);
            dbgout = "";
            for (int i = 0; i < out1.inputs.Length; i++)
            {
                dbgout += (in1.inputs[i].prediction >= 0.5f ? "A" : "_") + " ";
            }
            DebugLog.Log("Prediction : " + dbgout);
            for (int p = 0; p < 5; p++)
            {
                DebugLog.Log("Motor " + p + " pattern");
                out1.outSignalMotor(p);
                dbgout = "";
                for (int i = 0; i < in1.inputs.Length; i++)
                {
                    dbgout += (in1.getMotorValues()[i] >= 0.5f ? "A" : "_") + " ";
                }
                DebugLog.Log("Motor : " + dbgout);
                in1.reset();
            }
            out1.reset();
        }
        sz1.onDeactive();

    }
}
