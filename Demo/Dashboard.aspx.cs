using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private Reader reader = new Reader();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public async Task<string> Upload()
        {
            var client = new RestClient("https://dataclassifier.azurewebsites.net/api/UploadFile");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBdXRobXlBUEkiLCJlbWFpbCI6IlRlc3RAbWFpbC5jb20iLCJqdGkiOiIxZTVmNjZiNS04YjUzLTQ2M2QtODE0Ni1hZGMwMTgyN2YxYWQiLCJleHAiOjE2MDU1MzU2MTQsImlzcyI6Ik15RGVtb0FwcC5jb20iLCJhdWQiOiJNeURlbW9BcHAuY29tIn0.4KlXvdnbVjkPfn8vTAbK4b-KZhcdG8aJtPS7vev9Qao");
            //request.AddFile("files", FileUpload1.FileName);
            if(FileUpload1.HasFile)
            {
                request.AddFileBytes("files", FileUpload1.FileBytes, FileUpload1.FileName);
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            else
            {
                return "File not found";
            }
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            btnUpload.Enabled = true;
            string extension = Findextension();
            if (RadioButton1.Checked)
                Label4.Text = await Upload();
            if (extension.Length > 4)
                TextBox1.Text = extension;
            else if (extension.Equals("txt"))
                TextFiles();
            else if (extension.Equals("xls") || extension.Equals("xlsx"))
                ExcellFiles();
            else if (extension.Equals("csv"))
                CSVFiles();
        }

        protected string Findextension()
        {
            if(FileUpload1.HasFile)
            {
                string ext = FileUpload1.FileName;
                string[] temp = ext.Split('.');
                foreach (string line in temp)
                {
                    if (line.Equals("txt"))
                        return line;
                    else if (line.Equals("xls") || line.Equals("xlsx"))
                        return line;
                    else if (line.Equals("csv"))
                        return line;
                }
                return "Unsupported file type.\nSorry for the inconvenience but please upload either one of the following:\nText,\nMicrosoft Excell,\nCSV Files.";
            }
            return "Please Choose a file before you click on the submit button.";
        }

        private void TextFiles()
        {
            string lines = reader.ReadTextFile(FileUpload1.FileContent);
            Finder finder = new Finder();
            string[] lines2 = finder.findNames(lines);
            TextBox1.Text = "";
            foreach (string line in lines2)
                TextBox1.Text += line;
        }

        private void ExcellFiles()
        {
            List<IronXL.Cell> list = reader.ReadExcellFile(FileUpload1.FileBytes);
            foreach(var val in list)
            {
                TextBox1.Text += val.ToString()+"\n";
            }
        }

        private void CSVFiles()
        {
            string lines = reader.ReadCSVFile(FileUpload1.FileContent);
            string[] temp = lines.Split('\r');
            foreach (string val in temp)
            {
                string[] newTemp = val.Split(',');
                foreach (string newVal in newTemp)
                    TextBox1.Text += newVal+"\n";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string val = TextBox1.Text;
            int id = 0;
            if (Int32.TryParse(TextBox2.Text, out id))
            {
                var client = new RestClient("https://dataclassifier.azurewebsites.net/api/UploadTo/Insert?record=" + val + "&id=" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                IRestResponse response = client.Execute(request);
                TextBox2.Text = "";
                if (response.IsSuccessful)
                    TextBox1.Text = "Upload Successful!";
                else
                    TextBox1.Text = "Upload failed!";
            }
            else
                Label2.Text = "Invalid number or the number is already in use.";
        }
    }
}