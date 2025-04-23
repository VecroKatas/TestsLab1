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

        [Test, Ignore("Skip example test for now")]
        public void SkippedTest()
        {
            Assert.Fail("This test should be skipped");
        }
    }
}