using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public float StateDuration { get; private set; } = 0;

    public virtual void Enter()
    {
        StateDuration = 0;
    }

    public virtual void Exit()
    {

    }

    public virtual void FixedTick()
    {

    }

    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }

}
