namespace StudentTesting.Application.Services.Captcha
{
    public interface IStringGenerator
    {
        public string String { get; }
        public void GenerateString();
    }
}
