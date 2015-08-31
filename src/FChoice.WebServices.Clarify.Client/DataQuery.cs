using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Services;

using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client
{
	public class DataQuery
	{
		private Protocol.QueryProtocol genericProtocol;
		private ClarifyDataAccessWS clarifyDataAccessWS;

		private StringCollection dataFields = new StringCollection();
		private ArrayList filters = new ArrayList();
		private ArrayList filtersInList = new ArrayList();
		private ArrayList sorts = new ArrayList();
		private ArrayList childGenerics = new ArrayList();


		// constructor for root generics
		internal DataQuery( ClarifyDataAccessWS clarifyDataAccessWS, string objectName ) : this ( clarifyDataAccessWS, objectName, null ){}
		internal DataQuery( ClarifyDataAccessWS clarifyDataAccessWS, string objectName, string resultTableName )
		{
			this.clarifyDataAccessWS = clarifyDataAccessWS;
			genericProtocol = new Protocol.QueryProtocol();
			genericProtocol.ObjectName = objectName;
			genericProtocol.ResultTableName = resultTableName;
		}

		// factory methods for child generics
		private static DataQuery CreateTraverse( ClarifyDataAccessWS clarifyDataAccessWS, string traverseRelation, string resultTableName )
		{
			DataQuery gen = new DataQuery( clarifyDataAccessWS, null, resultTableName );
			gen.Protocol.TraverseRelation = traverseRelation;
			return gen;
		}

		internal Protocol.QueryProtocol Protocol
		{
			get{ return this.genericProtocol;}
		}

		public StringCollection DataFields
		{
			get{ return this.dataFields; }
		}

		public void AppendFilter(string field, string operation, string value)
		{
			if( field == null)
				throw new ArgumentNullException("field");

			if( operation == null)
				throw new ArgumentNullException("operation");

			if( value == null)
				throw new ArgumentNullException("value");

			Protocol.FilterProtocol filter = new Protocol.FilterProtocol();

			filter.Field = field;
			filter.Operation = operation;
			filter.Value = value;

			this.filters.Add( filter );
		}

		public void AppendFilterInList(string field, bool isIn, string[] values)
		{
			if( field == null)
				throw new ArgumentNullException("field");

			if( values == null)
				throw new ArgumentNullException("values");

			Protocol.FilterInListProtocol filter = new Protocol.FilterInListProtocol();

			filter.Field = field;
			filter.IsIn = isIn;
			filter.Values = values;

			this.filtersInList.Add( filter );
		}

		public void AppendSort(string field, bool isAscending)
		{
			if( field == null)
				throw new ArgumentNullException("field");

			Protocol.SortProtocol sort = new Protocol.SortProtocol();

			sort.Field = field;
			sort.IsAscending = isAscending;

			this.sorts.Add( sort );
		}

		public DataQuery Traverse(string relation)
		{
			if( relation == null)
				throw new ArgumentNullException("relation");

			return this.Traverse( relation, null );
		}

		public DataQuery Traverse(string relation, string resultTableName)
		{
			if( relation == null)
				throw new ArgumentNullException("relation");

			DataQuery child = CreateTraverse( this.clarifyDataAccessWS, relation, resultTableName );
			this.childGenerics.Add( child );

			return child;
		}

		public string Query()
		{
			return Query(false);
		}

		public string Query(bool includeSchema)
		{
			return this.clarifyDataAccessWS.Query( new DataQuery[]{ this }, includeSchema );
		}

		internal void QueryPreprocess()
		{
			string[] fields = new string[this.dataFields.Count];
			this.dataFields.CopyTo( fields, 0 );

			this.genericProtocol.DataFields = fields;

			if( this.filters.Count > 0 )
			{
				this.genericProtocol.Filters = 
					(Protocol.FilterProtocol[])this.filters.ToArray( typeof(Protocol.FilterProtocol) );
			}

			if( this.filtersInList.Count > 0 )
			{
				this.genericProtocol.FiltersInList = 
					(Protocol.FilterInListProtocol[])this.filtersInList.ToArray( typeof(Protocol.FilterInListProtocol) );
			}

			if( this.sorts.Count > 0 )
			{
				this.genericProtocol.Sorts = 
					(Protocol.SortProtocol[])this.sorts.ToArray( typeof(Protocol.SortProtocol) );
			}

			if( this.childGenerics.Count > 0 )
			{
				this.genericProtocol.ChildGenerics = new Protocol.QueryProtocol[ this.childGenerics.Count ];

				int i = 0;
				foreach(DataQuery child in this.childGenerics)
				{
					this.genericProtocol.ChildGenerics[i] = child.Protocol;
					child.QueryPreprocess();

					i++;
				}
			}

		}

	}
}
