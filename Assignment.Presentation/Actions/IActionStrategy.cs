namespace Assignment.Presentation.Actions
{
    public interface IActionStrategy
    {
        public int? ActionType { get; }


        public void Excute();
    }
}
