using System;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        FormatB_Warranty fbw = new FormatB_Warranty(new A_Warranty());
        fbw.warrantyInfo();
        Console.Write("\n");
        fbw.changeWarranty(new B_Warranty());
        fbw.MultiInfo(5);
        Console.Write("\n");
        fbw.changeWarranty(new C_Warranty());
        fbw.DecolateInfo("*");
    }
}

public class FormatA_Warranty : Warranty{
    public FormatA_Warranty(IWarrantyBridge iWarranty) : base(iWarranty){}
    
    public void MultiInfo(int num){
        for(int i = 0; i < num; i++) warrantyInfo();
    }
}

public class FormatB_Warranty : FormatA_Warranty{
    public FormatB_Warranty(IWarrantyBridge iWarranty) : base(iWarranty){}
    public void DecolateInfo(string deco){
        for(int i = 0; i < 10; i++) Console.Write(deco);
        Console.Write("\n");
        warrantyInfo();
        for(int i = 0; i < 10; i++) Console.Write(deco);
        Console.Write("\n");
    }
}

public class Warranty{
    private IWarrantyBridge IWarranty;
    public Warranty(IWarrantyBridge iWarranty){
        this.IWarranty = iWarranty;
    }
    public void changeWarranty(IWarrantyBridge iWarranty){
        this.IWarranty = iWarranty;
        Console.WriteLine("保証が変更されました。");
    }
    
    public void warrantyInfo(){
        IWarranty.warrantyInfo();
    }
}

public interface IWarrantyBridge{
    void warrantyInfo();
}

public class A_Warranty : IWarrantyBridge{
    public void warrantyInfo(){
        Console.WriteLine("Aであることを保証します。");
    }
}
public class B_Warranty : IWarrantyBridge{
    public void warrantyInfo(){
        Console.WriteLine("Bであることを保証します。");
    }
    
}
public class C_Warranty : IWarrantyBridge{
    public void warrantyInfo(){
        Console.WriteLine("Cであることを保証します。");
    }
    
}
