namespace pp_lab3
{
    public partial class Form1 : Form
    {
        private string? _inputFileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            openInputFileDialog.ShowDialog();
            string fileName = openInputFileDialog.FileName;

            if (fileName != "")
            {
                inputImagePreview.Image = new Bitmap(fileName);
                inputImagePreview.SizeMode = PictureBoxSizeMode.StretchImage;
                inputImagePreview.Refresh();
            }

            _inputFileName = fileName;
        }

        private async void processButton_Click(object sender, EventArgs e)
        {
            int imageWidth = inputImagePreview.Image.Width;
            int imageHeight = inputImagePreview.Image.Height;
            Bitmap inputImage = new Bitmap(_inputFileName);
            Color[,] inputRaw = new Color[inputImage.Width, inputImage.Height];

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    inputRaw[x, y] = inputImage.GetPixel(x, y);
                }
            }

            Task<Bitmap> grayscaleImageTask = ConvertImageToGrayScale(inputRaw, imageWidth, imageHeight);
            Task<Bitmap> negativeImageTask = ConvertImageToNegative(inputRaw, imageWidth, imageHeight);
            Task<Bitmap> greenImageTask = ConvertImageToGreenFilter(inputRaw, imageWidth, imageHeight);
            Task<Bitmap> thresholdImageTask = ConvertImageToThreshold(inputRaw, imageWidth, imageHeight, 128);

            await Task.WhenAll(grayscaleImageTask, negativeImageTask, greenImageTask, thresholdImageTask);

            Bitmap grayscaleImage = grayscaleImageTask.Result;
            grayscaleDisplayPictureBox.Image = grayscaleImage;
            grayscaleDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            grayscaleDisplayPictureBox.Refresh();

            Bitmap greenFilterImage = greenImageTask.Result;
            greenFilterDisplayPictureBox.Image = greenFilterImage;
            greenFilterDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            greenFilterDisplayPictureBox.Refresh();

            Bitmap negativeImage = negativeImageTask.Result;
            negativeDisplayPictureBox.Image = negativeImage;
            negativeDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            negativeDisplayPictureBox.Refresh();

            Bitmap thresholdImage = thresholdImageTask.Result;
            thresholdDisplayPictureBox.Image = thresholdImage;
            thresholdDisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            thresholdDisplayPictureBox.Refresh();
        }

        private async Task<Bitmap> ConvertImageToThreshold(Color[,] inputRaw, int width, int height, int threshold = 128)
        {
            return await Task.Run(() =>
            {
                Bitmap outputImage = new Bitmap(width, height);
                Color[,] outputRaw = new Color[width, height];

                Parallel.For(0, width * height, index =>
                {
                    int x = index % width;
                    int y = index / width;
                    Color pixelColor = inputRaw[x, y];
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int binary = gray >= threshold ? 255 : 0;
                    outputRaw[x, y] = Color.FromArgb(binary, binary, binary);
                });

                for (int y = 0; y < outputImage.Height; y++)
                {
                    for (int x = 0; x < outputImage.Width; x++)
                    {
                        outputImage.SetPixel(x, y, outputRaw[x, y]);
                    }
                }

                return outputImage;
            });
        }

        private async Task<Bitmap> ConvertImageToGreenFilter(Color[,] inputRaw, int width, int height)
        {
            return await Task.Run(() =>
            {
                Bitmap outputImage = new Bitmap(width, height);
                Color[,] outputRaw = new Color[width, height];

                Parallel.For(0, width * height, index =>
                {
                    int x = index % width;
                    int y = index / width;
                    Color pixelColor = inputRaw[x, y];
                    outputRaw[x, y] = Color.FromArgb(0, pixelColor.G, 0);
                });

                for (int y = 0; y < outputImage.Height; y++)
                {
                    for (int x = 0; x < outputImage.Width; x++)
                    {
                        outputImage.SetPixel(x, y, outputRaw[x, y]);
                    }
                }

                return outputImage;
            });
        }

        private async Task<Bitmap> ConvertImageToNegative(Color[,] inputRaw, int width, int height)
        {
            return await Task.Run(() =>
            {
                Bitmap outputImage = new Bitmap(width, height);
                Color[,] outputRaw = new Color[width, height];

                Parallel.For(0, width * height, index =>
                {
                    int x = index % width;
                    int y = index / width;
                    Color pixelColor = inputRaw[x, y];
                    outputRaw[x, y] = Color.FromArgb(
                        255 - pixelColor.R,
                        255 - pixelColor.G,
                        255 - pixelColor.B
                    );
                });

                for (int y = 0; y < outputImage.Height; y++)
                {
                    for (int x = 0; x < outputImage.Width; x++)
                    {
                        outputImage.SetPixel(x, y, outputRaw[x, y]);
                    }
                }

                return outputImage;
            });
        }

        private async Task<Bitmap> ConvertImageToGrayScale(Color[,] inputRaw, int width, int height)
        {
            return await Task.Run(() =>
            {
                Bitmap outputImage = new Bitmap(width, height);
                Color[,] outputRaw = new Color[width, height];

                Parallel.For(0, width * height, (index) =>
                {
                    int x = index % width;
                    int y = index / width;
                    Color pixelColor = inputRaw[x, y];

                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    outputRaw[x, y] = Color.FromArgb(grayValue, grayValue, grayValue);
                });

                for(int y = 0; y < outputImage.Height; y++)
                {
                    for (int x = 0; x < outputImage.Width; x++)
                    {
                        outputImage.SetPixel(x, y, outputRaw[x, y]);
                    }
                }

                return outputImage;
            });   
        }
    }
}
