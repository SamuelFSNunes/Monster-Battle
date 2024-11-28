public class Dice : IDice
{
    private Random _random;

    public Dice()
    {
        _random = new Random();
    }

    public int Roll(int max)
    {
        if (max < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(max), "O valor maximo deve ser maior que zero.");
        }
        int roll = _random.Next(1, max + 1);
        return roll;
    }
}