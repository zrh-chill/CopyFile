using ForTest.ModelAttribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Id = 1,
                Name = "Test",
            };
            
            var properties = person.GetType().GetProperties();

            foreach (var property in properties) 
            {
                // 该属性的名字
                var name =  property.Name;

                // 该属性的值
                var value = property.GetValue(person);

                // 修改改属性的值
                property.SetValue(person, value, null);

                // 获得该属性的某个类型的标签
                if (property.GetCustomAttribute(typeof(PersonCheckAttribute), true) is PersonCheckAttribute attribute)
                {
                    
                }

                // 获得该属性的所有标签
                var attrs = property.GetCustomAttributes();

                foreach (var attr in attrs)
                {
                    if(attr is PersonTestAttribute testAttribute)
                    {

                    }
                }
            }
        }
    }
}
