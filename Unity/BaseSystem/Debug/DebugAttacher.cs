using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseSystem;

/// <summary>
///このクラスはデバッグの出力カテゴリーをコントロールします。
/// </summary>
public class DebugAttacher : MonoBehaviour
{
    //デバッグの出力カテゴリーをインスペクター上で登録します。
    [SerializeField] List<DebugSystem.Type> debugTypes;

    /// <summary>
    /// インスペクター上で登録された出力カテゴリーをDebugSystemクラスの出力カテゴリーへ移します。
    /// </summary>
    void Awake()
    {
        foreach (var debugtype in debugTypes)
        {
            if (!DebugSystem.debugTypes.Contains(debugtype)) DebugSystem.debugTypes.Add(debugtype);
        }
        "DebugAttacher activated".Debug(DebugSystem.Type.Absolute);
    }
}
