using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lux_Lunae.Pages.TowerGraphics
{
    public class CloudGraphic
    {

        float x = 0;
        int y = 0;
        float size = 1;
        float speed = 0.5f;

        public CloudGraphic()
        {
            Random random = new Random(); 
            x = random.Next(-200, 1440);
            y = random.Next(-100, 200);
            size = 1;
            speed = (float)random.NextDouble() * 0.3f + 0.2f;
        }

        public void draw(ICanvas canvas)
        {

            canvas.FillColor = new Color(1f, 1f, 1f, 0.5f);
            canvas.FillRectangle(x + 40 * size, y + 20 * size, 40 * size, 10 * size);
            canvas.FillRectangle(x + 20 * size, y + 10 * size, 100 * size, 10 * size);
            canvas.FillRectangle(x, y, 150 * size, 10 * size);

            x += speed;

            if (x > 1500)
            {
                Random random = new Random();
                
                x = -200;
                y = random.Next(-100, 200);

            }
        }
    }
}
