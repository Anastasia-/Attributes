using System;
using System.Collections.Generic;
//using NUnit.Framework;
using Tests.TestsData;
using Attr.AttrSet;
using Attr.Checker;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsEvenTest()
        {
            bool result = true;
            var data = new EvenPropertiesTestData(14, new List<int>() { 2, 4, 6 });

            var prop = data.GetType().GetProperty(nameof(EvenPropertiesTestData.EvenField));
            foreach (var attr in prop.GetCustomAttributes())
            {
                if (attr is VerifiableAttribute)
                {
                    var vAttr = attr as VerifiableAttribute;
                    result = result && vAttr.Verify(data.EvenField);
                }
            }

            

            var propList = data.GetType().GetProperty(nameof(EvenPropertiesTestData.EvenListField));
            foreach (var attr in propList.GetCustomAttributes())
            {
                if (attr is VerifiableAttribute)
                {
                    var vAttr = attr as VerifiableAttribute;
                    result = result &&  vAttr.Verify(data.EvenListField);
                }
            }

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsNotEvenTest()
        {
            bool result = false;
            var data = new EvenPropertiesTestData(13, new List<int>() { 1, 5, 6 });

            var prop = data.GetType().GetProperty(nameof(EvenPropertiesTestData.EvenField));
            foreach (var attr in prop.GetCustomAttributes())
            {
                if (attr is VerifiableAttribute)
                {
                    var vAttr = attr as VerifiableAttribute;
                    result = result || vAttr.Verify(data.EvenField);
                }
            }



            var propList = data.GetType().GetProperty(nameof(EvenPropertiesTestData.EvenListField));
            foreach (var attr in propList.GetCustomAttributes())
            {
                if (attr is VerifiableAttribute)
                {
                    var vAttr = attr as VerifiableAttribute;
                    result = result || vAttr.Verify(data.EvenListField);
                }
            }

            Assert.IsTrue(!result);
        }

        [TestMethod]
        public void IsEvenPropertiesCheckerTest()
        {
            var data = new EvenPropertiesTestData(14, new List<int>() { 2, 4, 6 });
            bool result = CheckerProperties.Check(data);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotEvenPropertiesCheckerTest()
        {
            var data = new EvenPropertiesTestData(13, new List<int>() { 2, 3, 6 });
            bool result = CheckerProperties.Check(data);
            Assert.IsTrue(!result);
        }

       [TestMethod]
        public void IsNotAllEvenPropertiesCheckerTest()
        {
            var data1 = new EvenPropertiesTestData(13, new List<int>() { 2, 4, 6 });
            Assert.IsTrue(!CheckerProperties.Check(data1));


            var data2 = new EvenPropertiesTestData(14, new List<int>() { 2, 4, 7 });
            Assert.IsTrue(!CheckerProperties.Check(data2));
        }

        [TestMethod]
        public void CheckerEvenFieldsTest()
        {
            var data = new EvenFieldsTestData(14, new List<int>() { 2, 4, 6 });
            bool result = CheckerFields.Check(data);
            Assert.IsTrue(result);

            var data1 = new EvenFieldsTestData(13, new List<int>() { 2, 4, 6 });
            Assert.IsTrue(!CheckerFields.Check(data1));

            var data2 = new EvenFieldsTestData(14, new List<int>() { 2, 4, 7 });
            Assert.IsTrue(!CheckerFields.Check(data2));

            var data4 = new EvenFieldsTestData(13, new List<int>() { 2, 3, 6 });
            Assert.IsTrue(!CheckerFields.Check(data4));
        }

        [TestMethod]
        public void IsMultipleAttrCheckerFieldsTest()
        {
            var data = new MultipleAttrFieldTestData(new List<int>() { 2, 4, 6, 8 }, "23433");
            Assert.IsTrue(CheckerFields.Check(data));

            var data1 = new MultipleAttrFieldTestData(new List<int>() { 2, 4, 7, 8 }, "23433");
            Assert.IsTrue(!CheckerFields.Check(data1));

            var data2 = new MultipleAttrFieldTestData(new List<int>() { 2, 4 }, "23433");
            Assert.IsTrue(!CheckerFields.Check(data2));
        }


        [TestMethod]
        public void IsMultipleAttrCheckerPropertiesTest()
        {
            var data = new MultipleAttrFieldTestData(new List<int>() { 2, 4, 6, 8 }, "2313");
            Assert.IsTrue(CheckerFields.Check(data));

            var data1 = new MultipleAttrFieldTestData(new List<int>() { 2, 4, 7, 8 }, "2333");
            Assert.IsTrue(!CheckerFields.Check(data1));

            var data2 = new MultipleAttrFieldTestData(new List<int>() { 2, 4 }, "2333");
            Assert.IsTrue(!CheckerFields.Check(data2));

            var data3 = new MultipleAttrFieldTestData(new List<int>() { 2, 4, 6, 8 }, "scs9");
            Assert.IsTrue(!CheckerFields.Check(data3));

            var data4 = new MultipleAttrFieldTestData(new List<int>() { 2, 4, 6, 8 }, "233000001");
            Assert.IsTrue(!CheckerFields.Check(data4));
        }

        [TestMethod]
        public void HasStaticMetodAttributeClassCheckerPropertiesTest()
        {
            Assert.IsTrue(!CheckerClasses.Check(new EqualFalseStaticMethodClassTestData()));

            Assert.IsTrue(!CheckerClasses.Check(new LessFalseStaticMethodClassTestData()));

            Assert.IsTrue(CheckerClasses.Check(new LessTrueStaticMethodClassTestData()));

            Assert.IsTrue(!CheckerClasses.Check(new MoreFalseStaticMethodClassTestData()));
        }

        [TestMethod]
        public void HasEvenAttrParamCheckerMetodTest()
        {
            Assert.IsTrue(CheckerMethods.Check(new HasEvenFirstParamMethodTestData()));
            Assert.IsTrue(!CheckerMethods.Check(new HasEvenSecondParamAttrMethodData()));
            Assert.IsTrue(!CheckerMethods.Check(new HasNotEvenFirstAttrTestData()));
        }
    }
}