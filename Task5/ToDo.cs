using System;

namespace Task5
{
    [Serializable]
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo()
        {

        }

        public override string ToString()
        {
            return (IsDone ? "[x]" : "") + Title;
        }
    }
}
