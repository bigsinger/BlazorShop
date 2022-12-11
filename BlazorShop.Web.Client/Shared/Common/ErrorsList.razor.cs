namespace BlazorShop.Web.Client.Shared.Common {
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;

    public partial class ErrorsList {
        [Parameter]
        public bool ShowErrors { get; set; }

        [Parameter]
        public IEnumerable<string> Errors { get; set; }

        private void Reset() => this.ShowErrors = !this.ShowErrors;
    }
}
