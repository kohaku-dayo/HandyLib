Compositパターンはクラスの中にインターフェースのリストを保持することによって、
ディレクトリのようなブランチ構造を構築するための設計パターンです。

フォルダーの役割を果たすクラスにはインターフェースを引数とした自身のクラス内インターフェースリストへの追加を行う
関数を用意しておきます。
ブランチ構造を作成するには○○内に幾つかの○○が保持されているという状況を作り出す必要があるため、
Compositパターンのクラス内にインターフェースのリストを保持するという考えによって、
仮想的なブランチ構造を作成することが可能となります。


フォルダークラスには以下の関数が含まれます。
・フォルダー名を指定するもの public Folder(string name)
・フォルダーがディレクトリのどの位置に配置されているかを出力するもの public void Output(int depth)
・フォルダーのディレクトリ直下にファイルorフォルダーを配置するもの pubic void AddEntry(IEntry entry)

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

ファイルクラスには以下の関数が含まれます。
・ファイル名を指定するもの public File(string name)
・ファイルがディレクトリのどの位置に配置されているかを出力するもの public void Output(int depth)

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

エントリーインターフェースには以下の関数が定義されます。
・ファイルorフォルダーがディレクトリのどの位置に配置されているかを出力するもの public void Output(int depth)
interface IEntry{

    void Output(int depth);
}


Compositパターンに含まれる単語一覧：
・Folder フォルダー。自身の直下にフォルダーorファイルを配置することができます。
・File ファイル。自身の直下には何も配置することができません。
・IEntry エントリーインターフェース。二つの役割がある。
　１、自身がディレクトリのどの位置に配置されているかを出力。これはフォルダーもファイルも出力する必要があるため、共通。つまり、継承したクラスに定義されていることを保証。
  ２、継承することによって、異なる処理の記述されたクラスも同じクラスとして扱うことが可能。これにより、フォルダーのみではなく、ファイルをも同じリストととして保持しておくことが可能。
