namespace Graphic_Lab1
{
    public partial class Graphic_Lab1 : Form
    {
        private bool Desenhar = false;
        private bool Matric = false;
        private List<Point> points = new List<Point>();
        Point[] points1;
        public Graphic_Lab1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen RedPen = new Pen(Brushes.Red);
            RedPen.Width = 4;
            Pen GreenPen = new Pen(Brushes.Green);
            GreenPen.Width = 4;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int xOrigem = ClientRectangle.Width / 2;
            int yOrigem = ClientRectangle.Height / 2;
            if (Desenhar == true)
            {   
                int x =29*int.Parse(textBox1.Text);
                int y =29*int.Parse(textBox2.Text);
                Point point1 = new Point(xOrigem + x, yOrigem - y);
                points.Add(point1);
                points1 = points.Distinct().ToArray();
                if (points1.Length == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), x + xOrigem,yOrigem - y, 3, 3);
                }
                else if (points1.Length >= 3)
                {
                    if (points1[2].X * (points1[1].Y - points1[0].Y) - points1[2].Y *
               (points1[1].X - points1[0].X) == points1[0].X * points1[1].Y - points1[1].X * points1[0].Y)
                    {
                        MessageBox.Show("Точки знаходятся на одній прямій");
                        Close();
                    }
                    else
                    {
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                g.DrawLine(RedPen, points1[i], points1[i - 1]);
                            }
                            g.DrawLine(RedPen, points1[0], points1[2]);
                        }
                    }
                }
                else
                {
                   g.DrawLine(RedPen, points1[0], points1[1]);

                }
            }
            if (Matric == true)
            {
                int x1, x2, x3, y1, y2, y3;
                int p1 = int.Parse(textBox3.Text);
                int p2 = int.Parse(textBox4.Text);
                int p3 = int.Parse(textBox5.Text);
                int p4 = int.Parse(textBox6.Text);
                if (points1.Length == 1)
                {
                    x1 = p1 * (points1[0].X - xOrigem) + p3 * (yOrigem - points1[0].Y);
                    y1 = p2 * (points1[0].X - xOrigem) + p4 * (yOrigem - points1[0].Y);
                    g.FillRectangle(new SolidBrush(Color.Green), x1 + xOrigem, yOrigem - y1, 3, 3);
                }
                else if(points1.Length == 2) 
                {
                    x1 = p1 * (points1[0].X - xOrigem) + p3 * (yOrigem - points1[0].Y);
                    y1 = p2 * (points1[0].X - xOrigem) + p4 * (yOrigem - points1[0].Y);
                    x2 = p1 * (points1[1].X - xOrigem) + p3 * (yOrigem - points1[1].Y);
                    y2 = p2 * (points1[1].X - xOrigem) + p4 * (yOrigem - points1[1].Y);
                    Point point3 = new Point(xOrigem + x1, yOrigem - y1);
                    Point point4 = new Point(xOrigem + x2, yOrigem - y2);
                    g.DrawLine(GreenPen, point3, point4);
                }
                else
                {
                    x1 = p1 * (points1[0].X - xOrigem) + p3 * (yOrigem - points1[0].Y);
                    y1 = p2 * (points1[0].X - xOrigem) + p4 * (yOrigem - points1[0].Y);
                    x2 = p1 * (points1[1].X - xOrigem) + p3 * (yOrigem - points1[1].Y);
                    y2 = p2 * (points1[1].X - xOrigem) + p4 * (yOrigem - points1[1].Y);
                    x3 = p1 * (points1[2].X - xOrigem) + p3 * (yOrigem - points1[2].Y);
                    y3 = p2 * (points1[2].X - xOrigem) + p4 * (yOrigem - points1[2].Y);
                    Point point5 = new Point(xOrigem + x1, yOrigem - y1);
                    Point point6 = new Point(xOrigem + x2, yOrigem - y2);
                    Point point7 = new Point(xOrigem + x3, yOrigem - y3);
                    g.DrawLine(GreenPen, point5, point6);
                    g.DrawLine(GreenPen, point6, point7);
                    g.DrawLine(GreenPen, point5, point7);
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                return;
            Desenhar = true;
            Refresh();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() ==
                "" || textBox6.Text.Trim() == "" )
                return;
            Matric = true;
            Refresh();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Desenhar = false;
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Desenhar = false;
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Matric = false;
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Matric = false;
        }
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            Matric = false;
        }
        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            Matric = false;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
           Refresh();
        }
    }
}