﻿using GW2CSharp;
using GW2CSharp.V2.Unauthenticated.Miscellaneous.Quaggans;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tests.V2.Unauthenticated.Miscellaneous
{
    [TestFixture]
    public class QuagganUnitTest
    {
        [Test]
        public void ShouldReturnAllQuaggans()
        {
            IEnumerable<Lazy<Quaggan>> quaggans = GW2Api.V2.Quaggans.GetAllQuaggans();

            Assert.AreEqual(35, quaggans.Count());
        }

        [Test]
        public void ShouldReturnSpecificQuagganFromList()
        {
            List<Lazy<Quaggan>> quaggans = GW2Api.V2.Quaggans.GetAllQuaggans().ToList();
            Quaggan cryQuaggan = quaggans[13].Value;

            Assert.AreEqual("https://static.staticwars.com/quaggans/cry.jpg", cryQuaggan.Url);
        }

        [Test]
        public void ShouldReturnSingleQuaggan()
        {
            Quaggan cakeQuaggan = GW2Api.V2.Quaggans.GetQuaggan("cake");

            Assert.AreEqual("https://static.staticwars.com/quaggans/cake.jpg", cakeQuaggan.Url);
        }

        [Test]
        public void ShouldReturnCorrectBitmap()
        {
            Bitmap cakeQuaggan = GW2Api.V2.Quaggans.GetQuaggan("cake").GetImage();
            Assert.NotNull(cakeQuaggan);
        }
    }
}