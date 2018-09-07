﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    class HtmlFormatterTest
    {

        [Test]
        public void FOrmatAsBOld_WhenCalled_shouldEncloseTheStingWithStrongElemnt()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            //Specific Assertion
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);


            //more general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}
