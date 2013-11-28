using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RingCaptcha;

public partial class Default : System.Web.UI.Page 
{
    public const string APP_KEY = "o7adifu4ariqi6egyfa8";
    const string SECRET_KEY = "e7a2ajycakemu6i6i2e8";

    protected void Page_Load(object sender, EventArgs e)
    {
        // FormControl.AppKey = APP_KEY;

        if (IsPostBack)
        {
            var pinCode = Request["ringcaptcha_pin_code"];
            var token = Request["ringcaptcha_session_id"];

            if (!string.IsNullOrEmpty(token))
            {
                pnlTryAgain.Visible = true;

                var ringCaptch = new Ringcaptcha(APP_KEY, SECRET_KEY);
                if (ringCaptch.isValid(pinCode, token))
                {
                    FormControl.Visible = false;
                    ErrorControl.Visible = false;

                    SucessControl.TransactionID = ringCaptch.Id;
                    SucessControl.PhoneNumber = ringCaptch.PhoneNumber;
                    SucessControl.Geolocation = ringCaptch.Geolocated ? "TRUE" : "FALSE";
                    SucessControl.PhoneType = !string.IsNullOrEmpty(ringCaptch.PhoneType) ? ringCaptch.PhoneType : "N/A";
                    SucessControl.CarrierName = !string.IsNullOrEmpty(ringCaptch.CarrierName) ? ringCaptch.CarrierName : "N/A";
                    SucessControl.DeviceName = !string.IsNullOrEmpty(ringCaptch.DeviceName) ? ringCaptch.DeviceName : "N/A";
                    SucessControl.IspName = !string.IsNullOrEmpty(ringCaptch.IspName) ? ringCaptch.IspName : "N/A";

                    SucessControl.Visible = true;
                }
                else
                {
                    FormControl.Visible = false;
                    SucessControl.Visible = false;

                    ErrorControl.Message = ringCaptch.Message;
                    ErrorControl.Visible = true;
                }
            }
        }
        DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SucessControl.Visible = false;
        ErrorControl.Visible = false;
        pnlTryAgain.Visible = false;
        FormControl.Visible = true;
        
    }
}