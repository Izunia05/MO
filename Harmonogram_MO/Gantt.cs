using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Harmonogram_MO
{
    public class Gantt
    {
        private const int Scale = 20;
        private const int BarHeight = 25;
        private const int LeftMargin = 90;   // miejsce na oś Y
        private const int TopMargin = 40;    // miejsce na oś X

        // 🔹 oś czasu (X)
        private void DrawTimeAxis(Graphics g, int maxTime)
        {
            int yAxis = TopMargin - 15;

            for (int t = 0; t <= maxTime; t++)
            {
                int x = LeftMargin + t * Scale;

                g.DrawLine(Pens.Gray, x, yAxis, x, yAxis + 10);
                g.DrawString(
                    t.ToString(),
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    x + 2,
                    yAxis
                );
            }

            // linia osi X
            g.DrawLine(
                Pens.Black,
                LeftMargin,
                TopMargin,
                LeftMargin + maxTime * Scale,
                TopMargin
            );
        }

        // 🔹 oś zadań (Y)
        private void DrawTaskAxis(Graphics g, List<ScheduledTask> tasks)
        {
            int y = TopMargin;

            foreach (var task in tasks)
            {
                // nazwa zadania
                g.DrawString(
                    task.Name,
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    5,
                    y + 5
                );

                // kreska osi Y
                g.DrawLine(
                    Pens.LightGray,
                    LeftMargin - 5,
                    y + BarHeight / 2,
                    LeftMargin,
                    y + BarHeight / 2
                );

                y += BarHeight + 10;
            }

            // linia osi Y
            g.DrawLine(
                Pens.Black,
                LeftMargin,
                TopMargin,
                LeftMargin,
                y - 10
            );
        }

        // 🔹 kolory wg priorytetu
        private Brush GetBrushByPriority(int priority)
        {
            if (priority >= 6)
                return Brushes.IndianRed;
            else if (priority >= 3)
                return Brushes.Goldenrod;
            else
                return Brushes.SteelBlue;
        }

        // 🔹 główna metoda
        public void DrawGantt(Graphics g, List<ScheduledTask> tasks)
        {
            if (tasks == null || tasks.Count == 0) return;

            int maxTime = tasks.Max(t => t.StartTime + t.Duration);

            DrawTimeAxis(g, maxTime);
            DrawTaskAxis(g, tasks);

            int y = TopMargin;

            foreach (var task in tasks)
            {
                int x = LeftMargin + task.StartTime * Scale;
                int width = task.Duration * Scale;

                Rectangle rect = new Rectangle(x, y, width, BarHeight);

                Brush brush = GetBrushByPriority(task.Priority);

                g.FillRectangle(brush, rect);
                g.DrawRectangle(Pens.Black, rect);

                // tekst w środku prostokąta
                string text = $"{task.Duration}h";

                SizeF textSize = g.MeasureString(text, SystemFonts.DefaultFont);

                float textX = rect.X + (rect.Width - textSize.Width) / 2;
                float textY = rect.Y + (rect.Height - textSize.Height) / 2;

                g.DrawString(
                    text,
                    SystemFonts.DefaultFont,
                    Brushes.White,
                    textX,
                    textY
                );


                y += BarHeight + 10;
            }
        }
    }
}
