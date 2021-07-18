using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;

public partial class Callbacks : IConnectionCallbacks
{
    public void OnConnected()
    {
        "".Debug(DebugSystem.Type.IConnectionCallbacks);
    }

    public void OnConnectedToMaster()
    {
        "".Debug(DebugSystem.Type.IConnectionCallbacks);
    }

    public void OnCustomAuthenticationFailed(string debugMessage)
    {
        debugMessage.Debug(DebugSystem.Type.IConnectionCallbacks);
    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        "".Debug(DebugSystem.Type.IConnectionCallbacks);
    }

    public void OnDisconnected(DisconnectCause cause)
    {
        cause.ToString().Debug(DebugSystem.Type.IConnectionCallbacks);
    }

    public void OnRegionListReceived(RegionHandler regionHandler)
    {
        "".Debug(DebugSystem.Type.IConnectionCallbacks);
    }
}
