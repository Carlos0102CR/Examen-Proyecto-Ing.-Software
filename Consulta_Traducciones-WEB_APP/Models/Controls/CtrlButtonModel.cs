﻿using Traduccion_Viewer.Models.Base;

namespace Traduccion_Viewer.Models.Controls
{
    public class CtrlButtonModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string FunctionName { get; set; }
        public string ButtonType { get; set; } 

        public CtrlButtonModel()
        {
            ViewName = "";
        }
    }
}