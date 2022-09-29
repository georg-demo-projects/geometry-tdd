namespace Geometry.Figures
{
    public interface ITriangle : IFigure
    {
        double Side1 { get; }
        double Side2 { get; }
        double Side3 { get; }
    }
}
