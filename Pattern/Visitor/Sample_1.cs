using System;
using System.Collections.Generic;

public class Hello{public static void Main(){new Start();}}

public class Start{
    public Start(){
        TeacherAcceptor student = new TanakaHome();
        student.accept(new RookieTeacher());
    }
}

public abstract class Teacher{
    public abstract void visit(Home studentHome);
    public abstract void visit(TanakaHome studentHome);
    public abstract void visit(SuzukiHome studentHome);
}

public class RookieTeacher : Teacher{
    public override void visit(Home studentHome){
        Console.WriteLine("こんにちは");
    }
    public override void visit(TanakaHome studentHome){
        studentHome.praisedChild();
    }
    public override void visit(SuzukiHome studentHome){
        studentHome.reprovedChild();
    }
}

public abstract class Home{
    public abstract void praisedChild();
    public abstract void reprovedChild();
}

public interface TeacherAcceptor{
    void accept(Teacher teacher);
}

public class SuzukiHome : Home, TeacherAcceptor{
    public override void praisedChild(){
        Console.WriteLine("あら、先生ったらご冗談を");
    }
    public override void reprovedChild(){
        Console.WriteLine("うちの子に限ってそんなことは・・・。");
    }
    public void accept(Teacher teacher){
        teacher.visit(this);
    }
}
public class TanakaHome : Home, TeacherAcceptor{
    public override void praisedChild(){
        Console.WriteLine("あら、先生ったらご冗談を");
    }
    public override void reprovedChild(){
        Console.WriteLine("うちの子に限ってそんなことは・・・。");
    }
    public void accept(Teacher teacher){
        teacher.visit(this);
    }
}

/*
サンプルコード参照元↓
https://www.techscore.com/tech/DesignPattern/Visitor.html/
*/
