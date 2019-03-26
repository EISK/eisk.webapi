namespace Eisk.Test.Core.DataGen.InvalidData
{
    public class Get
    {
        private readonly bool _generateUniqueValue;

        public Get(bool generateUniqueValue)
        {
            _generateUniqueValue = generateUniqueValue;
        }

        public static Get Unique => new Get(true);

        public static Get Plain => new Get(false);

        public string InvalidEmail => new InvalidEmail(_generateUniqueValue).ToString();

        public string InvalidUri => new InvalidUri(_generateUniqueValue).ToString();

        public string InvalidAlphanumeric => new InvalidAlphanumeric(_generateUniqueValue).ToString();

        public string StringWithSpecialCharacters => new StringWithSpecialCharacters(_generateUniqueValue).ToString();
    }
}
