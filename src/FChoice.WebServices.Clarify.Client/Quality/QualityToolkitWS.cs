//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Web;
using System.Web.Services;
using Protocol = FChoice.WebServices.Clarify.Client.Protocols.QualityToolkitSrv;
using FChoice.WebServices.Clarify.Client;

namespace FChoice.WebServices.Clarify.Client.Quality
{
	public class QualityToolkitWS
	{
		private Protocol.QualityToolkitSrv toolkitProtocol;
		
		public QualityToolkitWS(ClarifySessionWS session)
		{
			toolkitProtocol = new Protocol.QualityToolkitSrv();
			toolkitProtocol.Url = new Uri( session.BaseUri, "QualityToolkitSrv.asmx" ).ToString();
			toolkitProtocol.AuthenticationHeaderValue = new Protocol.AuthenticationHeader();
			
			toolkitProtocol.AuthenticationHeaderValue.SessionID = session.SessionToken;
		}
		
		public Protocol.ToolkitResultProtocol FixFailed(String crIDNum)
		{
			return toolkitProtocol.FixFailed( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol FixFailed(FixFailedSetupWS setupParam)
		{
			return toolkitProtocol.FixFailed( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol LogCREmail(String crIDNum)
		{
			return toolkitProtocol.LogCREmail( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol LogCREmail(LogCREmailSetupWS setupParam)
		{
			return toolkitProtocol.LogCREmail( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol ReplicateCR(String crIDNum)
		{
			return toolkitProtocol.ReplicateCR( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol ReplicateCR(ReplicateCRSetupWS setupParam)
		{
			return toolkitProtocol.ReplicateCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol UpdateCR(String crIDNum)
		{
			return toolkitProtocol.UpdateCR( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol UpdateCR(UpdateCRSetupWS setupParam)
		{
			return toolkitProtocol.UpdateCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol FixCR(String crIDNum)
		{
			return toolkitProtocol.FixCR( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol FixCR(FixCRSetupWS setupParam)
		{
			return toolkitProtocol.FixCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol DuplicateCR(String crIDNum, String masterCRIDNum)
		{
			return toolkitProtocol.DuplicateCR( crIDNum, masterCRIDNum );
		}
		
		public Protocol.ToolkitResultProtocol DuplicateCR(DuplicateCRSetupWS setupParam)
		{
			return toolkitProtocol.DuplicateCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol AddModuleToCR(Int32 fixObjid, String fileName)
		{
			return toolkitProtocol.AddModuleToCR( fixObjid, fileName );
		}
		
		public Protocol.ToolkitResultProtocol AddModuleToCR(AddModuleToCRSetupWS setupParam)
		{
			return toolkitProtocol.AddModuleToCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol ChangeCRStatus(String crIDNum)
		{
			return toolkitProtocol.ChangeCRStatus( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol ChangeCRStatus(ChangeCRStatusSetupWS setupParam)
		{
			return toolkitProtocol.ChangeCRStatus( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol ReopenCR(String crIDNum)
		{
			return toolkitProtocol.ReopenCR( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol ReopenCR(ReopenCRSetupWS setupParam)
		{
			return toolkitProtocol.ReopenCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol CloseCR(String crIDNum)
		{
			return toolkitProtocol.CloseCR( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol CloseCR(CloseCRSetupWS setupParam)
		{
			return toolkitProtocol.CloseCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol CheckClearQualityTransition(String oldCondition, String oldStatus, String newCondition, String newStatus, String userName)
		{
			return toolkitProtocol.CheckClearQualityTransition( oldCondition, oldStatus, newCondition, newStatus, userName );
		}
		
		public Protocol.ToolkitResultProtocol CheckClearQualityTransition(CheckClearQualityTransitionSetupWS setupParam)
		{
			return toolkitProtocol.CheckClearQualityTransition( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol LogCRNote(String crIDNum)
		{
			return toolkitProtocol.LogCRNote( crIDNum );
		}
		
		public Protocol.ToolkitResultProtocol LogCRNote(LogCRNoteSetupWS setupParam)
		{
			return toolkitProtocol.LogCRNote( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol CreateCR(String partNumber, String partRevision, String partDomain)
		{
			return toolkitProtocol.CreateCR( partNumber, partRevision, partDomain );
		}
		
		public Protocol.ToolkitResultProtocol CreateCR(CreateCRSetupWS setupParam)
		{
			return toolkitProtocol.CreateCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol YankCR(String cridnum)
		{
			return toolkitProtocol.YankCR( cridnum );
		}
		
		public Protocol.ToolkitResultProtocol YankCR(YankCRSetupWS setupParam)
		{
			return toolkitProtocol.YankCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol MoveCR(String cridnum, String newWipBin)
		{
			return toolkitProtocol.MoveCR( cridnum, newWipBin );
		}
		
		public Protocol.ToolkitResultProtocol MoveCR(MoveCRSetupWS setupParam)
		{
			return toolkitProtocol.MoveCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol AssignCR(String cridnum)
		{
			return toolkitProtocol.AssignCR( cridnum );
		}
		
		public Protocol.ToolkitResultProtocol AssignCR(AssignCRSetupWS setupParam)
		{
			return toolkitProtocol.AssignCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol ForwardCR(String cridnum, String newQueue)
		{
			return toolkitProtocol.ForwardCR( cridnum, newQueue );
		}
		
		public Protocol.ToolkitResultProtocol ForwardCR(ForwardCRSetupWS setupParam)
		{
			return toolkitProtocol.ForwardCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol RejectCR(String cridnum)
		{
			return toolkitProtocol.RejectCR( cridnum );
		}
		
		public Protocol.ToolkitResultProtocol RejectCR(RejectCRSetupWS setupParam)
		{
			return toolkitProtocol.RejectCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol AcceptCR(String cridnum)
		{
			return toolkitProtocol.AcceptCR( cridnum );
		}
		
		public Protocol.ToolkitResultProtocol AcceptCR(AcceptCRSetupWS setupParam)
		{
			return toolkitProtocol.AcceptCR( setupParam.ToProtocol() );
		}
		
		public Protocol.ToolkitResultProtocol DispatchCR(String cridnum, String queue)
		{
			return toolkitProtocol.DispatchCR( cridnum, queue );
		}
		
		public Protocol.ToolkitResultProtocol DispatchCR(DispatchCRSetupWS setupParam)
		{
			return toolkitProtocol.DispatchCR( setupParam.ToProtocol() );
		}
		
	}
}
