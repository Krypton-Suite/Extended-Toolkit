namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class KeyboardState
    {
        private readonly HashSet<Key> _pressed = [];

        public IReadOnlyCollection<Key> PressedKeys => _pressed.ToArray();

        public void Down(Key key)
        {
            if (key == Key.Unknown)
            {
                return;
            }

            _pressed.Add(key);
        }

        public void Up(Key key)
        {
            if (key == Key.Unknown)
            {
                return;
            }

            _pressed.Remove(key);
        }
    }
}