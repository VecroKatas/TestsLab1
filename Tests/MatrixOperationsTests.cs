using Lab1;
using NUnit.Framework;
using System;
using System.Collections;

namespace Tests
{
    [TestFixture]
    public class MatrixOperationsTests
    {
        private MatrixOperations _matrixOps;

        [SetUp]
        public void Setup()
        {
            _matrixOps = new MatrixOperations();
        }

        [Test]
        public void MultiplyMatrices_ValidMatrices_ReturnsCorrectResult()
        {
            int[,] matrix1 = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            
            int[,] matrix2 = {
                { 7, 8 },
                { 9, 10 },
                { 11, 12 }
            };
            
            int[,] expected = {
                { 58, 64 },
                { 139, 154 }
            };

            int[,] result = _matrixOps.MultiplyMatrices(matrix1, matrix2);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplyMatrices_IncompatibleDimensions_ThrowsArgumentException()
        {
            int[,] matrix1 = {
                { 1, 2 },
                { 3, 4 }
            };
            
            int[,] matrix2 = {
                { 5, 6, 7 }
            };

            Assert.Throws<ArgumentException>(() => _matrixOps.MultiplyMatrices(matrix1, matrix2));
        }

        [Test]
        public void TransposeMatrix_ValidMatrix_ReturnsTransposedMatrix()
        {
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            
            int[,] expected = {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            };

            int[,] result = _matrixOps.TransposeMatrix(matrix);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
