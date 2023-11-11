using Assignment3_UnitTest_LiFan;

namespace UnitTest_problem2
{
    public class Tests
    {
        private ShippingCharge shippingCharge { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            shippingCharge = new ShippingCharge();
        }

        [Test]
        public void GetShippingCharge1()
        {
            double weight = 2;
            int distance = 550;
            string expected = "2.20";

            var res = shippingCharge.ChargeCalculate(weight, distance);
            
            Assert.AreEqual(expected, res);
            Assert.That(res, Is.TypeOf<String>());
        }


        [Test]
        public void GetShippingCharge2()
        {
            double weight = 7.5;
            int distance = 600;
            string expected = "27.75";

            var res = shippingCharge.ChargeCalculate(weight, distance);

            Assert.AreEqual(expected, res);
            Assert.That(res, Is.TypeOf<String>());
        }

        [Test]
        public void GetShippingCharge3()
        {
            double weight = 11;
            int distance = 1200;
            string expected = "105.60";

            var res = shippingCharge.ChargeCalculate(weight, distance);

            Assert.AreEqual(expected, res);
            Assert.That(res, Is.TypeOf<String>());
        }

        [Test]
        public void GetShippingCharge4()
        {
            double weight = 5.6;
            int distance = 1350;
            string expected = "24.64";

            var res = shippingCharge.ChargeCalculate(weight, distance);

            Assert.AreEqual(expected, res);
            Assert.That(res, Is.TypeOf<String>());
        }
    }
}