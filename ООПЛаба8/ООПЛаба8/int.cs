using System;

public class Int : IComparable<Int>, IEquatable<Int>
{
    private int value;

    public Int() => value = 0;
    public Int(int value) => this.value = value;
    public Int(Int other) => this.value = other?.value ?? 0;

    public int GetValue() => value;

    // === ВЫВОД: имитация operator<< через ToString() ===
    public override string ToString() => value.ToString();

    // === ВВОД: имитация operator>> через статический Parse ===
    public static Int Parse(string input)
    {
        if (int.TryParse(input, out int val))
            return new Int(val);
        throw new FormatException("Неверный формат для Int");
    }

    // Сравнение
    public int CompareTo(Int? other) => value.CompareTo(other?.value ?? 0);
    public bool Equals(Int? other) => other != null && value == other.value;
    public override bool Equals(object obj) => obj is Int other && Equals(other);
    public override int GetHashCode() => value.GetHashCode();
}