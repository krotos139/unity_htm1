using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron {
    private float forecast = 0.0f;
    private Column column;
    private Dictionary<INeuron, float> synaps;
    private float threshold = 0.5f;

    public Neuron(Column column)
    {
        this.synaps = new Dictionary<INeuron, float>();
        this.column = column;
    }

    public float pushInputActive(LinkedList<INeuron> inputs)
    {
        //active = 0.0f;
        float activeSynapsCount = 0f;
        foreach(INeuron s in inputs)
        {
            float syn;
            if (synaps.TryGetValue(s, out syn))
            {
                activeSynapsCount += syn;
            }
        }
        return activeSynapsCount;
    }

    public Dictionary<INeuron, float> getSynapses()
    {
        return synaps;
    }

    // Debug
    public void addNeirons(INeuron[] neurons)
    {
        int synapsCount = 0;
        for (int i = 0; i < neurons.Length; i++)
        {
            if (neurons[i].active > threshold) synapsCount++;
        }
        float strength = 1.0f / synapsCount;
        for (int i = 0; i < neurons.Length; i++)
        {
            if (neurons[i].active > threshold)
            {
                synaps.Add(neurons[i], strength);
            }
        }
        if (true)
        {
            int synapsNCount = 0;
            for (int i = 0; i < neurons.Length; i++)
            {
                if (neurons[i].active < threshold) synapsNCount++;
            }
            float strengthN = 1.0f / synapsNCount;
            for (int i = 0; i < neurons.Length; i++)
            {
                if (neurons[i].active < threshold)
                {
                    synaps.Add(neurons[i], -strengthN);
                }
            }
        }
    }
}
