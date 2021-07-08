/*
このサンプルコードはテックスコアさんの解説コードをC#に直して記述しています。
参照元↓
https://www.techscore.com/tech/DesignPattern/Decorator.html/
*/


using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        Icecream ice = new CashewNutsIcecream(new VanillaIcecream());
        Console.WriteLine(ice.getName());
        ice = new SliceAlmondToppingIcecream(ice);
        Console.WriteLine(ice.getName());
        Console.WriteLine(ice.Taste());
        ice = new SliceAlmondToppingIcecream(new GreenTeaIcecream());
        Console.WriteLine(ice.getName());
    }
}

public interface Icecream{
    string getName();
    string Taste();
}

public class VanillaIcecream : Icecream{
    public string getName(){
        return "バニラアイスクリーム";
    }
    public string Taste(){
        return "バニラ味";
    }
}
public class GreenTeaIcecream : Icecream{
    public string getName(){
        return "抹茶アイスクリーム";
    }
    public string Taste(){
        return "抹茶味";
    }
}

public class CashewNutsIcecream : Icecream{
    private Icecream ice = null;
    
    public CashewNutsIcecream(Icecream ice){
        this.ice = ice;
    }
    public string getName(){
        string name = "カシューナッツ";
        name += ice.getName();
        return name;
    }
    public string Taste(){
        return ice.Taste();
    }
}

public class SliceAlmondToppingIcecream : Icecream{
    private Icecream ice = null;
    
    public SliceAlmondToppingIcecream(Icecream ice){
        this.ice = ice;
    }
    public string getName(){
        string name = "アーモンドスライス";
        name += ice.getName();
        return name;
    }
    public string Taste(){
        return ice.Taste();
    }
}
