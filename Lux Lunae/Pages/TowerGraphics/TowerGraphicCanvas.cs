using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lux_Lunae.Pages.TowerGraphics
{
    public class TowerGraphicCanvas : IDrawable
    {
        private StarGraphic[] stars;
        private CloudGraphic[] clouds;

        public TowerGraphicCanvas() {
            stars = new StarGraphic[150];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new StarGraphic();
            }

            clouds = new CloudGraphic[20];
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i] = new CloudGraphic();
            }
        }
        public void Draw(ICanvas canvas, RectF canvasData)
        {
            //Fill background

            canvas.FillColor = Colors.White;

            LinearGradientPaint linearGradientPaint = new LinearGradientPaint
            {
                StartColor = new Color(0.3f, 0.15f, 0.324f),
                EndColor = new Color(0.05f, 0, 0.074f),
                StartPoint = new Point(0.5, 1),
                EndPoint = new Point(0.5, 0),
            };

            //                (0.2 - y*0.25f, 0.15 - y*0.25f, 0.324 - y*0.25f, 1);

            linearGradientPaint.AddOffset(0.15f / 0.25f, new Color(0.25f - (0.15f / 0.25f) * 0.25f, 0, 0.324f - (0.15f / 0.25f) *0.25f));
            linearGradientPaint.AddOffset(0.2f / 0.25f, new Color(0.05f, 0, 0.324f - (0.2f / 0.25f) * 0.25f));

            canvas.SetFillPaint(linearGradientPaint, canvasData);
            canvas.FillRectangle(canvasData);
            canvas.SetFillPaint(null, canvasData);


            //canvas.FillColor = Colors.Red;
            //canvas.FillRectangle(0, 0, 1000, 100);

            canvas.Translate(0, canvasData.Height);
            canvas.Scale(1, -1f);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].draw(canvas);
            }

            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].draw(canvas);
            }

        }
    }
}
