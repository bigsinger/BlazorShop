namespace BlazorShop.Models.Identity {
    using System.ComponentModel.DataAnnotations;
    using static Data.ModelConstants.Common;
    using static ErrorMessages;

    public class ChangeSettingsRequestModel {
        [Required]
        [StringLength(
            MaxNameLength,
            ErrorMessage = StringLengthErrorMessage,
            MinimumLength = MinNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(
            MaxNameLength,
            ErrorMessage = StringLengthErrorMessage,
            MinimumLength = MinNameLength)]
        public string LastName { get; set; }
    }
}