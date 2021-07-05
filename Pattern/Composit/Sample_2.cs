using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        Folder root = new Folder("root");
        Folder user = new Folder("user");
        Folder tmp = new Folder("tmp");
        Folder documents = new Folder("documents");
        Folder game = new Folder("げぇむ");
        
        File gomi = new File("ごみ");
        File ika = new File("ika");
        File tako = new File("tako");
        File salmon = new File("salmon");
        
        root.AddEntry(user);
        root.AddEntry(tmp);
        user.AddEntry(documents);
        user.AddEntry(game);
        
        tmp.AddEntry(gomi);
        game.AddEntry(ika);
        game.AddEntry(tako);
        game.AddEntry(salmon);
        
        root.Output(0);
    }
}

interface IEntry{
    void Output(int depth);
}

class Folder : IEntry{
    string name;
    private List<IEntry> entries = new List<IEntry>();
    
    public Folder(string name){
        this.name = name;
    }
    
    public void Output(int depth){
        for(int i = 0; i < depth; i++) Console.Write("  ");
        Console.WriteLine("Folder:" + name);
        foreach(IEntry entry in entries) entry.Output(depth + 1);
    }
    public void AddEntry(IEntry entry){
        entries.Add(entry);
    }
}

class File : IEntry{
    string name;
    
    public File(string name){
        this.name = name;
    }
    
    public void Output(int depth){
        for(int i = 0; i < depth; i++) Console.Write("  ");
        Console.WriteLine("File:" + name);
    }
}

/*
コード参照元↓
https://qiita.com/Nanakusajp/items/32ed648eaadaa9910159
*/
