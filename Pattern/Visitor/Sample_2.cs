using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        IStandby standby = new A_Standby();
        standby.accept(new A_Visitor());
        standby.accept(new B_Visitor());
        standby = new B_Standby();
        standby.accept(new A_Visitor());
        standby.accept(new B_Visitor());
        standby = new C_Standby();
        standby.accept(new A_Visitor());
        standby.accept(new B_Visitor());
    }
}

public class A_Visitor : IVisitor{
    public void visit(IStandby standby){
        mention();
        standby.Task1();
    }
    public void visit(A_Standby standby){
        mention();
        standby.Task2();
    }
    public void visit(B_Standby standby){
        mention();
        standby.Task3();
    }
    void mention(){
        Console.WriteLine("訪問クラス：A_Visitor");
    }
}
public class B_Visitor : IVisitor{
    
    public void visit(IStandby standby){
        mention();
        standby.Task1();
    }
    public void visit(A_Standby standby){
        mention();
        standby.Task2();
    }
    public void visit(B_Standby standby){
        mention();
        standby.Task3();
    }
    void mention(){
        Console.WriteLine("訪問クラス：B_Visitor");
    }
}

public class A_Standby : IStandby{
    public void Task1(){
        mention();
        Console.WriteLine("Task1が実行されました。");
    }
    public void Task2(){
        mention();
        Console.WriteLine("Task2が実行されました。");
    }
    public void Task3(){
        mention();
        Console.WriteLine("Task3が実行されました。");
    }
    public void accept(IVisitor visitor){
        visitor.visit(this);
    }
    void mention(){
        Console.WriteLine("待機クラス：A_Standby");
    }
}
public class B_Standby : IStandby{
    public void Task1(){
        mention();
        Console.WriteLine("Task1が実行されました。");
    }
    public void Task2(){
        mention();
        Console.WriteLine("Task2が実行されました。");
    }
    public void Task3(){
        mention();
        Console.WriteLine("Task3が実行されました。");
    }
    public void accept(IVisitor visitor){
        visitor.visit(this);
    }
    void mention(){
        Console.WriteLine("待機クラス：B_Standby");
    }
}

public class C_Standby : IStandby{
    public void Task1(){
        mention();
        Console.WriteLine("Task1が実行されました。");
    }
    public void Task2(){
        mention();
        Console.WriteLine("Task2が実行されました。");
    }
    public void Task3(){
        mention();
        Console.WriteLine("Task3が実行されました。");
    }
    public void accept(IVisitor visitor){
        visitor.visit(this);
    }
    void mention(){
        Console.WriteLine("待機クラス：C_Standby");
    }
}
public interface IVisitor{
    void visit(IStandby standby);
    void visit(A_Standby standby);
    void visit(B_Standby standby);
}

public interface IStandby{
    void accept(IVisitor visitor);
    
    void Task1();
    void Task2();
    void Task3();
}
