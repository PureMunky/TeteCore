using System;
using Tete.Comm.Service;

namespace Tete
{
  public static class RegisterServices
  {

    public static void Initialize()
    {
      ServiceCtrl serviceCtrl = new ServiceCtrl();
      serviceCtrl.RegisterService(new FunctionService("Modules", "GetAll", TestFunction));

    }

    private static ServiceResponse TestFunction(ServiceRequest request)
    {
      return new ServiceResponse(new ServiceRequest(request.Module, request.Service)){
        Body = "Testing"
      };
    }
  }
}