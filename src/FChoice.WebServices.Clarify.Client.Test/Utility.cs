using System;
using System.Data;
using System.IO;
using FChoice.WebServices.Clarify.Client.Interfaces;
using FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;
using FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv;
using FChoice.WebServices.Clarify.Client.Support;
using NUnit.Framework;
using SupportProto = FChoice.WebServices.Clarify.Client.Protocols.SupportToolkitSrv;
using InterfacesProto = FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv;
using DataAccessProtocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client.Test
{
	public class Utility
	{
		private ClarifySessionWS session;
		private SupportToolkitWS supportWS;
		private InterfacesToolkitWS interfacesWS;

		public Utility(ClarifySessionWS session)
		{
			this.session = session;
			supportWS = new SupportToolkitWS(session);
			interfacesWS = new InterfacesToolkitWS(session);
		}

		public int CreateAddress()
		{
			string address1 = DateTime.Now.GetHashCode().ToString() + " Street";
			string city = "Austin";
			string state = "TX";
			string zipcode = "78759";
			string country = "USA";
			string timezone = "CST";

			return interfacesWS.CreateAddress(address1, city, state, zipcode, country, timezone).Objid;
		}

		public string CreateSite()
		{
			int addressObjid = CreateAddress();
			CreateSiteSetupWS setup = new CreateSiteSetupWS(SiteType.Customer,
			                                                SiteStatus.Active, addressObjid);

			setup.SiteIDNum = session.GetNextNumScheme("Site ID");
			setup.SiteName = "Test" + DateTime.Now.GetHashCode().ToString();

			return interfacesWS.CreateSite(setup).IDNum;
		}

		public void CreatePartRevision(string partNum, string partDom, string modLevel)
		{
			interfacesWS.CreatePart(partNum, partDom, 30, PartRepairType.Repairable);
			interfacesWS.CreatePartRevision(partNum, partDom, modLevel);
		}

		public Contact CreateContact(string siteIDNum)
		{
			Contact contact = new Contact();

			contact.FirstName = DateTime.Now.GetHashCode().ToString();
			contact.LastName = DateTime.Now.GetHashCode().ToString();
			contact.Phone = DateTime.Now.GetHashCode().ToString();

			interfacesWS.CreateContact(contact.FirstName, contact.LastName, contact.Phone, siteIDNum);

			return contact;
		}

		public class Contact
		{
			public string FirstName;
			public string LastName;
			public string Phone;
		}


		public string CreateCase()
		{
			string siteIDNum = CreateSite();
			Contact contact = CreateContact(siteIDNum);

			CreateCaseSetupWS setup = new CreateCaseSetupWS(siteIDNum, contact.FirstName, contact.LastName, contact.Phone);
			setup.Title = "Test" + DateTime.Now.GetHashCode().ToString();
			return supportWS.CreateCase(setup).IDNum;
		}

		public string InsertSiteGetIDNum()
		{
			ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(session);
			string siteIDNum = session.GetNextNumScheme("Site ID");

			DataModifier generic = clarifyDA.CreateDataModifier();
			InsertModifier insert = generic.CreateInsertModifier("SiteInsert", "site");
			insert.SetField("site_id", siteIDNum);
			insert.SetField("name", "unit test");
			insert.SetField("type", "1");

			ModifierResultProtocol[] result = generic.Update();
			return siteIDNum;
		}

		public int InsertSiteGetObjid()
		{
			ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(session);
			string siteIDNum = session.GetNextNumScheme("Site ID");

			DataModifier generic = clarifyDA.CreateDataModifier();
			InsertModifier insert = generic.CreateInsertModifier("SiteInsert", "site");
			insert.SetField("site_id", siteIDNum);
			insert.SetField("name", "unit test");
			insert.SetField("type", "1");

			ModifierResultProtocol[] results = generic.Update();
			return results[0].Objid;
		}

		public void DeleteSiteByObjid(int objid)
		{
			ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(session);

			DataModifier generic = clarifyDA.CreateDataModifier();
			DeleteModifier delete = generic.CreateDeleteModifier("site", "site");
			delete.AppendUniqueFilter("objid", objid.ToString());

			ModifierResultProtocol[] results = generic.Update();
			Assert.AreEqual(objid, results[0].Objid);
		}

		public DataTable QueryTableByObjid(string tableName, int objid)
		{
			ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(session);

			DataQuery gen = clarifyDA.CreateDataQuery(tableName);
			gen.AppendFilter("objid", "Equals", objid.ToString());

			DataSet ds = GetDataSetFromXml(gen.Query(true));

			return ds.Tables[tableName] != null && ds.Tables[tableName].Rows.Count > 0 ? ds.Tables[tableName] : null;
		}

		public DataSet GetDataSetFromXml(string xml)
		{
			StringReader reader = new StringReader(xml);

			DataSet ds = new DataSet();
			ds.ReadXml(reader);

			return ds;
		}
	}
}