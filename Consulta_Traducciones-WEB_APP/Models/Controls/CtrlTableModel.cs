using Traduccion_Viewer.Models.Base;

namespace Traduccion_Viewer.Models.Controls
{
    public class CtrlTableModel : CtrlBaseModel
    {
        public string Title { get; set; }
        public string Columns { get; set; }
        public string ColumnsDataName { get; set; }
        public string FunctionName { get; set; }
        public string Clase { get; set; }

        public int ColumnsCount => Columns.Split(',').Length;

        public CtrlTableModel()
        {
            Columns = "";
        }

        public string ColumnHeaders
        {
            get
            {
                var headers = "";

                foreach (var text in Columns.Split(','))
                {
                    headers += "<th>" + text + "</th>";
                }
                return headers;
            }
        }
    }
}