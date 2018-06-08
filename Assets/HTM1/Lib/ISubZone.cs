using System.Collections;
using System.Collections.Generic;

public class ISubZone {

    public virtual void inSignalActive(INeuron input)
    {
        DebugLog.Log("ERROR: ISubZone.inSignalActive");
    }
    public virtual void inSignalForecast(INeuron input)
    {
        DebugLog.Log("ERROR: ISubZone.inSignalForecast");
    }
    public virtual void inSignalMotor(INeuron input)
    {
        DebugLog.Log("ERROR: ISubZone.inSignalMotor");
    }
}
