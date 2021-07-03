using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        StrategyControl.excuteMethods(new StrategyA());
    }
}

interface IStrategy{
    void Order1();
    void Order2();
    void Order3();
}

class StrategyA : IStrategy{
    public void Order1(){
        Console.WriteLine("StrategyA : Process1");
    }
    public void Order2(){
        Console.WriteLine("StrategyA : Process2");
    }
    public void Order3(){
        Console.WriteLine("StrategyA : Process3");
    }
}
class StrategyB : IStrategy{
    public void Order1(){
        Console.WriteLine("StrategyB : Process1");
    }
    public void Order2(){
        Console.WriteLine("StrategyB : Process2");
    }
    public void Order3(){
        Console.WriteLine("StrategyB : Process3");
    }
}

class StrategyControl{
    public static void excuteMethods(IStrategy strategy){
        strategy.Order1();
        strategy.Order2();
        strategy.Order3();
    }
}
