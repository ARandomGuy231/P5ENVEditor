using System.Diagnostics;

namespace P5ENVEditor
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            appAboutVerText.Text = $"v{Application.ProductVersion.Split("+")[0]}";
        }

        private void appAboutGithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/ARandomGuy231/P5ENVEditor") { UseShellExecute = true });
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
