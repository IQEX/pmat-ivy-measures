/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using System;

    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class ArithmeticOperationsTests
    {
        #region Unit tests

        [Test]
        public void Times_MultiplyAreaAndLength_ReturnsVolume()
        {
            var expected = new Measure<Volume>(6.0);
            var lhs = new Measure<Area>(2.0);
            var rhs = new Measure<Length>(3.0);
            Measure<Volume> actual; ArithmeticOperations.Times(lhs, rhs, out actual);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Times_MultiplyAreaAndAreaToVolume_Throws()
        {
            var lhs = new Measure<Area>(2.0);
            var rhs = new Measure<Area>(3.0);
            Measure<Volume> throws; ArithmeticOperations.Times(lhs, rhs, out throws);
        }

        [Test]
        public void Divide_DivideVolumeAndLength_ReturnsArea()
        {
            var expected = new Measure<Area>(4.0);
            var numerator = new Measure<Volume>(8.0);
            var denominator = new Measure<Length>(200.0, Length.CentiMeter);
            Measure<Area> actual; ArithmeticOperations.Divide(numerator, denominator, out actual);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_DivideAreaAndAreaToLength_Throws()
        {
            var numerator = new Measure<Area>(8.0);
            var denominator = new Measure<Area>(200.0, Area.SquareDeciMeter);
            Measure<Length> throws; ArithmeticOperations.Divide(numerator, denominator, out throws);
        }

        [Test]
        public void Power_LengthRaisedWith3_ReturnsVolume()
        {
            var expected = new InUnitMeasure<Volume>(1.0, Volume.CubicDeciMeter);
            var len = new InUnitMeasure<Length>(1.0, Length.DeciMeter);
            Measure<Volume> actual; ArithmeticOperations.Power(len, 3, out actual);
            MeasureAssert.AmountsAreEqual(expected, actual);
        }

        #endregion
    }
}
