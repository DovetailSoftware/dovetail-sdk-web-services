using System;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.Schema;
using FChoice.WebServices.Clarify.Protocols.Generic;

namespace FChoice.WebServices.Clarify
{
	internal class ClarifyGenericSrvQueryParser
	{
		private ClarifyDataSet dataSet;

		public ClarifyGenericSrvQueryParser( ClarifyDataSet dataSet )
		{
			if( dataSet == null)
				throw new ArgumentNullException("dataSet");

			this.dataSet = dataSet;
		}


		public void CreateGenerics( QueryProtocol[] queryItems )
		{
			if( queryItems == null)
				throw new ArgumentNullException("queryItems");

			ParseQueryItemsToGenerics( queryItems, null );
		}

		private void ParseQueryItemsToGenerics( QueryProtocol[] queryItems, QueryProtocol parentQueryItem )
		{
			bool isRootGeneric = parentQueryItem == null;

			foreach(QueryProtocol queryItem in queryItems)
			{
				if( isRootGeneric )
				{
					if(!ClarifyApplication.Instance.SchemaCache.IsValidTableOrView( queryItem.ObjectName ))
					{
						throw new ApplicationException(
							string.Format("'{0}' is not a table or view.", queryItem.ObjectName));
					}

					queryItem.ClarifyGeneric = this.dataSet.CreateGeneric( queryItem.ObjectName );
				}
				else
				{
					// Link up child / parents
					queryItem.Parent = parentQueryItem;

					if(!ClarifyApplication.Instance.SchemaCache.IsValidRelation( parentQueryItem.ObjectName, queryItem.TraverseRelation ))
					{
						throw new ApplicationException(
							string.Format("'{0}' is not a valid relation for object '{1}'.", queryItem.TraverseRelation, parentQueryItem.ObjectName));
					}

					SchemaRelation rel = ClarifyApplication.Instance.SchemaCache.GetRelation( 
						parentQueryItem.ObjectName, queryItem.TraverseRelation );

					if( parentQueryItem.ObjectName.ToLower() == rel.ChildTable.Name.ToLower() )
					{
						queryItem.ObjectName = rel.ParentTable.Name;
					}
					else
					{
						queryItem.ObjectName = rel.ChildTable.Name;
					}

					queryItem.ClarifyGeneric = parentQueryItem.ClarifyGeneric.Traverse(
						queryItem.TraverseRelation);
				}

				ParseQueryItem( queryItem );
			}
		}

		private void ParseQueryItem( QueryProtocol queryItem )
		{
			// Parse DataFields
			if( queryItem.DataFields != null )
			{
				foreach( string dataField in queryItem.DataFields)
					queryItem.ClarifyGeneric.DataFields.Add( dataField );
			}

			if( queryItem.Filters != null)
				ParseQueryItemFilters( queryItem );

			if( queryItem.FiltersInList != null)
				ParseQueryItemFiltersInList( queryItem );

			if( queryItem.Sorts != null)
				ParseQueryItemSorts( queryItem );

			if( queryItem.ChildGenerics != null)
				ParseQueryItemsToGenerics( queryItem.ChildGenerics, queryItem );
		}

		private void ParseQueryItemFilters( QueryProtocol queryItem )
		{
			foreach( FilterProtocol filter in queryItem.Filters )
			{
				if( !ClarifyApplication.Instance.SchemaCache.IsValidField( 
					queryItem.ObjectName, filter.Field ) )
				{
					throw new ApplicationException(string.Format("'{0}' is not a valid field for object '{1}'.", 
						filter.Field, queryItem.ObjectName));
				}

				SchemaFieldBase field = ClarifyApplication.Instance.SchemaCache.GetField( queryItem.ObjectName, filter.Field );

				NumberOps numberOp;
				switch( field.CommonType )
				{
					case (int)SchemaCommonType.String:
						StringOps strOp = (StringOps)GetParsedFilterOperation( typeof(StringOps), filter, queryItem.ObjectName );
						queryItem.ClarifyGeneric.AppendFilter( filter.Field, strOp, filter.Value );
						break;

					case (int)SchemaCommonType.Date:
						DateOps dateOp = (DateOps)GetParsedFilterOperation( typeof(DateOps), filter, queryItem.ObjectName );
						DateTime dateVal = GetParsedFilterValueToDateTime( filter, queryItem.ObjectName );

						queryItem.ClarifyGeneric.AppendFilter( filter.Field, dateOp, dateVal );
						break;

					case (int)SchemaCommonType.Float:
					case (int)SchemaCommonType.Double:
					case (int)SchemaCommonType.Decimal:
						numberOp = (NumberOps)GetParsedFilterOperation( typeof(NumberOps), filter, queryItem.ObjectName );
						Decimal decVal = GetParsedFilterValueToDecimal( filter, queryItem.ObjectName );

						queryItem.ClarifyGeneric.AppendFilter( filter.Field, numberOp, decVal );
						break;

					case (int)SchemaCommonType.Integer:
						numberOp = (NumberOps)GetParsedFilterOperation( typeof(NumberOps), filter, queryItem.ObjectName );
						int intVal = GetParsedFilterValueToInetger( filter, queryItem.ObjectName );

						queryItem.ClarifyGeneric.AppendFilter( filter.Field, numberOp, intVal );
						break;

					default:
						throw new InvalidOperationException(string.Format("Parse logic not implemented for SchemaCommonType.{0}", field.CommonType));
				}

			}
		}

		private void ParseQueryItemFiltersInList( QueryProtocol queryItem )
		{
			foreach( FilterInListProtocol filter in queryItem.FiltersInList )
			{
				if( !ClarifyApplication.Instance.SchemaCache.IsValidField( 
					queryItem.ObjectName, filter.Field ) )
				{
					throw new ApplicationException(string.Format("'{0}' is not a valid field for object '{1}'.", 
						filter.Field, queryItem.ObjectName));
				}

				SchemaFieldBase field = ClarifyApplication.Instance.SchemaCache.GetField( queryItem.ObjectName, filter.Field );

				switch( field.CommonType )
				{
					case (int)SchemaCommonType.String:
						queryItem.ClarifyGeneric.AppendFilterInList( filter.Field, filter.IsIn, filter.Values );
						break;

					case (int)SchemaCommonType.Date:
						DateTime[] dateVals = GetParsedFilterInListValueToDateTime( filter, queryItem.ObjectName );

						queryItem.ClarifyGeneric.AppendFilterInList( filter.Field, filter.IsIn, dateVals );
						break;

					case (int)SchemaCommonType.Float:
					case (int)SchemaCommonType.Double:
					case (int)SchemaCommonType.Decimal:
						Decimal[] decVals = GetParsedFilterInListValueToDecimal( filter, queryItem.ObjectName );

						queryItem.ClarifyGeneric.AppendFilterInList( filter.Field, filter.IsIn, decVals );
						break;

					case (int)SchemaCommonType.Integer:
						int[] intVals = GetParsedFilterInListValueToInetger( filter, queryItem.ObjectName );

						queryItem.ClarifyGeneric.AppendFilterInList( filter.Field, filter.IsIn, intVals );
						break;

					default:
						throw new InvalidOperationException(string.Format("Parse logic not implemented for SchemaCommonType.{0}", field.CommonType));
				}

			}
		}


		#region Parse Filter helper methods

		private object GetParsedFilterOperation(Type opEnum, FilterProtocol filter, string tableName)
		{
			try
			{
				return Enum.Parse( opEnum, filter.Operation, true );
			}
			catch(ArgumentException ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse operation '{0}' as an op enum '{1}' for field '{2}' on object '{3}'.", 
					filter.Operation, opEnum, filter.Field, tableName), ex );
			}
		}


		private DateTime GetParsedFilterValueToDateTime(FilterProtocol filter, string tableName)
		{
			try
			{
				return DateTime.Parse( filter.Value );
			}
			catch(Exception ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse value '{0}' as a DateTime for field '{1}' on object '{2}'.", 
					filter.Value, filter.Field, tableName), ex );
			}
		}

		private decimal GetParsedFilterValueToDecimal(FilterProtocol filter, string tableName)
		{
			try
			{
				return decimal.Parse( filter.Value );
			}
			catch(Exception ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse value '{0}' as a Decimal for field '{1}' on object '{2}'.", 
					filter.Value, filter.Field, tableName), ex );
			}
		}

		private int GetParsedFilterValueToInetger(FilterProtocol filter, string tableName)
		{
			try
			{
				return int.Parse( filter.Value );
			}
			catch(Exception ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse value '{0}' as an Integer for field '{1}' on object '{2}'.", 
					filter.Value, filter.Field, tableName), ex );
			}
		}

		#endregion

		#region Parse FilterInList helper methods

		private DateTime[] GetParsedFilterInListValueToDateTime(FilterInListProtocol filter, string tableName)
		{
			DateTime[] dates = new DateTime[filter.Values.Length];

			try
			{
				int i = 0;
				foreach(string val in filter.Values)
				{
					dates[i] = DateTime.Parse(val);
					i++;
				}

				return dates;
			}
			catch(Exception ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse values '{0}' as a DateTime[] for field '{1}' on object '{2}'.", 
					string.Join(",", filter.Values), 
					filter.Field, tableName), ex );
			}
		}

		private decimal[] GetParsedFilterInListValueToDecimal(FilterInListProtocol filter, string tableName)
		{
			decimal[] decs = new decimal[filter.Values.Length];
			try
			{
				int i = 0;
				foreach(string val in filter.Values)
				{
					decs[i] = decimal.Parse(val);
					i++;
				}

				return decs;
			}
			catch(Exception ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse values '{0}' as a decimal[] for field '{1}' on object '{2}'.", 
					string.Join(",", filter.Values), 
					filter.Field, tableName), ex );
			}
		}

		private int[] GetParsedFilterInListValueToInetger(FilterInListProtocol filter, string tableName)
		{
			int[] ints = new int[filter.Values.Length];

			try
			{
				int i = 0;
				foreach(string val in filter.Values)
				{
					ints[i] = int.Parse(val);
					i++;
				}

				return ints;
			}
			catch(Exception ex)
			{
				throw new ApplicationException(
					string.Format("Could not parse values '{0}' as a int[] for field '{1}' on object '{2}'.", 
					string.Join(",", filter.Values), 
					filter.Field, tableName), ex );
			}
		}

		#endregion
		
		private void ParseQueryItemSorts( QueryProtocol queryItem )
		{
			foreach(SortProtocol sort in queryItem.Sorts)
			{
				if( !ClarifyApplication.Instance.SchemaCache.IsValidField( 
					queryItem.ObjectName, sort.Field ) )
				{
					throw new ApplicationException(string.Format("'{0}' is not a valid field for object '{0}'.", 
						sort.Field, queryItem.ObjectName));
				}

				queryItem.ClarifyGeneric.AppendSort(sort.Field, sort.IsAscending);
			}
		}
	}
}
