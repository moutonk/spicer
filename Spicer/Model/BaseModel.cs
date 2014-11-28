using System;
using System.Text;
using Utils;

namespace Spicer.Model
{
    public class BaseModel
    {
        protected void Print(Object o)
        {
            var properties = o.GetType().GetProperties();
            var build = new StringBuilder();

            build.Append(o.GetType().Name);
            foreach (var property in properties)
            {
                build.Append(" [" + property.Name + ":" + property.GetValue(o) + "]");
            }
            Logs.Output.ShowOutput(build.ToString());
        }
    }
}
