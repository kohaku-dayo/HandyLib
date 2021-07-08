using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        ConcreteFactory concrete = new ConcreteFactory();
        IAbstractFactory factory = concrete.createFactory("Pattern1");
        //パターン1を代入。
        concrete.add_A(factory.getSetA());
        concrete.add_B(factory.getSetB());
        concrete.add_C(factory.getSetC());
        concrete.execute();
        //パターン2＋αを代入
        factory = concrete.createFactory("Pattern2");
        concrete.add_A(factory.getSetA(), new AComponent2());
        concrete.add_B(factory.getSetB());
        concrete.add_C(factory.getSetC(), new CComponent1(), new CComponent3(), new CComponent2());
        concrete.execute();
    }
}

public interface SetA{
    string getName();
}

public class AComponent1 : SetA{
    public string getName(){
        return "AComponent1";
    }
}
public class AComponent2 : SetA{
    public string getName(){
        return "AComponent2";
    }
}
public interface SetB{
    string getName();
}

public class BComponent1 : SetB{
    public string getName(){
        return "BComponent1";
    }
}
public class BComponent2 : SetB{
    public string getName(){
        return "BComponent2";
    }
}
public class BComponent3 : SetB{
    public string getName(){
        return "BComponent3";
    }
}
public interface SetC{
    string getName();
}

public class CComponent1 : SetC{
    public string getName(){
        return "CComponent1";
    }
}
public class CComponent2 : SetC{
    public string getName(){
        return "CComponent2";
    }
}
public class CComponent3 : SetC{
    public string getName(){
        return "CComponent3";
    }
}
public class CComponent4 : SetC{
    public string getName(){
        return "CComponent4";
    }
}
public class ConcreteFactory{
    private List<SetA> a;
    private List<SetB> b;
    private List<SetC> c;
    
    public ConcreteFactory(){
        a = new List<SetA>();
        b = new List<SetB>();
        c = new List<SetC>();
    }
    
    public void add_A(params SetA[] a){
        for(int i = 0; i < a.Length; i++) this.a.Add(a[i]);
    }
    public void add_B(params SetB[] b){
        for(int i = 0; i < b.Length; i++) this.b.Add(b[i]);
    }
    public void add_C(params SetC[] c){
        for(int i = 0; i < c.Length; i++) this.c.Add(c[i]);
    }
    
    public IAbstractFactory createFactory(string str){
        switch(str){
            case "Pattern1" : return new Pattern1();
            case "Pattern2" : return new Pattern2();
            case "Pattern3" : return new Pattern3();
            default: return null;
        }
    }
    
    public void execute(){
        Console.WriteLine("//SetA//");
        foreach(var _a in this.a) Console.WriteLine(_a);
        Console.WriteLine("//SetB//");
        foreach(var _b in this.b) Console.WriteLine(_b);
        Console.WriteLine("//SetC//");
        foreach(var _c in this.c) Console.WriteLine(_c);
    }
}

public class Pattern1 : IAbstractFactory{
    public SetA getSetA(){
        return new AComponent2();
    }
    public SetB getSetB(){
        return new BComponent3();
    }
    public SetC getSetC(){
        return new CComponent4();
    }
}
public class Pattern2 : IAbstractFactory{
    public SetA getSetA(){
        return new AComponent2();
    }
    public SetB getSetB(){
        return new BComponent3();
    }
    public SetC getSetC(){
        return new CComponent1();
    }
}
public class Pattern3 : IAbstractFactory{
    public SetA getSetA(){
        return new AComponent1();
    }
    public SetB getSetB(){
        return new BComponent2();
    }
    public SetC getSetC(){
        return new CComponent2();
    }
}
public interface IAbstractFactory{
    SetA getSetA();
    SetB getSetB();
    SetC getSetC();
}
