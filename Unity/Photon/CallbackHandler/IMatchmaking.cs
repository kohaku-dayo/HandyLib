using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;
using System.Reflection;

public partial class Callbacks : IMatchmakingCallbacks
{
    public void OnCreatedRoom()
    {
        "".Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }

    public void OnCreateRoomFailed(short returnCode, string message)
    {
        message.Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }

    public void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        "".Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }

    public void OnJoinedRoom()
    {
        "".Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }

    public void OnJoinRandomFailed(short returnCode, string message)
    {
        message.Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }

    public void OnJoinRoomFailed(short returnCode, string message)
    {
        message.Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }

    public void OnLeftRoom()
    {
        "".Debug(DebugSystem.Type.IMatchmakingCallbacks);
    }
}
