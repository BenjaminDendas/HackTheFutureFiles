using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using DataLayer;
using Newtonsoft.Json;
using RestSharp;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string TEAMID = "02845afe-2dcf-40ff-19e1-08d537d2cddd";
        public MainWindow()
        {
            InitializeComponent();
           // GetRobots();
        }

        private async void GetRobots()
        {
            RestClient client = new RestClient("https://htf2017.djohnnie.be");

            RestRequest req = new RestRequest($"teams/{TEAMID}/androids", Method.GET);

            var x = await client.GetTaskAsync<Androids>(req);
            if (x != null)
            {
                MessageBox.Show("All Robots received");
            }
            else
            {
                MessageBox.Show("Failed to receive Robots!");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedCombobox = androidLevelComboBox.SelectedIndex;
            int selectedAndroidLevel = androidLevelComboBox.SelectedIndex+1;
            int selectedLocationLevel = locationLevelComboBox.SelectedIndex;
            int selectedCrowdLevel = crowdLevelComboBox.SelectedIndex;
            int selectedMoodLevel = moodLevelComboBox.SelectedIndex;
            int selectedRelationshipLevel = relationshipComboBox.SelectedIndex;

            RestClient client = new RestClient("https://htf2017.djohnnie.be");
            Androids android = new Androids();
            android.password = "panda";
            android.autoPilot = new AutoPilot(selectedAndroidLevel.ToString());
            android.crowdSensorAccuracy = new CrowdSensorAccuracy(selectedCrowdLevel.ToString());
            android.locationSensorAccuracy = new LocationSensorAccuracy(selectedLocationLevel.ToString());
            android.moodSensorAccuracy = new MoodSensorAccuracy(selectedMoodLevel.ToString());
            android.relationshipSensorAccuracy = new RelationshipSensorAccuracy(selectedRelationshipLevel.ToString());
                
            RestRequest req = new RestRequest($"teams/{TEAMID}/androids",Method.POST);
            req.AddJsonBody(android);
           
            Console.WriteLine(JsonConvert.SerializeObject(android));

            var x = await client.PostTaskAsync<object>(req);
            if (x != null)
            {
                robotListview.Items.Add("Robot level "+ selectedAndroidLevel + " deployed");
            }
            else
            {
                robotListview.Items.Add("Failed to deploy level " + selectedAndroidLevel + " robot");
            }
        }

        private void androidLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (androidLevelComboBox.SelectedIndex)
            {
                case 0:
                    locationCheckBox.IsChecked = true;
                    locationCheckBox.IsEnabled = false;
                    locationLevelComboBox.SelectedIndex = 0;
                    locationLevelComboBox.IsEnabled = false;

                    crowdCheckBox.IsChecked = true;
                    crowdCheckBox.IsEnabled = false;
                    crowdLevelComboBox.SelectedIndex = 0;
                    crowdLevelComboBox.IsEnabled = false;

                    moodCheckbox.IsChecked = true;
                    moodCheckbox.IsEnabled = false;
                    moodLevelComboBox.SelectedIndex = 0;
                    moodLevelComboBox.IsEnabled = false;

                    relationshipCheckBox.IsChecked = true;
                    relationshipCheckBox.IsEnabled = false;
                    relationshipComboBox.SelectedIndex = 0;
                    relationshipComboBox.IsEnabled = false;

                    break;

                case 1:
                    locationCheckBox.IsChecked = true;
                    locationCheckBox.IsEnabled = false;
                    locationLevelComboBox.SelectedIndex = 1;
                    locationLevelComboBox.IsEnabled = false;

                    crowdCheckBox.IsChecked = true;
                    crowdCheckBox.IsEnabled = false;
                    crowdLevelComboBox.SelectedIndex = 1;
                    crowdLevelComboBox.IsEnabled = false;

                    moodCheckbox.IsChecked = true;
                    moodCheckbox.IsEnabled = false;
                    moodLevelComboBox.SelectedIndex = 1;
                    moodLevelComboBox.IsEnabled = false;

                    relationshipCheckBox.IsChecked = true;
                    relationshipCheckBox.IsEnabled = false;
                    relationshipComboBox.SelectedIndex = 1;
                    relationshipComboBox.IsEnabled = false;
                    break;
                case 2:
                    locationCheckBox.IsChecked = false;
                    locationCheckBox.IsEnabled = true;
                    locationLevelComboBox.SelectedIndex = 0;
                    locationLevelComboBox.IsEnabled = true;

                    crowdCheckBox.IsChecked = false;
                    crowdCheckBox.IsEnabled = true;
                    crowdLevelComboBox.SelectedIndex = 0;
                    crowdLevelComboBox.IsEnabled = true;

                    moodCheckbox.IsChecked = false;
                    moodCheckbox.IsEnabled = true;
                    moodLevelComboBox.SelectedIndex = 0;
                    moodLevelComboBox.IsEnabled = true;

                    relationshipCheckBox.IsChecked = false;
                    relationshipCheckBox.IsEnabled = true;
                    relationshipComboBox.SelectedIndex = 0;
                    relationshipComboBox.IsEnabled = true;
                    break;
            }
        }

        private async void request_button_Click(object sender, RoutedEventArgs e)
        {

            //request sturen

            string robot = id_textbox.Text.Trim();
            RestClient client = new RestClient("https://htf2017.djohnnie.be");

            Request request = new Request();
            request.crowd = false;
            request.mood = false;
            request.location = false;
            request.password = "panda";
            request.relationship = false;

            RestRequest req = new RestRequest($"teams/{TEAMID}/androids/{robot}/requests", Method.POST);
            req.AddJsonBody(request);

            var x = await client.PostTaskAsync<Androids>(req);


            robotListview.Items.Add("Requested robot with id: " + robot);
        }
    }
}
