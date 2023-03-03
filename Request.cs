public class Request {
    public List<int>? Numbers {get;set;}
}

public struct BiggestNumber
  {
    public BiggestNumber(int number, int count)
    {
        Number = number;
        Count = count;
    }

    public int Number { get; }
    public int Count { get; }
}