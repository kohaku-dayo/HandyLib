using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        Observable observable = new Observable();
        observable.Subscribe(new Observer("Aさん"));
        observable.Subscribe(new Observer("Bさん"));
        observable.Subscribe(helloworld);
        observable.SendNotice();
    }
    public void helloworld(){
        Console.WriteLine("Hello World");
    }
}

public interface IObserver<in T>{
    void OnCalled(T value);
    void OnCalled();
}

public interface IObservable<out T>{
    void Subscribe(IObserver<T> observer);
    void Subscribe(Action action);
}

public class Observer : IObserver<int>{
    string name;
    
    public Observer(string name){
        this.name = name;
    }
    
    public void OnCalled(){
        Console.WriteLine("Hello");
    }
    public void OnCalled(int value){
        Console.WriteLine($"{name}が{value}を受け取りました");
    }
}

public class Observable : IObservable<int>{
    private List<IObserver<int>> observers = new List<IObserver<int>>();
    private List<Action> actions = new List<Action>();

    public void Subscribe(IObserver<int> observer){
        if(!observers.Contains(observer)) observers.Add(observer);
    }
    public void Subscribe(Action action){
        if(!actions.Contains(action)) actions.Add(action);
    }
    public void SendNotice(){
        foreach(var obs in observers){
            obs.OnCalled(1);
            obs.OnCalled();
        }
        foreach(var acts in actions){
            acts();
        }
    }
}
