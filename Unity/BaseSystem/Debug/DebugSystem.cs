using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BaseSystem
{
    //デバッグの出力カテゴリーをコントロールし、
    //出力フォーマットをコントロールできるクラス。
    public static class DebugSystem
    {
        //出力カテゴリー一覧
        public enum Type
        {
            None,
            Test,
            
            PUN,
            PUNChat,
            PUNRealtime,
            PhotonNetwork,
            
            IConnectionCallbacks,
            IInRoomCallbacks,
            ILobbyCallbacks,
            IMatchmakingCallbacks,
            IOnEventCallback,
            IWebRpcCallback,
            IErrorInfoCallback,

            BaseSystem,

            Absolute,
        }

        //出力カテゴリー一覧
        public static List<Type> debugTypes = new List<Type>();

        /// <summary>
        ///デバッグ拡張メソッドオーバーロード
        ///引数で受け取った文字列を優先して出力する
        /// </summary>
        public static string Debug(this string obj, object message, Type type = Type.None)
        {
            bool show = false;
            for(int i = 0; i < debugTypes.Count && show == false; i++) if(debugTypes[i] == type) show = true;
            if (type == Type.Absolute) show = true;
            if (show) UnityEngine.Debug.Log("[" + type + "] " + new System.Diagnostics.StackFrame(1).GetMethod().Name + " : " + message);
            return obj;
        }
        /// <summary>
        ///デバッグ拡張メソッドオーバーロード
        ///結合元(.より左に記述された文字列)を優先して出力する
        /// </summary>
        public static string Debug(this string obj, Type type = Type.None)
        {
            bool show = false;
            for (int i = 0; i < debugTypes.Count && show == false; i++) if (debugTypes[i] == type) show = true;
            if (type == Type.Absolute) show = true;
            if (show)
            {
                if(obj == "")
                UnityEngine.Debug.Log("[" + type + "] " + new System.Diagnostics.StackFrame(1).GetMethod().Name);
                else
                UnityEngine.Debug.Log("[" + type + "] " + new System.Diagnostics.StackFrame(1).GetMethod().Name + " : " + obj);
            }
            return obj;
        }
    }
}
