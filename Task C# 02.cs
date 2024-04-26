//решение для первой части задания, касающуюся библиотеки на C#.
//Создан интерфейс IShapeдля

public interface IShape
{
    double Area();
}


//Реализуем классы CircleиTriangle, импIShape:

public class Circle : IShape
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; }

    public double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Triangle : IShape
{
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public double Area()
    {
        var s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public bool IsRight()
    {
        return Math.Abs(Math.Pow(SideA, 2) + Math.Pow(SideB, 2) - Math.Pow(SideC, 2)) < 0.001 ||
               Math.Abs(Math.Pow(SideA, 2) + Math.Pow(SideC, 2) - Math.Pow(SideB, 2)) < 0.001 ||
               Math.Abs(Math.Pow(SideB, 2) + Math.Pow(SideC, 2) - Math.Pow(SideA, 2)) < 0.001;
    }
}

//Добавим класс ShapeAreaCalculatorдля расчета квадратной фигуры

public class ShapeAreaCalculator
{
    public double CalculateArea(IShape shape)
    {
        return shape.Area();
    }
}
//юнит-тесты для проверки

[TestClass]
public class ShapeTests
{
    [TestMethod]
    public void TestCircleArea()
    {
        var circle = new Circle(2);
        var expectedArea = Math.PI * 4;
        Assert.AreEqual(expectedArea, circle.Area());
    }

    [TestMethod]
    public void TestTriangleArea()
    {
        var triangle = new Triangle(3, 4, 5);
        var expectedArea = 6;
        Assert.AreEqual(expectedArea, triangle.Area());
    }

    [TestMethod]
    public void TestIsRightTriangle()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.IsTrue(triangle.IsRight());
    }

    [TestMethod]
    public void TestNotRightTriangle()
    {
        var triangle = new Triangle(3, 4, 6);
        Assert.IsFalse(triangle.IsRight());
    }
}
//Для добавления других фигур достаточно будет создать новый класс, реализующий интерфейс IShape, и реализовать в нем метод Area().
