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

        // 🔹 OPIS OSI X
        private void DrawXAxisLabel(Graphics g, int maxTime)
        {
            string label = "Czas [h]";
            SizeF size = g.MeasureString(label, SystemFonts.DefaultFont);

            float x = LeftMargin + (maxTime * Scale) / 2 - size.Width / 2;
            float y = 5;

            g.DrawString(label, SystemFonts.DefaultFont, Brushes.Black, x, y);
        }
        // 🔹 OPIS OSI Y NAD WYKRESEM (NA BIAŁYM TLE)
        private void DrawYAxisLabelTop(Graphics g)
        {
            string label = "Zadania";

            float x = 5;               // lewa krawędź białego obszaru
            float y = TopMargin - 25;  // NAD pierwszym zadaniem

            g.DrawString(label, SystemFonts.DefaultFont, Brushes.Black, x, y);
        }


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
                g.DrawString(
                    task.Name,
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    5,
                    y + 5
                );

                g.DrawLine(
                    Pens.LightGray,
                    LeftMargin - 5,
                    y + BarHeight / 2,
                    LeftMargin,
                    y + BarHeight / 2
                );

                y += BarHeight + 10;
            }

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
            if (priority >= 50)
                return Brushes.IndianRed;
            else if (priority >= 25)
                return Brushes.Goldenrod;
            else
                return Brushes.SteelBlue;
        }

        // 🔹 LEGENDA
        private void DrawLegend(Graphics g)
        {
            int x = LeftMargin + 300;
            int y = TopMargin + 10;

            g.DrawString("Legenda:", SystemFonts.DefaultFont, Brushes.Black, x, y);
            y += 20;

            DrawLegendItem(g, x, y, Brushes.IndianRed, "Wysoka kara");
            y += 20;

            DrawLegendItem(g, x, y, Brushes.Goldenrod, "Średnia kara");
            y += 20;

            DrawLegendItem(g, x, y, Brushes.SteelBlue, "Niska kara");
        }

        private void DrawLegendItem(Graphics g, int x, int y, Brush brush, string text)
        {
            g.FillRectangle(brush, x, y, 15, 15);
            g.DrawRectangle(Pens.Black, x, y, 15, 15);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, x + 20, y);
        }

        // 🔹 główna metoda
        public void DrawGantt(Graphics g, List<ScheduledTask> tasks)
        {
            if (tasks == null || tasks.Count == 0) return;

            int maxTime = tasks.Max(t => t.StartTime + t.Duration);

            DrawTimeAxis(g, maxTime);
            DrawTaskAxis(g, tasks);

            DrawXAxisLabel(g, maxTime);
            DrawYAxisLabelTop(g);

            int y = TopMargin;

            foreach (var task in tasks)
            {
                int x = LeftMargin + task.StartTime * Scale;
                int width = task.Duration * Scale;

                Rectangle rect = new Rectangle(x, y, width, BarHeight);
                Brush brush = GetBrushByPriority(task.Priority);

                g.FillRectangle(brush, rect);
                g.DrawRectangle(Pens.Black, rect);

                string text = $"{task.Duration}h";
                SizeF textSize = g.MeasureString(text, SystemFonts.DefaultFont);

                float textX = rect.X + (rect.Width - textSize.Width) / 2;
                float textY = rect.Y + (rect.Height - textSize.Height) / 2;

                g.DrawString(text, SystemFonts.DefaultFont, Brushes.White, textX, textY);

                y += BarHeight + 10;
            }

            DrawLegend(g);
        }
    }
}
