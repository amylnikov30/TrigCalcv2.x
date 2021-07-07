using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Json;
using Json.Net;
using Newtonsoft.Json;
using TrigCalc2.Calculation;
using TrigCalc2.Utilities;

namespace TrigCalc2.UI
{
    public partial class TrigCalcUI : Form
    {

        private ICalculator calculator;

        private ICalculator previousCalculator;

        private Graphics graphics;

        private Font font;

        private Settings settings;

        private Point longSide_left  = new Point(250, 350);
        private Point longSide_right = new Point(750, 350);
        private Point finalPoint;

        #region Labels
        private Label ssLabel = new Label();
        private Label fsLabel = new Label();
        private Label lsLabel = new Label();

        private Label saLabel = new Label();
        private Label faLabel = new Label();
        private Label laLabel = new Label();
        #endregion

        #region Inputs

        private TextBox[] sideInputs;
        private TextBox[] angleInputs;

        #endregion

        #region Colors

        private Color drawingColor;

        private Color darkMode_fore  = Color.LightGray;
        private Color lightMode_fore = Color.Black;

        private Color darkMode_back  = Color.FromArgb(0, 34, 64);
        private Color lightMode_back = Color.White;

        #endregion


        private const int labelOffset = 15;

        public TrigCalcUI()
        {
            InitializeComponent();
            //graphics = this.CreateGraphics();
            font = new Font("Courier", 15);
            this.Paint += new PaintEventHandler(this.TrigCalcUI_Paint_Init);

            sideInputs  = new TextBox[3] { Input_Side_a,  Input_Side_b,  Input_Side_c  };
            angleInputs = new TextBox[3] { Input_Angle_A, Input_Angle_B, Input_Angle_C };



            ReadSettings();
            if (settings.theme == ColorTheme.light)
                ChangeTheme(settings.theme, false);
            else
                ChangeTheme(settings.theme, true);

            ChangeCalculationType(settings.calculationType);

            //this.Hide();

            //SplashScreen splashScreen = new SplashScreen();
            //ShowSplashScreen(splashScreen);

            //this.Show();
        }

        private void ShowSplashScreen(SplashScreen splashScreen)
        {
            splashScreen.Show();
            splashScreen.LoadingBarTimer.Enabled = true;
            splashScreen.LoadingBarTimer.Start();

            do
            {
                continue;
            } while (splashScreen.LoadingBar.Width != splashScreen.Width);

            splashScreen.Hide();
        }

        private void ChangeCalculationType(CalculationType type)
        {
            if (settings.calculationType == CalculationType.degrees)
            {
                Button_RadDeg.Text = "Radians";
            }
            else
            {
                Button_RadDeg.Text = "Degrees";
            }
            settings.calculationType = type;
        }

        private void ReadSettings()
        {
            using (StreamReader r = new StreamReader("Resources\\settings.json"))
            {
                string json = r.ReadToEnd();
                settings = JsonConvert.DeserializeObject<Settings>(json);
            }
        }

        private void WriteSettings()
        {
            using (StreamWriter r = new StreamWriter("Resources\\settings.json"))
            {
                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                r.Write(json);
                Console.WriteLine(settings.calculationType);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void TrigCalcUI_Paint(object sender, PaintEventArgs e)
        {
            //this.graphics = e.Graphics;
            DrawTriangle();
            DrawTriangleLabels();

            //this.Invalidate();
        }

        private void TrigCalcUI_Paint_Init(object sender, PaintEventArgs e)
        {
            this.graphics = e.Graphics;
        }
        

        private void Button_Calculate_Click(object sender, EventArgs e)
        {
            Calculate(recalculate: false);
        }

        private void Calculate(bool recalculate)
        {
            double a;
            double.TryParse(Input_Side_a.Text, out a);

            double b;
            double.TryParse(Input_Side_b.Text, out b);

            double c;
            double.TryParse(Input_Side_c.Text, out c);

            double A;
            double.TryParse(Input_Angle_A.Text, out A);

            double B;
            double.TryParse(Input_Angle_B.Text, out B);

            double C;
            double.TryParse(Input_Angle_C.Text, out C);



            if (settings.calculationType == CalculationType.degrees)
            {
                if (calculator != new CalculatorD(a, b, c, A, B, C) && calculator != null)
                    previousCalculator = calculator;

                if (!recalculate)
                    calculator = new CalculatorD(a, b, c, A, B, C);
            }
            else
            {
                if (calculator != new CalculatorR(a, b, c, Input_Angle_A.Text, Input_Angle_B.Text, Input_Angle_C.Text) && calculator != null)
                    previousCalculator = calculator;

                if (!recalculate)
                    calculator = new CalculatorR(a, b, c, Input_Angle_A.Text, Input_Angle_B.Text, Input_Angle_C.Text);
            }


            //Console.WriteLine(calculator.enoughInfo);

            if (calculator == null || !calculator.enoughInfo)
            {
                return;
            }

            calculator.Calculate();

            
            ClearDrawings();
            ClearFields();

            if (calculator.enoughInfo)
            {
                Input_Side_a.Text = calculator.a.ToString();
                Input_Side_b.Text = calculator.b.ToString();
                Input_Side_c.Text = calculator.c.ToString();

                Input_Angle_A.Text = calculator.sA;
                Input_Angle_B.Text = calculator.sB;
                Input_Angle_C.Text = calculator.sC;

                //Console.WriteLine(calculator.b);

                this.Invalidate();

                this.Paint += new PaintEventHandler(this.TrigCalcUI_Paint);

                EnoughInfo.Text = "Success";
                EnoughInfo.ForeColor = Color.Green;

            }
            else
            {
                EnoughInfo.Text = "Invalid information provided, please try again";
                EnoughInfo.ForeColor = Color.Red;
            }

            Controls.Add(EnoughInfo);
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            ClearDrawings();
            ClearFields();
        }

        //private void TrigCalcUI_FormClosing(Object sender, FormClosingEventArgs e)
        //{
        //    WriteSettings();
        //}

        private void ClearDrawings()
        {
            this.CreateGraphics().Clear(BackColor);
        }

        private void ClearFields()
        {
            Utils.ResetAllControls(this);
        }

        private void DrawTriangle() //  needs to be PaintEventArgs
        {
            double[] sides  = new double[] { calculator.a, calculator.b, calculator.c };
            double[] angles = new double[] { calculator.A, calculator.B, calculator.C };


            Array.Sort(angles);

            double longSide = sides[2];
            double shortSide = sides[0];

            double x = (longSide_right.X - longSide_left.X) * (shortSide / longSide) * Math.Cos(CalculatorD.Radians(angles[1]));
            double y = (longSide_right.X - longSide_left.X) * (shortSide / longSide) * Math.Sin(CalculatorD.Radians(angles[1]));

            finalPoint = new Point(((int)x + longSide_left.X), (longSide_left.Y - (int)y));

            
            Pen pen = new Pen(drawingColor, 4);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Point[] points = { longSide_left, longSide_right, finalPoint };

            graphics.DrawPolygon(pen, points);
        }

        private void DrawTriangleLabels()
        {
            double[] sides = new double[] { calculator.a, calculator.b, calculator.c };
            double[] angles = new double[] { calculator.A, calculator.B, calculator.C };


            for (int i = 0; i<sides.Length; i++)
            {
                sides[i]  = Math.Round(sides[i], 2);
                angles[i] = Math.Round(angles[i], 2);
            }


            Array.Sort(sides);
            Array.Sort(angles);

            double longSide = sides[0];
            double shortSide = sides[2];
            double finalSide = sides[1];

            Point ssMidpoint = CalculatorD.Midpoint(finalPoint, longSide_left);
            Point fsMidpoint = CalculatorD.Midpoint(finalPoint, longSide_right);
            Point lsMidpoint = CalculatorD.Midpoint(longSide_left, longSide_right);


            SolidBrush textBrush = new SolidBrush(drawingColor);
            Pen pen = new Pen(drawingColor);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.FitBlackBox;



            SizeF ssSize = graphics.MeasureString(sides[0].ToString(), font);
            SizeF fsSize = graphics.MeasureString(sides[1].ToString(), font);
            SizeF lsSize = graphics.MeasureString(sides[2].ToString(), font);

            SizeF saSize = graphics.MeasureString(calculator.sA, font);
            SizeF faSize = graphics.MeasureString(calculator.sB, font);
            SizeF laSize = graphics.MeasureString(calculator.sC, font);


            Point ssPoint = new Point((ssMidpoint.X - labelOffset) - (int)ssSize.Width,
                                       ssMidpoint.Y - (int)ssSize.Height);

            Point fsPoint = new Point(fsMidpoint.X + labelOffset + (int)fsSize.Width,
                                      fsMidpoint.Y - (int)fsSize.Height);

            Point lsPoint = new Point(lsMidpoint.X, lsMidpoint.Y + labelOffset);

            Point saPoint = new Point(longSide_right.X, longSide_right.Y - (int)saSize.Height);
            Point faPoint = new Point(longSide_left.X, longSide_left.Y - (int)faSize.Height);
            Point laPoint = new Point(finalPoint.X - (int)(laSize.Width / 2), finalPoint.Y - (int)laSize.Height);


            Rectangle ssRect = new Rectangle(ssPoint.X, ssPoint.Y, (int)ssSize.Width, (int)ssSize.Height);
            Rectangle fsRect = new Rectangle(fsPoint.X, fsPoint.Y, (int)fsSize.Width, (int)fsSize.Height);
            Rectangle lsRect = new Rectangle(lsPoint.X, lsPoint.Y, (int)lsSize.Width, (int)lsSize.Height);

            Rectangle saRect = new Rectangle(saPoint.X, saPoint.Y, (int)saSize.Width, (int)saSize.Height);
            Rectangle faRect = new Rectangle(faPoint.X, faPoint.Y, (int)faSize.Width, (int)faSize.Height);
            Rectangle laRect = new Rectangle(laPoint.X, laPoint.Y, (int)laSize.Width, (int)laSize.Height);

            while (Utils.LineIntersectsRect(longSide_right, finalPoint, saRect))
            {
                saPoint.X--;
                saRect.X = saPoint.X;
            }
            while (Utils.LineIntersectsRect(longSide_left, finalPoint, faRect))
            {
                faPoint.X++;
                faRect.X = faPoint.X;
            }

            double ratio = (longSide_right.X - longSide_left.X) / laRect.Width;

            double largeHeight = longSide_left.Y - finalPoint.Y;

            double distanceToLa = largeHeight / ratio;

            laRect.Y = finalPoint.Y + (int)distanceToLa;
            laPoint.Y = laRect.Y;
            //Console.WriteLine("ratio: " + ratio);

            if (Utils.LineIntersectsRect(longSide_left, finalPoint, laRect))
            {
                while (!Utils.LineIntersectsRect(longSide_right, finalPoint, laRect))
                {
                    laRect.X++;
                    laPoint.X = laRect.X;
                }
            }
            else if (Utils.LineIntersectsRect(longSide_right, finalPoint, laRect))
            {
                while (!Utils.LineIntersectsRect(longSide_right, finalPoint, laRect))
                {
                    laRect.X--;
                    laPoint.X = laRect.X;
                }
            }


            graphics.DrawString(sides[0].ToString(), font, textBrush, ssPoint);
            graphics.DrawString(sides[1].ToString(), font, textBrush, fsPoint);
            graphics.DrawString(sides[2].ToString(), font, textBrush, lsPoint);

            graphics.DrawString(calculator.sA.ToString(), font, textBrush, saPoint);
            graphics.DrawString(calculator.sB.ToString(), font, textBrush, faPoint);
            graphics.DrawString(calculator.sC.ToString(), font, textBrush, laPoint);
        }

        private void Recalculate()
        {
            if (previousCalculator == null)
                return;

            calculator = previousCalculator;
            //Console.WriteLine("calculator.a: " + calculator.a);
            Calculate(recalculate: true);
        }

        private void ChangeTheme(ColorTheme theme, bool invertImages)
        {
            if (theme == ColorTheme.dark) // change to dark theme
            {
                this.BackColor = darkMode_back;

                foreach (Control control in this.Controls)
                {
                    if (control.GetType() != typeof(TextBox))
                        control.ForeColor = darkMode_fore;
                }

                if (invertImages)
                {
                    Button_Calculate.Image = Utils.InvertImage(Button_Calculate.Image);
                    Button_Clear.Image = Utils.InvertImage(Button_Clear.Image);
                    Button_Redo.Image = Utils.InvertImage(Button_Redo.Image);
                }

                for (int i=0; i<sideInputs.Length; i++)
                {
                    sideInputs[i].ForeColor = lightMode_fore;
                    angleInputs[i].ForeColor = lightMode_fore;
                }

                drawingColor = darkMode_fore;

            }
            else                          // change to light theme
            {
                this.BackColor = lightMode_back;

                foreach(Control control in this.Controls)
                {
                    if (control.GetType() != typeof(TextBox))
                        control.ForeColor = lightMode_fore;
                }

                if (invertImages)
                {
                    Button_Calculate.Image = Utils.InvertImage(Button_Calculate.Image);
                    Button_Clear.Image = Utils.InvertImage(Button_Clear.Image);
                    Button_Redo.Image = Utils.InvertImage(Button_Redo.Image);
                }

                drawingColor = lightMode_fore;

            }
            settings.theme = theme;

            WriteSettings();
        }

        private void TrigCalcUI_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:               // Enter to calculate
                    Calculate(recalculate: false); break;
                
                case Keys.Escape:               // Escape to quit program
                    Application.Exit(); break;

                case Keys.Alt:                  // Alt+R to recalculate
                    if (e.KeyCode == Keys.R)
                        Recalculate(); break;
                
                default:
                    break;
            }
        }

        private void Button_Redo_Click(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Button_ColorTheme_Click(object sender, EventArgs e)
        {
            if (settings.theme == ColorTheme.dark)
            {
                ChangeTheme(ColorTheme.light, true);
            }
            else
            {
                ChangeTheme(ColorTheme.dark, true);
            }
        }

        private void RadDeg_Click(object sender, EventArgs e) // Supposed to be Button_RadDeg
        {
            if (settings.calculationType == CalculationType.degrees)
            {
                ChangeCalculationType(CalculationType.radians);
            }
            else
            {
                ChangeCalculationType(CalculationType.degrees);
            }

            WriteSettings();
        }

        private void TrigCalcUI_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing");
        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    var relativePoint = this.PointToClient(Cursor.Position);

        //    Console.WriteLine(relativePoint.X + ", " + relativePoint.Y);
        //    Console.Out.Flush();
        //}
    }
}
