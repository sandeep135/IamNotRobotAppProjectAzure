using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuplicateDetectionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// /
    public partial class MainWindow : Window
    {
        private readonly string computerVisionApiKey = "a4fddddca4334c499134205a61422122";
        private readonly string computerVisionEndpoint = "https://azsbaiservice.cognitiveservices.azure.com/";

        private readonly ComputerVisionClient computerVisionClient;
        public MainWindow()
        {
            InitializeComponent();

            computerVisionClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(computerVisionApiKey))
            {
                Endpoint = computerVisionEndpoint
            };
        }

        private async void UploadImage1_Click(object sender, RoutedEventArgs e)
        {
            List<string> selectedImagePaths = GetSelectedImagePaths();

            if (selectedImagePaths.Count < 2)
            {
                MessageBox.Show("Select at least two images to detect duplicates.");
                return;
            }

            foreach (string imagePath in selectedImagePaths)
            {
                ImageAnalysis features = await ExtractImageFeatures(imagePath);
                // Compare features to identify duplicates
                // You may use any suitable comparison algorithm here
            }
        }

         

        private async Task<ImageAnalysis> ExtractImageFeatures(string imagePath)
        {
            try
            {
                using (Stream imageStream = File.OpenRead(imagePath))
                {
                    List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() { 
                        VisualFeatureTypes.Categories,
                        VisualFeatureTypes.Description,
                        VisualFeatureTypes.Faces,
                        VisualFeatureTypes.ImageType,
                        VisualFeatureTypes.Tags 
                    };
                    ImageAnalysis result = await computerVisionClient.AnalyzeImageInStreamAsync(imageStream, features);

                    return result;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error analyzing image: {ex.Message}");
                return null;
            }
        }

        private List<string> GetSelectedImagePaths()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*"
            };

            List<string> selectedImagePaths = new List<string>();

            if (openFileDialog.ShowDialog() == true)
            {
                
                selectedImagePaths.AddRange(openFileDialog.FileNames);
            }

            return selectedImagePaths;
        }
    }
}
