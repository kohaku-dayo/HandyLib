using System;
public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        StateControl sc = StateControl.create(new A());
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
        sc.ChangeState(new B());
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
        sc.transit();
        sc.CurrentState();
    }
}

public class StateControl{
    public static StateControl statecontrol;
    private IState _state;
    public StateControl(){
        _state = new A();
        CurrentState();
    }
    public StateControl(IState state){
        _state = state;
        CurrentState();
    }
    
    public static StateControl create(IState state = null){
        if(state == null){
            statecontrol = new StateControl();
        }else{
            statecontrol = new StateControl(state);
        }
        return statecontrol;
    }
    
    public void CurrentState(){
        _state.showState();
    }
    public void ChangeState(IState state){
        System.Console.WriteLine("強制遷移：" + _state.GetType().Name + " → " + state.GetType().Name);
        _state = state;
    }
    public void transit(){
        _state = _state.transitState();
    }
}

public interface IState{
    void showState();
    IState transitState();
}

public class A : IState{
    public void showState(){
        Console.WriteLine("状態：A");
    }
    
    public IState transitState(){
        Console.WriteLine("遷移：A → B");
        return new B();
    }
}
public class B : IState{
    public void showState(){
        Console.WriteLine("状態：B");
    }
    public IState transitState(){
        Console.WriteLine("遷移：B → C");
        return new C();
    }
}
public class C : IState{
    public void showState(){
        Console.WriteLine("状態：C");
    }
    public IState transitState(){
        Console.WriteLine("遷移：C → D");
        return new D();
    }
}
public class D : IState{
    public void showState(){
        Console.WriteLine("状態：D");
    }
    public IState transitState(){
        Console.WriteLine("遷移：D → E");
        return new E();
    }
}
public class E : IState{
    public void showState(){
        Console.WriteLine("状態：E");
    }
    public IState transitState(){
        Console.WriteLine("遷移：E → A");
        return new A();
    }
}
