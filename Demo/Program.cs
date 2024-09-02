using Demo.顺序结构模式;
using System.Transactions;
// See https://aka.ms/new-console-template for more information

//string string1 = "abcd";
//string string2 = "abcd";
//var result = string.ReferenceEquals(string1, string2);
//string2 = "132";
//var result1 = string.ReferenceEquals(string1, string2);
//string2 = "abcd";
//var result2 = string.ReferenceEquals(string1, string2);
//string1 = string2 = "1234";
//var result4 = string.ReferenceEquals(string1, string2);
//string string1 = "a";
//string string2 = "";
//var result1 = string.ReferenceEquals(string1, string2);
//string2 = "a";
//var result2 = string.ReferenceEquals(string1, string2);
//string1 += "b";
//string2 = "abc";
//string1 += "c";
//var result3 = string.ReferenceEquals(string1, string2);
//if (string1 == string2)
//{

//}

//比如：
//字符串是个例外
String s1, s2, s3 = "abc", s4 = "abc";

s1 = new String("abc");

s2 = new String("abc");

//那么：

var mmm = s1 == s2;   //是 false      //两个变量的内存地址不一样，也就是说它们指向的对象不 一样，故不相等。

var mmmmm = s1.Equals(s2); //是 true    //两个变量的所包含的内容是abc，故相等。
 

//using (ArrayNew array=new ArrayNew())
//{

//}
Console.WriteLine("Hello, World!");



