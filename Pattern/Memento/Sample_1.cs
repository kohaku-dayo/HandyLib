using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    static Stack<Memento> mementoList = new Stack<Memento>();
    public Start(){
        Originator originator = new Originator(0, "");
        for(int i = 0; i < 5; i++){
            originator.setField(i, (i + "回目"));
            mementoList.Push(originator.createMemento());
        }
        while(mementoList.Count != 0){
            Memento memento = (Memento)mementoList.Pop();
            originator.setMemento(memento);
            Console.WriteLine(originator);
        }
    }
}

public class Originator{
    int param1;
    string param2;
    
    public Originator(int param1, string param2){
        this.param1 = param1;
        this.param2 = param2;
    }
    
    public void setField(int param1, string param2){
        Console.WriteLine("originatorの値が変更されました");
        this.param1 = param1;
        this.param2 = param2;
    }
    
    public Memento createMemento(){
        Console.WriteLine("mementoが作成されました");
        return new Memento(param1, param2);
    }
    public void setMemento(Memento memento){
        Console.WriteLine("過去のmementoが呼び出されました");
        this.param1 = memento.param1;
        this.param2 = memento.param2;
    }
    public override string ToString(){
        return "param1=>" + param1 + " / param2=>" + param2;
    }
}

public class Memento{
    public int param1{get;}
    public string param2{get;}
    
    public Memento(int param1, string param2){
        this.param1 = param1;
        this.param2 = param2;
    }
}
