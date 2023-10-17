using NUnit.Framework;
using System;
using System.Linq;

namespace Task1.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Sort_Numbers_ReturnsAscendingSortedNumbers()
        {
            int[] numbers = { 4, 2, 1, 3, -5 };

            Utilities.Sort(numbers);

            CollectionAssert.AreEqual(numbers.OrderBy(x => x), numbers);
        }

        [Test]
        public void Sort_Null_ThrowsArgumentNullException()
        {
            Assert.That(() => Utilities.Sort(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Sort_EmptyArray_ReturnsEmptyArray()
        {
            int[] numbers = Array.Empty<int>();

            Utilities.Sort(numbers);

            CollectionAssert.AreEqual(Array.Empty<int>(), numbers);
        }

        [Test]
        public void IndexOf_Products_ReturnsTwo()
        {
            var products = new[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            var productToFind = new Product("Product 3", 30.0d);

            int index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            Assert.That(index, Is.EqualTo(2));
        }

        [Test]
        public void IndexOf_NoMatch_ReturnsMinusOne()
        {
            var products = new[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            var productToFind = new Product("Product 4", 30.0d);

            int index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            Assert.That(index, Is.EqualTo(-1));
        }

        [Test]
        public void IndexOf_EqualsWithNull_ReturnsMinusOne()
        {
            var products = new[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            Product productToFind = null;
            int index = Utilities.IndexOf(products, product => product.Equals(productToFind));
            Assert.That(index, Is.EqualTo(-1));
        }

        [Test]
        public void IndexOf_SearchForNonProductTypeObject_ReturnsMinusOne()
        {
            var products = new Product[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };
            var productToFind = 42;

            int index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            Assert.That(index, Is.EqualTo(-1));
        }

        [Test]
        public void IndexOf_NullProducts_ThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                var productToFind = new Product("Product 3", 30.0d);
                int index = Utilities.IndexOf(null, product => product.Equals(productToFind));
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void IndexOf_NullPredicate_ThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                var products = new[] { new Product("Product 1", 10.0d) };
                int index = Utilities.IndexOf(products, null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void IndexOf_EmptyArray_ReturnsMinusOne()
        {
            var products = Array.Empty<Product>();
            var productToFind = new Product("Product 3", 30.0d);

            int index = Utilities.IndexOf(products, product => product.Equals(productToFind));

            Assert.That(index, Is.EqualTo(-1));
        }
    }
}