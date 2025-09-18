public interface ICSet
{
    void Print();
    void SaveToFile(string path);
    bool Contains(object item);
    void Add(object item);

    IEnumerable<object> GetElements();
}
