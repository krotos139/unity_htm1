public class INeuron {
    public float active = 0.0f;
    public float prediction = 0.0f;

    public float getActive()
    {
        return active + prediction;
    }
    public void setPrediction(float a)
    {
        prediction = a;
    }
}
