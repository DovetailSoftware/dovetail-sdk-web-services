using System;
using System.Collections;
using System.Data;

using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class ClarifyDataAccessWS
	{
		private Protocol.ClarifyDataAccessSrv genericSrvProtocol;
		private ClarifySessionWS session;
		private ArrayList generics = new ArrayList();

		public ClarifyDataAccessWS(ClarifySessionWS session)
		{
			this.session = session;

			this.genericSrvProtocol = new Protocol.ClarifyDataAccessSrv();
			this.genericSrvProtocol.AuthenticationHeaderValue = new Protocol.AuthenticationHeader();
			this.genericSrvProtocol.AuthenticationHeaderValue.SessionID = session.SessionToken;
			this.genericSrvProtocol.Url = new Uri( session.BaseUri, "ClarifyDataAccessSrv.asmx" ).ToString();
		}

		public DataQuery CreateDataQuery(string objectName)
		{
			return CreateDataQuery( objectName, null );
		}

		public DataQuery CreateDataQuery(string objectName, string resultTableName)
		{
			if( objectName == null)
				throw new ArgumentNullException("objectName");

			DataQuery genWS = new DataQuery( this, objectName, resultTableName );

			this.generics.Add(genWS);
			return genWS;
		}

		public DataModifier CreateDataModifier()
		{
			return new DataModifier( this );
		}

		public string Query(DataQuery[] dataQueryItems)
		{
			return Query(dataQueryItems, false);
		}

		public string Query(DataQuery[] dataQueryItems, bool includeSchema)
		{
			Protocol.QueryProtocol[] protocolGenerics = 
				new Protocol.QueryProtocol[ dataQueryItems.Length ];

			int i = 0;
			foreach( DataQuery generic in dataQueryItems )
			{
				generic.QueryPreprocess();

				protocolGenerics[i] = generic.Protocol;
				i++;
			}

			return this.genericSrvProtocol.Query( protocolGenerics, includeSchema );
		}

		internal Protocol.ModifierResultProtocol[] Update(Protocol.ModifierProtocol[] protocolMods)
		{
			return this.genericSrvProtocol.Update( protocolMods );
		}

	}
}
