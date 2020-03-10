# DynamicJavonet
A open-source wrapper for Javonet (.NET call Java) using C# `dynamic`.

Javonet is a commercial solution for .NET & Java interop. 
DynamicJavonet is a free and open-source (MIT licensed) wrapper for Javonet.

The DynamicJavonet project simplifies the syntax of Javonet:

```
var calc = Javonet.New("Calculator");
dynamic calc = DJ.New("Calculator"); //DJ ver

var CalcType = Javonet.GetType("Calculator");
var CalcType = DJ.Type("Calculator");

calc.Invoke<float>("Sub", new JPrimitive(1f / 3f), new JPrimitive(1f / 7f));
calc.Sub(1f / 3f, 1f / 7f);

calc.Set("FieldInt", new JPrimitive(3));
calc.FieldInt = 3;

var i = calc.Get<int>("FieldInt");
var i = calc.FieldInt;
```

By running `DyanmicJavonet.TestCLI`, the following result is expected:

```
Without DJ:
0.1904762       0.1904762       0.1904762       0.19047619047619        0.19047619047619        0.19047619047619
With DJ:
0.1904762       0.1904762       0.1904762       0.19047619047619        0.19047619047619        0.19047619047619
```

If your result is error or wrong - congrats, you just met a Javonet bug and you should just ask them for a fix.

---
by Monarch Solutions