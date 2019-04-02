using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace RonEBaySearchEngine
{
    public partial class Form1 : Form
    {
        bool fileDone;
        int brCnt;

        public bool finalDelete { get; set; }

        public Form1()
        {
            InitializeComponent();

           // this.Size 
            DataGridView.CheckForIllegalCrossThreadCalls = false;

            string line;
            List<string> B1 = new List<string>();
            List<string> B2 = new List<string>();
            List<string> B3 = new List<string>();
            List<string> B4 = new List<string>();
            List<string> B5 = new List<string>();
            List<string> B6 = new List<string>();
            List<string> B7 = new List<string>();

            int flag = 0;

            DateTime lastModified;
            if (!File.Exists("data.txt"))
            {
                File.Copy("data_origin.txt", "data.txt");
                lastModified = System.IO.File.GetLastWriteTime("data_origin.txt");
                label2.Text = "Last Search : " + lastModified.ToString();
            }
            else {
                lastModified = System.IO.File.GetLastWriteTime("data.txt");
                label2.Text = "Last Search : " + lastModified.ToString();
            }

           // label2.Text = "Last Search : " + DateTime.Now.ToString();

            System.IO.StreamReader file =
            new System.IO.StreamReader(@"data.txt");
            while ((line = file.ReadLine()) != null)
            {

                if (line =="@")
                {                   
                    flag++;
                }
                else
                {
                    if (flag == 0)
                        B1.Add(line);

                    if (flag == 1)
                        B2.Add(line);

                    if (flag == 2)
                        B3.Add(line);

                    if (flag == 3)
                        B4.Add(line);

                    if (flag == 4)
                        B5.Add(line);

                    if (flag == 5)
                        B6.Add(line);

                    if (flag == 6)
                        B7.Add(line);
                }
            }

            file.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("Line"); //0
            dt.Columns.Add("KEY WORD NO 1"); //0
            dt.Columns.Add("AU1");
            dt.Columns.Add("UK1");
            dt.Columns.Add("US1");
            dt.Columns["Line"].DataType = typeof(Int32);
            dt.Columns["AU1"].DataType = typeof(Int32);
            dt.Columns["UK1"].DataType = typeof(Int32);
            dt.Columns["US1"].DataType = typeof(Int32);
            dt.Columns.Add("KEY WORD NO 2"); //4
            dt.Columns.Add("AU2");
            dt.Columns.Add("UK2");
            dt.Columns.Add("US2");
            dt.Columns["AU2"].DataType = typeof(Int32);
            dt.Columns["UK2"].DataType = typeof(Int32);
            dt.Columns["US2"].DataType = typeof(Int32);
            dt.Columns.Add("KEY WORD NO 3"); //8
            dt.Columns.Add("AU3");
            dt.Columns.Add("UK3");
            dt.Columns.Add("US3");
            dt.Columns["AU3"].DataType = typeof(Int32);
            dt.Columns["UK3"].DataType = typeof(Int32);
            dt.Columns["US3"].DataType = typeof(Int32);
            dt.Columns.Add("KEY WORD NO 4"); //12
            dt.Columns.Add("AU4");
            dt.Columns.Add("UK4");
            dt.Columns.Add("US4");
            dt.Columns["AU4"].DataType = typeof(Int32);
            dt.Columns["UK4"].DataType = typeof(Int32);
            dt.Columns["US4"].DataType = typeof(Int32);
            dt.Columns.Add("KEY WORD NO 5"); //16
            dt.Columns.Add("AU5");
            dt.Columns.Add("UK5");
            dt.Columns.Add("US5");
            dt.Columns["AU5"].DataType = typeof(Int32);
            dt.Columns["UK5"].DataType = typeof(Int32);
            dt.Columns["US5"].DataType = typeof(Int32);
            dt.Columns.Add("KEY WORD NO 6"); //20
            dt.Columns.Add("AU6");
            dt.Columns.Add("UK6");
            dt.Columns.Add("US6");
            dt.Columns["AU6"].DataType = typeof(Int32);
            dt.Columns["UK6"].DataType = typeof(Int32);
            dt.Columns["US6"].DataType = typeof(Int32);
            dt.Columns.Add("KEY WORD NO 7"); //24
            dt.Columns.Add("AU7");
            dt.Columns.Add("UK7");
            dt.Columns.Add("US7");
            dt.Columns["AU7"].DataType = typeof(Int32);
            dt.Columns["UK7"].DataType = typeof(Int32);
            dt.Columns["US7"].DataType = typeof(Int32);
            DataRow dr;
            string tmp = "";
            for (int i = 0; i < B1.Count; i++) {
                dr = dt.NewRow();
                tmp = B1[i];
                dr[0] = tmp.Split(',')[0];
                dr[1] = tmp.Split(',')[1];
                dr[2] = tmp.Split(',')[2];
                dr[3] = tmp.Split(',')[3];
                dr[4] = tmp.Split(',')[4];
                tmp = B2[i];
                dr[5] = tmp.Split(',')[0];
                dr[6] = tmp.Split(',')[1];
                dr[7] = tmp.Split(',')[2];
                dr[8] = tmp.Split(',')[3];
                tmp = B3[i];
                dr[9] = tmp.Split(',')[0];
                dr[10] = tmp.Split(',')[1];
                dr[11] = tmp.Split(',')[2];
                dr[12] = tmp.Split(',')[3];
                tmp = B4[i];
                dr[13] = tmp.Split(',')[0];
                dr[14] = tmp.Split(',')[1];
                dr[15] = tmp.Split(',')[2];
                dr[16] = tmp.Split(',')[3];
                tmp = B5[i];
                dr[17] = tmp.Split(',')[0];
                dr[18] = tmp.Split(',')[1];
                dr[19] = tmp.Split(',')[2];
                dr[20] = tmp.Split(',')[3];
                tmp = B6[i];
                dr[21] = tmp.Split(',')[0];
                dr[22] = tmp.Split(',')[1];
                dr[23] = tmp.Split(',')[2];
                dr[24] = tmp.Split(',')[3];
                tmp = B7[i];
                dr[25] = tmp.Split(',')[0];
                dr[26] = tmp.Split(',')[1];
                dr[27] = tmp.Split(',')[2];
                dr[28] = tmp.Split(',')[3];
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;
          
            //dataGridView1.DataSource

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {    
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }


            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridView1.Columns[0].ReadOnly = true;

            writeHtml();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

     

        private void writeHtml()
        {

            //   webBrowser2.Visible = true;
            //if (webBrowser2.DocumentText != "")
            //{
            //    webBrowser2.DocumentText = "";
            //}

            int cnt = 0;

            if (File.Exists(@"SearchList.txt"))
            {
                string text = File.ReadAllText(@"SearchList.txt");
                string[] lines = text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
                string[] datas;
                string html = "";              
                IList<string> prevs = new List<string>();
                IList<string> images = new List<string>();

                foreach (string ln in lines)
                {
                    if (ln != "")
                    {
                        datas = ln.Split(new string[] { "|||" }, StringSplitOptions.None);                        
                         
                        if (datas.Length == 3)
                        {
                            if ((prevs.Count == 0) || ((prevs.IndexOf(datas[2].Trim()) < 0)  &&  (images.IndexOf(datas[1].Trim()) < 0)))
                            {
                                html += "<tr>";
                                html += "<td>";
                                html += "<a href='" + datas[0] + "' target='_blank'><img src='" + datas[1] + "'/></a>";
                                html += "</td>";
                                html += "<td>";
                                html += "&nbsp;&nbsp;&nbsp;&nbsp;";
                                html += "</td>";
                                html += "<td valign='bottom' style='font-size=25px'>";
                                html += "<a href='" + datas[0] + "' target='_blank'>" + datas[2] + "</a>";
                                html += "</td>";
                                html += "</tr>";
                                cnt++;
                                images.Add(datas[1].Trim());
                                prevs.Add(datas[2].Trim());                            
                            }
                        }
                    }
                }              

                if (html != "")
                {
                    webBrowser2.DocumentText = "<html><body><table>" + html + "</table></body></html>";
                    label3.Text = "ITEMS FOUND: " + cnt.ToString();
                }
                else {
                    label3.Text = "ITEMS FOUND: 0";
                }
            }
         //   webBrowser2.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("data.txt"))
                    File.Delete("data.txt");

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"data.txt"))
                {
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[0].Value != null)
                        {
                            file.WriteLine(dr.Cells[0].Value.ToString());
                        }
                    }

                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[1].Value != null)
                        {
                            file.WriteLine(dr.Cells[1].Value.ToString());
                        }
                    }

                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[2].Value != null)
                        {
                            file.WriteLine(dr.Cells[2].Value.ToString());
                        }
                    }


                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[3].Value != null)
                        {
                            file.WriteLine(dr.Cells[3].Value.ToString());
                        }
                    }


                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[4].Value != null)
                        {
                            file.WriteLine(dr.Cells[4].Value.ToString());
                        }
                    }

                }

                MessageBox.Show("The New Data has been saved sucessfully.");
            }
            catch (Exception er) {
                MessageBox.Show("The New Data has been saved unsucessfully.\n"+@er.Message);
                if (File.Exists("data.txt"))
                    File.Delete("data.txt");

                File.Copy("data_origin.txt", "data.txt");
            }
        }





        //private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        //{
        //    e.Cancel = true;
        //    WebClient client = new WebClient();

        //    client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);

        //    client.DownloadDataAsync(e.Url);

        //}


        //void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        //{           
        //    string filepath = @"DataSearch\"+dataGridView1.CurrentCell.Value.ToString() + ".html";
        //    brCnt++;

        //    if (brCnt == 3)
        //    {
        //        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
        //        webBrowser1.Url = new Uri("https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[0].Cells[1].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1");
        //        brCnt = 0;
        //    }

        //    if (!File.Exists(filepath))
        //    {
        //        File.WriteAllBytes(filepath, e.Result);             
        //    }
        //  //  MessageBox.Show("File downloaded");
        //}


        async System.Threading.Tasks.Task PutTaskDelay()
        {
            await System.Threading.Tasks.Task.Delay(10000);
            this.Close();
        }

             

        public string WebText(string url)
        {
            string html = "";

            if (url == "")
                return "";

            try
            {
                using (WebClient client = new WebClient())
                {
                    // client.UseDefaultCredentials

                    //client.UseDefaultCredentials = true;
                    //client.Credentials = new NetworkCredential("scott_zhan@hotmail.com", "ilike7fish");
                    client.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.12) Gecko/20100824 Firefox/3.5.12x";
                    client.Encoding = Encoding.UTF8;
                    html = client.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                // handle error
                Console.WriteLine(ex.Message);
            }

            return (html == "" ? "" : html.Trim());
        }


        public void DoWork(IProgress<int> progress)
        {
            // This method is executed in the context of
            // another thread (different than the main UI thread),
            // so use only thread-safe code
         
            int cnt = 0; 
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            string url = "";
            string qty = "";
            string[] rsultArrr;
            int n;
            bool isNumeric;
            string text = "";
            int isOk = 0;

            for (int r = 0; r < dataGridView1.RowCount; r++)
            {
                for (int c = 0; c < dataGridView1.ColumnCount; c++)
                {
                    if ((c != 0) && (c != 1) && (c != 5) && (c != 9) && (c != 13) && (c != 17) && (c != 21) && (c != 25))
                    {
                        dataGridView1.Rows[r].Cells[c].Value = 0;
                    }
                }
            }

            string Html = "";
            string text2 = "";
            string rowIdx = "";
            brCnt = 0;
            for (int r = 0; r < dataGridView1.RowCount; r++)
          // for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < dataGridView1.ColumnCount; c++)
                {
                    if ((c == 1) || (c == 5) || (c == 9) || (c == 13) || (c == 17) || (c == 21) || (c == 25)){
                        if (dataGridView1.Rows[r].Cells[c].Value != null)
                        {
                           // if ((dataGridView1.Rows[r].Cells[c].Value.ToString() != "") && (dataGridView1.Rows[r].Cells[c].Value.ToString() == "RADIOEAR DEVICE"))
                             if (dataGridView1.Rows[r].Cells[c].Value.ToString() != "")
                            {
                                if (!File.Exists(dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html"))
                                {
                                    url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[r].Cells[c].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";

                                    // url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[r].Cells[c].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1&_clu=2&_fcid=15&_localstpos=2526&_stpos=2526&gbr=1";
                                    // File.WriteAllBytes(@"DataSearch\AU_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", Encoding.ASCII.GetBytes(WebText(url)));

                                    text2 = WebText(url);
                                    text = text2.Split(new string[] { "result" }, StringSplitOptions.None)[0];
                                    rsultArrr = text.Split('>');

                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" VINTAGE") > -1) {
                                        rowIdx = "1";
                                    }

                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" DEVICE") > -1)
                                    {
                                        rowIdx = "2";
                                    }


                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" ANTIQUE") > -1)
                                    {
                                        rowIdx = "3";
                                    }


                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" HEARING") > -1)
                                    {
                                        rowIdx = "4";
                                    }


                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" CATALOGUE") > -1)
                                    {
                                        rowIdx = "5";
                                    }


                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" RARE") > -1)
                                    {
                                        rowIdx = "6";
                                    }


                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf(" VTG") > -1)
                                    {
                                        rowIdx = "7";
                                    }



                                    qty = rsultArrr[rsultArrr.Length - 1].Replace(",", "");
                                    isNumeric = int.TryParse(qty, out n);
                                    if (isNumeric)
                                    {
                                        dataGridView1.Rows[r].Cells[c + 1].Value = Convert.ToInt32(qty);                                      
                                        buildHtml(ref Html, text2, url, qty, "AU_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", "Line "+ dataGridView1.Rows[r].Cells[0].Value.ToString() + " (AU"+ rowIdx + ") "+ dataGridView1.Rows[r].Cells[c].Value.ToString());
                                    }
                                    else
                                    {
                                        try
                                        {
                                            qty = rsultArrr[rsultArrr.Length - 3].Replace("</span", "").Replace(",", ""); ;
                                            dataGridView1.Rows[r].Cells[c + 1].Value = Convert.ToInt32(qty);                                            
                                            buildHtml(ref Html, text2, url, qty, "AU_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", "Line " + dataGridView1.Rows[r].Cells[0].Value.ToString() + " (AU" + rowIdx + ") " + dataGridView1.Rows[r].Cells[c].Value.ToString());
                                        }
                                        catch (Exception er) {
                                            dataGridView1.Rows[r].Cells[c + 1].Value = Convert.ToInt32(0);
                                        }
                                    }



                                    url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw="+ dataGridView1.Rows[r].Cells[c].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1&_clu=2&_fcid=3&_localstpos=cb89tn&_stpos=cb89tn&gbr=1";

                                    //  url = "https://www.ebay.co.uK/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[r].Cells[c].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                                    //  File.WriteAllBytes(@"DataSearch\UK_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", Encoding.ASCII.GetBytes(WebText(url)));
                                    text2 = WebText(url);
                                    text = text2.Split(new string[] { "result" }, StringSplitOptions.None)[0];
                                    rsultArrr = text.Split('>');
                                    
                                    string colIdx = "";
                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf("VINTAGE") > -1) {
                                        colIdx = "1";
                                    }

                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf("DEVICE") > -1)
                                    {
                                        colIdx = "2";
                                    }

                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf("ANTIQUE") > -1)
                                    {
                                        colIdx = "3";
                                    }

                                    if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf("HEARING") > -1)
                                    {
                                        colIdx = "4";
                                    }


                                    qty = rsultArrr[rsultArrr.Length - 1].Replace(",", "");
                                    isNumeric = int.TryParse(qty, out n);
                                    if (isNumeric)
                                    {
                                        dataGridView1.Rows[r].Cells[c + 2].Value = Convert.ToInt32(qty);                                        
                                        buildHtml(ref Html, text2, url, qty, "UK_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", "Line " + dataGridView1.Rows[r].Cells[0].Value.ToString() + " (UK" + rowIdx + ") " + dataGridView1.Rows[r].Cells[c].Value.ToString());
                                    }
                                    else
                                    {
                                        try
                                        {
                                            qty = rsultArrr[rsultArrr.Length - 3].Replace("</span", "").Replace(",", "");
                                            dataGridView1.Rows[r].Cells[c + 2].Value = Convert.ToInt32(qty);                                       
                                            buildHtml(ref Html, text2, url, qty, "UK_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", "Line " + dataGridView1.Rows[r].Cells[0].Value.ToString() + " (UK" + rowIdx + ") " + dataGridView1.Rows[r].Cells[c].Value.ToString());
                                        }
                                        catch (Exception er)
                                        {
                                            dataGridView1.Rows[r].Cells[c + 2].Value = Convert.ToInt32(0);
                                        }
                                    }

                                    url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[r].Cells[c].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                                    text2 = WebText(url);
                                    text = text2.Split(new string[] { "result" }, StringSplitOptions.None)[0];
                                    rsultArrr = text.Split('>');

                                    qty = rsultArrr[rsultArrr.Length - 1].Replace(",", "");
                                    isNumeric = int.TryParse(qty, out n);
                                    if (isNumeric)
                                    {
                                        dataGridView1.Rows[r].Cells[c + 3].Value = Convert.ToInt32(qty);
                                        brCnt++;
                                        buildHtml(ref Html, text2, url, qty, "US_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", "Line " + dataGridView1.Rows[r].Cells[0].Value.ToString() + " (US" + rowIdx + ") " + dataGridView1.Rows[r].Cells[c].Value.ToString());
                                    }
                                    else
                                    {
                                        try
                                        {
                                            qty = rsultArrr[rsultArrr.Length - 3].Replace("</span", "").Replace(",", "");
                                            dataGridView1.Rows[r].Cells[c + 3].Value = Convert.ToInt32(qty);
                                            brCnt++;
                                            buildHtml(ref Html, text2, url, qty, "US_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", "Line " + dataGridView1.Rows[r].Cells[0].Value.ToString() + " (US" + rowIdx + ") " + dataGridView1.Rows[r].Cells[c].Value.ToString());
                                        }
                                        catch (Exception er)
                                        {
                                            dataGridView1.Rows[r].Cells[c + 2].Value = Convert.ToInt32(0);
                                        }
                                    }

                                    // File.WriteAllBytes(@"DataSearch\US_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html", Encoding.ASCII.GetBytes(WebText(url)));
                                }
                            }
                        }

                        if (progress != null)
                        {
                            cnt++;
                            progress.Report(cnt * 100 / (dataGridView1.RowCount * (dataGridView1.ColumnCount / 4)));
                            if ((cnt * 100 / (dataGridView1.RowCount * (dataGridView1.ColumnCount / 4))) == 100)
                            {
                                ReUpdate("New Search Data has been updated sucessfully.", Html);
                            }

                            //progress.Report(cnt * 100 / (3 * (dataGridView1.ColumnCount / 4)));
                            //if ((cnt * 100 / (3 * (dataGridView1.ColumnCount / 4))) == 100)
                            //    ReUpdate("New Search Data has been updated sucessfully.", Html);
                            //}
                        }                      

                    }
                }
            }          
        }

        private void buildHtml(ref string Html, string text, string url, string qty, string fileName, string SearchBy)
        {
            try
            {
                //if (url == "https://www.ebay.co.uK/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=AUREX+HEARING&_sacat=0&LH_TitleDesc=1")
                //{
                //    string ss = "dd";
                //}

                string[] rsultArrr; 
                if ((qty.Replace(" ", "") == "1") || (qty.Replace(" ", "") == "2") || (qty.Replace(" ", "") == "3"))
                {
                    string subHtml = "";
                    string desc = "";
                    if (Html != "") {
                        Html += System.Environment.NewLine;
                    }

                    subHtml += url + "|||";
                    rsultArrr = text.Split(new string[] { @"https://i.ebayimg.com/thumbs/images" }, StringSplitOptions.None);

                    if (rsultArrr.Length > 1)
                    {
                        subHtml += "https://i.ebayimg.com/thumbs/images" + rsultArrr[1].Split('"')[0] + "|||";
                        rsultArrr = rsultArrr[1].Split(new string[] { "</a>" }, StringSplitOptions.None);
                        rsultArrr = rsultArrr[1].Replace("</h3>","").Split('>');
                        desc = rsultArrr[rsultArrr.Length - 1].Replace("\r","").Replace("\n", "").Replace("\t", "");

                        if (desc == "") {
                            rsultArrr = text.Split(new string[] { @"https://i.ebayimg.com/thumbs/images" }, StringSplitOptions.None);                    
                            rsultArrr = rsultArrr[1].Split(new string[] { "</a>" }, StringSplitOptions.None);
                            rsultArrr = rsultArrr[2].Replace("</h3>", "").Split('>');
                            desc = rsultArrr[rsultArrr.Length - 1];
                        }

                        subHtml += desc+"<br/>"+ SearchBy;


                        if ((qty == "2") || (qty == "3"))
                        {
                            subHtml += System.Environment.NewLine;
                            subHtml += url + "|||";
                            rsultArrr = text.Split(new string[] { "https://i.ebayimg.com/thumbs/images" }, StringSplitOptions.None);
                            if (rsultArrr.Length > 2)
                            {
                                subHtml += "https://i.ebayimg.com/thumbs/images" + rsultArrr[2].Split('"')[0] + "|||";
                                //rsultArrr = rsultArrr[2].Split(new string[] { "role=\"text\">" }, StringSplitOptions.None);
                                //Html += rsultArrr[rsultArrr.Length - 1].Split('<')[0].Replace("'", "");

                                rsultArrr = rsultArrr[2].Split(new string[] { "</a>" }, StringSplitOptions.None);
                                rsultArrr = rsultArrr[1].Replace("</h3>", "").Split('>');

                                desc = rsultArrr[rsultArrr.Length - 1].Replace("\r", "").Replace("\n", "").Replace("\t", ""); 

                                if (desc == "")
                                {
                                    rsultArrr = text.Split(new string[] { @"https://i.ebayimg.com/thumbs/images" }, StringSplitOptions.None);
                                    rsultArrr = rsultArrr[2].Split(new string[] { "</a>" }, StringSplitOptions.None);
                                    rsultArrr = rsultArrr[2].Replace("</h3>", "").Split('>');
                                    desc = rsultArrr[rsultArrr.Length - 1];
                                }
                                subHtml += desc + "<br/>" + SearchBy;


                                if (qty == "3")
                                {
                                    subHtml += System.Environment.NewLine;
                                    subHtml += url + "|||";
                                    rsultArrr = text.Split(new string[] { "https://i.ebayimg.com/thumbs/images" }, StringSplitOptions.None);

                                    if (rsultArrr.Length > 3)
                                    {
                                        subHtml += "https://i.ebayimg.com/thumbs/images" + rsultArrr[3].Split('"')[0] + "|||";
                                        //rsultArrr = rsultArrr[3].Split(new string[] { "role=\"text\">" }, StringSplitOptions.None);
                                        //Html += rsultArrr[rsultArrr.Length - 1].Split('<')[0].Replace("'", "");
                                        rsultArrr = rsultArrr[3].Split(new string[] { "</a>" }, StringSplitOptions.None);
                                        rsultArrr = rsultArrr[1].Replace("</h3>", "").Split('>');
                                        desc = rsultArrr[rsultArrr.Length - 1].Replace("\r", "").Replace("\n", "").Replace("\t", "");

                                        if (desc == "")
                                        {
                                            rsultArrr = text.Split(new string[] { @"https://i.ebayimg.com/thumbs/images" }, StringSplitOptions.None);
                                            rsultArrr = rsultArrr[3].Split(new string[] { "</a>" }, StringSplitOptions.None);
                                            rsultArrr = rsultArrr[2].Replace("</h3>", "").Split('>');
                                            desc = rsultArrr[rsultArrr.Length - 1];
                                        }
                                        subHtml += desc + "<br/>" + SearchBy;
                                    }
                                }
                            }
                        }

                        if (subHtml != "") {
                            Html += subHtml;
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(fileName + System.Environment.NewLine + System.Environment.NewLine + ex.Message);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            //DirectoryInfo dir = new DirectoryInfo("DataSearch");
            //brCnt = 0;
            //foreach (FileInfo fi in dir.GetFiles())
            //{
            //    fi.Delete();
            //}

            button4.Text = "SHOW LIST";
            dataGridView1.Visible = true;
            webBrowser2.Visible = false;

            progressBar1.Visible = true;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            progressBar1.Maximum = 100;
            progressBar1.Step = 1;


            var progress = new Progress<int>(v =>
            { 
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                progressBar1.Value = v;
            });
            
            await Task.Run(() => DoWork(progress));        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)(dataGridView1.DataSource)).DefaultView;
            dv.Sort = "Line asc";

            if (textBox1.Text.Replace(" ", "") != "") {
                DataTable dt = dv.ToTable();
                DataRow dr = dt.NewRow();
                dr["Line"] = (dataGridView1.RowCount+1).ToString();
                dr["KEY WORD NO 1"] = textBox1.Text.Trim() + " VINTAGE";
                dr["KEY WORD NO 2"] = textBox1.Text.Trim() + " DEVICE";
                dr["KEY WORD NO 3"] = textBox1.Text.Trim() + " ANTIQUE";
                dr["KEY WORD NO 4"] = textBox1.Text.Trim() + " HEARING";
                dr["KEY WORD NO 5"] = textBox1.Text.Trim() + " CATALOGUE";
                dr["KEY WORD NO 6"] = textBox1.Text.Trim() + " RARE";
                dr["KEY WORD NO 7"] = textBox1.Text.Trim() + " VTG";
                dt.Rows.Add(dr);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                ReUpdate(textBox1.Text.Trim() + " has been added sucessfullly ", "");
            }
            

          //  dr[""]          
          //  DataTable dt = dv.ToTable();          
            //using (FileStream stream = File.OpenWrite(@"C:\Temp\Ebay.ico"))
            //{
            //    Bitmap bitmap = (Bitmap)Image.FromFile(@"c:\Temp\icon3.png");
            //    Icon.FromHandle(bitmap.GetHicon()).Save(stream);
            //}

            //webBrowser2.DocumentText = ""

            //writeHtml();

            //   string text = File.ReadAllText(@"DataSearch\AU_" + dataGridView1.Rows[0].Cells[0].Value.ToString() + ".html");


            //   string Html = "";

            ////  buildHtml(ref Html, text,"jkjk", "2","rr");

            //   string ss = Html;

            //for (int r = 0; r < dataGridView1.RowCount; r++)
            //{
            //    for (int c = 0; c < dataGridView1.ColumnCount; c++)
            //    {
            //        if ((c == 0) || (c == 4) || (c == 8) || (c == 12) || (c == 16) || (c == 20) || (c == 24))
            //        {
            //            if (dataGridView1.Rows[r].Cells[c].Value != null)
            //            {
            //                if (dataGridView1.Rows[r].Cells[c].Value.ToString() != "")
            //                {
            //                    if (File.Exists(@"DataSearch\AU_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html"))
            //                    {

            //                        //if (dataGridView1.Rows[r].Cells[c].Value.ToString().IndexOf("VINTAGE") > -1)
            //                        //{
            //                        //    string ss = "ss";
            //                        //}

            //                        string text = File.ReadAllText(@"DataSearch\AU_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html").Split(new string[] { "result" }, StringSplitOptions.None)[0];
            //                        string[] rsultArrr = text.Split('>');

            //                        string qty = rsultArrr[rsultArrr.Length - 1].Replace(",", "");
            //                        int n;
            //                        bool isNumeric = int.TryParse(qty, out n);
            //                        if (isNumeric)
            //                        {
            //                            dataGridView1.Rows[r].Cells[c + 1].Value = rsultArrr[rsultArrr.Length - 1];
            //                        }
            //                        else
            //                        {
            //                            dataGridView1.Rows[r].Cells[c + 1].Value = rsultArrr[rsultArrr.Length - 3].Replace("</span", "");
            //                        }
            //                    }
            //                }

            //                if (dataGridView1.Rows[r].Cells[c].Value.ToString() != "")
            //                {
            //                    if (File.Exists(@"DataSearch\UK_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html"))
            //                    {
            //                        string text = File.ReadAllText(@"DataSearch\UK_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html").Split(new string[] { "result" }, StringSplitOptions.None)[0];
            //                        string[] rsultArrr = text.Split('>');

            //                        string qty = rsultArrr[rsultArrr.Length - 1].Replace(",", "");
            //                        int n;
            //                        bool isNumeric = int.TryParse(qty, out n);
            //                        if (isNumeric)
            //                        {
            //                            dataGridView1.Rows[r].Cells[c + 2].Value = rsultArrr[rsultArrr.Length - 1];
            //                        }
            //                        else
            //                        {
            //                            dataGridView1.Rows[r].Cells[c + 2].Value = rsultArrr[rsultArrr.Length - 3].Replace("</span", "");
            //                        }
            //                    }
            //                }


            //                if (dataGridView1.Rows[r].Cells[c].Value.ToString() != "")
            //                {
            //                    if (File.Exists(@"DataSearch\US_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html"))
            //                    {
            //                        string text = File.ReadAllText(@"DataSearch\US_" + dataGridView1.Rows[r].Cells[c].Value.ToString() + ".html").Split(new string[] { "result" }, StringSplitOptions.None)[0];
            //                        string[] rsultArrr = text.Split('>');

            //                        string qty = rsultArrr[rsultArrr.Length - 1].Replace(",", "");
            //                        int n;
            //                        bool isNumeric = int.TryParse(qty, out n);
            //                        if (isNumeric)
            //                        {
            //                            dataGridView1.Rows[r].Cells[c + 3].Value = rsultArrr[rsultArrr.Length - 1];
            //                        }
            //                        else
            //                        {
            //                            dataGridView1.Rows[r].Cells[c + 3].Value = rsultArrr[rsultArrr.Length - 3].Replace("</span", "");
            //                        }
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}
        }

        private void ReUpdate(string msg, string Html) {

            try
            {
                if (File.Exists("data.txt"))
                    File.Delete("data.txt");

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"data.txt"))
                {
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[1].Value != null)
                        {

                            file.WriteLine(dr.Cells[0].Value.ToString() + "," + dr.Cells[1].Value.ToString() + "," +
                                ((dr.Cells[2].Value.ToString() == "") ? "0" : dr.Cells[2].Value.ToString()) + "," +
                                ((dr.Cells[3].Value.ToString() == "") ? "0" : dr.Cells[3].Value.ToString()) + "," +
                                ((dr.Cells[4].Value.ToString() == "") ? "0" : dr.Cells[4].Value.ToString()));
                        }
                    }

                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[5].Value != null)
                        {
                            file.WriteLine(dr.Cells[5].Value.ToString() + "," +
                                ((dr.Cells[6].Value.ToString() == "") ? "0" : dr.Cells[6].Value.ToString()) + "," +
                                ((dr.Cells[7].Value.ToString() == "") ? "0" : dr.Cells[7].Value.ToString()) + "," +
                                ((dr.Cells[8].Value.ToString() == "") ? "0" : dr.Cells[8].Value.ToString()));

                        }
                    }


                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[9].Value != null)
                        {
                            file.WriteLine(dr.Cells[9].Value.ToString() + "," +
                                ((dr.Cells[10].Value.ToString() == "") ? "0" : dr.Cells[10].Value.ToString()) + "," +
                                ((dr.Cells[11].Value.ToString() == "") ? "0" : dr.Cells[11].Value.ToString()) + "," +
                                ((dr.Cells[12].Value.ToString() == "") ? "0" : dr.Cells[12].Value.ToString()));

                        }
                    }


                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[13].Value != null)
                        {
                            file.WriteLine(dr.Cells[13].Value.ToString() + "," +
                                 ((dr.Cells[14].Value.ToString() == "") ? "0" : dr.Cells[14].Value.ToString()) + "," +
                                ((dr.Cells[15].Value.ToString() == "") ? "0" : dr.Cells[15].Value.ToString()) + "," +
                                ((dr.Cells[16].Value.ToString() == "") ? "0" : dr.Cells[16].Value.ToString()));

                        }
                    }


                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[17].Value != null)
                        {
                            file.WriteLine(dr.Cells[17].Value.ToString() + "," +
                              ((dr.Cells[18].Value.ToString() == "") ? "0" : dr.Cells[18].Value.ToString()) + "," +
                                ((dr.Cells[19].Value.ToString() == "") ? "0" : dr.Cells[19].Value.ToString()) + "," +
                                ((dr.Cells[20].Value.ToString() == "") ? "0" : dr.Cells[20].Value.ToString()));

                        }
                    }


                    file.WriteLine("@");


                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[21].Value != null)
                        {
                            file.WriteLine(dr.Cells[21].Value.ToString() + "," +
                                 ((dr.Cells[22].Value.ToString() == "") ? "0" : dr.Cells[22].Value.ToString()) + "," +
                                ((dr.Cells[23].Value.ToString() == "") ? "0" : dr.Cells[23].Value.ToString()) + "," +
                                ((dr.Cells[24].Value.ToString() == "") ? "0" : dr.Cells[24].Value.ToString()));

                        }
                    }

                    file.WriteLine("@");

                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[25].Value != null)
                        {
                            file.WriteLine(dr.Cells[25].Value.ToString() + "," +
                               ((dr.Cells[26].Value.ToString() == "") ? "0" : dr.Cells[26].Value.ToString()) + "," +
                                ((dr.Cells[27].Value.ToString() == "") ? "0" : dr.Cells[27].Value.ToString()) + "," +
                                ((dr.Cells[28].Value.ToString() == "") ? "0" : dr.Cells[28].Value.ToString()));

                        }
                    }
                }



                if (Html != "")
                {
                    if (File.Exists(@"SearchList.txt"))
                        File.Delete(@"SearchList.txt");
                    File.WriteAllBytes(@"SearchList.txt", Encoding.ASCII.GetBytes(Html));
                }

                label2.Text = "Last Search: " + DateTime.Now.ToString();
                progressBar1.Visible = false;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                }


                writeHtml();


                MessageBox.Show(msg);
            }
            catch (Exception er)
            {
                MessageBox.Show("The New Data has been saved unsucessfully.\n" + @er.Message);
                if (File.Exists("data.txt"))
                    File.Delete("data.txt");

                File.Copy("data_origin.txt", "data.txt");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (progressBar1.Visible == false)
            {
                ReUpdate("The New Data has been saved sucessfully.","");
            }
            else {
                MessageBox.Show("Searching is in progressing.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        //    Process P = Process.Start("Notepad", TextBox1.Text)
        //P.WaitForInputIdle(1000)
        // TextBox3.Text = P.Id
        // AppActivate(P.Id)


            string url = "";
            

            if (e.RowIndex > -1)
            {

                switch (e.ColumnIndex)
                {
                    case 2:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 3:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 4:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;

                    case 6:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 7:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 8:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;

                    case 10:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 11:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 12:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;

                    case 14:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 15:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 16:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;

                    case 18:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 19:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 20:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;


                    case 22:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 23:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 24:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;


                    case 26:
                        url = "https://www.ebay.com.au/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 27:
                        url = "https://www.ebay.co.uk/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;
                    case 28:
                        url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=" + dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString().Replace(" ", "+") + "&_sacat=0&LH_TitleDesc=1";
                        System.Diagnostics.Process.Start(url);
                        break;

                    default:
                        break;
                }

               // this.TopMost = false;
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "SHOW LIST")
            {
                button4.Text = "SHOW RESULTS";
                webBrowser2.Visible = true;
                dataGridView1.Visible = false;
                button3.Visible = false;
                label3.Visible = true;
            }
            else {
                button4.Text = "SHOW LIST";
                webBrowser2.Visible = false;
                dataGridView1.Visible = true;
                button3.Visible = false;
                label3.Visible = false;
            }
        }

        private void webBrowser2_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Process.Start(((System.Windows.Forms.WebBrowser)sender).StatusText);
        }
        
  
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            finalDelete = false;
            var confirmResult = MessageBox.Show("Are you sure to delete this item(s) ??",
                                      "Confirm Delete!!",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                finalDelete = true;
              
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ReUpdate("Item has been deleted sucessfullly. ", "");
        }

        //private void webBrowser2_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        //{
        //    e.Cancel = true;

        //    //this opens the URL in the user's default browser
        //    Process.Start(e.Url.ToString());

        //}
    }
}
