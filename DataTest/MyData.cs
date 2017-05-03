using Newtonsoft.Json;
using System;

namespace SPA_Tutorial.DataTest
{
    public class MyData
    {
        public MyData()
        {
            
        }

        public string MakeData()
        {
            var data = new
            {
                labels = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" },
                series = new[] {
                    new[] { 1, 5, 2, 5, 4, 3 },
                    new[] { 2, 3, 4, 8, 1, 2 },
                    new[] { 5, 4, 3, 2, 1, 0 }

            }};
            string json = JsonConvert.SerializeObject(data);
            return json;
        }
    }
}
