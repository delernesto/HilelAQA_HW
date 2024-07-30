﻿namespace Lesson21
{
    internal class GenericHomework
    {
        // TODO: Uncomment and implement GetParameterType so that test pass
        public string GetParameterType<Astolfo>(Astolfo AstType )
            {
            return $"Data type: {typeof(Astolfo)}";

        }


        [Test]
        public void GenericFunction()
        {
            var intType = GetParameterType(123);
            Assert.That(intType, Is.EqualTo("Data type: System.Int32"));

            var stringType = GetParameterType("some string");
            Assert.That(stringType, Is.EqualTo("Data type: System.String"));

            var doubleType = GetParameterType(new List<double>() { 1.23 });
            Assert.That(doubleType, Is.EqualTo("Data type: System.Collections.Generic.List`1[System.Double]"));
        }
        
    }
}
