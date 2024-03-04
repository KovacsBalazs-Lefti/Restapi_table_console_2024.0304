using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Restapi_table_console_2024._0304;

namespace Restapi_table_console_2024._0304
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ProcessDataAsync();
            Console.WriteLine("Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }

        static async Task ProcessDataAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://retoolapi.dev/Kc6xuH/data";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var employees = JsonConvert.DeserializeObject<Dolgozok[]>(content);

                        // Adatok feldolgozása és megjelenítése
                        DisplayData(employees);
                    }
                    else
                    {
                        Console.WriteLine($"HTTP hiba: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
        }

        static void DisplayData(Dolgozok[] employees)
        {
            Console.WriteLine("Dolgozók listája:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}\nNév: {employee.Name}\nFizetés: {employee.Salary}\nMunkakör: {employee.Position}\n");
            }
            PrintNumberOfElements(employees);
            PrintEmployeeWithMaxSalary(employees);
            PrintNumberOfEmployeesByPosition(employees);
            // Várakozás a felhasználó bemenetére, mielőtt befejezzük a programot
        }
        static void PrintNumberOfElements(Dolgozok[] employees)
        {
            int numberOfElements = employees.Length;
            Console.WriteLine($"Elemek száma: {numberOfElements}");
        }

        static void PrintEmployeeWithMaxSalary(Dolgozok[] employees)
        {
            var employeeWithMaxSalary = employees.OrderByDescending(emp => emp.Salary).FirstOrDefault();
            if (employeeWithMaxSalary != null)
            {
                Console.WriteLine($"A legmagasabb fizetéssel rendelkező dolgozó neve: {employeeWithMaxSalary.Name}");
            }
            else
            {
                Console.WriteLine("Nincs adat elérhető a dolgozók fizetéséről.");
            }
        }

        static void PrintNumberOfEmployeesByPosition(Dolgozok[] employees)
        {
            var groupedByPosition = employees.GroupBy(emp => emp.Position)
                                             .Select(group => new
                                             {
                                                 Position = group.Key,
                                                 Count = group.Count()
                                             });

            Console.WriteLine("Dolgozók száma munkakörönként:");
            foreach (var group in groupedByPosition)
            {
                Console.WriteLine($"Munkakör: {group.Position}, Dolgozók száma: {group.Count}");
            }
        }
    }
}
