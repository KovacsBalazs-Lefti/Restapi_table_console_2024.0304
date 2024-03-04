using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Restapi_table_console_2024._0304
{
    internal class Dolgozok
    {
        private int id;
        private string name;
        private string salary;
        private string position;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Position { get => position; set => position = value; }

        public Dolgozok(int id, string name, string salary, string position)
        {
            this.Id = id;
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
        }
    }
}
