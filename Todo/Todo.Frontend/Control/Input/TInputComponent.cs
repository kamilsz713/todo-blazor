using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Frontend.Control.Input
{
    public partial class TInputComponent : InputBase<string>
    {

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Type { get; set; } = "text";

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
