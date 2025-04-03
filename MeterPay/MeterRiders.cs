using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecting_Project_Ex2
{

    
    public class House
    {
        public int ID;
        public string Name;
        public string Address;
        public House(int id, string name, string address) {
            this.ID = id;
            this.Name = name;
            this.Address = address;
        }

    }
    public class MeterInfo
    {

        public DateTime date { get; set; }
        int kilowatt;
        int price;
        private static byte DayPrice = 2;
        private static byte NightPrice = 3;
        public MeterInfo(DateTime date, int kilowatt)
        {
            this.date = date;
            this.kilowatt = kilowatt;
            if (date.Hour == 12)
                price = DayPrice * kilowatt;
            else
                price = NightPrice * kilowatt;
        }
        public string getInfo() => date.ToString() + $", {kilowatt}_____{price} grn";
        public int getPrice() => price;


    }
    public class MeterRiders
    {
        private static int counter = 0;
        private const int minHistoryVal = 20;
        
        public House house { get; set; }
        List<MeterInfo> history = new();
        public MeterRiders(House house) => this.house = house;


        
        public void setNewInfo(MeterInfo materInfo) {
            
            history.Add(materInfo);
        }
        public int sumPay()
        {
            int sum = 0;
            foreach (var payment in history)
                sum += payment.getPrice();

            return sum;
        }
        private void sortHistory()
        {
            for (int i = 0; i < history.Count - 1; i++)
            {
                if (history[i].date > history[i + 1].date)
                {
                    MeterInfo tmp = history[i];
                    history[i] = history[i + 1];
                    history[i + 1] = tmp;
                }
            }
        }
        public DateTime getLastTime() {
            sortHistory();
            if (history.Count == 0)
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            return history[history.Count - 1].date;
        }
        
        public string[] getHistoryStrings()
        {
            sortHistory();

            string[] result = new string[history.Count];
            int i = 0;
            foreach (var info in history) 
                result[i++] = info.getInfo();
                
            return result;
        }
    }
    
}
