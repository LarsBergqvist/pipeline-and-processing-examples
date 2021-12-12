namespace Common
{
    public class Data
    {
        public Data(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public string Text { get; }
        public int Value { get; }

        public override string ToString()
        {
            return $"Text: {Text}, Value: {Value}";
        }
    }
}
