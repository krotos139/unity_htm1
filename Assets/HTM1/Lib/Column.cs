using System.Collections;
using System.Collections.Generic;

public class Column : INeuron {

    private ArrayList neurons;
    private SubZone zone;
    private int lastActiveNeuron;
    private int confDeepanalyse;
    private float threshold = 0.8f;
    private float degradation = 0.4f;


    public Column(SubZone zone)
    {
        this.zone = zone;
        this.neurons = new ArrayList();
        active = 0.0f;
        lastActiveNeuron = 0;
        confDeepanalyse = 1;
    }

    public void pushInput(LinkedList<INeuron> inputs)
    {
        if (neurons.Count == 0) return;
        float dactive = 0.0f;
        for (int i = 0; i < confDeepanalyse; i++)
        {
            dactive += ((Neuron)neurons[lastActiveNeuron + i]).pushInputActive(inputs);
        }
        dactive = (dactive - 0.5f) * 2f;

        if (dactive > threshold)
        {
            active += dactive;
            lastActiveNeuron += 1;
        }
        if (active > threshold)
        {
            zone.outSignalActive(this, active);
        }
        if (lastActiveNeuron >= neurons.Count)
        {
            onDeactive();
        }
        if (active > 1) active = 1;
        if (active < 1 - threshold)
        {
            onDeactive();
        }
        if (lastActiveNeuron != 0)
        {
            foreach (KeyValuePair<INeuron, float> me in ((Neuron)neurons[lastActiveNeuron]).getSynapses()) {
                if (me.Value > 0)
                {
                    zone.outSignalForecast(me.Key);
                }
            }
        }
    }

    public void onDegradation()
    {
        active -= degradation;
        if (active < 1 - threshold) {
            onDeactive();
        }
    }

    public void onForecast()
    {
        active += 1.0f;
        // todo send forecasts
    }

    public void onMotor()
    {
        if (neurons.Count == 0) return;
        foreach (KeyValuePair<INeuron, float> me in ((Neuron)neurons[lastActiveNeuron]).getSynapses())
        {
            if (me.Value > 0) {
                zone.outSignalMotor(me.Key);
            }
        }
    }

    public void onDeactive()
    {
        lastActiveNeuron = 0;
        active = 0;
    }

    public void onDeactiveZone()
    {
        lastActiveNeuron = 0;
        active = 0;
        zone.onDeactive();
    }

    // =========================================
    // Debug
    public void addNeurons(INeuron[] c)
    {
        Neuron n = new Neuron(this);
        n.addNeirons(c);
        neurons.Add(n);
        //        if (neurons.size() > 1) {
        //            neurons.get(neurons.size()-2).setNext(n);
        //        }
    }

}
