using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class CustomerControllerTest
    {

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            //NotFound Object
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound or one of its derevatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIszero_ReturnOk()
        {
            var conroller = new CustomerController();
            var result = conroller.GetCustomer(1);
            Assert.That(result, Is.TypeOf<Ok>());
        
        }

    }
}
