```bash
using System;
using System.Globalization;
public static class Program {
public static void Main() {
String s1 = "Strasse";
String s2 = "Straﬂe";
Boolean eq;
// CompareOrdinal returns nonzero.
eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2,
eq ? "==" : "!=");
// Compare Strings appropriately for people
// who speak German (de) in Germany (DE)
CultureInfo ci = new CultureInfo("de-DE");
// Compare returns zero.
eq = String.Compare(s1, s2, true, ci) == 0;
Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2,
eq ? "==" : "!=");
}
}
Building and running this code produces the following output:
Ordinal comparison: 'Strasse' != 'Straﬂe'
Cultural comparison: 'Strasse' == 'Straﬂe'
```