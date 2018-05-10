using Traduccion_Viewer.Models.Base;

namespace Traduccion_Viewer.Models.Controls
{
    public class CtrlInputModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string ColumnDataName { get; set; }
        public string PlaceHolder { get; set; }
        public string Required { get; set; }
        public string Clase { get; set; }
        public string ClaseLabel { get; set; }
        public string Disabled { get; set; }
        public CtrlInputModel() { ViewName = ""; }
    }
}