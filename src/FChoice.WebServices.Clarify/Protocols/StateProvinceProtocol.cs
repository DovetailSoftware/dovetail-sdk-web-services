using System;

using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.WebServices.Clarify.Protocols
{

	[Serializable]
	public class StateProvinceProtocol
	{
		public StateProvinceProtocol(){}

		public StateProvinceProtocol(StateProvince state)
		{
			this.Name = state.Name;
			this.FullName = state.FullName;
			this.IsDefault = state.IsDefault;
			this.ObjectID = state.ObjectID;
		}

		public string Name;
		public string FullName;
		public bool IsDefault;
		public int ObjectID;

		public static StateProvinceProtocol[] ConvertCollection(StateCollection states)
		{
			StateProvinceProtocol[] protoStates = new StateProvinceProtocol[states.Count];

			for(int i = 0; i < states.Count; i++ )
			{
				protoStates[i] = new StateProvinceProtocol( states[i] );
			}


			return protoStates;
		}

	}
}
