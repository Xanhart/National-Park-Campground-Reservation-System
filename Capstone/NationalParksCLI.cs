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
        //const string Command_SHowAllCampsites = "3";
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
            while (true)
            {
                Console.WriteLine("Acdia = 1");
                Console.WriteLine("Arches = 2");
                Console.WriteLine("Cuy valley = 3");
                Console.WriteLine("Quit = 4");
                int parkchoiceMade = CLIHelper.GetInteger("Make choice");

                switch(parkchoiceMade)
                {
                    case 1:
                        ShowAcadiaCampgrounds();
                       break;
                    case 2:
                        ShowArchesCampgrounds();
                        break;
                    case 3:
                        ShowCuyahogaCampgrounds();
                        break;
                    case 4:
                        RunCLI();
                        break;

                }
                break;

            }
        }

        private void ShowCuyahogaCampgrounds()
        {
            Console.WriteLine("Cuyahoga Campgrounds ");
            CampgroundSQLDAL dal = new CampgroundSQLDAL(connectionString);
            List<Campground> cuyahogaCampgrounds = dal.GetAllCampgrounds(3);
            foreach(Campground c in cuyahogaCampgrounds)
            {
                Console.WriteLine();
                Console.WriteLine(c.Campground_ID + " - " + c.Name + " - " + c.Open_From_MM + " - " + c.Open_To_MM + " -  $" + Math.Round(c.Daily_Fee));

            }
            Console.WriteLine("Make a reservation = 1");
            Console.WriteLine("return to main menu = 2");
            int campgroundChoiceMade = CLIHelper.GetInteger("Make choice");
            // reservation system
        }

        private void ShowArchesCampgrounds()
        {
            Console.WriteLine("Arches Campgrounds");
            CampgroundSQLDAL dal = new CampgroundSQLDAL(connectionString);
            List<Campground> archesCampgrounds = dal.GetAllCampgrounds(2);
            foreach (Campground c in archesCampgrounds)
            {
                Console.WriteLine();
                Console.WriteLine(c.Campground_ID + " - " + c.Name + " - " + c.Open_From_MM + " - " + c.Open_To_MM + " -  $" + Math.Round(c.Daily_Fee, 2));
            }
            Console.WriteLine("Make a reservation = 1");
            Console.WriteLine("return to main menu = 2");
            int campgroundChoiceMade = CLIHelper.GetInteger("Make choice");
            // reservation system
        }

        private void ShowAcadiaCampgrounds()
        {
            Console.WriteLine("Acadia Campgrounds");
            CampgroundSQLDAL dal = new CampgroundSQLDAL(connectionString);
            List<Campground> acadiaCampgrounds = dal.GetAllCampgrounds(1);
            foreach (Campground c in acadiaCampgrounds)
            {
                Console.WriteLine();
                Console.WriteLine(c.Campground_ID + " - " + c.Name + " - " + c.Open_From_MM + " - " + c.Open_To_MM + " -  $" + Math.Round(c.Daily_Fee, 2));
            }
            Console.WriteLine("Make a reservation = 1");
            Console.WriteLine("return to main menu = 2");
            int campgroundChoiceMade = CLIHelper.GetInteger("Make choice");
            // reservation system
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
        public void GetAllCampsites()
        {

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
            Console.WriteLine(" 2 - Show campgroup By Park");
            Console.WriteLine(" 3 - ");
            Console.WriteLine(" 4 - ");
            Console.WriteLine(" 5 - ");
            Console.WriteLine(" 6 - ");
            Console.WriteLine(" Q - Quit");
        }
    }
}

