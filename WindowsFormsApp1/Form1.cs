using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;


namespace Assignment1
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap processedImage; // Store the processed image
        private object flowPanel;

        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true // Allow multiple file selection
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Clear all thumbnails in FlowLayoutPanel
                //flowPanel.Controls.Clear();

                // Load the first file into the main PictureBox
                string firstFile = openFileDialog.FileNames.FirstOrDefault();
                if (!string.IsNullOrEmpty(firstFile))
                {
                    originalImage = new Bitmap(firstFile);
                    pictureBox1.Image = ResizeImageToBox(originalImage, pictureBox1.Width, pictureBox1.Height); // Display the image
                    GenerateHistogram(originalImage, histogram1); // Display histogram
                }

                // Add all selected images as thumbnails to the FlowLayoutPanel
                //foreach (string filePath in openFileDialog.FileNames)
                //{
                //    try
                //    {
                //        Bitmap image = new Bitmap(filePath);

                //        Bitmap resizedImage = ResizeImageToBox(image, 50, 50);

                //        // Create PictureBox for thumbnail
                //        PictureBox thumbnailBox = new PictureBox
                //        {
                //            Image = resizedImage,
                //            SizeMode = PictureBoxSizeMode.Zoom,
                //            Size = new Size(100, 100),
                //            Margin = new Padding(5)
                //        };

                //        // Add thumbnail to FlowLayoutPanel
                //        //flowPanel.Controls.Add(thumbnailBox);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"Could not load file: {filePath}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

                // Notify user of success
                MessageBox.Show($"Loaded {openFileDialog.FileNames.Length} images successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (originalImage == null) return;

                double mean = CalculateMeanGrayLevel(originalImage);
                processedImage = ApplyThresholding(originalImage, (byte)mean);
                outputBox.Image = ResizeImageToBox(processedImage, pictureBox1.Width, pictureBox1.Height);

                GenerateHistogram(processedImage, histogram2);
            }
        }


        private void imageQuan_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            processedImage = ApplyQuantization(originalImage, 8);
            outputBox.Image = ResizeImageToBox(processedImage, pictureBox1.Width, pictureBox1.Height);

            GenerateHistogram(processedImage, histogram2);

            // Quantize the image to 8 levels
            Bitmap quantizedImage8 = ApplyQuantization(originalImage, 8);

            // Quantize the image to 16 levels
            Bitmap quantizedImage16 = ApplyQuantization(originalImage, 16);

            // Show both images in a single popup
            ShowComparisonPopup(quantizedImage8, "Quantization - 8 Levels", quantizedImage16, "Quantization - 16 Levels");
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            processedImage = ApplyHistogramEqualization(originalImage);
            outputBox.Image = ResizeImageToBox(processedImage, pictureBox1.Width, pictureBox1.Height);

            GenerateHistogram(processedImage, histogram2);
        }

        private void imageDifference_Click(object sender, EventArgs e)
        {
            if (originalImage == null || processedImage == null) return;

            Bitmap diffImage = CalculateImageDifference(originalImage, processedImage);
            difBox.Image = ResizeImageToBox(diffImage, pictureBox1.Width, pictureBox1.Height); ;
        }


        private void ShowComparisonPopup(Bitmap image1, string title1, Bitmap image2, string title2)
        {
            // Create a new form to act as a popup
            Form popupForm = new Form
            {
                Text = "Image Comparison",
                Size = new Size(800, 400), // Fixed size for the form
                StartPosition = FormStartPosition.CenterScreen
            };

            // Create a TableLayoutPanel to arrange images
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = false, // Prevent resizing
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Set column sizes equally
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Labels
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Images

            // Add the first image
            PictureBox pictureBox1 = new PictureBox
            {
                Image = image1,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };
            Label label1 = new Label
            {
                Text = title1,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Add the second image
            PictureBox pictureBox2 = new PictureBox
            {
                Image = image2,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };
            Label label2 = new Label
            {
                Text = title2,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Add components to the TableLayoutPanel
            tableLayout.Controls.Add(label1, 0, 0);
            tableLayout.Controls.Add(label2, 1, 0);
            tableLayout.Controls.Add(pictureBox1, 0, 1);
            tableLayout.Controls.Add(pictureBox2, 1, 1);

            // Add the TableLayoutPanel to the form
            popupForm.Controls.Add(tableLayout);

            // Show the form
            popupForm.ShowDialog();
        }


        private void GenerateHistogram(Bitmap image, PictureBox histogramBox)
        {
            // Initialize arrays for each color channel
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            // Calculate the histogram for each color channel
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    redHistogram[pixel.R]++;
                    greenHistogram[pixel.G]++;
                    blueHistogram[pixel.B]++;
                }
            }

            // Create Chart control
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill // Fill the PictureBox
            };

            // Configure ChartArea
            ChartArea chartArea = new ChartArea
            {
                AxisX = { Minimum = 0, Maximum = 255, Title = "Intensity" },
                AxisY = { Minimum = 0, Title = "Frequency" }
            };
            chart.ChartAreas.Add(chartArea);

            // Add Red series
            Series redSeries = new Series
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.Red,
                Name = "Red"
            };
            for (int i = 0; i < 256; i++)
                redSeries.Points.AddXY(i, redHistogram[i]);
            chart.Series.Add(redSeries);

            // Add Green series
            Series greenSeries = new Series
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.Green,
                Name = "Green"
            };
            for (int i = 0; i < 256; i++)
                greenSeries.Points.AddXY(i, greenHistogram[i]);
            chart.Series.Add(greenSeries);

            // Add Blue series
            Series blueSeries = new Series
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue,
                Name = "Blue"
            };
            for (int i = 0; i < 256; i++)
                blueSeries.Points.AddXY(i, blueHistogram[i]);
            chart.Series.Add(blueSeries);

            // Clear and add Chart to PictureBox
            histogramBox.Controls.Clear();
            histogramBox.Controls.Add(chart);
        }


        private double CalculateMeanGrayLevel(Bitmap image)
        {
            long totalGray = 0;
            int pixelCount = image.Width * image.Height;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    totalGray += (pixel.R + pixel.G + pixel.B) / 3;
                }
            }

            return (double)totalGray / pixelCount;
        }

        private Bitmap ApplyThresholding(Bitmap image, byte threshold)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    int binary = gray >= threshold ? 255 : 0;
                    result.SetPixel(x, y, Color.FromArgb(binary, binary, binary));
                }
            }

            return result;
        }
        private Bitmap ApplyQuantization(Bitmap image, int levels)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int step = 256 / levels;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    int quantized = (gray / step) * step + step / 2;
                    result.SetPixel(x, y, Color.FromArgb(quantized, quantized, quantized));
                }
            }

            return result;

        }

        private Bitmap ApplyHistogramEqualization(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int[] histogram = new int[256];

            // Calculate histogram
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int gray = (image.GetPixel(x, y).R + image.GetPixel(x, y).G + image.GetPixel(x, y).B) / 3;
                    histogram[gray]++;
                }
            }

            // Calculate CDF
            int[] cdf = new int[256];
            cdf[0] = histogram[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + histogram[i];
            }

            // Apply Equalization
            int totalPixels = image.Width * image.Height;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int gray = (image.GetPixel(x, y).R + image.GetPixel(x, y).G + image.GetPixel(x, y).B) / 3;
                    int equalized = cdf[gray] * 255 / totalPixels;
                    result.SetPixel(x, y, Color.FromArgb(equalized, equalized, equalized));
                }
            }

            return result;
        }
        private Bitmap CalculateImageDifference(Bitmap original, Bitmap processed)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color origPixel = original.GetPixel(x, y);
                    Color procPixel = processed.GetPixel(x, y);

                    int diffR = Math.Abs(origPixel.R - procPixel.R);
                    int diffG = Math.Abs(origPixel.G - procPixel.G);
                    int diffB = Math.Abs(origPixel.B - procPixel.B);

                    result.SetPixel(x, y, Color.FromArgb(diffR, diffG, diffB));
                }
            }

            return result;
        }

        private Bitmap ResizeImageToBox(Bitmap originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);
            }

            return resizedImage;
        }
    }
}
