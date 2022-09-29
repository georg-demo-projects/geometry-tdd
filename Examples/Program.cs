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
            Console.WriteLine("---------- DefaultFiguresExample ----------");
            DefaultFiguresExample();

            Console.WriteLine("---------- ModifyStrategyExample ----------");
            ModifyStrategyExample(); // add RightAngledTriangle area strategy

            Console.WriteLine("---------- AddFigureExample ----------");
            AddFigureExample(); // add Rectangle figure

            Console.WriteLine("---------- NewVisitorExample ----------");
            NewVisitorExample(); // print figure list visitor

            Console.WriteLine("---------- AreasSum ----------");
            AreasSum(); // calculate areas sum of the printed figures
        }

        public static void DefaultFiguresExample()
        {
            // Setup
            var areaCalculator = new AreaFigureVisitor();

            // Create figures
            var circle = Circle.Create(5);
            var triangle = Triangle.Create(13, 12, 5);

            double circleArea = areaCalculator.Visit(circle);
            Console.WriteLine($"Circle: Radius={circle.Radius}");
            Console.WriteLine($"Area={circleArea}");
            Console.WriteLine();

            double triangleArea = areaCalculator.Visit(triangle);
            Console.WriteLine($"Triangle: Sides={triangle.Side1}; {triangle.Side2}; {triangle.Side3}");
            Console.WriteLine($"Area={triangleArea}");
            Console.WriteLine();
        }

        public static void ModifyStrategyExample()
        {
            // Setup
            var areaCalculator = new AreaFigureVisitor();
            var defaultTriangleStrategy = new TriangleAreaStrategy();

            // create extended triangle strategy
            var extendedTriangleStrategy = new RightAngledTriangleAreaStrategy(defaultTriangleStrategy);

            // replace existing triangle strategy
            areaCalculator.StrategyContainer.Register<ITriangleStrategy<double>>(extendedTriangleStrategy);

            var rightAngled = Triangle.Create(5, 4, 3);

            Console.WriteLine($"Triangle: Sides = {rightAngled.Side1}; {rightAngled.Side2}; {rightAngled.Side3};");
            Console.WriteLine($"Area={areaCalculator.Visit(rightAngled)}");
            Console.WriteLine();

            // output:
            // >    Triangle: Sides = 5; 4; 3;
            // >    --- Applied the strategy for a right-angled triangle ---
            // >    6
        }

        public static void AddFigureExample()
        {
            // Setup
            var areaCalculator = new AreaFigureVisitor();
            var rect = new Rectangle(5, 10);

            // add rectangle strategy
            areaCalculator.StrategyContainer.Register<IRectangleStrategy<double>>(new RectangleAreaStrategy());

            Console.WriteLine($"Rectangle: H/W = {rect.Hight}; {rect.Width};");
            Console.WriteLine($"Area={areaCalculator.Visit(rect)}");
            Console.WriteLine();
        }

        public static void NewVisitorExample()
        {
            var figurePrinter = new PrintVisitor();

            foreach (IFigure f in GetFigures())
            {
                string figureInfo = figurePrinter.Visit(f);
                Console.WriteLine(figureInfo);
            }
        }

        public static void AreasSum()
        {
            var areaCalculator = new AreaFigureVisitor();
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