using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace FChoice.WebServices.Clarify.Client.Demo
{
	public class PostBackPageScroll : Control, INamingContainer
	{
		protected HtmlInputHidden scrollX = new HtmlInputHidden();
		protected HtmlInputHidden scrollY = new HtmlInputHidden();

		protected override void CreateChildControls()
		{
			scrollX.ID = "scrollX";
			scrollY.ID = "scrollY";
			this.Controls.Add( scrollX );
			this.Controls.Add( scrollY );
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			string js = String.Format(@"
					<script language=""javascript"">
							window.onscroll = SetPageScroll;
							function SetPageScroll()
							{0}
								document.all.{2}.value = document.body.scrollLeft;
								document.all.{3}.value = document.body.scrollTop;
								return true;
							{1}
					</script>", "{", "}",
				this.scrollX.ClientID,
				this.scrollY.ClientID );

			Page.RegisterClientScriptBlock( "SetPageScroll", js);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render (writer);
			if( Page.IsPostBack )
			{
				writer.Write(@"<script language=""javascript"">window.scroll({0},{1});</script>",
					this.scrollX.Value.Length > 0 ? this.scrollX.Value : "0",
					this.scrollY.Value.Length > 0 ? this.scrollY.Value : "0");
			}
		}
	}
}
