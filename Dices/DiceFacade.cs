public class DiceFacade
{
    private IDice _dice;

    public DiceFacade()
    {
        _dice = new Dice();
    }
    public int Roll(int max)
    {
        return _dice.Roll(max);
    }
}