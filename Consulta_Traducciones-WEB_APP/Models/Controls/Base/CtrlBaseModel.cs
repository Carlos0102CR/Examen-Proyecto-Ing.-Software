using System.IO;
using System.Web;

namespace Traduccion_Viewer.Models.Base
{
    public class CtrlBaseModel
    {
        public string Id { get; set; }
        public string ViewName { get; set; }


        private string ReadFileText()
        {
            var path = HttpContext.Current.Server.MapPath(@"~\Models\Controls\Html\");
            string fileName = this.GetType().Name + ".html";

            path = path + fileName;

            string text = System.IO.File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in this.GetType().GetProperties())
            {
                var value = prop.GetValue(this, null).ToString();

                var tag = string.Format("-#{0}-", prop.Name);
                html = html.Replace(tag, value);
            }
            return html;
        }
    }
}