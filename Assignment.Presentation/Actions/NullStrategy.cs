namespace Assignment.Presentation.Actions
{
    public class NullStrategy : IActionStrategy
    {
        public int? ActionType => null;
        public void Excute() { }
    }
}
