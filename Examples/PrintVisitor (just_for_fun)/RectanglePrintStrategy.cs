
namespace Examples
{
    internal class RectanglePrintStrategy : IRectangleStrategy<string>
    {
        public string Execute(IRectangle rect)
        {
            return $"Rectangle H={rect.Hight} W={rect.Width}";
        }
    }
}
