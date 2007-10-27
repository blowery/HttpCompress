using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Fetch
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
    private System.Windows.Forms.StatusBar statusBar;
    private System.Windows.Forms.Label urlLabel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton gzipOption;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox urlToHit;
    private System.Windows.Forms.Button evaluateButton;
    private System.Windows.Forms.RadioButton deflateOption;
    private System.Windows.Forms.ListBox resultsList;
    private System.Windows.Forms.Label userAgentLabel;
    private System.Windows.Forms.TextBox userAgentToUse;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.urlToHit = new System.Windows.Forms.TextBox();
      this.urlLabel = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.userAgentToUse = new System.Windows.Forms.TextBox();
      this.userAgentLabel = new System.Windows.Forms.Label();
      this.gzipOption = new System.Windows.Forms.RadioButton();
      this.deflateOption = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.evaluateButton = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.resultsList = new System.Windows.Forms.ListBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 247);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(492, 22);
      this.statusBar.TabIndex = 0;
      this.statusBar.Text = "OK";
      // 
      // urlToHit
      // 
      this.urlToHit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.urlToHit.Location = new System.Drawing.Point(8, 32);
      this.urlToHit.Name = "urlToHit";
      this.urlToHit.Size = new System.Drawing.Size(376, 21);
      this.urlToHit.TabIndex = 1;
      this.urlToHit.Text = "http://";
      // 
      // urlLabel
      // 
      this.urlLabel.Location = new System.Drawing.Point(8, 16);
      this.urlLabel.Name = "urlLabel";
      this.urlLabel.Size = new System.Drawing.Size(120, 16);
      this.urlLabel.TabIndex = 2;
      this.urlLabel.Text = "URL to Check:";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.userAgentToUse);
      this.groupBox1.Controls.Add(this.userAgentLabel);
      this.groupBox1.Controls.Add(this.gzipOption);
      this.groupBox1.Controls.Add(this.deflateOption);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.urlLabel);
      this.groupBox1.Controls.Add(this.urlToHit);
      this.groupBox1.Controls.Add(this.evaluateButton);
      this.groupBox1.Location = new System.Drawing.Point(8, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(476, 136);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Connection Options";
      // 
      // userAgentToUse
      // 
      this.userAgentToUse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.userAgentToUse.Location = new System.Drawing.Point(224, 64);
      this.userAgentToUse.Name = "userAgentToUse";
      this.userAgentToUse.Size = new System.Drawing.Size(160, 21);
      this.userAgentToUse.TabIndex = 6;
      this.userAgentToUse.Text = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT)";
      // 
      // userAgentLabel
      // 
      this.userAgentLabel.Location = new System.Drawing.Point(152, 64);
      this.userAgentLabel.Name = "userAgentLabel";
      this.userAgentLabel.Size = new System.Drawing.Size(64, 16);
      this.userAgentLabel.TabIndex = 7;
      this.userAgentLabel.Text = "User Agent";
      // 
      // gzipOption
      // 
      this.gzipOption.Checked = true;
      this.gzipOption.Location = new System.Drawing.Point(24, 104);
      this.gzipOption.Name = "gzipOption";
      this.gzipOption.TabIndex = 5;
      this.gzipOption.TabStop = true;
      this.gzipOption.Text = "GZip";
      // 
      // deflateOption
      // 
      this.deflateOption.Location = new System.Drawing.Point(24, 80);
      this.deflateOption.Name = "deflateOption";
      this.deflateOption.TabIndex = 4;
      this.deflateOption.Tag = "deflate";
      this.deflateOption.Text = "Deflate";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 64);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(144, 23);
      this.label1.TabIndex = 3;
      this.label1.Text = "Compression  Algorithm:";
      // 
      // evaluateButton
      // 
      this.evaluateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.evaluateButton.Location = new System.Drawing.Point(392, 32);
      this.evaluateButton.Name = "evaluateButton";
      this.evaluateButton.TabIndex = 4;
      this.evaluateButton.Text = "Fetch!";
      this.evaluateButton.Click += new System.EventHandler(this.evaluateButton_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.resultsList);
      this.groupBox2.Location = new System.Drawing.Point(8, 160);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(476, 84);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Results";
      // 
      // resultsList
      // 
      this.resultsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.resultsList.Location = new System.Drawing.Point(8, 16);
      this.resultsList.Name = "resultsList";
      this.resultsList.Size = new System.Drawing.Size(456, 56);
      this.resultsList.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AcceptButton = this.evaluateButton;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
      this.ClientSize = new System.Drawing.Size(492, 269);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.statusBar);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.MinimumSize = new System.Drawing.Size(500, 300);
      this.Name = "MainForm";
      this.Text = "Compression Checker";
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void evaluateButton_Click(object sender, System.EventArgs e) {
      Uri url;
      try {
        url = new Uri(urlToHit.Text);
      } catch(UriFormatException) {
        statusBar.Text = "Invalid URL!";
        return;
      }
      statusBar.Text = "Fetching uncompressed...";
      
      RunInfo[] results = new RunInfo[2];
      
      results[0] = FetchUncompressedUrl(url);
      statusBar.Text = "Fetching compressed...";
      
      if(deflateOption.Checked) 
        results[1] = FetchCompressedUrl(url, "deflate");
      else
        results[1] = FetchCompressedUrl(url, "gzip");

      resultsList.DataSource = results;

      statusBar.Text = "Done!";

    }

    RunInfo FetchUncompressedUrl(Uri url) {
      RunInfo ri = new RunInfo();
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.UserAgent = userAgentToUse.Text;
      DateTime start = DateTime.Now;
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      ri.TimeToFirstByte = DateTime.Now - start;
      ri.BytesReceived = DumpStream(response.GetResponseStream(), Stream.Null);
      ri.TimeToLastByte = DateTime.Now - start;
      return ri;
    }

    RunInfo FetchCompressedUrl(Uri url, string algo) {
      RunInfo ri = new RunInfo(algo);
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.Headers["Accept-Encoding"] = algo;
      request.UserAgent = userAgentToUse.Text;
      DateTime start = DateTime.Now;
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      ri.TimeToFirstByte = DateTime.Now - start;
      ri.BytesReceived = DumpStream(response.GetResponseStream(), Stream.Null);
      ri.TimeToLastByte = DateTime.Now - start;
      return ri;
    }

    static long DumpStream(Stream s, Stream output) {

      byte[] buffer = new byte[1024];
      long count = 0;
      int read = 0;
      while((read = s.Read(buffer, 0, 1024)) > 0) {
        count += read;
        output.Write(buffer, 0, read);
      }
      return count;
    }

    class RunInfo {
      public long BytesReceived = -1;
      public TimeSpan TimeToFirstByte = TimeSpan.Zero;
      public TimeSpan TimeToLastByte = TimeSpan.Zero;
      public TimeSpan TransitTime { get { return TimeToLastByte - TimeToFirstByte; } }
      public string Algorithm = "none";

      public RunInfo() {
      }

      public RunInfo(string algo) {
        Algorithm = algo;
      }

      public override string ToString() {
        return string.Format("{0}; {1} bytes; TTFB={2}ms; TTLB={3}ms; Transit={4}ms", Algorithm, BytesReceived,  TimeToFirstByte.TotalMilliseconds, TimeToLastByte.TotalMilliseconds, TransitTime.TotalMilliseconds);
      }

    }
	}
}
