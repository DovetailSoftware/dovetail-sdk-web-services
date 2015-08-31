using System;
using FChoice.Toolkits.Clarify.Support;

namespace FChoice.WebServices.Clarify.Protocols
{
	public class CaseTimeAndExpensesProtocol
	{
		public int TotalPhoneTime;
		public int TotalActualPhoneTime;
		public int CasePhoneTime;
		public int CaseActualPhoneTime;
		public int TotalResearchTime;
		public int TotalActualResearchTime;
		public int CaseResearchTime;
		public int CaseActualResearchTime;
		public int TotalNonBillableTime;
		public int CaseNonBillableTime;
		public int TotalBillableTime;
		public int CaseBillableTime;
		public decimal TotalNonBillableExpenses;
		public decimal CaseNonBillableExpenses;
		public decimal TotalBillableExpenses;
		public decimal CaseBillableExpenses;

		internal void FillCaseTimeAndExpenses( CaseTimeAndExpenses totals )
		{
			totals.TotalPhoneTime = TimeSpan.FromSeconds(this.TotalPhoneTime);
			totals.TotalActualPhoneTime = TimeSpan.FromSeconds(this.TotalActualPhoneTime);
			totals.CasePhoneTime = TimeSpan.FromSeconds(this.CasePhoneTime);
			totals.CaseActualPhoneTime = TimeSpan.FromSeconds(this.CaseActualPhoneTime);
			totals.TotalResearchTime = TimeSpan.FromSeconds(this.TotalResearchTime);
			totals.TotalActualResearchTime = TimeSpan.FromSeconds(this.TotalActualResearchTime);
			totals.CaseResearchTime = TimeSpan.FromSeconds(this.CaseResearchTime);
			totals.CaseActualResearchTime = TimeSpan.FromSeconds(this.CaseActualResearchTime);
			totals.TotalNonBillableTime = TimeSpan.FromSeconds(this.TotalNonBillableTime);
			totals.CaseNonBillableTime = TimeSpan.FromSeconds(this.CaseNonBillableTime);
			totals.TotalBillableTime = TimeSpan.FromSeconds(this.TotalBillableTime);
			totals.CaseBillableTime = TimeSpan.FromSeconds(this.CaseBillableTime);
			totals.TotalNonBillableExpenses = this.TotalNonBillableExpenses;
			totals.CaseNonBillableExpenses = this.CaseNonBillableExpenses;
			totals.TotalBillableExpenses = this.TotalBillableExpenses;
			totals.CaseBillableExpenses = this.CaseBillableExpenses;
		}

		public CaseTimeAndExpensesProtocol(){}

		internal CaseTimeAndExpensesProtocol(CaseTimeAndExpenses totals)
		{
			this.TotalPhoneTime = totals.TotalPhoneTime.Seconds;
			this.TotalActualPhoneTime = totals.TotalActualPhoneTime.Seconds;
			this.CasePhoneTime = totals.CasePhoneTime.Seconds;
			this.CaseActualPhoneTime = totals.CaseActualPhoneTime.Seconds;
			this.TotalResearchTime = totals.TotalResearchTime.Seconds;
			this.TotalActualResearchTime = totals.TotalActualResearchTime.Seconds;
			this.CaseResearchTime = totals.CaseResearchTime.Seconds;
			this.CaseActualResearchTime = totals.CaseActualResearchTime.Seconds;
			this.TotalNonBillableTime = totals.TotalNonBillableTime.Seconds;
			this.CaseNonBillableTime = totals.CaseNonBillableTime.Seconds;
			this.TotalBillableTime = totals.TotalBillableTime.Seconds;
			this.CaseBillableTime = totals.CaseBillableTime.Seconds;
			this.TotalNonBillableExpenses = totals.TotalNonBillableExpenses;
			this.CaseNonBillableExpenses = totals.CaseNonBillableExpenses;
			this.TotalBillableExpenses = totals.TotalBillableExpenses;
			this.CaseBillableExpenses = totals.CaseBillableExpenses;
		}

	}
}
