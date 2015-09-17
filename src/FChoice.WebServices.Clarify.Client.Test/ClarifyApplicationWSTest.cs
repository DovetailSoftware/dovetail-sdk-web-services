using NUnit.Framework;
using SupportProto = FChoice.WebServices.Clarify.Client.Protocols.SupportToolkitSrv;
using InterfacesProto = FChoice.WebServices.Clarify.Client.Protocols.InterfacesToolkitSrv;
using Protocol = FChoice.WebServices.Clarify.Client.Protocols.ClarifyDataAccessSrv;

namespace FChoice.WebServices.Clarify.Client.Test
{
	//[TestFixture]
	//public class ClarifyApplicationWSTest : WebservicesTest
	//{
	//	[Test]
	//	public void GetClarifyVersion()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetClarifyVersion().Length > 0);
	//	}

	//	[Test]
	//	public void GetCountries()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetCountries().Length > 0);
	//	}

	//	[Test]
	//	public void GetDatabaseVersion()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetDatabaseVersion().Length > 0);
	//	}

	//	[Test]
	//	public void GetDefaultCountry()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetDefaultCountry().Name == "USA");
	//	}

	//	[Test]
	//	public void GetDefaultTimeZone()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetDefaultTimeZone().Name.Length > 0);
	//	}

	//	[Test]
	//	public void GetGbstDefault()
	//	{
	//		Assert.IsNotNull(_clarifyApplicationWS.GetGbstDefault("New"));
	//	}

	//	[Test]
	//	public void GetGbstList()
	//	{
	//		Assert.IsNotNull(_clarifyApplicationWS.GetGbstList("New"));
	//	}

	//	[Test]
	//	public void GetHgbstList()
	//	{
	//		Assert.IsNotNull(_clarifyApplicationWS.GetHgbstList("FAMILY"));
	//	}

	//	[Test]
	//	public void GetHgbstElmDefault()
	//	{
	//		Assert.IsNotNull(_clarifyApplicationWS.GetHgbstElmDefault("FAMILY"));
	//	}

	//	[Test]
	//	public void GetServerTimezone()
	//	{
	//		Assert.IsNotNull(_clarifyApplicationWS.GetServerTimezone());
	//	}

	//	[Test]
	//	public void GetStates()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetStates("USA").Length > 0);
	//	}

	//	[Test]
	//	public void GetTimeZoneObjid()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetTimeZoneObjid("CST", false) > 0);
	//	}

	//	[Test]
	//	public void GetTimeZones()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetTimeZones().Length > 0);
	//	}

	//	[Test]
	//	public void GetTimeZonesInCountry()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.GetTimeZonesInCountry("USA").Length > 0);
	//	}

	//	[Test]
	//	public void IsCountry()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.IsCountry("USA"));
	//	}

	//	[Test]
	//	public void IsState()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.IsState("USA", "TX", false));
	//	}

	//	[Test]
	//	public void IsTimeZone()
	//	{
	//		Assert.IsTrue(_clarifyApplicationWS.IsTimeZone("CST"));
	//	}
	//}
}