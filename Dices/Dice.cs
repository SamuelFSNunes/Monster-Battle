public class Dice : IDice
{
    private Random _random;

    public Dice()
    {
        _random = new Random();
    }

    public int Roll(int max)
    {
        return _random.Next(1, max + 1);
    }
}