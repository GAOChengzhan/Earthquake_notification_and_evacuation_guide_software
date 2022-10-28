using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 前台
{
    
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form0());

              
        }
    }
    class LocationData
    {
        private string _time;
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }            private decimal _id;
        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _value;
        public decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
