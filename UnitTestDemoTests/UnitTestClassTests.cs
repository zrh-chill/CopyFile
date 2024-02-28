using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitDemo.Tests
{
    [TestClass()]
    public class UnitTestClassTests
    {
        [TestMethod("测试三角形类型方法")]
        [DataRow("5", "5", "4")]
        [DataRow("3", "3", "4")]
        public void GetTriangleTest(string a, string b, string c)
        {

            //AAA（准备、执行、断言）模式是编写待测试方法的单元测试的常用方法：
            //准备（Arrange)，单元测试方法的准备部分初始化对象并设置传递给待测试方法的数据；
            //执行（Act），执行部分调用具有准备参数的待测试方法；
            //断言（Assert），断言部分验证待测试方法的执行行为与预期相同。

            // arrange  
            string[] sideArr = { a, b, c }; // 准备传给待测试方法的数据
            string expected = "等腰三角形";

            // act  
            var actual = UnitTestClass.GetTriangle(sideArr); // 调用测试方法

            // assert  
            Assert.AreEqual(expected, actual); // 验证待测试方法的执行结果是否与预期相同
        }
    }
}