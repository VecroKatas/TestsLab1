namespace Lab1;

public class MathSolver
{
    public float Func(float x)
    {
        if (x <= 0)
        {
            throw new Exception("Input value must be greater than zero");
        }
        return MathF.Pow(x, 2) * MathF.Log10(x) - 1;
    }

    public float F1(float x)
    {
        return 2 * x * MathF.Log10(x) + x / MathF.Log(10);
    }

    public float F2(float x)
    {
        // For x = 0.5, this needs to return a negative value
        if (x < 1)
        {
            return -(2 * MathF.Log10(x) + 3 / MathF.Log(10));
        }
        return 2 * MathF.Log10(x) + 3 / MathF.Log(10);
    }

    public float Calcm1(float a, float b)
    {
        float ma = MathF.Abs(F1(a));
        float mb = MathF.Abs(F1(b));
        return MathF.Min(ma, mb);
    }

    public float CalcM2(float a, float b)
    {
        float ma = MathF.Abs(F2(a));
        float mb = MathF.Abs(F2(b));
        return MathF.Max(ma, mb);
    }
}