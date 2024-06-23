namespace Examples
{
    /// <summary>
    /// Class used for demo purposes. This could be anything listed in a CheckBoxComboBox.
    /// </summary>
    public class Status
    {
        public Status(int id, string name)
        {
            _id = id;
            _name = name;
        }

        private int _id;
        private string _name;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Now used to return the Name.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;
    }
}