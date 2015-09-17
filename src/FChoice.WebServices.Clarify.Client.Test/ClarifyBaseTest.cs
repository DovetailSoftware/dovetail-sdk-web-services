using System;
using System.Collections.Generic;
using System.Data;
using FChoice.Common.Data;
using FChoice.Common.Licensing;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Toolkits.Clarify;
using FChoice.Toolkits.Clarify.Interfaces;
using FChoice.Toolkits.Clarify.Support;
using NUnit.Framework;

namespace FChoice.WebServices.Clarify.Client.Test
{
	//[TestFixture]
	//public class ClarifyBaseTest 
	//{
	//	[TestFixtureSetUp]
	//	public void TestFixtureSetUp()
	//	{
	//		InitializeClarifyApplication();

	//		OnTestFixtureSetup();
	//	}

	//	[TestFixtureTearDown]
	//	public void TestFixtureTearDown()
	//	{
	//		foreach (string employeeLoginName in _createdEmployeeLoginNames)
	//		{
	//			DeleteTestEmployee(employeeLoginName);
	//		}

	//		OnTestFixtureTeardown();
	//	}

	//	protected virtual void OnTestFixtureSetup() { }
	//	protected virtual void OnTestFixtureTeardown() { }

	//	public void InitializeClarifyApplication()
	//	{
	//		DbProviderFactory.Provider = DbProviderFactory.CreateProvider();

	//		if (!ClarifyApplication.IsInitialized)
	//		{
	//			ClarifyApplication.Initialize();
	//		}

	//		LicenseManager.Instance.RefreshLicensing();
	//	}

	//	private readonly List<string> _createdEmployeeLoginNames = new List<string>();

	//	public void CreateEmployee(out string loginName, out string password)
	//	{
	//		CreateEmployee("Hotline Engineer", out loginName, out password);
	//	}

	//	public void CreateEmployee(string privilegeClassName, out string loginName, out string password)
	//	{
	//		loginName = "a" + GetRandomString15CharactersLong();
	//		password = "password";

	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);
	//			var addressResult = interfacesToolkit.CreateAddress("address1", "Austin", "TX", "78759", "USA", "CST");
	//			var siteResult = interfacesToolkit.CreateSite(SiteType.Customer, SiteStatus.Active, addressResult.Objid);

	//			CreateEmployeeSetup createEmployeeSetup = new CreateEmployeeSetup("restriction", "testuser", loginName, password, siteResult.IDNum, "rtestuser@test.com", privilegeClassName);
	//			ToolkitResult createEmployeeResult = interfacesToolkit.CreateEmployee(createEmployeeSetup);
				
	//			if(createEmployeeResult.Objid < 1)
	//			{
	//				throw new ApplicationException("Could not create employee");
	//			}

	//			_createdEmployeeLoginNames.Add(loginName);
            
	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public ClarifySession CreateTestEmployee(out string loginName, out string password)
	//	{
	//		var clarifySession = CreateTestEmployee("Hotline Engineer", out loginName, out password);
	//		//clarifySession.CurrentCulture = new CultureInfo("tr-TR");
	//		return clarifySession;
	//	}

	//	public ClarifySession CreateTestEmployee(string privilegeClassName, out string loginName, out string password)
	//	{
	//		CreateEmployee(privilegeClassName, out loginName, out password);

	//		return ClarifyApplication.Instance.CreateSession(loginName, password, ClarifyLoginType.User);
	//	}

	//	private static void DeleteTestEmployee(string employeeLoginName)
	//	{
	//		if (DbProviderFactory.IsOracle() == false)
	//		{
	//			try
	//			{
	//				const string mssqlRemovedDbAccess = @"EXEC dbo.sp_revokedbaccess N'{0}'";
	//				SqlHelper.ExecuteNonQuery(string.Format(mssqlRemovedDbAccess, employeeLoginName));

	//				const string mssqlDropLogin = @"EXEC master.dbo.sp_droplogin @loginame = N'{0}'";
	//				SqlHelper.ExecuteNonQuery(string.Format(mssqlDropLogin, employeeLoginName));
	//			}
	//			catch
	//			{
	//				Console.WriteLine("Failed to drop mssql user {0}.", employeeLoginName);
	//			}

	//		}
	//		else
	//		{
	//			try
	//			{
	//				const string oracleDropUser = @"DROP USER {0} CASCADE";
	//				SqlHelper.ExecuteNonQuery(string.Format(oracleDropUser, employeeLoginName));
	//			}
	//			catch
	//			{
	//				Console.WriteLine("Failed to drop oracle user {0}.", employeeLoginName);
	//			}
	//		}
	//	}

	//	public ToolkitResult CreateSite(string siteName)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var ds = new ClarifyDataSet(administratorSession);
	//			var gSite = ds.CreateGeneric("site");
	//			gSite.AppendFilter("name", StringOps.Equals, siteName);
	//			gSite.Query();

	//			if (gSite.Rows.Count > 0)
	//			{
	//				var result = new ToolkitResult { Objid = Convert.ToInt32(gSite[0].UniqueID), IDNum = Convert.ToString(gSite[0]["site_id"]) };
	//				administratorSession.CloseSession();
	//				return result;
	//			}

	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);

	//			var addressResult = interfacesToolkit.CreateAddress("address1", "Austin", "TX", "78759", "USA", "CST");

	//			var createSiteSetup = new CreateSiteSetup(SiteType.Internal, SiteStatus.Active, addressResult.Objid)
	//									  {
	//										  SiteName = siteName
	//									  };

	//			var site = interfacesToolkit.CreateSite(createSiteSetup);

	//			administratorSession.CloseSession();

	//			return site;
	//		}
	//	}

	//	public void CreateQueue(string queueName, string employeeLoginName)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);

	//			var createQueueSetup =
	//				new CreateQueueSetup(queueName, true, true, true, true, true, true, true, true, true, true);
	//			interfacesToolkit.CreateQueue(createQueueSetup);

	//			AddUserToQueue(queueName, employeeLoginName);

	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public void AddUserToQueue(string queueName, string employeeLoginName)
	//	{
	//		var addUserToQueueSetup = new AddUserToQueueSetup(queueName, employeeLoginName);

	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			InterfacesToolkit interfacesToolkit = new InterfacesToolkit(administratorSession);
	//			interfacesToolkit.AddUserToQueue(addUserToQueueSetup);

	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public void CreateWipBin(string wipBinName, string employeeLoginName)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);
	//			var createWipBinSetup = new CreateWipBinSetup(wipBinName);
	//			createWipBinSetup.UserName = employeeLoginName;

	//			interfacesToolkit.CreateWipBin(createWipBinSetup);

	//			administratorSession.CloseSession();
	//		}
	//	}
		
	//	public int CreateContact(string firstName, string lastName, string siteIDNum, out string phoneNumber)
	//	{
	//		phoneNumber = GetRandomString15CharactersLong();

	//		var contact = CreateContact(siteIDNum, firstName, lastName, phoneNumber);
	//		return contact.Objid;
	//	}

	//	public ToolkitResult CreateContact(string siteIDNum, string firstName, string lastName, string phoneNumber)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var ds = new ClarifyDataSet(administratorSession);
	//			var generic = ds.CreateGeneric("contact");
	//			generic.AppendFilter("first_name", StringOps.Equals, firstName);
	//			generic.AppendFilter("last_name", StringOps.Equals, lastName);
	//			generic.AppendFilter("phone", StringOps.Equals, phoneNumber);
	//			generic.Query();

	//			if (generic.Rows.Count > 0)
	//			{
	//				var result = new ToolkitResult { Objid = Convert.ToInt32(generic[0].UniqueID) };
	//				administratorSession.CloseSession();
	//				return result;
	//			}

	//			var createContactSetup = new CreateContactSetup(firstName, lastName, phoneNumber, siteIDNum);
	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);
                
	//			var contact = interfacesToolkit.CreateContact(createContactSetup);
                
	//			administratorSession.CloseSession();

	//			return contact;
	//		}
	//	}

	//	public void MakeContactAWebUser(int contactObjID, string loginName, string password)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var clarifyDataSet = new ClarifyDataSet(administratorSession);
	//			var webUserGeneric = clarifyDataSet.CreateGeneric("web_user");
	//			var webUser = webUserGeneric.AddNew();
	//			webUser.RelateByID(contactObjID, "web_user2contact");
	//			webUser["user_key"] = administratorSession.GetNextNumScheme("WebSupport User Key");
	//			webUser["login_name"] = loginName;
	//			webUser["password"] = password;
	//			webUser["status"] = 1;
	//			webUser.Update();

	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public void AddWebCmd(string name, int type)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var clarifyDataSet = new ClarifyDataSet(administratorSession);
	//			var gWebCmd = clarifyDataSet.CreateGeneric("x_web_cmd");
	//			gWebCmd.AppendFilter("x_name", StringOps.Equals, name);
	//			gWebCmd.AppendFilter("x_type", NumberOps.Equals, type);
	//			gWebCmd.Query();

	//			if (gWebCmd.Rows.Count > 0)
	//			{
	//				return;
	//			}

	//			var webCmd = gWebCmd.AddNew();
	//			webCmd["x_name"] = name;
	//			webCmd["x_type"] = type;
	//			webCmd.Update();

	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public void CreateContract(string contractId)
	//	{
	//		CreateContract(contractId, String.Empty);
	//	}

	//	public void CreateContract(string contractId, string poNumber)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);
	//			var contractSetup = new CreateContractSetup();
	//			contractSetup.AdditionalFields.Append("id", AdditionalFieldType.String, contractId);
	//			contractSetup.AdditionalFields.Append("po_number", AdditionalFieldType.String, poNumber);
	//			interfacesToolkit.CreateContract(contractSetup);

	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public ToolkitResult CreateSolution(string title, string queue, bool isPublic)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var interfacesToolkit = new InterfacesToolkit(administratorSession);
	//			var solutionSetup = new CreateSolutionSetup { Title = title, IsPublic = isPublic };
	//			if(!String.IsNullOrEmpty(queue))
	//			{
	//				solutionSetup.Queue = queue;
	//			}
	//			var result = interfacesToolkit.CreateSolution(solutionSetup);

	//			administratorSession.CloseSession();

	//			return result;
	//		}
	//	}

	//	public void RelateContractToSite(string siteName, string contractId)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var ds = new ClarifyDataSet(administratorSession);
	//			var gSite = ds.CreateGeneric("site");
	//			gSite.AppendFilter("name", StringOps.Equals, siteName);

	//			var gContract = ds.CreateGeneric("contract");
	//			gContract.AppendFilter("id", StringOps.Equals, contractId);
	//			ds.Query(gSite, gContract);

	//			var site = gSite[0];
	//			site.RelateRecord(gContract[0], "cust_loc2contract");
	//			site.Update();

	//			administratorSession.CloseSession();
	//		}
	//	}

	//	public ToolkitResult CreateCaseForSite(string siteName, string caseTitle, string firstName, string lastName, string phoneNumber, IDbTransaction transaction = null)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var ds = new ClarifyDataSet(administratorSession);
	//			var gSite = ds.CreateGeneric("site");
	//			gSite.AppendFilter("name", StringOps.Equals, siteName);
	//			gSite.Query(transaction);

	//			var site = gSite[0];
	//			var siteId = site["site_id"].ToString();

	//			var supportToolkit = new SupportToolkit(administratorSession);
	//			var caseSetup = new CreateCaseSetup(siteId, firstName, lastName, phoneNumber) { Title = caseTitle };
	//			var caseResult = supportToolkit.CreateCase(caseSetup, transaction);

	//			administratorSession.CloseSession();

	//			return caseResult;
	//		}
	//	}

	//	public ToolkitResult CreateSubcase(string caseID)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var supportToolkit = new SupportToolkit(administratorSession);
	//			var subcaseSetup = new CreateSubcaseSetup(caseID);
	//			var subcaseResult = supportToolkit.CreateSubcase(subcaseSetup);

	//			administratorSession.CloseSession();

	//			return subcaseResult;
	//		}
	//	}

	//	public int NumberOfCasesForSite(string siteName)
	//	{
	//		using (var administratorSession = CreateAdministrationSession())
	//		{
	//			var ds = new ClarifyDataSet(administratorSession);
	//			var gSite = ds.CreateGeneric("site");
	//			gSite.AppendFilter("name", StringOps.Equals, siteName);

	//			var gCase = ds.CreateGeneric("case");
	//			gCase.TraverseFromParent(gSite, "cust_loc2case");

	//			ds.Query(gSite, gCase);

	//			var count = gCase.Rows.Count;

	//			administratorSession.CloseSession();

	//			return count;
	//		}
	//	}

	//	public ClarifySession CreateAdministrationSession()
	//	{
	//		return ClarifyApplication.Instance.CreateSession("sa", "sa", ClarifyLoginType.User);
	//	}
		
	//	public static string GetRandomQueueName()
	//	{
	//		return "q" + GetRandomString15CharactersLong();
	//	}
		
	//	public static string GetRandomWipBinName()
	//	{
	//		return "w" + GetRandomString15CharactersLong();
	//	}

	//	public static string GetRandomUserName()
	//	{
	//		return "u" + GetRandomString15CharactersLong();
	//	}

	//	public static string GetRandomString15CharactersLong()
	//	{
	//		return Guid.NewGuid().ToString().Substring(0, 15).Replace("-", string.Empty);
	//	}
	//}
}