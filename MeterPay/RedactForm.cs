using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projecting_Project_Ex2
{
    public partial class RedactForm : Form
    {
        const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\LogicMan\\source\\repos\\Projecting_Project_Ex2\\Projecting_Project_Ex2\\MeterResult.mdf;Integrated Security=True";
        MeterRiders history;
        public RedactForm(House house)
        {
            InitializeComponent();
            HouseName.Text += house.Name;
            Address.Text += house.Address;

            history = new(house);



            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();

                string query = $"SELECT * FROM HistoryMeter Where HouseListId = {history.house.ID}";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int hour = 0;
                    if ((string)reader["dayTime"] == "Day")
                        hour = 12;

                    history.setNewInfo(
                        new MeterInfo(
                            new DateTime(
                                (int)reader["Year"],
                                (int)reader["month"],
                                (int)reader["day"],
                                hour, 0, 0),
                            (int)reader["Kilovat"])
                        );
                }

                foreach (var line in history.getHistoryStrings())
                    History.Items.Add(line);

                SumPay.Text = "Payment: " + history.sumPay();
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

        private void History_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RedactForm_Load(object sender, EventArgs e)
        {

        }

        private void AddPayment_Click(object sender, EventArgs e)
        {
            int kilowatt;
            if (!int.TryParse(kilovatForNewDay.Text, out kilowatt))
                return;

            var nextTime = history.getLastTime();
            nextTime = nextTime.AddHours(12);
            var info = new MeterInfo(nextTime, kilowatt);
            string dayTime = "Night";
            if (nextTime.Hour == 12)
                dayTime = "Day";

            history.setNewInfo(info);
            SumPay.Text = "Payment: " + history.sumPay();

            History.Items.Add(info.getInfo());
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                string query = "INSERT INTO HistoryMeter (Year, month, day, dayTime, HouseListId, Kilovat) " +
               "VALUES (@Year, @Month, @Day, @DayTime, @HouseListId, @Kilovat)";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", nextTime.Year);
                    command.Parameters.AddWithValue("@Month", nextTime.Month);
                    command.Parameters.AddWithValue("@Day", nextTime.Day);
                    command.Parameters.AddWithValue("@DayTime", dayTime);
                    command.Parameters.AddWithValue("@HouseListId", history.house.ID);
                    command.Parameters.AddWithValue("@Kilovat", kilowatt);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
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

        private void kilovatForNewDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pay_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                string query = $"DELETE FROM HistoryMeter WHERE HouseListId = {history.house.ID}";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();

                History.Items.Clear();
                SumPay.Text = "Payment: 0";
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
    }
}
