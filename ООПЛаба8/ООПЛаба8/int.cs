using System;

public class Int : IComparable<Int>
{
    private int value;

    public Int() { value = 0; }
    public Int(int value) { this.value = value; }
    public Int(Int i) { this.value = i.value; }

    public int GetValue() => value;

    public override string ToString() => value.ToString();

    public int CompareTo(Int? other) => value.CompareTo(other?.value ?? 0);

    public override bool Equals(object obj)
    {
        if (obj is Int other)
            return this.value == other.value;
        return false;
    }

    public override int GetHashCode() => value.GetHashCode();
}
