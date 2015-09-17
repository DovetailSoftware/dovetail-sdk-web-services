using System;
using System.Data;
using System.IO;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Toolkits.Clarify;
using FChoice.Toolkits.Clarify.Interfaces;
using FChoice.Toolkits.Clarify.Logistics;
using FChoice.WebServices.Clarify.Client.Contracts;
using FChoice.WebServices.Clarify.Client.DepotRepair;
using FChoice.WebServices.Clarify.Client.FieldOps;
using FChoice.WebServices.Clarify.Client.Interfaces;
using FChoice.WebServices.Clarify.Client.Logistics;
using FChoice.WebServices.Clarify.Client.Quality;
using FChoice.WebServices.Clarify.Client.Sales;
using FChoice.WebServices.Clarify.Client.Support;
using NUnit.Framework;
using SupportProto = FChoice.WebServices.Clarify.Client.Protocols.SupportToolkitSrv;
using InterfacesProto = FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv;
using ContractsProto = FChoice.WebServices.Clarify.Client.Protocols.ContractsToolkitSrv;
using CreateContractSetupWS=FChoice.WebServices.Clarify.Client.Contracts.CreateContractSetupWS;
using LogisticsProto = FChoice.WebServices.Clarify.Client.Protocols.LogisticsToolkitSrv;
using FieldOpsProto = FChoice.WebServices.Clarify.Client.Protocols.FieldOpsToolkitSrv;
using DepotRepairProto = FChoice.WebServices.Clarify.Client.Protocols.DepotRepairToolkitSrv;
using SalesProto = FChoice.WebServices.Clarify.Client.Protocols.SalesToolkitSrv;
using QualityProto = FChoice.WebServices.Clarify.Client.Protocols.QualityToolkitSrv;
using SiteStatus=FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv.SiteStatus;
using SiteType=FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv.SiteType;
using ToolkitResultProtocol=FChoice.WebServices.Clarify.Client.Protocols.SupportToolkitSrv.ToolkitResultProtocol;

namespace FChoice.WebServices.Clarify.Client.Test
{
	//[TestFixture]
	//public class ToolkitsWSTest : WebservicesTest
	//{
	//	[Test]
	//	public void SupportToolkit_CreateCase()
	//	{
	//		SupportToolkitWS supportWS = new SupportToolkitWS(_clarifySessionWS);

	//		string siteID = _utility.CreateSite();

	//		Utility.Contact contact = _utility.CreateContact(siteID);

	//		CreateCaseSetupWS setup = new CreateCaseSetupWS(siteID, contact.FirstName,
	//														contact.LastName, contact.Phone);

	//		setup.Title = "This is a test";

	//		ToolkitResultProtocol result = supportWS.CreateCase(setup);

	//		Assert.IsTrue(result.Objid > 0);

	//		ClarifyDataAccessWS clarifyDA = new ClarifyDataAccessWS(_clarifySessionWS);
	//		DataQuery caseQuery = clarifyDA.CreateDataQuery("case");

	//		caseQuery.AppendFilter("objid", "Equals", result.Objid.ToString());

	//		string result2 = caseQuery.Query(true);

	//		StringReader reader = new StringReader(result2);

	//		DataSet ds = new DataSet();
	//		ds.ReadXml(reader);

	//		Assert.AreEqual(setup.Title, ds.Tables[0].Rows[0]["Title"].ToString());
	//	}

	//	[Test]
	//	public void InterfacesToolkit_CreateSite()
	//	{
	//		InterfacesToolkitWS toolkitWS = new InterfacesToolkitWS(_clarifySessionWS);

	//		int addressObjid = _utility.CreateAddress();

	//		CreateSiteSetupWS setup = new CreateSiteSetupWS(
	//			SiteType.Customer,
	//			SiteStatus.Active,
	//			addressObjid);

	//		Protocols.InterfacesToolkitSrv.ToolkitResultProtocol result = toolkitWS.CreateSite(setup);

	//		Assert.IsTrue(result.Objid > 0);
	//	}

	//	[Test]
	//	public void ContractsToolkit_CreateContract()
	//	{
	//		ContractsToolkitWS toolkitWS = new ContractsToolkitWS(_clarifySessionWS);

	//		CreateContractSetupWS setup = new CreateContractSetupWS("Test title");

	//		Protocols.ContractsToolkitSrv.ToolkitResultProtocol result = toolkitWS.CreateContract(setup);

	//		Assert.IsTrue(result.Objid > 0);
	//	}

	//	[Test]
	//	public void LogisticsToolkit_CreatePartRequestHeader()
	//	{
	//		LogisticsToolkitWS toolkitWS = new LogisticsToolkitWS(_clarifySessionWS);

	//		string siteID = _utility.CreateSite();
	//		Utility.Contact contact = _utility.CreateContact(siteID);


	//		CreatePartRequestHeaderSetupWS setup = new CreatePartRequestHeaderSetupWS(
	//			contact.FirstName, contact.LastName, contact.Phone, siteID);

	//		Protocols.LogisticsToolkitSrv.ToolkitResultProtocol result = toolkitWS.CreatePartRequestHeader(setup);

	//		Assert.IsTrue(result.Objid > 0);
	//	}

	//	[Test]
	//	public void LogPartsUsedRemove_should_only_remove_the_specified_quantity_when_the_quantity_is_less_than_the_number_of_parts_installed()
	//	{
	//		ClarifySession clarifySession = ClarifyApplication.Instance.CreateSession(_employeeLoginName, _employeePassword, ClarifyLoginType.User);

	//		string _siteIDNum;
	//		string _partNumber = GetRandomString15CharactersLong();
	//		string _modLevel = "1.0";
	//		string _domain = "Literature";
		
	//		string _firstName = GetRandomString15CharactersLong();
	//		string _lastName = GetRandomString15CharactersLong();
	//		string _phoneNumber = GetRandomString15CharactersLong();

	//		InterfacesToolkit interfacesToolkit = new InterfacesToolkit(clarifySession); ToolkitResult addressResult = interfacesToolkit.CreateAddress("123 street", "Austin", "TX", "78759", "USA", "CST");
	//		ToolkitResult siteResult = interfacesToolkit.CreateSite(Toolkits.Clarify.SiteType.Customer, Toolkits.Clarify.SiteStatus.Active, addressResult.Objid);
	//		_siteIDNum = siteResult.IDNum;

	//		interfacesToolkit.CreateContact(_firstName, _lastName, _phoneNumber, _siteIDNum);
	//		interfacesToolkit.CreatePart(_partNumber, _domain, 30, PartRepairType.Repairable);
	//		interfacesToolkit.CreatePartRevision(_partNumber, _domain, _modLevel);

	//		int createQuantity = 10;
	//		int removeQuantity  = 4;
	//		ToolkitResult sitePartResult = interfacesToolkit.InstallSitePartToSite(_siteIDNum, _partNumber, _modLevel, _domain, createQuantity);

	//		LogisticsToolkit logisticsToolkit = new LogisticsToolkit(clarifySession);
	//		ToolkitResult partRequestHeaderResult = logisticsToolkit.CreatePartRequestHeader(_firstName, _lastName, _phoneNumber, _siteIDNum);
	//		ToolkitResult createPartRequestDetailResult = logisticsToolkit.CreatePartRequestDetail(partRequestHeaderResult.IDNum, _partNumber, _domain, _modLevel, createQuantity);

	//		SetLogisticsTransitionSetup setLogisticsTransitionSetup = new SetLogisticsTransitionSetup(PartRequestType.PleaseSpecify,PartRequestCondition.RequestOpen, PartRequestCondition.PartUsed, new string[] { "Hotline Engineer" });
	//		logisticsToolkit.SetLogisticsTransition(setLogisticsTransitionSetup);

	//		FieldOpsToolkitWS toolkitWS = new FieldOpsToolkitWS(_clarifySessionWS);

	//		LogPartsUsedRemoveSetupWS setup = new LogPartsUsedRemoveSetupWS(createPartRequestDetailResult.IDNum, sitePartResult.Objid);
	//		setup.RemoveQuantity = removeQuantity;

	//		Protocols.FieldOpsToolkitSrv.ToolkitResultProtocol result = toolkitWS.LogPartsUsedRemove(setup);

	//		Assert.IsTrue(result.Objid > 0);

	//		ClarifyDataSet clarifyDataSet = new ClarifyDataSet(clarifySession);

	//		ClarifyGeneric sitePartGen = clarifyDataSet.CreateGeneric("site_part");
	//		sitePartGen.AppendFilter("objid", NumberOps.Equals, sitePartResult.Objid);
	//		sitePartGen.Query();

	//		Assert.AreEqual(createQuantity - removeQuantity, Convert.ToInt32(sitePartGen.Rows[0]["quantity"]));
	//	}

	//	[Test]
	//	public void DepotRepairToolkit_CreateEcoHeader()
	//	{
	//		DepotRepairToolkitWS toolkitWS = new DepotRepairToolkitWS(_clarifySessionWS);

	//		CreateEcoHeaderSetupWS setup = new CreateEcoHeaderSetupWS(DateTime.Now, DateTime.Now.AddDays(10));
	//		setup.Description = "This is a test";

	//		Protocols.DepotRepairToolkitSrv.ToolkitResultProtocol result = toolkitWS.CreateEcoHeader(setup);

	//		Assert.IsTrue(result.Objid > 0);
	//	}

	//	[Test]
	//	public void SalesToolkit_CreateQuote()
	//	{
	//		SalesToolkitWS toolkitWS = new SalesToolkitWS(_clarifySessionWS);

	//		CreateQuoteSetupWS setup = new CreateQuoteSetupWS("this is a test");

	//		Protocols.SalesToolkitSrv.ToolkitResultProtocol result = toolkitWS.CreateQuote(setup);

	//		Assert.IsTrue(result.Objid > 0);
	//	}

	//	[Test]
	//	public void QualityToolkit_CreateCR()
	//	{
	//		string partNum = GetRandomString15CharactersLong();
	//		string partDom = "Product";
	//		string modLevel = "1.0";

	//		_utility.CreatePartRevision(partNum, partDom, modLevel);

	//		QualityToolkitWS toolkitWS = new QualityToolkitWS(_clarifySessionWS);

	//		CreateCRSetupWS setup = new CreateCRSetupWS(partNum, modLevel, partDom);
	//		Protocols.QualityToolkitSrv.ToolkitResultProtocol result = toolkitWS.CreateCR(setup);

	//		Assert.IsTrue(result.Objid > 0);
	//	}
	//}
}