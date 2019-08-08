using System.Threading.Tasks;

namespace Tete.Comm.Service
{
  public interface IServiceCtrl
  {
    ServiceResponse Invoke(ServiceRequest request);
  }
}