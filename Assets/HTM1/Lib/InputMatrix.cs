﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMatrix : ISubZone {

    public NInput[] inputs;
    private float[] oldInputsActive;
    private float[] inputsMotor;
    private SubZone upSubZone;
    private float threshold = 0.8f;

    public InputMatrix(int count)
    {
        inputs = new NInput[count];
        oldInputsActive = new float[count];
        inputsMotor = new float[count];
        for (int i = 0; i < count; i++)
        {
            inputs[i] = new NInput();
            oldInputsActive[i] = 0.0f;
            inputsMotor[i] = 0.0f;
        }

        upSubZone = null;
    }
    public void setUpSubZone(SubZone zone)
    {
        if (upSubZone != null)
        {
            DebugLog.Log("ERROR setUpSubZone: upSubZone is set already");
        }
        upSubZone = zone;
    }
    public void sendSignals()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i].active > oldInputsActive[i] && inputs[i].active > threshold)
            {
                upSubZone.inSignalActive(inputs[i]);
            }
        }
    }

    public override void inSignalForecast(INeuron inputNeuron)
    {
        inputNeuron.prediction = 1.0f;
    }

    public override void inSignalMotor(INeuron inputNeuron)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i] == inputNeuron)
            {
                inputsMotor[i] = 1.0f;
                break;
            }
        }
        inputNeuron.prediction = 1.0f;
    }

    public float[] getMotorValues()
    {
        return inputsMotor;
    }

    // Debug
    public void setBooleans(bool[] in1)
    {
        for (int i = 0; i < Mathf.Min(inputs.Length, in1.Length); i++)
        {
            inputs[i].active = in1[i] ? 1.0f : 0.0f;
            inputs[i].prediction = 0.0f;
        }
    }

    public void reset()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].active = 0.0f;
            inputs[i].prediction = 0.0f;
            inputsMotor[i] = 0.0f;
        }
    }
}
