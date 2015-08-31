using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

using FChoice.Foundation.Clarify;

namespace FChoice.WebServices.Clarify.Protocols.Generic
{
	public class QueryProtocol
	{
		public string ResultTableName;
		public string ObjectName;
		public string TraverseRelation = "";

		public string[] DataFields;
		public FilterProtocol[] Filters;
		public FilterInListProtocol[] FiltersInList;
		public SortProtocol[] Sorts;
		public QueryProtocol[] ChildGenerics;

		[SoapIgnore]
		internal QueryProtocol Parent;
		[SoapIgnore]
		internal ClarifyGeneric ClarifyGeneric;
		[SoapIgnore]
		internal DataTable ResultDataTable;
	}
}
