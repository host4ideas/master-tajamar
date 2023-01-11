namespace Fundamentos
{
    public partial class Form02ColoresPosicion : Form
    {
        int originalBtnX;
        int originalBtnY;

        public Form02ColoresPosicion()
        {
            InitializeComponent();
            originalBtnX = this.btnChangePos.Location.X;
            originalBtnY = this.btnChangePos.Location.Y;
        }

        private void btnChangePos_Click(object sender, EventArgs e)
        {
            int x = int.Parse(this.textX.Text);
            int y = int.Parse(this.textY.Text);
            this.btnChangePos.Location = new Point(x, y);
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            int r = int.Parse(this.textR.Text);
            int g = int.Parse(this.textG.Text);
            int b = int.Parse(this.textB.Text);
            this.BackColor = Color.FromArgb(r, g, b);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.btnChangePos.Location = new Point(originalBtnX, originalBtnY);
        }
    }
}
