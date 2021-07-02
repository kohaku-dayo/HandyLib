using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        A testA = A.Instance.a().b().c().d();
    }
}

public class A{
    private A(){}
    public static A Instance{
        get{ return new A(); }
    }
    public A a(){
        Console.WriteLine("a");
        return this;
    }
    public A b(){
        Console.WriteLine("b");
        return this;
    }
    public A c(){
        Console.WriteLine("c");
        return this;
    }
    public A d(){
        Console.WriteLine("d");
        return this;
    }
}
