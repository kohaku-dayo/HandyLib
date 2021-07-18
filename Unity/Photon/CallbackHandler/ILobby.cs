using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;

public partial class Callbacks : ILobbyCallbacks
{
    public void OnJoinedLobby()
    {
        "".Debug(DebugSystem.Type.ILobbyCallbacks);
    }

    public void OnLeftLobby()
    {
        "".Debug(DebugSystem.Type.ILobbyCallbacks);
    }

    public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
    {
        "".Debug(DebugSystem.Type.ILobbyCallbacks);
    }

    public void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        "".Debug(DebugSystem.Type.ILobbyCallbacks);
    }
}
