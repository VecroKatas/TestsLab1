using Lab1;

namespace Tests
{
    [TestFixture]
    public class MathSolverTests
    {
        private MathSolver _solver;

        [SetUp]
        public void Setup()
        {
            _solver = new MathSolver();
        }

        [Test]
        public void Func_ReturnsCorrectValue()
        {
            float x = 2f;
            float expected = MathF.Pow(x, 2) * MathF.Log10(x) - 1;
            float actual = _solver.Func(x);

            Assert.That(actual, Is.EqualTo(expected).Within(1e-5));
        }

        [Test]
        public void Func_ThrowsException_WhenXIsZeroOrNegative()
        {
            Assert.Throws<Exception>(() => _solver.Func(0));
            Assert.Throws<Exception>(() => _solver.Func(-1));
        }

        [TestCase(2f, true)]
        [TestCase(0.5f, false)]
        public void F2_Sign_Check(float x, bool expectedPositive)
        {
            float result = _solver.F2(x);
            Assert.That(result > 0, Is.EqualTo(expectedPositive));
        }

        [Test]
        public void Calcm1_ReturnsMinAbsF1()
        {
            float a = 1.5f, b = 2.5f;

            float result = _solver.Calcm1(a, b);
            float expected = MathF.Min(MathF.Abs(_solver.F1(a)), MathF.Abs(_solver.F1(b)));

            Assert.That(result, Is.EqualTo(expected).Within(1e-5));
        }

        [Test]
        public void CalcM2_ReturnsMaxAbsF2()
        {
            float a = 1.5f, b = 2.5f;

            float result = _solver.CalcM2(a, b);
            float expected = MathF.Max(MathF.Abs(_solver.F2(a)), MathF.Abs(_solver.F2(b)));

            Assert.That(result, Is.EqualTo(expected).Within(1e-5));
        }
        
        [Test]
        public void CalcCoefficients_ReturnsCorrectValues()
        {
            float a = 1.5f, b = 2.5f, x0 = 2.0f;
            
            float[] coefficients = _solver.CalcCoefficients(a, b, x0);
            
            float expectedM1 = _solver.Calcm1(a, b);
            float expectedM2 = _solver.CalcM2(a, b);
            float expectedZ0 = MathF.Max(MathF.Abs(a - x0), MathF.Abs(b - x0));
            float expectedQ = expectedM2 * expectedZ0 / (2 * expectedM1);
            
            float[] expected = [expectedM1, expectedM2, expectedZ0, expectedQ];
            
            Assert.That(coefficients, Is.EqualTo(expected).Within(1e-5));
        }
        
        [Test]
        public void CalcCoefficients_WhenAEqualsB_CalculatesCorrectly()
        {
            float a = 2.0f, b = 2.0f, x0 = 2f;
            
            float[] coefficients = _solver.CalcCoefficients(a, b, x0);
            
            float expectedM1 = _solver.Calcm1(a, b);
            float expectedM2 = _solver.CalcM2(a, b);
            float expectedZ0 = MathF.Abs(a - x0); 
            float expectedQ = expectedM2 * expectedZ0 / (2 * expectedM1);
            
            float[] expected = [expectedM1, expectedM2, expectedZ0, expectedQ];
            
            Assert.That(coefficients, Is.EqualTo(expected).Within(1e-5));
        }
        
        [Test]
        public void CalcCoefficients_WhenX0OutsideRange_ThrowsException()
        {
            float a = 1.5f, b = 2.5f, x0 = 3.0f;
            
            Assert.Throws<Exception>(() => _solver.CalcCoefficients(a, b, x0));
        }
    }
}