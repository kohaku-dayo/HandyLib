using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        IAdapter A = new AAdapter();
        IAdapter B = new BAdapter();
        IAdapter C = new CAdapter();
        A.main();
        B.main();
        C.main();
    }
}

interface IAdapter{
    void main();
}

class TaskA{
    public void task1(){
        Console.WriteLine("TaskA : task1");
    }
}
class TaskB{
    public void task1(){
        Console.WriteLine("TaskB : task1");
    }
    public void task2(){
        Console.WriteLine("TaskB : task2");
    }
}
class TaskC{
    public void task1(){
        Console.WriteLine("TaskC : task1");
    }
    public void task2(){
        Console.WriteLine("TaskC : task2");
    }
    public void task3(){
        Console.WriteLine("TaskC : task3");
    }
}

class AAdapter : IAdapter{
    public void main(){
        TaskA a_task = new TaskA();
        a_task.task1();
    }
}
class BAdapter : IAdapter{
    public void main(){
        TaskB b_task = new TaskB();
        b_task.task1();
        b_task.task2();
    }
}
class CAdapter : IAdapter{
    public void main(){
        TaskC c_task = new TaskC();
        c_task.task1();
        c_task.task2();
        c_task.task3();
    }
}
