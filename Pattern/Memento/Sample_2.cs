using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    Originator originator = new Originator();
    
    public Start(){
        for(int i = 0; i < 5; i++){
            originator.param1 = i;
            originator.param2 = i*2 + "回目";
            originator.Save();
        }
        while(originator.dataListCount != 0){
            originator.Reverse();
        }
        
        originator.param1 = 5;
        originator.Save();
        originator.param2 = "ff";
        originator.Save();
        originator.Reverse();
        originator.param1 = 7;
        originator.Save();
        
        while(originator.dataListCount != 0){
            originator.Reverse();
        }
    }
}

public class Originator{
    Stack<Memento> mementoList = new Stack<Memento>();
    
    public int param1 = 0;
    public string param2 = "";
    
    public int dataListCount{
        get => mementoList.Count;
    }
    
    public void Save(){
        mementoList.Push(new Memento(param1, param2));
        Console.WriteLine("Save data : [param1=>{0}] [param2=>{1}]", param1, param2);
    }
    public void Reverse(){
        if(mementoList.Count == 0){
            Console.WriteLine("No more saving data");
            return;
        }
        Memento memento = (Memento)mementoList.Pop();
        this.param1 = memento.param1;
        this.param2 = memento.param2;
        Console.WriteLine("Reverse data : [param1=>{0}] [param2=>{1}]", param1, param2);
    }
    public override string ToString(){
        return "[param1=>" + param1 + "] [param2=>" + param2 + "]";
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
