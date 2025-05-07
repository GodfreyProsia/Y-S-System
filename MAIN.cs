using CustomControls.RJControls;

namespace Y_S_System
{
    public partial class MAIN : Form
    {
        public static MAIN instance;
        public RJButton btnLogin;

        public MAIN()
        {
            InitializeComponent();

        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            loadpage(new Login(this));
        }
        public void loadpage(object Form)
        {
            if (this.MainPanel.Controls.Count > 0)
            {
                this.MainPanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }//load the main page
    }
}
