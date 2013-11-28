using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sucess : System.Web.UI.UserControl
{
    public string TransactionID { get; set; }
    public string PhoneNumber { get; set; }
    public string Geolocation { get; set; }
    public string PhoneType { get; set; }
    public string CarrierName { get; set; }
    public string DeviceName { get; set; }
    public string IspName { get; set; }
}