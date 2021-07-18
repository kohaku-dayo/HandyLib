using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;

public partial class Callbacks : IErrorInfoCallback
{
    public void OnErrorInfo(ErrorInfo errorInfo)
    {
        "".Debug(DebugSystem.Type.IErrorInfoCallback);
    }
}
