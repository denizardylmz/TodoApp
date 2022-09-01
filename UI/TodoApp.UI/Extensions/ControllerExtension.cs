using Microsoft.AspNetCore.Mvc;
using TodoApp.Common.Interfaces;
using TodoApp.Common.Responses;

namespace TodoApp.UI.Extensions;

public static class ControllerExtension
{
    public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionName)
    {
        if (response.ResponseType == ResponseType.ValidationError)
        {
            foreach (var error in response.ValidationErrors)
            {
                controller.ModelState.AddModelError(error.ProperyName, error.ErrorMessage);    
            }

            return controller.View(response.Data);
        }
        else if (response.ResponseType == ResponseType.NotFound)
        {
            return controller.NotFound();
        }

        return controller.RedirectToAction(actionName);
    }



    public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
    {
        if (response.ResponseType == ResponseType.NotFound)
        {
            return controller.NotFound();
        }

        return controller.View(response.Data);
    }

    public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response,
        string actionName)
    {
        if (response.ResponseType == ResponseType.NotFound)
            return controller.NotFound();
        return controller.RedirectToAction(actionName);
    }
}