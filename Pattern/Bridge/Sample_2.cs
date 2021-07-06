using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        InfoBridge bridge = new InfoBridge(new A_implement());
        bridge.changeImplement(new B_implement());
        bridge.PreviewImplement();
        bridge.ImplementInfo();
    }
}

public interface Implement{
    string classname{get; set;}
    void print();
}

//管理クラス
public class Manage{
    protected Implement implements;
    public Manage(Implement implements){
        this.implements = implements;
        Console.WriteLine("管理クラス：初期実装クラスが設定されました。");
    }
}

public class ChangeBridge : Manage{
    public ChangeBridge(Implement implements) : base(implements){}
    public void changeImplement(Implement implements){
        base.implements = implements;
        Console.WriteLine("機能クラス：実装クラスが変更されました。");
    }
}

public class PreviewBridge : ChangeBridge{
    public PreviewBridge(Implement implements) : base(implements){}
    public void PreviewImplement(){
        Console.WriteLine("機能クラス：現在の実装クラスは" + base.implements + "です。");
    }
}

public class InfoBridge : PreviewBridge{
    public InfoBridge(Implement implements) : base(implements){}
    public void ImplementInfo(){
        Console.WriteLine("--実装クラス一覧--");
        Console.WriteLine("・A_implement");
        Console.WriteLine("・B_implement");
        Console.WriteLine("・C_implement");
    }
}


//以下実装クラス
public class A_implement : Implement{
    public string classname{get; set;}
    public A_implement(){
        classname = "Aクラス";
    }
    public void print(){
        Console.WriteLine("実装クラス：A_implementクラス実装中");
    }
}
public class B_implement : Implement{
    public string classname{get; set;}
    public B_implement(){
        classname = "Bクラス";
    }
    public void print(){
        Console.WriteLine("実装クラス：B_implementクラス実装中");
    }
}
public class C_implement : Implement{
    public string classname{get; set;}
    public C_implement(){
        classname = "Cクラス";
    }
    public void print(){
        Console.WriteLine("実装クラス：C_implementクラス実装中");
    }
}
