using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest
{
    internal class JsonClass
    {
        public void Run()
        {
            JsonClass jsonClass = new JsonClass();
            var json = jsonClass.ClassToJson();
            PeopleInfo peopleInfo = jsonClass.JsonToClass(json);
            Console.WriteLine(json);
            Console.ReadLine();
        }

        public string ClassToJson()
        {
            PeopleInfo p = new PeopleInfo();
            p.Name = "来福";
            p.Age = 30;
            p.Birthday = DateTime.Now;
            p.Gender = EnumGender.male;
            p.Hobby = new List<string> { "吃饭", "睡觉", "打豆豆" };

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(p, settings);
        }

        public PeopleInfo JsonToClass(string json)
        {
            return JsonConvert.DeserializeObject<PeopleInfo>(json);
        }
    }

    public enum EnumGender
    {
        woman,
        male
    }

    public class PeopleInfo
    {
        private string PrivateProperty { get; set; }
        [JsonIgnore]
        public string IgnoreProperty { get; set; }
        [JsonProperty(PropertyName = "姓名", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public EnumGender Gender { get; set; }
        public List<string> Hobby { get; set; }
    }
}
