using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tete.Comm.Service
{

  public class HttpClientService
  {

    #region "Private Variables"
    bool mock = false;
    string mockValue = "";
    #endregion

    #region Constructors

    public HttpClientService()
    {
      this.mock = false;
    }

    public HttpClientService(string mockValue)
    {
      this.mock = true;
      this.mockValue = mockValue;
    }

    #endregion

    #region "Public Functions"

    public async Task<string> GetStringAsync(string url) {
      string rtnValue;

      if(mock)
      {
        rtnValue = this.mockValue;
      }
      else
      {
        rtnValue = await new HttpClient().GetStringAsync(url);
      }

      return rtnValue;
    }

    #endregion
  }
}