using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;

public partial class Callbacks : IInRoomCallbacks
{
    public void OnMasterClientSwitched(Player newMasterClient)
    {
        "".Debug(DebugSystem.Type.IInRoomCallbacks);
    }

    public void OnPlayerEnteredRoom(Player newPlayer)
    {
        "".Debug(DebugSystem.Type.IInRoomCallbacks);
    }

    public void OnPlayerLeftRoom(Player otherPlayer)
    {
        "".Debug(DebugSystem.Type.IInRoomCallbacks);
    }

    public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        "".Debug(DebugSystem.Type.IInRoomCallbacks);
    }

    public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        "".Debug(DebugSystem.Type.IInRoomCallbacks);
    }
}
