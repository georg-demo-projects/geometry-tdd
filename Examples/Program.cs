using Geometry;
using Geometry.Figures;
using Geometry.Strategies;
using Geometry.Visitors;

namespace Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DefaultFiguresExample();
            
            ModifyStrategyExample(); // add RightAngledTriangle area strategy
            
            AddFigureExample(); // add Rectangle figure
            
            NewVisitorExample(); // print figure list visitor

            AreasSum(); // calculate areas sum of the printed figures
        }

        public static void DefaultFiguresExample()
        {
            Console.WriteLine("\n* DefaultFiguresExample *\n");

            // Setup
            IFigureVisitor<double> areaCalculator = new AreaFigureVisitor();
            double radius = 5;
            double a = 13, b = 12, c = 5;

            IFigure circle = Circle.Create(radius);
            double circleArea = areaCalculator.Visit(circle);
            
            IFigure triangle = Triangle.Create(a, b, c);
            double triangleArea = areaCalculator.Visit(triangle);

            Console.WriteLine($"Circle radius: {radius}; Area={circleArea}");
            Console.WriteLine($"Triangle sides: {a}; {b}; {c}; Area={triangleArea}");
        }

        public static void ModifyStrategyExample()
        {
            Console.WriteLine("\n* ModifyStrategyExample *\n");

            // Setup
            IFigureVisitor<double> areaCalculator = new AreaFigureVisitor();
            ITriangleStrategy<double> defaultTriangleStrategy = new TriangleAreaStrategy();
            double a = 5, b = 4, c = 3;

            IFigure triangle = Triangle.Create(a, b, c);

            // create extended triangle strategy
            ITriangleStrategy<double> extendedTriangleStrategy = new RightAngledTriangleAreaStrategy(defaultTriangleStrategy);

            // replace existing triangle strategy
            areaCalculator.StrategyContainer.Register<ITriangleStrategy<double>>(extendedTriangleStrategy);

            // calc area with extended triangle strategy
            double triangleArea = areaCalculator.Visit(triangle);

            Console.WriteLine($"Triangle sides: {a}; {b}; {c}; Area={triangleArea}");

            // output:
            // >    --- Applied the strategy for a right-angled triangle ---
            // >    Triangle: Sides = 5; 4; 3; Area=6
        }

        public static void AddFigureExample()
        {
            Console.WriteLine("\n* AddFigureExample *\n");

            // Setup
            IFigureVisitor<double> areaCalculator = new AreaFigureVisitor();
            double h = 5, w = 10;

            IFigure rect = new Rectangle(h, w);

            // add rectangle strategy
            areaCalculator.StrategyContainer.Register<IRectangleStrategy<double>>(new RectangleAreaStrategy());

            // calc area
            double rectArea = areaCalculator.Visit(rect);

            Console.WriteLine($"Rectangle: H/W: {h}; {w}; Area={rectArea}");
        }

        public static void NewVisitorExample()
        {
            Console.WriteLine("\n* NewVisitorExample *\n");

            IFigureVisitor<string> figurePrinter = new PrintVisitor();

            foreach (IFigure f in GetFigures())
            {
                string figureInfo = figurePrinter.Visit(f);
                Console.WriteLine(figureInfo);
            }
        }

        public static void AreasSum()
        {
            Console.WriteLine("\n* AreasSum *\n");

            IFigureVisitor<double> areaCalculator = new AreaFigureVisitor();
            areaCalculator.StrategyContainer.Register<IRectangleStrategy<double>>(new RectangleAreaStrategy());

            double totalArea = GetFigures().Sum(f => areaCalculator.Visit(f));

            Console.WriteLine($"TotalArea={totalArea}");
        }

        private static IEnumerable<IFigure> GetFigures()
        {
            yield return Circle.Create(5);
            yield return Circle.Create(10);

            yield return Triangle.Create(5, 7, 4);
            yield return Triangle.Create(5, 4, 3);
            yield return Triangle.Create(13, 12, 5);

            yield return new Rectangle(5, 10);
        }
    }
}