Builderパターンの解説

Builderパターンは再帰化を任意な回数実行することが可能なデザインパターンと言い表すのが最適だと思います。

このパターンはまず、自分自身を戻り値にすることで再度クラス内の関数を呼ぶことができます。

例：
・実装
public class A{
  private a = 10, b = 5;
  public A add(){
    a += b;
    return this;
  }
  public A minus(){
    a -= b;
    return this;
  }
}

・呼び出し
public static void main(){
  new A.add().minus().add().minus();
}

Builderパターンは戻り値を自分自身にすることが関数連結の必須条件なので、
Builderパターンを実装しているクラスでは情報を得ることが不可能である。
よって、直接内部処理・計算を行うのは避けるべきであり、
通常のクラスの中にBuilderパターンクラスを内蔵し実装する、
又はデリゲートによる外部イベント実行などの方法を用いて値を取得したり処理を行うのが好ましい。

上記の制限や使用難易度の高さから基本的にはコンストラクタを用いたクラス内変数の初期化に使用する引数を短縮化させることを目的に使われることが多い。

Builderパターン単一で実装する最も簡単な設計はこちらを参照してください。
HandyLib/Pattern/Builder/Sample_2.cs
Builderパターンを内蔵したクラス設計はこちらを参照してください。
HandyLib/Pattern/Builder/Sample_1.cs
