using System;
using FChoice.Toolkits.Clarify.Support;

namespace FChoice.WebServices.Clarify.Protocols
{
	public class SubcaseTimeAndExpensesProtocol
	{
		public int CapturedPhoneTime;
		public int CapturedResearchTime;
		public int TotalNonBillableTime;
		public int TotalBillableTime;
		public decimal TotalNonBillableExpenses;
		public decimal TotalBillableExpenses;

		public SubcaseTimeAndExpensesProtocol(){}

		internal SubcaseTimeAndExpensesProtocol(SubcaseTimeAndExpenses totals)
		{
			this.CapturedPhoneTime = totals.CapturedPhoneTime.Seconds;
			this.CapturedResearchTime = totals.CapturedResearchTime.Seconds;
			this.TotalNonBillableTime = totals.TotalNonBillableTime.Seconds;
			this.TotalBillableTime = totals.TotalBillableTime.Seconds;
			this.TotalNonBillableExpenses = totals.TotalNonBillableExpenses;
			this.TotalBillableExpenses = totals.TotalBillableExpenses;
		}

	}
}
