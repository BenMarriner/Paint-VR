using System;
using UnityEngine;
using Valve.VR;

public static class GameManager
{
    public static GameObject Player { get; private set; }
    public static GameObject ObjectInLeftHand { get; private set; }
    public static GameObject ObjectInRightHand { get; private set; }

    public static void SetPlayer(GameObject player) { Player = player; }

    public static void SetObjectInHand(SteamVR_Input_Sources hand, GameObject objectInHand)
    {
        if (objectInHand == null)
            throw new ArgumentNullException("Please use ClearObjectInHand() instead");
        
        if (!(hand == SteamVR_Input_Sources.LeftHand && hand == SteamVR_Input_Sources.RightHand)) 
            throw new ArgumentException("Invalid hand argument for SetObjectInHand()");
        
        switch (hand)
        {
            case SteamVR_Input_Sources.LeftHand:
                ObjectInLeftHand = objectInHand;
                break;
            case SteamVR_Input_Sources.RightHand:
                ObjectInRightHand = objectInHand;
                break;
            default:
                break;
        }
    }

    public static void ClearObjectInHand(SteamVR_Input_Sources hand)
    {
        switch (hand)
        {
            case SteamVR_Input_Sources.LeftHand:
                ObjectInLeftHand = null;
                break;
            case SteamVR_Input_Sources.RightHand:
                ObjectInRightHand = null;
                break;
            default:
                break;
        }
    }
}
