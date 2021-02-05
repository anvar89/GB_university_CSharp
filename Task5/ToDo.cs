namespace Task5
{
    class ToDo
    {
        public string Title { get; private set; }
        public bool IsDone { get; set; }

        public ToDo(string title)
        {
            Title = title;
        }

        public ToDo()
        {
        }

        public override string ToString()
        {
            return (IsDone ? "[x]" : "") + Title;
        }
    }
}
