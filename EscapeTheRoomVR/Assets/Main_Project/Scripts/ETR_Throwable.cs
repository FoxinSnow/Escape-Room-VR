using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class ETR_Throwable : Throwable
{

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void GetReleaseVelocities(Hand hand, out Vector3 velocity, out Vector3 angularVelocity)
    {
        base.GetReleaseVelocities(hand, out velocity, out angularVelocity);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void HandAttachedUpdate(Hand hand)
    {
        base.HandAttachedUpdate(hand);
    }

    protected override void HandHoverUpdate(Hand hand)
    {
        base.HandHoverUpdate(hand);
    }

    protected override IEnumerator LateDetach(Hand hand)
    {
        return base.LateDetach(hand);
    }

    protected override void OnAttachedToHand(Hand hand)
    {
        base.OnAttachedToHand(hand);
    }

    protected override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);
    }

    protected override void OnHandFocusAcquired(Hand hand)
    {
        base.OnHandFocusAcquired(hand);
    }

    protected override void OnHandFocusLost(Hand hand)
    {
        base.OnHandFocusLost(hand);
    }

    protected override void OnHandHoverBegin(Hand hand)
    {
        base.OnHandHoverBegin(hand);
    }

    protected override void OnHandHoverEnd(Hand hand)
    {
        base.OnHandHoverEnd(hand);
    }
}
