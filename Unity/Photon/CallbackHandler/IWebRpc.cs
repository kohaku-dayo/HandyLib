using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;
using ExitGames.Client.Photon;

public partial class Callbacks : IWebRpcCallback
{
    public void OnWebRpcResponse(OperationResponse response)
    {
        "".Debug(DebugSystem.Type.IWebRpcCallback);
    }
}
