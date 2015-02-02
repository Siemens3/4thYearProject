using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Configuration;
using System.Drawing.Imaging;

namespace ReptileManager
{
    public partial class QrView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();

            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            encoder.QRCodeScale = 4;

             
            // change this so the id is passed to create the code
          Bitmap img = encoder.Encode("https://reptilemanager.azurewebsites.net/");
          img.Save("C:\\Users\\Stephen\\Documents\\GitHub\\4thYearPro\\ReptileManager\\ReptileManager\\qrImage.jpg",ImageFormat.Jpeg);

          QRImage.ImageUrl = "qrImage.jpg";
        }
    }
}