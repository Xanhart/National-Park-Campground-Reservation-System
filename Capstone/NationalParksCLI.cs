using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
    

    public class NationalParksCLI
    {
        
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NationalParks;User ID=te_student;Password=sqlserver1";
        const string Command_ShowAllParks = "1";
        const string Command_ShowCampGroundByPark = "2";
        //const string /*Command_ = "3";*/
        //const string /*Command_ = "4";*/
        //const string /*Command_= "5";*/
        //const string /*Command_ = "6";*/
        const string Command_Quit = "q";





        public void RunCLI()
        {
            PrintHeader();
            PrintMenu();

            while (true)
            {
                string command = Console.ReadLine();
                switch (command.ToLower())
                {

                    case "1":
                        ShowAllNationalParks();
                        break;
                    case "2":
                        ShowCampgroundByPark();
                        break;
                    //case //Option 3 
                    //    break;
                    //case //Option 4 
                    //    break;
                    //case //Option 5
                    //    break;
                    //case //Option 6 
                    //    break;
                    case Command_Quit:
                        Console.WriteLine("Thanks for doing stuff on our stuff");
                             break;
                }
            


            }


        }

        private void ShowCampgroundByPark()
        {
            throw new NotImplementedException();
        }

        private void ShowAllNationalParks()
        {
          
            ParkSQLDAL dal = new ParkSQLDAL(connectionString);
            List<Park> allParks = dal.ShowAllNationalParks();
            Console.WriteLine("Showing all National Parks in our System");

            foreach (Park p in allParks)
            {
                Console.WriteLine();
                Console.WriteLine(p.Park_id + ")" + p.Name + " - " + p.Location + " - " + p.Establish_date + " - " + p.Area + " - " + p.Visitors + " visitors per year  ");
                Console.WriteLine("Description: " + p.Description);


            }
            Console.WriteLine();
        }

        private void PrintHeader()
        {
            Console.WriteLine("Header top");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Header mid ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Header Bottom");
        }
        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Main-Menu Type in a command");
            Console.WriteLine(" 1 - Show all National Parks in our System ");
            Console.WriteLine(" 2 - Find campgroup By Park");
            Console.WriteLine(" 3 - ");
            Console.WriteLine(" 4 - ");
            Console.WriteLine(" 5 - ");
            Console.WriteLine(" 6 - ");
            Console.WriteLine(" Q - Quit");
        }
    }
}

