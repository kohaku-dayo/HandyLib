using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;

/// <summary>
/// PhotonNetworkからのコールバックを受け取るクラス。
/// 複数のインターフェースを継承しています。
/// 部分型定義クラス(partial class)であるため、複数のファイルに自身のクラスを分割しています。
/// Callbacksの参照から分割されたクラス一覧を見てください。
/// </summary>
public partial class Callbacks : MonoBehaviour{

    //自身のクラスをPhotonNetworkからのコールバック対象として登録します。
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    //自身のクラスをPhotonNetworkからのコールバック対象から除外します。
    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}
