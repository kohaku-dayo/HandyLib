using System;

public class Hello{
    public static void Main(){
        new Start();
    }
}

public class Start{
    public Start(){
        BuilderSample sample1 = BuilderSample.Builder.Instance.Optinal1(100).Optinal3(35).Optinal2(27).Build(100, 204);
        BuilderSample sample2 = BuilderSample.Builder.Instance.Optinal3(33).Build(450, 56);
        BuilderSample sample3 = BuilderSample.Builder.Instance.Build(10, 10);
        
        Console.WriteLine(sample1);
        Console.WriteLine(sample2);
        Console.WriteLine(sample3);
    }
}

public class BuilderSample{
    int necessary1;
    int necessary2;
    int optional1;
    int optional2;
    int optional3;
    
    public sealed class Builder{
        public int necessary1{get; private set;}
        public int necessary2{get; private set;}
        public int optional1{get; private set;}
        public int optional2{get; private set;}
        public int optional3{get; private set;}
        
        private Builder(){}
        
        public Builder Optinal1(int val){
            this.optional1 = val;
            return this;
        }
        public Builder Optinal2(int val){
            this.optional2 = val;
            return this;
        }
        public Builder Optinal3(int val){
            this.optional3 = val;
            return this;
        }
        public BuilderSample Build(int necessary1, int necessary2){
            this.necessary1 = necessary1;
            this.necessary2 = necessary2;
            return new BuilderSample(this);
        }
        public static Builder Instance{
            get{return new Builder();}
        }
    }
    private BuilderSample(Builder builder){
        this.necessary1 = builder.necessary1;
        this.necessary2 = builder.necessary2;
        this.optional1 = builder.optional1;
        this.optional2 = builder.optional2;
        this.optional3 = builder.optional3;
    }
    
    public override string ToString(){
        string result = "";
        result += this.necessary1 + ":";
        result += this.necessary2 + ":";
        result += this.optional1 + ":";
        result += this.optional2 + ":";
        result += this.optional3;
        
        return result;
    }
}


/*
コード参照元↓
https://zecl.hatenablog.com/entry/20091117/p1
*/
