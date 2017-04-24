<%@ WebHandler Language="C#" Class="GetImageUrl" %>

using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Custom.Data;

public class GetImageUrl : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        int id = -1;
        int big = 0;
        int width = 0;
        int height = 0;
        Font f;
        bool result = Int32.TryParse(context.Request.QueryString["id"], out id);
        if (!result)
            context.Response.End();
        byte[] img = null;
        Int32.TryParse(context.Request.QueryString["big"], out big);
        //Int32.TryParse(context.Request.QueryString["size"], out width);
        Int32.TryParse(context.Request.QueryString["width"], out width);
        Int32.TryParse(context.Request.QueryString["height"], out height);
        SqlConnection conn = DataProvider.GetConnection();
        SqlCommand cmd = new SqlCommand("SELECT [Image] FROM images WHERE Id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        conn.Open();
        img = (byte[])cmd.ExecuteScalar();
        conn.Close();
        if (img != null && img.Length > 0)
        {
            context.Response.ContentType = "image/jpeg";
            Stream s = new MemoryStream();
            BinaryWriter w = new BinaryWriter(s);
            w.Write(img);
            System.Drawing.Image img1 = System.Drawing.Image.FromStream(s);
            if (big == 1)
            {
                width = img1.Width;
                height = img1.Height;
                f = new Font("Tahoma", 48);
            }
            else
            {
                if (width <= 0 && height <= 0)
                    width = 200;
                if (width <= 0 && height > 0)
                    width = img1.Width * height / img1.Height;
                else
                    height = img1.Height * width / img1.Width;
                f = new Font("Tahoma", 7);
            }
            Bitmap imgOutput = new Bitmap(width, height);
            imgOutput.MakeTransparent(Color.Black);
            Graphics newGraphics = Graphics.FromImage(imgOutput);
            newGraphics.Clear(Color.FromArgb(0, 255, 255, 255));
            newGraphics.CompositingQuality = CompositingQuality.HighQuality;
            newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            newGraphics.DrawImage(img1, 0, 0, width, height);
            SolidBrush b = new SolidBrush(Color.Beige);
            //newGraphics.DrawString("MyBritishCats", f, b, 3, 3);
            newGraphics.Flush();
            newGraphics.Dispose();
            imgOutput.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }

}