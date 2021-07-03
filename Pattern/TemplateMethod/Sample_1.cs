using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        new A().Run();
        new B().Run();
        new C().Run();
    }
}

public abstract class AbstractTemplateMethod{
    public abstract void task1();
    public abstract void task2();
    public abstract void task3();
    
    public void Run(){
        task1();
        task2();
        task3();
    }
}

public class A : AbstractTemplateMethod{
    public override void task1(){
        Console.WriteLine("A : task1");
    }
    public override void task2(){
        Console.WriteLine("A : task2");
    }
    public override void task3(){
        Console.WriteLine("A : task3");
    }
}

public class B : AbstractTemplateMethod{
    public override void task1(){
        Console.WriteLine("B : task1");
    }
    public override void task2(){
        Console.WriteLine("B : task2");
    }
    public override void task3(){
        Console.WriteLine("B : task3");
    }
}

public class C : AbstractTemplateMethod{
    public override void task1(){
        Console.WriteLine("C : task1");
    }
    public override void task2(){
        Console.WriteLine("C : task2");
    }
    public override void task3(){
        Console.WriteLine("C : task3");
    }
}
