using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseSystem;

/// <summary>
/// このクラスをコンポーネントとしたオブジェクトは必ずDontDestroyOnLoadに移されます。
/// 親オブジェクトが存在する場合でも移されます。
/// 子オブジェクトが存在する場合は子オブジェクトも一緒にDontDestroyOnLoadに移されます。
/// </summary>
public class EnableDontDestroyOnLoad : MonoBehaviour
{

    private void OnDestroy()
    {
        Destroy(this);
    }
    /// <summary>
    /// 親子関係から自身を外すことによりDontDestroyOnLoadから除外されることを阻止します。
    /// 最後にDontDestroyOnLoadに自身を登録します。
    /// </summary>
    void Awake()
    {
        ChildMover();
        transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// 子オブジェクトが存在した場合、
    /// 子オブジェクトの親を自身の親オブジェクトにします。
    /// </summary>
    void ChildMover()
    {
        if (HasChild(this.gameObject))
        {
            foreach(Transform n in this.gameObject.transform)
            {
                n.gameObject.transform.parent = this.transform.parent;
            }
        }
    }
    /// <summary>
    ///子オブジェクトが存在するかどうかを返す
    /// </summary>
    bool HasChild(GameObject gameObject)
    {
        return 0 < gameObject.transform.childCount;
    }
}
