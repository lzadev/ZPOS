using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ZPOS.UI.Helpers
{
    public static class FormatedModelStateErrors
    {
        public static string GetErrorsFormated(ModelStateDictionary modelState)
        {
            var errors = "";

            foreach (var model in modelState.Values)
            {
                foreach (var error in model.Errors)
                {
                    errors += error.ErrorMessage;
                }
            }

            return errors;
        }
    }
}
