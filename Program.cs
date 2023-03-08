using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationEleven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define the parameters of the simulation
            int initialPopulation = 10000;
            int days = 100;
            double deathRate = 0.1;
            double injuryRate = 0.2;
            double recoveryRate = 0.05;

            // Create a chart to display the simulation results
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea("area"));
            chart.Series.Add("Deaths");
            chart.Series.Add("Injured");
            chart.Series.Add("Alive");
            chart.Series["Deaths"].ChartType = SeriesChartType.Line;
            chart.Series["Injured"].ChartType = SeriesChartType.Line;
            chart.Series["Alive"].ChartType = SeriesChartType.Line;

            // Set the colors and legend of each series
            chart.Series["Deaths"].Color = System.Drawing.Color.Red;
            chart.Series["Injured"].Color = System.Drawing.Color.Blue;
            chart.Series["Alive"].Color = System.Drawing.Color.Green;
            chart.Series["Deaths"].LegendText = "Deaths";
            chart.Series["Injured"].LegendText = "Injured";
            chart.Series["Alive"].LegendText = "Alive";

            // Simulate the attack and update the chart with the results
            int deaths = 0;
            int injuries = 0;
            int alive = initialPopulation;

            for (int day = 0; day <= days; day++)
            {
                deaths += (int)(alive * deathRate);
                injuries += (int)(alive * injuryRate);
                alive -= deaths + injuries;
                alive += (int)(injuries * recoveryRate);

                chart.Series["Deaths"].Points.AddXY(day, deaths);
                chart.Series["Injured"].Points.AddXY(day, injuries);
                chart.Series["Alive"].Points.AddXY(day, alive);
            }

            // Display the chart
            var form = new Form();
            chart.Dock = DockStyle.Fill;
            chart.Legends.Add(new Legend("legend"));
            chart.Legends["legend"].Docking = Docking.Bottom;
            form.Controls.Add(chart);
            form.ShowDialog();
        }
    }
}
