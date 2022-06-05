using Models.Helpers;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var obj1 = new TestObj()
            {
                Name = "Hello",
                Value = false
            };

            var obj2 = new TestObj()
            {
                Name = "Hello",
                Value = true
            };

            Assert.IsFalse(NeedsUpdateHelper.NeedsUpdate(obj1, obj2, new string[] { "Value" }));
        }

        public class TestObj
        {
            public string? Name { get; set; }
            public bool? Value { get; set; }
        }
    }
}