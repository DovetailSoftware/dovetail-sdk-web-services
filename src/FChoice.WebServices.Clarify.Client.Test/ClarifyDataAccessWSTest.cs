using System;
using System.Data;
using System.IO;
using System.Web.Services.Protocols;
using FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;
using NUnit.Framework;
using SupportProto = FChoice.WebServices.Clarify.Client.Protocols.SupportToolkitSrv;
using InterfacesProto = FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv;

namespace FChoice.WebServices.Clarify.Client.Test
{
	//[TestFixture]
	//public class ClarifyDataAccessWSTest : WebservicesTest
	//{
	//	//[Test]
	//	public void ForDocs_1()
	//	{
	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		//	Get all sites whose 'type' is 1 and sort by site ID, descending
	//		DataQuery siteQuery = clarifyDA.CreateDataQuery("site");
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});
	//		siteQuery.AppendFilter("type", "Equals", "1");
	//		siteQuery.AppendSort("site_id", false);

	//		// Now query the data and return the result
	//		string result = siteQuery.Query();

	//		// Output the result to the console
	//		Console.WriteLine(result);
	//	}

	//	//[Test]
	//	public void ForDocs_2()
	//	{
	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		//	Get all sites whose 'type' is 1 and sort by site ID, descending
	//		DataQuery siteQuery = clarifyDA.CreateDataQuery("site");
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});
	//		siteQuery.AppendFilter("type", "Equals", "1");
	//		siteQuery.AppendSort("site_id", false);

	//		// Now query the data and return the result with schema information
	//		string result = siteQuery.Query(true);

	//		// Create a string reader to read the result
	//		StringReader reader = new StringReader(result);

	//		// Create and load the DataSet with the result
	//		DataSet ds = new DataSet();
	//		ds.ReadXml(reader);

	//		// Get the site table from the DataSet
	//		Assert.IsNotNull(ds.Tables["site"]);
	//	}

	//	//[Test]
	//	public void ForDocs_3()
	//	{
	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		//	Get all sites whose 'type' is 1 and sort by site ID, descending
	//		DataQuery siteQuery = clarifyDA.CreateDataQuery("site");
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});
	//		siteQuery.AppendFilter("type", "Equals", "1");
	//		siteQuery.AppendSort("site_id", false);

	//		//	Get the primary address for the site by doing a traverse
	//		DataQuery addressQuery = siteQuery.Traverse("cust_primaddr2address");

	//		// Specify Data Fields to return
	//		addressQuery.DataFields.AddRange(new string[] {"address", "city", "state", "zipcode"});

	//		// Now query the data and return the result
	//		string result = siteQuery.Query();

	//		// Output the result to the console
	//		Console.WriteLine(result);
	//	}

	//	//[Test]
	//	public void ForDocs_4()
	//	{
	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		//	Get the address
	//		DataQuery addressQuery = clarifyDA.CreateDataQuery("address");

	//		// Specify Data Fields to return and filters
	//		addressQuery.DataFields.AddRange(new string[] {"objid", "address", "city", "state", "zipcode"});
	//		addressQuery.AppendFilter("objid", "Equals", "268435473");

	//		//  Traverse from address and get all sites whose 'type' is 1 and sort by site ID, descending
	//		DataQuery siteQuery = addressQuery.Traverse("primary_addr2site");
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});
	//		siteQuery.AppendFilter("type", "Equals", "1");
	//		siteQuery.AppendSort("site_id", false);

	//		// Now query the data and return the result
	//		string result = addressQuery.Query();

	//		// Output the result to the console
	//		Console.WriteLine(result);
	//	}

	//	//[Test]
	//	public void ForDocs_5()
	//	{
	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		//	Get all sites whose 'type' is 1 and sort by site ID, descending
	//		DataQuery siteQuery = clarifyDA.CreateDataQuery("site");
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});
	//		siteQuery.AppendFilter("type", "Equals", "1");
	//		siteQuery.AppendSort("site_id", false);

	//		//	Get the addresses and specify names for result tables
	//		DataQuery primaryAddress = siteQuery.Traverse("cust_primaddr2address", "primaryAddress");
	//		DataQuery shipAddress = siteQuery.Traverse("cust_shipaddr2address", "shipAddress");
	//		DataQuery billAddress = siteQuery.Traverse("cust_billaddr2address", "billAddress");

	//		// Specify Data Fields to return
	//		primaryAddress.DataFields.AddRange(new string[] {"address", "city", "state", "zipcode"});
	//		shipAddress.DataFields.AddRange(new string[] {"address", "city", "state", "zipcode"});
	//		billAddress.DataFields.AddRange(new string[] {"address", "city", "state", "zipcode"});

	//		// Now query the data and return the result
	//		string result = siteQuery.Query();

	//		// Output the result to the console
	//		Console.WriteLine(result);
	//	}

	//	//[Test]
	//	public void ForDocs_6()
	//	{
	//		// Get next id number for site
	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");

	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		// Create an instance of the data modifier client
	//		DataModifier modifier = clarifyDA.CreateDataModifier();

	//		// Create InsertModifier to insert a new record
	//		InsertModifier siteInsert = modifier.CreateInsertModifier("mysite", "site");

	//		// Specify values for fields
	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "My test site");
	//		siteInsert.SetField("type", "1");

	//		// Execute the database modifications and get the results
	//		ModifierResultProtocol[] insertResults = modifier.Update();

	//		// Loop through each result and write information to the console
	//		foreach (ModifierResultProtocol result in insertResults)
	//		{
	//			Console.WriteLine(
	//				string.Format("Action:{0}, Table:{1}, Name:{2}, Objid:{3}",
	//							  result.Action, result.Table, result.Name, result.Objid));
	//		}
	//	}

	//	//[Test]
	//	public void ForDocs_7()
	//	{
	//		// Get next id number for site and case
	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");
	//		string caseIDNum = _clarifySessionWS.GetNextNumScheme("Case ID");

	//		// Create an instance of data access client using a valid client _clarifySessionWS
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		// Create an instance of the data modifier client
	//		DataModifier modifier = clarifyDA.CreateDataModifier();

	//		// Create InsertModifiers to insert a new records
	//		InsertModifier siteInsert = modifier.CreateInsertModifier("mysite", "site");
	//		InsertModifier caseInsert = modifier.CreateInsertModifier("mycase", "case");

	//		// Set site fields
	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "My site test");
	//		siteInsert.SetField("type", "1");

	//		// Relate site to case
	//		siteInsert.RelateRecord("cust_loc2case", caseInsert);

	//		// Set case fields
	//		caseInsert.SetField("title", "Test from docs");
	//		caseInsert.SetField("id_number", caseIDNum);

	//		// Execute the database modifications and get the results
	//		ModifierResultProtocol[] insertResults = modifier.Update();

	//		// Loop through each result and write information to the console
	//		foreach (ModifierResultProtocol result in insertResults)
	//		{
	//			Console.WriteLine(
	//				string.Format("Action:{0}, Table:{1}, Name:{2}, Objid:{3}",
	//							  result.Action, result.Table, result.Name, result.Objid));
	//		}
	//	}

	//	//[Test]
	//	public void ForDocs_8()
	//	{
	//		int siteObjid = 0;
	//		int caseObjid = 0;

	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");
	//		string caseIDNum = _clarifySessionWS.GetNextNumScheme("Case ID");

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		InsertModifier siteInsert = modifierWS1.CreateInsertModifier("mysite", "site");
	//		InsertModifier caseInsert = modifierWS1.CreateInsertModifier("mycase", "case");

	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "unit test");
	//		siteInsert.SetField("type", "1");
	//		siteInsert.RelateRecord("cust_loc2case", caseInsert);

	//		caseInsert.SetField("title", "Test from nunit");
	//		caseInsert.SetField("id_number", caseIDNum);

	//		ModifierResultProtocol[] insertResults = modifierWS1.Update();

	//		foreach (ModifierResultProtocol result in insertResults)
	//		{
	//			if (result.Table == "case")
	//				caseObjid = result.Objid;

	//			if (result.Table == "site")
	//				siteObjid = result.Objid;
	//		}

	//		Assert.IsTrue(_utility.QueryTableByObjid("site", siteObjid).Rows.Count == 1);
	//		Assert.IsTrue(_utility.QueryTableByObjid("case", caseObjid).Rows.Count == 1);


	//		// Create an instance of the data modifier client
	//		DataModifier modifier = clarifyDA.CreateDataModifier();

	//		// Create modifier for updating site and reference a case
	//		UpdateModifier siteUpdate = modifier.CreateUpdateModifier("mysite", "site");
	//		ReferenceModifier caseUpdateRef = modifier.CreateReferenceModifier("mycase", "case");

	//		// Set field to update on site
	//		siteUpdate.SetField("name", "new title from nunit");

	//		// Add a unique relation by case
	//		siteUpdate.AppendUniqueRelation("case_reporter2site", caseUpdateRef);

	//		// Add a unique filter by case objid
	//		caseUpdateRef.AppendUniqueFilter("objid", caseObjid);

	//		// Execute the database modifications and get the results
	//		ModifierResultProtocol[] updateResults = modifier.Update();

	//		// Loop through each result and write information to the console
	//		foreach (ModifierResultProtocol result in updateResults)
	//		{
	//			Console.WriteLine(
	//				string.Format("Action:{0}, Table:{1}, Name:{2}, Objid:{3}",
	//							  result.Action, result.Table, result.Name, result.Objid));
	//		}
	//	}
		
	//	[Test]
	//	public void SimpleQuery()
	//	{
	//		string caseIDNum = _utility.CreateCase();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilter("id_number", "Equals", caseIDNum);

	//		DataSet ds = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds.Tables["case"];

	//		Assert.AreEqual(1, caseTable.Rows.Count);
	//		Assert.AreEqual(caseIDNum, caseTable.Rows[0]["id_number"]);
	//		Assert.IsTrue(caseTable.Columns.Count > 5);
	//	}

	//	[Test]
	//	public void SimpleQuery_SortAscending()
	//	{
	//		string[] caseIDNums = new string[] {_utility.CreateCase(), _utility.CreateCase(), _utility.CreateCase()};

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilterInList("id_number", true, caseIDNums);
	//		caseQuery.AppendSort("id_number", true);

	//		DataSet ds = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds.Tables["case"];

	//		Assert.AreEqual(3, caseTable.Rows.Count);
	//		Assert.AreEqual(caseIDNums[0], caseTable.Rows[0]["id_number"]);
	//		Assert.AreEqual(caseIDNums[1], caseTable.Rows[1]["id_number"]);
	//		Assert.AreEqual(caseIDNums[2], caseTable.Rows[2]["id_number"]);
	//	}

	//	[Test]
	//	public void SimpleQuery_SortDecending()
	//	{
	//		string[] caseIDNums = new string[] {_utility.CreateCase(), _utility.CreateCase(), _utility.CreateCase()};

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilterInList("id_number", true, caseIDNums);
	//		caseQuery.AppendSort("id_number", false);

	//		DataSet ds = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds.Tables["case"];

	//		Assert.AreEqual(3, caseTable.Rows.Count);
	//		Assert.AreEqual(caseIDNums[0], caseTable.Rows[2]["id_number"]);
	//		Assert.AreEqual(caseIDNums[1], caseTable.Rows[1]["id_number"]);
	//		Assert.AreEqual(caseIDNums[2], caseTable.Rows[0]["id_number"]);
	//	}

	//	[Test]
	//	public void SimpleQuery_SpecifyColumns()
	//	{
	//		string caseIDNum = _utility.CreateCase();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.DataFields.AddRange(new string[] {"objid", "title", "id_number", "creation_time"});
	//		caseQuery.AppendFilter("id_number", "Equals", caseIDNum);

	//		DataSet ds = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds.Tables["case"];

	//		Assert.AreEqual(1, caseTable.Rows.Count);
	//		Assert.IsTrue(caseTable.Columns.Count > 4);
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void SimpleQuery_InvalidColumns()
	//	{
	//		string caseIDNum = _utility.CreateCase();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.DataFields.AddRange(new string[] {"objid2", "title", "id_number", "creation_time"});
	//		caseQuery.AppendFilter("id_number", "Equals", caseIDNum);

	//		caseQuery.Query(true);
	//	}

	//	[Test]
	//	public void TraverseQuery()
	//	{
	//		string[] caseIDNums = new string[] {_utility.CreateCase(), _utility.CreateCase(), _utility.CreateCase()};

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		DataQuery siteQuery = caseQuery.Traverse("case_reporter2site");

	//		caseQuery.DataFields.AddRange(new string[] {"objid", "title", "id_number", "creation_time"});
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});

	//		caseQuery.AppendFilterInList("id_number", true, caseIDNums);

	//		DataSet ds = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds.Tables["case"];
	//		DataTable siteTable = ds.Tables["site"];

	//		Assert.AreEqual(3, caseTable.Rows.Count);
	//		Assert.AreEqual(3, siteTable.Rows.Count);
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void TraverseQuery_InvalidRelation()
	//	{
	//		string[] caseIDNums = new string[] {_utility.CreateCase(), _utility.CreateCase(), _utility.CreateCase()};

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		DataQuery siteQuery = caseQuery.Traverse("case_reporter2site2");

	//		caseQuery.DataFields.AddRange(new string[] {"objid", "title", "id_number", "creation_time"});
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});

	//		caseQuery.AppendFilterInList("id_number", true, caseIDNums);

	//		caseQuery.Query(true);
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void DuplicateTables_Neg()
	//	{
	//		string[] caseIDNums = new string[] {_utility.CreateCase(), _utility.CreateCase(), _utility.CreateCase()};

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		DataQuery siteQuery = caseQuery.Traverse("case_reporter2site");
	//		DataQuery caseQuery2 = siteQuery.Traverse("cust_loc2case");

	//		caseQuery.DataFields.AddRange(new string[] {"objid", "title", "id_number", "creation_time"});
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});

	//		caseQuery.AppendFilterInList("id_number", true, caseIDNums);

	//		caseQuery.Query(true);
	//	}

	//	[Test]
	//	public void DuplicateTables()
	//	{
	//		string[] caseIDNums = new string[] {_utility.CreateCase(), _utility.CreateCase(), _utility.CreateCase()};

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		DataQuery siteQuery = caseQuery.Traverse("case_reporter2site");
	//		DataQuery caseQuery2 = siteQuery.Traverse("cust_loc2case", "case2");

	//		caseQuery.DataFields.AddRange(new string[] {"objid", "title", "id_number", "creation_time"});
	//		siteQuery.DataFields.AddRange(new string[] {"objid", "site_id", "name"});

	//		caseQuery.AppendFilterInList("id_number", true, caseIDNums);

	//		DataSet ds = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds.Tables["case"];
	//		DataTable siteTable = ds.Tables["site"];
	//		DataTable case2Table = ds.Tables["case2"];

	//		Assert.AreEqual(3, caseTable.Rows.Count);
	//		Assert.AreEqual(3, siteTable.Rows.Count);
	//		Assert.AreEqual(3, case2Table.Rows.Count);
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void InvalidStringOp()
	//	{
	//		string caseIDNum = _utility.CreateCase();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilter("id_number", "MaybeEquals", caseIDNum);

	//		caseQuery.Query(true);
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void InvalidNumberOp()
	//	{
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilter("objid", "MaybeEquals", "123");

	//		caseQuery.Query(true);
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void InvalidIntValue()
	//	{
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilter("objid", "Equals", "ABC");

	//		caseQuery.Query(true);
	//	}

	//	[Test]
	//	public void MultipleRootGenerics()
	//	{
	//		string caseIDNum = _utility.CreateCase();
	//		string siteIDNum = _utility.CreateSite();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilter("id_number", "Equals", caseIDNum);

	//		DataQuery siteQuery = clarifyDA.CreateDataQuery("site");
	//		siteQuery.AppendFilter("site_id", "Equals", siteIDNum);

	//		DataSet ds1 = _utility.GetDataSetFromXml(caseQuery.Query(true));

	//		DataTable caseTable = ds1.Tables["case"];

	//		Assert.IsTrue(!ds1.Tables.Contains("site"));
	//		Assert.AreEqual(1, caseTable.Rows.Count);
	//		Assert.AreEqual(caseIDNum, caseTable.Rows[0]["id_number"]);

	//		DataSet ds2 = _utility.GetDataSetFromXml(siteQuery.Query(true));

	//		DataTable siteTable = ds2.Tables["site"];

	//		Assert.IsTrue(!ds2.Tables.Contains("case"));
	//		Assert.AreEqual(1, siteTable.Rows.Count);
	//		Assert.AreEqual(siteIDNum, siteTable.Rows[0]["site_id"]);
	//	}

	//	[Test]
	//	public void MultipleRootGenerics_QueryAllAtOnce()
	//	{
	//		string caseIDNum = _utility.CreateCase();
	//		string siteIDNum = _utility.CreateSite();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");
	//		caseQuery.AppendFilter("id_number", "Equals", caseIDNum);

	//		DataQuery siteQuery = clarifyDA.CreateDataQuery("site");
	//		siteQuery.AppendFilter("site_id", "Equals", siteIDNum);

	//		DataSet ds1 = _utility.GetDataSetFromXml(clarifyDA.Query(new DataQuery[] {caseQuery, siteQuery}));

	//		DataTable caseTable = ds1.Tables["case"];
	//		DataTable siteTable = ds1.Tables["site"];

	//		Assert.AreEqual(1, caseTable.Rows.Count);
	//		Assert.AreEqual(caseIDNum, caseTable.Rows[0]["id_number"]);
	//		Assert.AreEqual(1, siteTable.Rows.Count);
	//		Assert.AreEqual(siteIDNum, siteTable.Rows[0]["site_id"]);
	//	}

	//	[Test]
	//	public void SimpleInsertUpdateDelete()
	//	{
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		// insert
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();
	//		InsertModifier insert = modifierWS1.CreateInsertModifier("CaseInsert", "case");
	//		insert.SetField("pickup_ext", "222");
	//		insert.SetField("title", "Test from NUnit");
	//		insert.SetField("id_number", Guid.NewGuid().ToString());

	//		ModifierResultProtocol[] results = modifierWS1.Update();
	//		int caseObjid = results[0].Objid;
	//		Assert.IsTrue(caseObjid > 0, "record did not insert");
	//		Assert.AreEqual(results[0].Name, "CaseInsert");
	//		Assert.AreEqual(results[0].Action, "Insert");
	//		Assert.AreEqual(results[0].Table, "case");


	//		//	update
	//		DataModifier modifierWS2 = clarifyDA.CreateDataModifier();
	//		UpdateModifier update = modifierWS2.CreateUpdateModifier("CaseUpdate", "case");
	//		update.SetField("pickup_ext", "223");
	//		update.AppendUniqueFilter("objid", caseObjid.ToString());

	//		ModifierResultProtocol[] updateResults = modifierWS2.Update();
	//		Assert.AreEqual(updateResults[0].Name, "CaseUpdate");
	//		Assert.AreEqual(updateResults[0].Objid, caseObjid);
	//		Assert.AreEqual(updateResults[0].Action, "Update");
	//		Assert.AreEqual(updateResults[0].Table, "case");


	//		//	delete
	//		DataModifier modifierWS3 = clarifyDA.CreateDataModifier();
	//		DeleteModifier delete = modifierWS3.CreateDeleteModifier("CaseDelete", "case");
	//		delete.AppendUniqueFilter("objid", caseObjid.ToString());
	//		delete.AppendUniqueFilter("pickup_ext", "223");

	//		ModifierResultProtocol[] deleteResults = modifierWS3.Update();
	//		Assert.AreEqual(deleteResults[0].Objid, caseObjid);
	//		Assert.AreEqual(deleteResults[0].Name, "CaseDelete");
	//		Assert.AreEqual(deleteResults[0].Action, "Delete");
	//		Assert.AreEqual(deleteResults[0].Table, "case");
	//	}

	//	[Test]
	//	public void UpdateWithPreQuery()
	//	{
	//		string siteIDNum = _utility.InsertSiteGetIDNum();

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		DataModifier generic = clarifyDA.CreateDataModifier();
	//		UpdateModifier update = generic.CreateUpdateModifier("SiteUpdate", "site");
	//		update.SetField("name", "unit test123");
	//		update.AppendUniqueFilter("site_id", siteIDNum);

	//		ModifierResultProtocol[] results = generic.Update();
	//		Assert.IsTrue(results[0].Objid > 0);

	//		_utility.DeleteSiteByObjid(results[0].Objid);
	//	}

	//	[Test]
	//	public void UpdateWithUniqueRelation()
	//	{
	//		int siteObjid = 0;
	//		int caseObjid = 0;

	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");
	//		string caseIDNum = _clarifySessionWS.GetNextNumScheme("Case ID");

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		InsertModifier siteInsert = modifierWS1.CreateInsertModifier("mysite", "site");
	//		InsertModifier caseInsert = modifierWS1.CreateInsertModifier("mycase", "case");

	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "unit test");
	//		siteInsert.SetField("type", "1");
	//		siteInsert.RelateRecord("cust_loc2case", caseInsert);

	//		caseInsert.SetField("title", "Test from nunit");
	//		caseInsert.SetField("id_number", caseIDNum);

	//		ModifierResultProtocol[] insertResults = modifierWS1.Update();

	//		foreach (ModifierResultProtocol result in insertResults)
	//		{
	//			if (result.Table == "case")
	//				caseObjid = result.Objid;

	//			if (result.Table == "site")
	//				siteObjid = result.Objid;
	//		}

	//		Assert.IsTrue(_utility.QueryTableByObjid("site", siteObjid).Rows.Count == 1);
	//		Assert.IsTrue(_utility.QueryTableByObjid("case", caseObjid).Rows.Count == 1);


	//		//update data
	//		DataModifier modifierWS2 = clarifyDA.CreateDataModifier();

	//		UpdateModifier siteUpdate = modifierWS2.CreateUpdateModifier("mysite", "site");
	//		ReferenceModifier caseUpdateRef = modifierWS2.CreateReferenceModifier("mycase", "case");

	//		siteUpdate.SetField("name", "new title from nunit");
	//		siteUpdate.AppendUniqueRelation("case_reporter2site", caseUpdateRef);

	//		caseUpdateRef.AppendUniqueFilter("objid", caseObjid);

	//		ModifierResultProtocol[] updateResults = modifierWS2.Update();

	//		Assert.AreEqual(_utility.QueryTableByObjid("site", siteObjid).Rows[0]["name"], "new title from nunit");


	//		//delete site data
	//		DataModifier deleteSiteGeneric = clarifyDA.CreateDataModifier();

	//		DeleteModifier siteDelete = deleteSiteGeneric.CreateDeleteModifier("mysite", "site");
	//		ReferenceModifier caseUpdateRef2 = deleteSiteGeneric.CreateReferenceModifier("mycase", "case");

	//		siteDelete.AppendUniqueRelation("case_reporter2site", caseUpdateRef);
	//		caseUpdateRef2.AppendUniqueFilter("objid", caseObjid);

	//		ModifierResultProtocol[] deleteSiteResults = deleteSiteGeneric.Update();
	//		Assert.IsNull(_utility.QueryTableByObjid("site", siteObjid), "site record not deleted");


	//		//delete case data
	//		DataModifier deleteCaseGeneric = clarifyDA.CreateDataModifier();

	//		DeleteModifier caseDelete = deleteCaseGeneric.CreateDeleteModifier("mycase", "case");
	//		caseDelete.AppendUniqueFilter("objid", caseObjid);
	//		deleteCaseGeneric.Update();

	//		Assert.IsNull(_utility.QueryTableByObjid("case", caseObjid), "case record not deleted");
	//	}

	//	[Test]
	//	public void UpdateWith2UniqueRelations()
	//	{
	//		int siteObjid = 0;
	//		int caseObjid = 0;
	//		int phoneLogObjid = 0;

	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");
	//		string caseIDNum = _clarifySessionWS.GetNextNumScheme("Case ID");

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		InsertModifier siteInsert = modifierWS1.CreateInsertModifier("mysite", "site");
	//		InsertModifier caseInsert = modifierWS1.CreateInsertModifier("mycase", "case");
	//		InsertModifier phoneLogInsert = modifierWS1.CreateInsertModifier("myphonelog", "phone_log");

	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "unit test");
	//		siteInsert.SetField("type", "1");
	//		siteInsert.RelateRecord("cust_loc2case", caseInsert);

	//		caseInsert.SetField("title", "Test from nunit");
	//		caseInsert.SetField("id_number", caseIDNum);
	//		caseInsert.RelateRecord("case_phone2phone_log", phoneLogInsert);

	//		phoneLogInsert.SetField("notes", "Test form Nunit");

	//		ModifierResultProtocol[] insertResults = modifierWS1.Update();

	//		foreach (ModifierResultProtocol result in insertResults)
	//		{
	//			if (result.Table == "case")
	//				caseObjid = result.Objid;

	//			if (result.Table == "site")
	//				siteObjid = result.Objid;

	//			if (result.Table == "phone_log")
	//				phoneLogObjid = result.Objid;
	//		}

	//		Assert.IsTrue(caseObjid > 0);
	//		Assert.IsTrue(siteObjid > 0);
	//		Assert.IsTrue(phoneLogObjid > 0);


	//		//update data
	//		DataModifier modifierWS2 = clarifyDA.CreateDataModifier();

	//		UpdateModifier siteUpdate = modifierWS2.CreateUpdateModifier("mysite", "site");
	//		ReferenceModifier caseUpdateRef = modifierWS2.CreateReferenceModifier("mycase", "case");
	//		ReferenceModifier phoneLogUpdateRef = modifierWS2.CreateReferenceModifier("myphonelog", "phone_log");

	//		siteUpdate.SetField("name", "new title from nunit");

	//		siteUpdate.AppendUniqueRelation("case_reporter2site", caseUpdateRef);
	//		caseUpdateRef.AppendUniqueRelation("case_phone2case", phoneLogUpdateRef);
	//		phoneLogUpdateRef.AppendUniqueFilter("objid", phoneLogObjid);

	//		ModifierResultProtocol[] updateResults = modifierWS2.Update();

	//		Assert.AreEqual(_utility.QueryTableByObjid("site", siteObjid).Rows[0]["name"], "new title from nunit");


	//		//delete data
	//		DataModifier modifierWS3 = clarifyDA.CreateDataModifier();

	//		DeleteModifier siteDelete = modifierWS3.CreateDeleteModifier("mysite", "site");
	//		DeleteModifier caseDelete = modifierWS3.CreateDeleteModifier("mycase", "case");
	//		DeleteModifier phoneLogDelete = modifierWS3.CreateDeleteModifier("myphonelog", "phone_log");

	//		siteDelete.AppendUniqueFilter("objid", siteObjid);
	//		caseDelete.AppendUniqueFilter("objid", caseObjid);
	//		phoneLogDelete.AppendUniqueFilter("objid", phoneLogObjid);

	//		modifierWS3.Update();
	//		Assert.IsNull(_utility.QueryTableByObjid("site", siteObjid), "site record not deleted");
	//		Assert.IsNull(_utility.QueryTableByObjid("case", caseObjid), "case record not deleted");
	//		Assert.IsNull(_utility.QueryTableByObjid("phone_log", phoneLogObjid), "phone_log record not deleted");
	//	}


	//	[Test]
	//	public void RelateRecordsByID()
	//	{
	//		int siteObjid = 0;
	//		int caseObjid = 0;

	//		string siteIDNum = _utility.InsertSiteGetIDNum();
	//		string caseIDNum = _clarifySessionWS.GetNextNumScheme("Case ID");


	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		ReferenceModifier siteRef = modifierWS1.CreateReferenceModifier("mysite", "site");
	//		InsertModifier caseInsert = modifierWS1.CreateInsertModifier("mycase", "case");

	//		siteRef.AppendUniqueFilter("site_id", siteIDNum);

	//		caseInsert.SetField("title", "Test from nunit");
	//		caseInsert.SetField("id_number", caseIDNum);
	//		caseInsert.RelateRecord("case_reporter2site", siteRef);

	//		ModifierResultProtocol[] insertResults = modifierWS1.Update();

	//		foreach (ModifierResultProtocol result in insertResults)
	//		{
	//			if (result.Table == "case")
	//				caseObjid = result.Objid;

	//			if (result.Table == "site")
	//				siteObjid = result.Objid;
	//		}

	//		Assert.IsTrue(caseObjid > 0);
	//		Assert.IsTrue(siteObjid > 0);

	//		Assert.IsTrue(_utility.QueryTableByObjid("site", siteObjid).Rows.Count == 1);
	//		Assert.IsTrue(_utility.QueryTableByObjid("case", caseObjid).Rows.Count == 1);


	//		//delete data
	//		DataModifier modifierWS3 = clarifyDA.CreateDataModifier();

	//		DeleteModifier siteDelete = modifierWS3.CreateDeleteModifier("mysite", "site");
	//		DeleteModifier caseDelete = modifierWS3.CreateDeleteModifier("mycase", "case");

	//		siteDelete.AppendUniqueFilter("objid", siteObjid);
	//		caseDelete.AppendUniqueFilter("objid", caseObjid);

	//		modifierWS3.Update();
	//		Assert.IsNull(_utility.QueryTableByObjid("site", siteObjid), "site record not deleted");
	//		Assert.IsNull(_utility.QueryTableByObjid("case", caseObjid), "case record not deleted");
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void InvalidObjectInsert()
	//	{
	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		InsertModifier siteInsert = modifierWS1.CreateInsertModifier("mysite", "foo");

	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "unit test");
	//		siteInsert.SetField("type", "1");

	//		modifierWS1.Update();
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void InvalidFieldInsert()
	//	{
	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		InsertModifier siteInsert = modifierWS1.CreateInsertModifier("mysite", "site");

	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("foo", "unit test");
	//		siteInsert.SetField("type", "1");

	//		modifierWS1.Update();
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void InvalidRelation()
	//	{
	//		string siteIDNum = _clarifySessionWS.GetNextNumScheme("Site ID");
	//		string caseIDNum = _clarifySessionWS.GetNextNumScheme("Case ID");

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataModifier modifierWS1 = clarifyDA.CreateDataModifier();

	//		InsertModifier siteInsert = modifierWS1.CreateInsertModifier("mysite", "site");
	//		InsertModifier caseInsert = modifierWS1.CreateInsertModifier("mycase", "case");
	//		InsertModifier phoneLogInsert = modifierWS1.CreateInsertModifier("myphonelog", "phone_log");

	//		siteInsert.SetField("site_id", siteIDNum);
	//		siteInsert.SetField("name", "unit test");
	//		siteInsert.SetField("type", "1");
	//		siteInsert.RelateRecord("cust_loc2case", caseInsert);

	//		caseInsert.SetField("title", "Test from nunit");
	//		caseInsert.SetField("id_number", caseIDNum);
	//		caseInsert.RelateRecord("case_phone2phone_logBOGUS", phoneLogInsert);

	//		phoneLogInsert.SetField("notes", "Test form Nunit");

	//		modifierWS1.Update();
	//	}

	//	[Test, ExpectedException(typeof (SoapException))]
	//	public void CircularReference()
	//	{
	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);

	//		//update data
	//		DataModifier modifierWS2 = clarifyDA.CreateDataModifier();

	//		UpdateModifier siteUpdate = modifierWS2.CreateUpdateModifier("mysite", "site");
	//		ReferenceModifier caseUpdateRef = modifierWS2.CreateReferenceModifier("mycase", "case");

	//		siteUpdate.SetField("name", "new title from nunit");
	//		siteUpdate.AppendUniqueRelation("case_reporter2site", caseUpdateRef);

	//		caseUpdateRef.AppendUniqueRelation("site2case_reporter", siteUpdate);

	//		modifierWS2.Update();
	//	}
	//}
}