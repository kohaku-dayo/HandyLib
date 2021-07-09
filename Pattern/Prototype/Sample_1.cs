/*
Attention!
このコードにはバグが複数存在します！
引用はご遠慮ください。
*/

/*
バグ説明：
・二度複製
Dictionaryの値取得の際に一度コピーして渡されるため、
プロトタイプパターン本来の機能である複製とコピー時の生成で二度複製されてしまい、
一度の生成処理で二つのクローンを意図せず生成しています。

・ジェネリック型出力
Tをジェネリックのキーワードとして設定していますが、
値を正確に読み取れずエラーだけが出力されることなくnullとして判定されています。
又、キャストしても無表示は変わりませんでした。
*/


using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        PrototypeKeeper<string> prototype = new PrototypeKeeper<string>();
        prototype.addCloneable("applemaker", "リンゴメーカー");
        prototype.addCloneable("orangemaker", "オレンジメーカー");
        prototype.addCloneable("berrymaker", "ベリーメーカー");
        prototype.getClone("applemaker").createClone().getCloneInfo();
    }
}

public class PrototypeKeeper<T>{
    private Dictionary<string, Cloneable<T>> prototypes = new Dictionary<string, Cloneable<T>>();
    
    public void addCloneable(string key, T value){
        if(prototypes.ContainsKey(key)) return;
        prototypes.Add(key, new Cloneable<T>(key, value));
        Console.WriteLine("クローンが登録されました。");
        Console.WriteLine("登録情報： key = {0} info = {1}", key, value);
    }
    public Cloneable<T> getClone(string key){
        if(!prototypes.ContainsKey(key)) return null;
        Cloneable<T> prototype = prototypes[key];
        return prototype;
    }
}

public class Cloneable<T>{
    private string name;
    private T _data;
    public T data{get;}
    public Cloneable(){
        Console.WriteLine("クローンが生成されました。");
    }
    
    public Cloneable(string name, T _data){
        Console.WriteLine("クローンが生成されました。");
        this.name = name;
        this._data = _data;
    }
    
    public Cloneable<T> createClone(){
        Cloneable<T> cloneable = new Cloneable<T>();
        cloneable.name = this.name;
        cloneable._data = this._data;
        return cloneable;
    }
    
    public void getCloneInfo(){
        Console.WriteLine("クローン情報：name = {0}, data = {1}", this.name, (T)data);
    }
}
