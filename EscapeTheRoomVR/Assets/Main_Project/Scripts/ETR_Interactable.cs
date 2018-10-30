using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class ETR_Interactable : Interactable
{
    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
