using System;
using System.Collections;
using System.Data;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.Schema;
using FChoice.WebServices.Clarify.Protocols.Generic;

namespace FChoice.WebServices.Clarify
{
	internal class ClarifyGenericSrvQuery
	{
		private ClarifyDataSet dataSet;

		public ClarifyGenericSrvQuery(ClarifySession session)
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}

			dataSet = new ClarifyDataSet(session);
		}


		public DataSet ExecuteDataSet(QueryProtocol[] queryItems)
		{
			if (queryItems == null)
				throw new ArgumentNullException("queryItems");

			ClarifyGenericSrvQueryParser parser = new ClarifyGenericSrvQueryParser(dataSet);
			parser.CreateGenerics(queryItems);

			// run generic query
			dataSet.Query(GetRootGenericsToQuery(queryItems));

			DataSet ds = new DataSet("ClarifyGenericQuery");

			CreateDataTables(ds, queryItems);
			FillDataTables(ds, queryItems, null, null);


			return ds;
		}

		private ClarifyGeneric[] GetRootGenericsToQuery(QueryProtocol[] queryItems)
		{
			ClarifyGeneric[] generics = new ClarifyGeneric[queryItems.Length];

			for (int i = 0; i < generics.Length; i++)
				generics[i] = queryItems[i].ClarifyGeneric;

			return generics;
		}

		private void FillDataTables(DataSet ds, QueryProtocol[] queryItems, ClarifyDataRow parentClarifyRow, DataRow parentRow)
		{
			foreach (QueryProtocol queryItem in queryItems)
			{
				FillDataTable(ds, queryItem, parentClarifyRow, parentRow);
			}
		}

		private void FillDataTable(DataSet ds, QueryProtocol queryItem, ClarifyDataRow parentClarifyRow, DataRow parentRow)
		{
			IEnumerator clarifyRowEnumerator;

			if (parentClarifyRow == null)
			{
				clarifyRowEnumerator = queryItem.ClarifyGeneric.Rows.GetEnumerator();
			}
			else
			{
				clarifyRowEnumerator = parentClarifyRow.RelatedRows(queryItem.ClarifyGeneric).GetEnumerator();
			}

			while (clarifyRowEnumerator.MoveNext())
			{
				ClarifyDataRow clarifyRow = (ClarifyDataRow) clarifyRowEnumerator.Current;

				DataRow row = queryItem.ResultDataTable.NewRow();
				queryItem.ResultDataTable.Rows.Add(row);

				for (int t = 0; t < row.Table.Columns.Count; t++)
				{
					if (row.Table.Columns[t].ColumnName == "_parentid")
						row[t] = parentRow["_id"];
					else if (row.Table.Columns[t].ColumnName != "_id")
						row[t] = clarifyRow[row.Table.Columns[t].ColumnName];
				}

				if (queryItem.ChildGenerics != null)
					FillDataTables(ds, queryItem.ChildGenerics, clarifyRow, row);
			}
		}

		#region Create query result DataSet Schema helper methods

		private void CreateDataTables(DataSet ds, QueryProtocol[] queryItems)
		{
			foreach (QueryProtocol queryItem in queryItems)
			{
				CreateDataTable(ds, queryItem);
			}
		}

		private void CreateDataTable(DataSet ds, QueryProtocol queryItem)
		{
			queryItem.ResultDataTable = new DataTable(GetTableName(queryItem));
			ds.Tables.Add(queryItem.ResultDataTable);

			SchemaFieldBase[] fields = GetTableFields(queryItem.ObjectName, queryItem.DataFields);

			DataColumn column;

			foreach (SchemaFieldBase field in fields)
			{
				column = queryItem.ResultDataTable.Columns.Add(field.Name, field.ObjectType);
				column.ColumnMapping = MappingType.Attribute;
			}

			column = queryItem.ResultDataTable.Columns.Add("_id", typeof (int));
			column.ColumnMapping = MappingType.Hidden;
			column.AutoIncrement = true;
			column.Unique = true;

			if (queryItem.Parent != null)
			{
				column = queryItem.ResultDataTable.Columns.Add("_parentid", typeof (int));
				column.ColumnMapping = MappingType.Hidden;

				DataRelation dataRel = new DataRelation(
					queryItem.TraverseRelation,
					queryItem.Parent.ResultDataTable.Columns["_id"],
					queryItem.ResultDataTable.Columns["_parentid"], false);

				dataRel.Nested = true;
				ds.Relations.Add(dataRel);
			}

			if (queryItem.ChildGenerics != null)
				CreateDataTables(ds, queryItem.ChildGenerics);
		}

		private string GetTableName(QueryProtocol queryItem)
		{
			return queryItem.ResultTableName != null
			       && queryItem.ResultTableName.Trim().Length > 0
			       	? queryItem.ResultTableName.Trim()
			       	: queryItem.ObjectName.Trim();
		}

		private SchemaFieldBase[] GetTableFields(string tableName, string[] fieldNames)
		{
			SchemaTableBase table = ClarifyApplication.Instance.SchemaCache.GetTableOrView(tableName);

			ArrayList fields = new ArrayList();

			foreach (SchemaFieldBase field in table.Fields)
			{
				if (fieldNames == null || fieldNames.Length == 0)
					fields.Add(field);
				else
				{
					foreach (string fieldName in fieldNames)
					{
						if (field.Name.ToLower() == fieldName)
						{
							fields.Add(field);
							break;
						}
					}
				}
			}

			return (SchemaFieldBase[]) fields.ToArray(typeof (SchemaFieldBase));
		}

		#endregion
	}
}