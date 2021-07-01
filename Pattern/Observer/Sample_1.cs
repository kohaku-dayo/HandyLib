using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        Observer observerA = new Observer("Aさん");
        Observer observerB = new Observer("Bさん");
        Observer observerC = new Observer("Cさん");
        
        Observable observable = new Observable();
        
        IDisposable disposableA = observable.Subscribe(observerA);
        IDisposable disposableB = observable.Subscribe(observerB);
        IDisposable disposableC = observable.Subscribe(observerC);
        Console.WriteLine("Aさん～Cさんが値を購読しました");
        
        Console.WriteLine("値を発行させます");
        observable.SendNotice();
        
        Console.WriteLine("Aさんが購読解除します");
        disposableA.Dispose();
        
        Console.WriteLine("値を発行させます");
        observable.SendNotice();
        
        Console.WriteLine("Bさんが購読解除します");
        disposableA.Dispose();
        
        Console.ReadKey();
    }
}

public interface IObserver<in T>{
    void OnCompleted();
    void OnError(Exception error);
    void OnNext(T value);
}

public interface IObservable<out T>{
    IDisposable Subscribe(IObserver<T> observer);
}

public class Observer : IObserver<int>{
    public string m_name;
    
    public Observer(string name){
        m_name = name;
    }
    public void OnCompleted(){
        Console.WriteLine($"{m_name}通知の受け取りが完了しました");
    }
    
    public void OnError(Exception error){
        Console.WriteLine($"{m_name}がエラーを受信しました : {error.Message}");
    }
    
    public void OnNext(int value){
        Console.WriteLine($"{m_name}が{value}を受け取りました");
    }
}

public class Observable : IObservable<int>{
    private List<IObserver<int>> m_observers = new List<IObserver<int>>();
    
    public IDisposable Subscribe(IObserver<int> observer){
        if(!m_observers.Contains(observer)) m_observers.Add(observer);
        return new Unsubscriber(m_observers, observer);
    }
    
    public void SendNotice(){
        foreach(var observer in m_observers){
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
        }
    }
    
    private class Unsubscriber : IDisposable{
        private List<IObserver<int>> m_observers;
        private IObserver<int> m_observer;
        
        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer){
            m_observers = observers;
            m_observer = observer;
        }
        
        public void Dispose(){
            m_observers.Remove(m_observer);
        }
    }
}
