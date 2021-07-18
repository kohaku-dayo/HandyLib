using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using BaseSystem;
using System;
using UnityEngine.UI;

public class PUNConnect : MonoBehaviour
{
    [SerializeField] Text text;


    RoomCreatorBuild createdRoom;


    private void Start()
    {
        Connector();
        PrepareRoom();
    }

    /// <summary>
    /// マスターサーバー(Photonサーバー)へ接続
    /// </summary>
    public void Connector()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    /// <summary>
    /// マスターサーバー(Photonサーバー)から切断
    /// </summary>
    public void Disconnector()
    {
        PhotonNetwork.Disconnect();
    }
    /// <summary>
    /// ルーム生成の準備をします。
    /// ルーム生成自体は行いません。
    /// ルーム生成時はCreateRoom関数を実行してください。
    /// </summary>
    public void PrepareRoom()
    {
        if(createdRoom == null) createdRoom = new RoomCreatorBuild();
    }
    /// <summary>
    /// ルームを生成します。
    /// PrepareRoom関数を実行してから実行してください。
    /// </summary>
    public void CreateRoom()
    {
        if (createdRoom != null) createdRoom.RoomCreate();
        else "ルームを生成する準備が整っていません".Debug(DebugSystem.Type.PhotonNetwork);
    }
    /// <summary>
    /// ルームに参加する
    /// </summary>
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    /// <summary>
    /// 既に存在するランダムなルームに参加する
    /// </summary>
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    /// <summary>
    /// ルームMAXプレイヤー数。
    /// </summary>
    public void EditRoomMaxPlayer(int num = 0)
    {
        updateText(text, ("ルーム最大人数:" + createdRoom.maxPlayerNum.ToString()));
        if (num != 0)createdRoom.EditRoomMaxPlayer(num);
    }
    /// <summary>
    /// ルームMAXプレイヤー数増加
    /// </summary>
    public void AddRoomMaxPlayer()
    {
        updateText(text, ("ルーム最大人数:" + createdRoom.maxPlayerNum.ToString()));
        createdRoom.AddRoomMaxPlayer();
    }
    /// <summary>
    /// ルームMAXプレイヤー数減少
    /// </summary>
    public void MinusRoomMaxPlayer()
    {
        updateText(text, ("ルーム最大人数:" + createdRoom.maxPlayerNum.ToString()));
        createdRoom.MinusRoomMaxPlayer();
    }

    /// <summary>
    /// ルーム名を編集。
    /// </summary>
    public void EditRoomDisplayName(string displayName = null)
    {
        if(displayName != null) createdRoom.EditRoomDisplayName(displayName);
    }
    /// <summary>
    /// ルームを生成。
    /// </summary>
    public void EditRoomMessage(string message = null)
    {
        if(message != null)createdRoom.EditRoomMessage(message);
    }
    /// <summary>
    /// ルームから退出
    /// </summary>
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    /// <summary>
    /// ロビーへ参加
    /// OnRoomListUpdateにてルームリストを得られます。
    /// </summary>
    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }
    /// <summary>
    /// ロビーから退出
    /// </summary>
    public void LeaveLobby()
    {
        PhotonNetwork.LeaveLobby();
    }

    void updateText(Text targetText, object text)
    {
        targetText.text = text.ToString();
    }

    /// <summary>
    /// ルーム情報を入力しない場合はテンプレートで登録されます。
    /// </summary>
    class RoomCreatorBuild{
        private RoomCreatorBuild instance;

        RoomOptions roomOptions;
        ExitGames.Client.Photon.Hashtable initialProps;
        string[] propsForLobby;
        private int maxplayernum;
        public int maxPlayerNum
        {
            get
            {
                return maxplayernum;
            }
            set
            {
                if(2 <= value && value <= 100) maxplayernum = value;
                else
                {
                    "範囲外のプレイヤー数が代入されました。".Debug(DebugSystem.Type.None);
                    return;
                }
            }
        }

        public RoomCreatorBuild()
        {
            instance = this;
            initialProps = new ExitGames.Client.Photon.Hashtable();
            initialProps["DisplayName"] = $"{PhotonNetwork.NickName}の部屋";
            initialProps["Message"] = "誰でも参加OK!";

            propsForLobby = new[] { "DisplayName", "Message" };

            roomOptions = new RoomOptions()
            {
                MaxPlayers = 2,
                CustomRoomProperties = initialProps,
                CustomRoomPropertiesForLobby = propsForLobby
            };
            maxPlayerNum = roomOptions.MaxPlayers;
        }

        /// <summary>
        /// ルームMAXプレイヤー数。
        /// </summary>
        internal RoomCreatorBuild EditRoomMaxPlayer(int playerNum)
        {
            maxPlayerNum = Mathf.Clamp(playerNum, 2, 20);
            roomOptions.MaxPlayers = (byte)maxPlayerNum;
            return this;
        }

        internal RoomCreatorBuild AddRoomMaxPlayer()
        {
            maxPlayerNum++;
            roomOptions.MaxPlayers = (byte)maxPlayerNum;
            return this;
        }
        internal RoomCreatorBuild MinusRoomMaxPlayer()
        {
            maxPlayerNum--;
            roomOptions.MaxPlayers = (byte)maxPlayerNum;
            return this;
        }
        /// <summary>
        /// ルーム名を編集。
        /// </summary>
        internal RoomCreatorBuild EditRoomDisplayName(string displayname)
        {
            initialProps["DisplayName"] = displayname;
            roomOptions.CustomRoomProperties = initialProps;
            return this;
        }
        /// <summary>
        /// ルームメッセージを編集。
        /// </summary>
        internal RoomCreatorBuild EditRoomMessage(string message)
        {
            initialProps["Message"] = message;
            roomOptions.CustomRoomProperties = initialProps;
            return this;
        }
        /// <summary>
        /// ルームを生成。
        /// </summary>
        internal void RoomCreate(string roomname = null)
        {
            PhotonNetwork.CreateRoom(roomname, roomOptions);
        }
    }
}
