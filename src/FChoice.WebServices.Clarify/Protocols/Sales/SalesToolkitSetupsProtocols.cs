//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using FChoice.Toolkits.Clarify;
using FChoice.WebServices.Clarify;

namespace FChoice.WebServices.Clarify.Protocols.Sales
{
	[Serializable]
	public class ReopenOpportunitySetupProtocol
	{
		public ReopenOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String Status;
		public System.String WipBin;
		public System.DateTime ReopenDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class CloseOpportunitySetupProtocol
	{
		public CloseOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String Status;
		public System.DateTime CloseDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class LogLeadPhoneSetupProtocol
	{
		public LogLeadPhoneSetupProtocol(){}

		public System.Int32 LeadObjid;
		public System.String Notes;
		public System.String InternalUseOnlyNotes;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String ActionType;
		public System.DateTime LogDate;
		public System.Int32 Duration;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class LogLeadNoteSetupProtocol
	{
		public LogLeadNoteSetupProtocol(){}

		public System.Int32 LeadObjid;
		public System.String Notes;
		public System.String InternalUseOnlyNotes;
		public System.DateTime LogDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AssignLeadSetupProtocol
	{
		public AssignLeadSetupProtocol(){}

		public System.Int32 LeadObjid;
		public System.String NewOwner;
		public System.DateTime AssignDate;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class CreateLeadSetupProtocol
	{
		public CreateLeadSetupProtocol(){}

		public System.Int32 LeadObjid;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String Fax;
		public System.String Address;
		public System.String Address2;
		public System.String City;
		public System.String State;
		public System.String PostalCode;
		public System.String Country;
		public System.String TimeZone;
		public System.String Email;
		public System.String Title;
		public System.String CompanyName;
		public System.String SiteName;
		public FChoice.Toolkits.Clarify.LeadSiteType SiteType;
		public System.String Rating;
		public System.String ContactRole;
		public System.String LeadSource;
		public System.String UserName;
		public System.DateTime CreateDate;
		public System.Boolean GenerateTimeBombs;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class UpdateLeadSetupProtocol
	{
		public UpdateLeadSetupProtocol(){}

		public System.Int32 LeadObjid;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String Fax;
		public System.String Address;
		public System.String Address2;
		public System.String City;
		public System.String State;
		public System.String PostalCode;
		public System.String Country;
		public System.String TimeZone;
		public System.String Email;
		public System.String Title;
		public System.String CompanyName;
		public System.String SiteName;
		public FChoice.Toolkits.Clarify.LeadSiteType SiteType;
		public System.String Rating;
		public System.String ContactRole;
		public System.String LeadSource;
		public System.String UserName;
		public System.DateTime CreateDate;
		public System.Boolean GenerateTimeBombs;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class CreateQuoteLineItemSetupProtocol
	{
		public CreateQuoteLineItemSetupProtocol(){}

		public System.String ContractIDNum;
		public System.String UserName;
		public System.DateTime CreateDate;
		public System.DateTime StartDate;
		public System.DateTime EndDate;
		public System.String PartNumber;
		public System.String PartDomain;
		public System.String PartRevision;
		public System.Int32 Quantity;
		public System.String PriceSchedule;
		public System.Double OverridePrice;
		public System.Double UnitsUsed;
		public System.String SerialNumber;
		public System.Boolean IsTaxable;
		public System.Boolean AutoInstall;
		public System.String Comments;
		public System.String QuotedSiteIDNum;
		public System.String ServicedAtSiteIDNum;
		public System.Int32 ParentLineItemObjid;
		public System.String POIDNum;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class CreateQuoteSetupProtocol
	{
		public CreateQuoteSetupProtocol(){}

		public System.String QuoteTitle;
		public System.String AccountIDNum;
		public System.String SiteIDNum;
		public System.String OpportunityIDNum;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String Status;
		public System.String BillToSiteIDNum;
		public System.String ShipToSiteIDNum;
		public System.String Currency;
		public System.String PriceProgram;
		public System.String Queue;
		public System.String AdminUserName;
		public System.DateTime CreateDate;
		public System.String UserName;
		public System.Int16 QuoteLengthInDays;
		public System.Boolean GenerateTimeBombs;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ChangeQuoteStatusSetupProtocol
	{
		public ChangeQuoteStatusSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.String NewStatus;
		public System.DateTime ChangeDate;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ChangeOpportunityStatusSetupProtocol
	{
		public ChangeOpportunityStatusSetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String NewStatus;
		public System.DateTime ChangeDate;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ChangeActionItemStatusSetupProtocol
	{
		public ChangeActionItemStatusSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String NewStatus;
		public System.DateTime ChangeDate;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class MoveQuoteSetupProtocol
	{
		public MoveQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.String NewWipBin;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class MoveOpportunitySetupProtocol
	{
		public MoveOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String NewWipBin;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class MoveActionItemSetupProtocol
	{
		public MoveActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String NewWipBin;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AssignQuoteSetupProtocol
	{
		public AssignQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.String NewUser;
		public System.String WipBin;
		public System.DateTime AssignDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AssignOpportunitySetupProtocol
	{
		public AssignOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String NewUser;
		public System.String WipBin;
		public System.DateTime AssignDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AssignActionItemSetupProtocol
	{
		public AssignActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String NewUser;
		public System.String WipBin;
		public System.DateTime AssignDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class YankQuoteSetupProtocol
	{
		public YankQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.String WipBin;
		public System.DateTime YankDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class YankOpportunitySetupProtocol
	{
		public YankOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String WipBin;
		public System.DateTime YankDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class YankActionItemSetupProtocol
	{
		public YankActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String WipBin;
		public System.DateTime YankDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ForwardQuoteSetupProtocol
	{
		public ForwardQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.String NewQueue;
		public System.DateTime ForwardDate;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ForwardOpportunitySetupProtocol
	{
		public ForwardOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String NewQueue;
		public System.DateTime ForwardDate;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ForwardActionItemSetupProtocol
	{
		public ForwardActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String NewQueue;
		public System.DateTime ForwardDate;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AcceptQuoteSetupProtocol
	{
		public AcceptQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.DateTime AcceptDate;
		public System.String WipBin;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AcceptOpportunitySetupProtocol
	{
		public AcceptOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.DateTime AcceptDate;
		public System.String WipBin;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class AcceptActionItemSetupProtocol
	{
		public AcceptActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.DateTime AcceptDate;
		public System.String WipBin;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class RejectQuoteSetupProtocol
	{
		public RejectQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.DateTime RejectDate;
		public System.String WipBin;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class RejectOpportunitySetupProtocol
	{
		public RejectOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.DateTime RejectDate;
		public System.String WipBin;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class RejectActionItemSetupProtocol
	{
		public RejectActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.DateTime RejectDate;
		public System.String WipBin;
		public System.String Notes;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class DispatchQuoteSetupProtocol
	{
		public DispatchQuoteSetupProtocol(){}

		public System.String QuoteIDNum;
		public System.String Queue;
		public System.DateTime DispatchDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class DispatchOpportunitySetupProtocol
	{
		public DispatchOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String Queue;
		public System.DateTime DispatchDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class DispatchActionItemSetupProtocol
	{
		public DispatchActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String Queue;
		public System.DateTime DispatchDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class CreateOpportunitySetupProtocol
	{
		public CreateOpportunitySetupProtocol(){}

		public System.String OpportunityName;
		public System.String AccountIDNum;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String Territory;
		public System.Decimal Amount;
		public System.DateTime CloseDate;
		public System.String SalesStage;
		public System.String LeadSource;
		public System.String Currency;
		public System.Single Probability;
		public System.String Process;
		public System.String UserName;
		public System.DateTime CreateDate;
		public System.Boolean GenerateTimeBombs;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class UpdateOpportunitySetupProtocol
	{
		public UpdateOpportunitySetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String OpportunityName;
		public System.String AccountIDNum;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String Territory;
		public System.Decimal Amount;
		public System.DateTime CloseDate;
		public System.String LeadSource;
		public System.String Currency;
		public System.Single Probability;
		public System.String Process;
		public System.DateTime UpdateDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ChangeActionItemConditionSetupProtocol
	{
		public ChangeActionItemConditionSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String NewCondition;
		public System.String NewStatus;
		public System.String UserName;
		public System.DateTime ChangeDate;
		public System.Boolean GenerateTimeBombs;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class CreateActionItemSetupProtocol
	{
		public CreateActionItemSetupProtocol(){}

		public System.String Title;
		public System.String Notes;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String AccountName;
		public System.String LeadFirstName;
		public System.String LeadLastName;
		public System.String OpportunityIDNum;
		public System.String TaskType;
		public System.String Priority;
		public System.DateTime StartDate;
		public System.DateTime DueDate;
		public System.DateTime CompleteDate;
		public System.String Status;
		public System.DateTime CreateDate;
		public System.String UserName;
		public System.Boolean GenerateTimeBombs;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class UpdateActionItemSetupProtocol
	{
		public UpdateActionItemSetupProtocol(){}

		public System.String ActionItemIDNum;
		public System.String Title;
		public System.String Notes;
		public System.String ContactFirstName;
		public System.String ContactLastName;
		public System.String ContactPhone;
		public System.String AccountName;
		public System.String LeadFirstName;
		public System.String LeadLastName;
		public System.String OpportunityIDNum;
		public System.String TaskType;
		public System.String Priority;
		public System.DateTime StartDate;
		public System.DateTime DueDate;
		public System.DateTime CompleteDate;
		public System.String Status;
		public System.DateTime UpdateDate;
		public Protocols.AdditionalFieldProtocol[] AdditionalFields;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
	[Serializable]
	public class ChangeOpportunityStageSetupProtocol
	{
		public ChangeOpportunityStageSetupProtocol(){}

		public System.String OpportunityIDNum;
		public System.String NewStatus;
		public System.String Notes;
		public System.String UserName;
		public System.DateTime ChangeDate;
		public System.Boolean GenerateTimeBombs;
		public FChoice.Toolkits.Clarify.OpportunityStage Stage;

		public int DirtyFieldFlags;
		public int ConstructorCue;
		
	}
}