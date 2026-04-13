using Microsoft.VisualStudio.TestTools.UnitTesting;
using GLS_CLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLS_CLI.Tests {
    [TestClass()]
    public class ProgramTests {
        [TestMethod()]
        [DataRow(10, 100, 10)]
        [DataRow(16, 200, 8)]
        [DataRow(0, 0, 0)]
        public void AtlagFogyasztasTest(int liter, int tav, int elvart) {
            double actual = Program.AtlagFogyasztas(tav,liter);
            Assert.AreEqual(elvart, actual);
        }
    }
}