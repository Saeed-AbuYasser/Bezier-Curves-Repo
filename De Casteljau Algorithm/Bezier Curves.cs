using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



//De Casteljau's Algorithm to draw Bezier's Curves
//saeed_293640 , ali_299393 , obaida_307066


namespace Graphic
{
    public partial class Form1 : Form
    {

        //those are some essential variables to complete application's work
        //---------------------
        private byte Tracker = 0;
        private PointF[] ControlPoints = new PointF[6];
        private Label[] PointsLabelsContainer = new Label[6];
        bool CanAccessDrawPanel = true;
        //---------------------
        public Form1()
        {
            InitializeComponent();


        }


        // this function will write the point selected coordinates as a label control
        //---------------------
        private Label CreateLabel(String Text, MouseEventArgs e)
        {
            PointsLabelsContainer[Tracker] = new Label();
            this.pnlDrawSquar.Controls.Add(PointsLabelsContainer[Tracker]);
            PointsLabelsContainer[Tracker].Location = new Point(e.X + 6, e.Y - 8);
            PointsLabelsContainer[Tracker].Text = Text;
            PointsLabelsContainer[Tracker].BackColor = Color.Transparent;
            PointsLabelsContainer[Tracker].AutoSize = true;
            PointsLabelsContainer[Tracker].Font = new System.Drawing.Font("Script MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PointsLabelsContainer[Tracker].ForeColor = System.Drawing.Color.Red;
            PointsLabelsContainer[Tracker] = PointsLabelsContainer[Tracker];
            return PointsLabelsContainer[Tracker];
        }
        //----------------------


        // this procedure will remove all points, labels and curves.
        //----------------------
        private void ClearDrawPanel()
        {
            CanAccessDrawPanel = true;
            ControlPoints = new PointF[6];
            Graphics g = pnlDrawSquar.CreateGraphics();
            g.Clear(pnlDrawSquar.BackColor);
            for (int i = 0; i < Tracker; i++)
            {
                PointsLabelsContainer[i].Dispose();
            }
            PointsLabelsContainer = new Label[6];
            Tracker = 0;
            btnDraw.Enabled = true;
        }
        //----------------------



        //this function is for finding the lower point's coordinates between the two upper points to form the Bezier Curve
        //----------------------
        private PointF NewCasteljauPoint(PointF point1, PointF point2,double t)
        {
            return new PointF(((point1.X) * (float)(1 - t) + point2.X * (float)t), ((point1.Y) * (float)(1 - t) + (point2.Y) * (float)t));
        }
        //----------------------


        //and this one for drawing it
        //----------------------
        private void DrawCasteljauPoint(PointF point1,PointF point2,double t,Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Red, 2), ((float)(point1.X) * (float)(1 - t) + (float)point2.X * (float)t), ((float)(point1.Y) * (float)(1 - t) + (float)point2.Y * (float)t), 2, 2);

        }
        //----------------------


        //All the following procedures are for drawing different Degrees of Bezier Curves
        //Note: I am the writer "Saeed Saleh" who code this algorithm all by myself just after understanding
        //the De Casteljau's algorithm from some youtube videos. And to be honest, The explanation that is offered 
        //on the university website was so frustrating, and this absolutely does not mean to disrespect any person
        //but hopefully purposeful criticism.
        //----------------------
        private void DrawFirstDegreeCurve(PointF point1, PointF point2, Graphics g)
        {
            for (double t = 0; t <= 1; t = t + 0.001)
            {
                DrawCasteljauPoint(point1, point2, t, g);
            }
        }
        private void DrawSecondDegreeCurve(PointF point1, PointF point2, PointF point3, Graphics g)
        {
            PointF point1_2 = new PointF();
            PointF point2_3 = new PointF();

            for (double t = 0; t <= 1; t += 0.001)
            {
                point1_2 = NewCasteljauPoint(point1,point2,t);
                point2_3 = NewCasteljauPoint(point1, point3, t);
                DrawCasteljauPoint(point1_2, point2_3, t, g);

            }
        }
        private void DrawThirdDegreeCurve(PointF point1, PointF point2, PointF point3, PointF point4, Graphics g)
        {
            PointF point1_2, point2_3, point3_4;
            PointF point1_2__2_3, point2_3__3_4;
            for (double t = 0; t <= 1; t += 0.001)
            {
                point1_2 = NewCasteljauPoint(point1, point2, t);
                point2_3 = NewCasteljauPoint(point2, point3, t);
                point3_4 = NewCasteljauPoint(point3, point4, t);

                point1_2__2_3 = NewCasteljauPoint(point1_2,point2_3,t);
                point2_3__3_4 = NewCasteljauPoint(point2_3,point3_4,t);
                DrawCasteljauPoint(point1_2__2_3,point2_3__3_4,t, g);
            }
        } 
        private void DrawForthDegreeCurve(PointF point1, PointF point2, PointF point3, PointF point4,PointF point5, Graphics g)
        {
            PointF point1_2, point2_3, point3_4,point4_5;
            PointF point1_2__2_3, point2_3__3_4,point3_4__4_5;
            PointF point1_2__2_3__3_4, point2_3__3_4__4_5;
            for (double t = 0; t <= 1; t += 0.001)
            {
                point1_2 = NewCasteljauPoint(point1,point2,t);
                point2_3 = NewCasteljauPoint(point2,point3,t);
                point3_4 = NewCasteljauPoint(point3,point4,t);
                point4_5 = NewCasteljauPoint(point4,point5,t);


                point1_2__2_3 = NewCasteljauPoint(point1_2, point2_3, t);
                point2_3__3_4 = NewCasteljauPoint(point2_3, point3_4, t);
                point3_4__4_5 = NewCasteljauPoint(point3_4, point4_5, t);


                point1_2__2_3__3_4 = NewCasteljauPoint(point1_2__2_3, point2_3__3_4, t);
                point2_3__3_4__4_5 = NewCasteljauPoint(point2_3__3_4, point3_4__4_5, t);

                DrawCasteljauPoint(point1_2__2_3__3_4 , point2_3__3_4__4_5,t,g);
            }
        }
        private void DrawFifthDegreeCurve(PointF point1, PointF point2, PointF point3, PointF point4, PointF point5,PointF point6, Graphics g)
        {
            PointF point1_2, point2_3, point3_4, point4_5,point5_6;
            PointF point1_2__2_3, point2_3__3_4, point3_4__4_5, point4_5__5_6;
            PointF point1_2__2_3__3_4, point2_3__3_4__4_5, point3_4__4_5__5_6;
            PointF point1_2__2_3__3_4__4_5, point2_3__3_4__4_5__5_6;
            for (double t = 0; t <= 1; t += 0.001)
            {
                point1_2 = NewCasteljauPoint(point1,point2,t);
                point2_3 = NewCasteljauPoint(point2,point3,t);
                point3_4 = NewCasteljauPoint(point3,point4,t);
                point4_5 = NewCasteljauPoint(point4,point5,t);
                point5_6 = NewCasteljauPoint(point5,point6,t);

                point1_2__2_3 = NewCasteljauPoint(point1_2,point2_3,t);
                point2_3__3_4 = NewCasteljauPoint(point2_3,point3_4,t);
                point3_4__4_5 = NewCasteljauPoint(point3_4,point4_5,t);
                point4_5__5_6 = NewCasteljauPoint(point4_5,point5_6,t);

                point1_2__2_3__3_4 =NewCasteljauPoint( point1_2__2_3, point2_3__3_4, t);
                point2_3__3_4__4_5 = NewCasteljauPoint(point2_3__3_4, point3_4__4_5, t);
                point3_4__4_5__5_6 = NewCasteljauPoint(point3_4__4_5, point4_5__5_6, t);

                point1_2__2_3__3_4__4_5 = NewCasteljauPoint(point1_2__2_3__3_4, point2_3__3_4__4_5, t);
                point2_3__3_4__4_5__5_6 = NewCasteljauPoint(point2_3__3_4__4_5, point3_4__4_5__5_6, t);

                DrawCasteljauPoint(point1_2__2_3__3_4__4_5, point2_3__3_4__4_5__5_6, t, g);
            }
        }
        //----------------------

 
        //and this procedure also I made it alone, which is for drawing a surrounding rectangle 
        //----------------------
        private void DrawRectangle(Pen pen ,PointF [] points,Graphics g)
        {
            float Biggest_X = points[0].X, Biggest_Y= points[0].Y, Smallest_X = points[0].X , Smallest_Y = points[0].Y;
            for(int i = 1; i <Tracker; i++)
            {
                Biggest_X = Biggest_X > points[i].X ? Biggest_X : points[i].X;
                Smallest_X = Smallest_X < points[i].X ? Smallest_X : points[i].X;
                Biggest_Y = Biggest_Y > points[i].Y ? Biggest_Y : points[i].Y;
                Smallest_Y = Smallest_Y < points[i].Y ? Smallest_Y : points[i].Y;
            }
            g.DrawRectangle(pen, Smallest_X, Smallest_Y,( Biggest_X - Smallest_X), (Biggest_Y - Smallest_Y));

        }
        //----------------------



        //this procedure will call different Draw Procedure based on How many point the user choose to set.
        private void DrawBezierCurves()
        {
            Graphics g = pnlDrawSquar.CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);


            //I know that it's easier to write the followings with Short Hand If, but it's faster with Switch Case Statement.
            switch (Tracker)
            {
                case 2:
                    DrawFirstDegreeCurve(ControlPoints[0], ControlPoints[1], g);
                    DrawRectangle(pen, ControlPoints, g);
                    break;
                case 3:
                    DrawFirstDegreeCurve(ControlPoints[0], ControlPoints[1], g);
                    DrawSecondDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], g);
                    DrawRectangle(pen, ControlPoints, g);
                    break;
                case 4:
                    DrawFirstDegreeCurve(ControlPoints[0], ControlPoints[1], g);
                    DrawSecondDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], g);
                    DrawThirdDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3], g);
                    DrawRectangle(pen, ControlPoints, g);
                    break;
                case 5:
                    DrawFirstDegreeCurve(ControlPoints[0], ControlPoints[1], g);
                    DrawSecondDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], g);
                    DrawThirdDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3], g);
                    DrawForthDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3],ControlPoints[4], g);
                    DrawRectangle(pen, ControlPoints, g);
                    break;
                case 6:
                    DrawFirstDegreeCurve(ControlPoints[0], ControlPoints[1], g);
                    DrawSecondDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], g);
                    DrawThirdDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3], g);
                    DrawForthDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3], ControlPoints[4], g);
                    DrawFifthDegreeCurve(ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3], ControlPoints[4],ControlPoints[5], g);
                    DrawRectangle(pen, ControlPoints, g);
                    break;
                default:
                    return;
            }

        }
        //----------------------


        //this proceduer will track the Mouse Click Event on the blue panel then will deal with different procedures
        //to store, show the coordinates of and draw the point
        //----------------------
        private void pnlDrawSquar_MouseClick(object sender, MouseEventArgs e)
        {
            if (Tracker == 6 || !CanAccessDrawPanel)
                return;

            ControlPoints[Tracker] = new Point(e.X, e.Y);
            CreateLabel($"({e.X},{e.Y})", e);
            Graphics g = pnlDrawSquar.CreateGraphics();
            g.DrawEllipse(new System.Drawing.Pen(Color.Red, 5), e.X, e.Y, 3, 3);
            PointsLabelsContainer[Tracker].SendToBack();
            Tracker++;
            
            pnlDrawSquar.SendToBack();

        }
        //----------------------


        //Clicking on the button (Clear) well delete all the stored data and clean the screen then will back to defaults values
        //----------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDrawPanel();

        }
        //----------------------


        //this procedure will active the De Casteljau's Althorithm
        //----------------------
        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (Tracker <= 1)
            {
                MessageBox.Show("You must set at least two points!");
                return;
            }
            CanAccessDrawPanel = false;
            DrawBezierCurves();

            btnDraw.Enabled = false;
        }
        //----------------------


        //when clicking the Set Points button this going to allow you set points on the blue panel
        //----------------------
        private void btnSetPoints_Click(object sender, EventArgs e)
        {
            if (!CanAccessDrawPanel)
            {
                if (MessageBox.Show("To Set Points, You Should Clear The Panel First.\n Do You Want To Clear It?", "Error",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    ClearDrawPanel();
            }


        }
        //----------------------

        
    }
}
