using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lux_Lunae.Pages.TowerGraphics
{
    public class StarGraphic
    {

        int PositionX = 0;
        int PositionY = 0;
        int Radius = 3;
        bool Large = false;
        Color Color;
        int Timer = 0;

        const float BigStarP = 0.2f;
        const float LargeStarP = 0.07f;
        const int BlinkDuration = 10;
        const int TimeTillBlink = 100000;

        public StarGraphic()
        {
            Random random = new Random();
            Timer = random.Next(0, TimeTillBlink);


            PositionX = random.Next(0 + Radius*2, 350 - Radius * 2);
            PositionY = random.Next(0 + Radius * 2, 650 - Radius * 2);

            if (random.NextDouble() < LargeStarP)
            {
                Large = true;
            }
            else
            {
                if (random.NextDouble() < BigStarP)
                {
                    Radius = 5;
                }
            }

            int c = random.Next(0, 3);

            switch (c)
            {
                case 0:
                    Color = new Color(0.588f, 0.38f, 0.776f);
                    break;
                case 1:
                    Color = new Color(0.38f, 0.541f, 0.776f);
                    break;
                case 2:
                    Color = new Color(1f, 1f, 1f);
                    break;
                default:
                    break;
            }


        }


        public void draw(ICanvas canvas)
        {

            Timer++;
            if (Timer > TimeTillBlink - BlinkDuration)
            {
                if (Timer > TimeTillBlink)
                {
                    Timer = 0;
                }
                return;
            }

            if (!Large)
            {
                canvas.FillColor = Color;
                canvas.FillRectangle(PositionX, PositionY, Radius, Radius);
            }
            else
            {
                canvas.FillColor = new Color(1f, 1f, 1f);
                canvas.FillRectangle(PositionX, PositionY, Radius, Radius);

                bool color = PositionX % 2 == 0;

                if (color)
                {
                    canvas.FillColor = new Color(0.886f, 0.686f, 0.973f);
                }
                else
                {
                    canvas.FillColor = new Color(0.529f, 0.478f, 0.776f);
                }
                canvas.FillRectangle(PositionX + Radius, PositionY, Radius, Radius);
                canvas.FillRectangle(PositionX - Radius, PositionY, Radius, Radius);
                canvas.FillRectangle(PositionX, PositionY + Radius, Radius, Radius);
                canvas.FillRectangle(PositionX, PositionY - Radius, Radius, Radius);

                if (color)
                {
                    canvas.FillColor = new Color(0.749f, 0.161f, 1f);
                }
                else
                {
                    canvas.FillColor = new Color(0.31f, 0.22f, 0.761f);
                }
                canvas.FillRectangle(PositionX + Radius * 2, PositionY, Radius, Radius);
                canvas.FillRectangle(PositionX - Radius * 2, PositionY, Radius, Radius);
                canvas.FillRectangle(PositionX, PositionY + Radius * 2, Radius, Radius);
                canvas.FillRectangle(PositionX, PositionY - Radius * 2, Radius, Radius);
            }

        }

    }
}
