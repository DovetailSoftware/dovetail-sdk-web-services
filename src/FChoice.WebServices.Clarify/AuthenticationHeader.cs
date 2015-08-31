using System.Web.Services.Protocols;

namespace FChoice.WebServices.Clarify
{
	public class AuthenticationHeader : SoapHeader
	{
		public string SessionID;
	}
}
