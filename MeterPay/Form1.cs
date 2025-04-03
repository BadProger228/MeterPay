using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Projecting_Project_Ex2
{
    public partial class Form1 : Form
    {
        const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\LogicMan\\source\\repos\\Projecting_Project_Ex2\\Projecting_Project_Ex2\\MeterResult.mdf;Integrated Security=True";

        List<House> houses = new List<House>();
        public Form1()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();

                string query = "SELECT Id, HouseName, Address FROM HouseList";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    HousesList.Items.Add($"{reader["HouseName"]}, Address: {reader["Address"]}");
                    houses.Add(new((int)reader["Id"], (string)reader["HouseName"], (string)reader["Address"]));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void HousesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HousesList_DoubleClick(object sender, EventArgs e)
        {
            if (HousesList.SelectedItems is null)
                return;

            var redactForm = new RedactForm(houses[HousesList.SelectedIndex]);
            redactForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
