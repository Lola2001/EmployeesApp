using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;

namespace EmployeesApp
{
    public class ChartGenerator
    {
            public void GeneratePieChart(List<Employee> employees, string filePath)
            {
            int width = 650;
            int height = 450;
            int margin = 50; 

            using (var bitmap = new System.Drawing.Bitmap(width, height))
            using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.White);

                float startAngle = 0f;
                System.Drawing.Color[] colors = new[] { System.Drawing.Color.Red, System.Drawing.Color.Green, System.Drawing.Color.Blue, System.Drawing.Color.Yellow, System.Drawing.Color.Purple, System.Drawing.Color.Orange };
                int colorIndex = 0;

                double totalHours = employees.Sum(emp => emp.TotalHoursWorked);

            
                int centerX = width / 2;
                int centerY = height / 2;

                int radius = Math.Min(centerX, centerY) - margin;

                foreach (var employee in employees)
                {
                    float sweepAngle = (float)(employee.TotalHoursWorked / totalHours) * 360;
                    graphics.FillPie(new System.Drawing.SolidBrush(colors[colorIndex]), centerX - radius, centerY - radius, 2 * radius, 2 * radius, startAngle, sweepAngle);

                    float midAngle = startAngle + sweepAngle / 2;
                    double x = centerX + (radius / 2) * Math.Cos(midAngle * Math.PI / 180);
                    double y = centerY + (radius / 2) * Math.Sin(midAngle * Math.PI / 180);

                    string hoursText = $"{employee.TotalHoursWorked:N2} hrs";

                    System.Drawing.SolidBrush hoursTextBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.Font hoursFont = new System.Drawing.Font("Arial", 10);
                    System.Drawing.SizeF hoursTextSize = graphics.MeasureString(hoursText, hoursFont);
                    graphics.DrawString(hoursText, hoursFont, hoursTextBrush, (float)x - hoursTextSize.Width / 2, (float)y - hoursTextSize.Height / 2);

                 
                    double textX = centerX + (radius + 40) * Math.Cos(midAngle * Math.PI / 180);
                    double textY = centerY + (radius + 40) * Math.Sin(midAngle * Math.PI / 180);

                    string nameText = employee.EmployeeName;

                    System.Drawing.SolidBrush nameTextBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.Font nameFont = new System.Drawing.Font("Arial", 12);
                    System.Drawing.SizeF nameTextSize = graphics.MeasureString(nameText, nameFont);
                    graphics.DrawString(nameText, nameFont, nameTextBrush, (float)textX - nameTextSize.Width / 2, (float)textY - nameTextSize.Height / 2);

                    startAngle += sweepAngle;
                    colorIndex = (colorIndex + 1) % colors.Length;
                
            }

                bitmap.Save(filePath, ImageFormat.Png);
            }
            }
        }

    }
