using Lab1;

var mathSolver = new MathSolver();

// x^2 * lg(x) - 1 = 0
// log(x) - 1/x^2=0

float a = 0, b = 0, x, e, tmp, init_a = 0, init_b = 0;
int n;
string[] input;
Console.WriteLine("Метод ділення навпіл");

while (a == 0)
{
    Console.WriteLine("Enter a and b");
    input = Console.ReadLine().Split();
    float _a = float.Parse(input[0]);
    float _b = float.Parse(input[1]);

    if (_a > 0)
    {
        float A = mathSolver.Func(_a), B = mathSolver.Func(_b);
        
        if ((A < 0 && B > 0) || (A > 0 && B < 0))
        {
            a = _a;
            b = _b;
            init_a = _a;
            init_b = _b;
        }
        else
        {
            Console.WriteLine("Wrong input. f(a) and f(b) has to have different signs");
        }
    }
    else
    {
        Console.WriteLine("Wrong input. a must be > 0");
    }
}

Console.WriteLine("Enter e (as in 10^-e)");

e = Convert.ToInt32(Console.ReadLine());
x = (a + b) / 2;
n = (int)Math.Floor(MathF.Log2((b - a) / MathF.Pow(10, -e))) + 1;

Console.WriteLine("Iterations: " + n);

tmp = mathSolver.Func(x);

Console.WriteLine("n \t\t x_n \t\t f(x_n)");
Console.WriteLine(0 + "\t\t" + x + "\t\t" + tmp);

float x_ = 0;

for (int i = 1; i <= n; i++)
{
    x_ = x;
    if ((a <= 0 && tmp >= 0) || (a >= 0 && tmp < 0))
        a = x;
    else if ((b >= 0 && tmp >= 0) || (b <= 0 && tmp < 0))
        b = x;
    x = (a + b) / 2;
        
    tmp = mathSolver.Func(x);

    if (MathF.Abs(x_ - x) < MathF.Pow(10, -e))
    {
        Console.WriteLine();
        Console.WriteLine("Вихід раніше: " + i + "\t\t" + x + "\t\t" + tmp);
        Console.WriteLine();
    }
        
        
    Console.WriteLine(i + "\t\t" + x + "\t\t" + tmp);
    
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Метод Ньютона");
a = init_a;
b = init_b;

Console.WriteLine("a = " + a + "; b = " + b);

float x0 = 0;
while (x0 == 0)
{
    Console.WriteLine("Type x_0");

    float _x0 = float.Parse(Console.ReadLine());
    if (_x0 >= a && _x0 <= b)
    {
        if (mathSolver.Func(_x0) * mathSolver.F2(_x0) > 0)
        {
            x0 = _x0;
            
            Console.WriteLine("f(x_0) = " + mathSolver.Func(x0) + "; f``(x_0) = " + mathSolver.F2(x0));
        }
        else
        {
            Console.WriteLine("Wrong x_0 input.");
        }
        Console.WriteLine("f(x_0) * f``(x_0) > 0 = " + (mathSolver.Func(_x0) * mathSolver.F2(_x0) > 0));
    }
    else
        Console.WriteLine("Wrong input. x0 must be a <= x0 <= b");
}

float M2, m1, z0, q, xi = x0;

var coefficients = mathSolver.CalcCoefficients(a, b, x0);

m1 = coefficients[0];
M2 = coefficients[1];
z0 = coefficients[2];
q = coefficients[3];

Console.WriteLine("m1 = " + m1);
Console.WriteLine("M2 = " + M2);
Console.WriteLine("z0 = " + z0);
Console.WriteLine("q = " + q);

float n0 = MathF.Floor(MathF.Log2(MathF.Log(z0 / MathF.Pow(10, -e)) / MathF.Log(1 / q) + 1)) + 1;
Console.WriteLine("n0 = " + n0);

Console.WriteLine("n \t\t x_n \t\t f(x_n)");
Console.WriteLine("0 \t\t" + xi + "\t\t" + mathSolver.Func(xi));

for (int i = 1; i <= n0; i++)
{
    xi = xi - mathSolver.Func(xi) / mathSolver.F1(xi);
    Console.WriteLine(i + "\t\t" + xi + "\t\t" + mathSolver.Func(xi));
}
Console.WriteLine();

int j = 0;
xi = x0;
x_ = 0;

while (MathF.Abs(x_ - xi) > MathF.Pow(10, -e))
{
    x_ = xi;
    xi = xi - mathSolver.Func(xi) / mathSolver.F1(xi);
    j++;
    Console.WriteLine(j + "\t\t" + xi + "\t\t" + mathSolver.Func(xi));
}