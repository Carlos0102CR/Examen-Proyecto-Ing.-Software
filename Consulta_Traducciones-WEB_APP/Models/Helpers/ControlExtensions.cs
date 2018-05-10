using Traduccion_Viewer.Models.Controls;
using System.Web;
using System.Web.Mvc;

namespace Traduccion_Viewer.Models.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = "", string buttonType = "")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title, string columnsTitle, string ColumnsDataName, string onSelectFunction, string clase)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction,
                Clase = clase
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string clase, string label, string claseLabel = "", string placeHolder = "", bool required = false, string columnDataName = "", bool disabled = false)
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                Clase = clase,
                ClaseLabel = claseLabel,
                Required = required ? "required" : "",
                Disabled = disabled ? "disabled" : ""
            };

            return new HtmlString(ctrl.GetHtml());
        }
    }
}