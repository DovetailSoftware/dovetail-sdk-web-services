using System;

namespace FChoice.WebServices.Clarify.Protocols
{
	public class ToolkitResultProtocol
	{
		public ToolkitResultProtocol(){}
		internal ToolkitResultProtocol(FChoice.Toolkits.Clarify.ToolkitResult result)
		{
			this.ReturnCode = result.ReturnCode;
			this.IDNum = result.IDNum;
			this.Objid = result.Objid;
		}

		public short ReturnCode;
		public string IDNum;
		public int Objid;
	}
}
