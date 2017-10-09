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
                 
                    case Command_Quit:
                        Console.WriteLine("Thanks for using your National Parks System!");
                        Console.WriteLine("Remember: National Parks are your land. Please pack in - pack out!");
                             break;
                }
            


            }


        }

        private void ShowCampgroundByPark()
        {
                Console.WriteLine("Which National Park campground would you like to view?");
                Console.WriteLine("For Acadia National Park type --- 1");
                Console.WriteLine("For Arches National Park type --- 2");
                Console.WriteLine("For Cuyahoga National Park type --- 3");
                
                int parkchoiceMade = CLIHelper.GetInteger("Make choice");
            
            Console.WriteLine( "Campgrounds ");
            CampgroundSQLDAL dal = new CampgroundSQLDAL(connectionString);
            List<Campground> cuyahogaCampgrounds = dal.GetAllCampgrounds(parkchoiceMade);
            System.Globalization.DateTimeFormatInfo dtf = new System.Globalization.DateTimeFormatInfo();
            string monthEnd = "";
            string monthStart = "";
            foreach (Campground c in cuyahogaCampgrounds)
            {
                Console.WriteLine();
                monthStart = dtf.GetMonthName(c.Open_From_MM).ToString();
                monthEnd = dtf.GetMonthName(c.Open_To_MM).ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Campground ID".PadRight(20) + "Campground Name".PadLeft(20)  + "Open From".PadLeft(20) + "Open Until".PadLeft(20) + "Daily Fee".PadLeft(20));
                Console.ResetColor();
                Console.WriteLine(c.Campground_ID.ToString().PadRight(20) +  c.Name.ToString().PadLeft(20) +  monthStart.ToString().PadLeft(20) + monthEnd.ToString().PadLeft(20) + (c.Daily_Fee.ToString("c")).PadLeft(20));

            }
            Console.WriteLine("Make a reservation = 1");
            Console.WriteLine("return to main menu = 2");
            int campgroundChoiceMade = CLIHelper.GetInteger("Please enter your selection");
            if(campgroundChoiceMade == 2)
            {
                RunCLI();
            }

            int campgroundchoice = CLIHelper.GetInteger("Please enter The Campground ID");
                DateTime fromDate = CLIHelper.GetDateTime("When do you want to arrive at the campsite (DD-MM-YYYY)");
                DateTime toDate =   CLIHelper.GetDateTime("When do you want to leave? (DD-MM-YYYY)");

            CampsiteSQLDAL siteDal = new CampsiteSQLDAL(connectionString);

            List<Campsite> availableSites = siteDal.GetAvailableCampsites(campgroundchoice, fromDate, toDate);
            if (availableSites.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Campsites Available");
                Console.ResetColor();
            }
            else
            {
                foreach (Campsite c in availableSites)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Capsite ID".PadRight(20)  + "Campsite Number".PadLeft(20) + "Max Occupancy".PadLeft(20) + "Handicap".PadLeft(20)+ "Max RV Length".PadLeft(20) + "Utilities".PadLeft(20));
                    Console.ResetColor();
                    Console.WriteLine(c.Site_ID.ToString().PadRight(20) +  c.Site_Number.ToString().PadLeft(20) + c.Max_Occupancy.ToString().PadLeft(20) + c.Accessible.ToString().PadLeft(20) + c.Max_RV_Length.ToString().PadLeft(20) + c.Utilities.ToString().PadLeft(20));
                }
            }

            int siteIdChoice = CLIHelper.GetInteger("Which campsite would you like to reserve? Please enter the Campsite ID");
            string reservationName = CLIHelper.GetString("What is your last name?");
            ReservationSQLDAL rdal = new ReservationSQLDAL(connectionString);
            int reservationReferenceID =  rdal.MakeReservation(siteIdChoice, reservationName, fromDate, toDate);
            Console.WriteLine("Your reservation has been made. Your reservation ID is :  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(reservationReferenceID.ToString().PadLeft(20));
            Console.ResetColor();
            Console.WriteLine("Please bring Cash/Check/Money Order in the amount of : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"TOTAL AMOUNT: #######");
            Console.ResetColor();
            Console.WriteLine(" when you arrive at the Park .");
            RunCLI();
            // add the option to email or write to a file the 
        }

        

        private void ShowAllNationalParks()
        {
          
            ParkSQLDAL dal = new ParkSQLDAL(connectionString);
            List<Park> allParks = dal.ShowAllNationalParks();
            Console.WriteLine("Showing all National Parks in our System");
            //DateTime time = DateTime.Now;
            string format = "yyyy";

            foreach (Park p in allParks)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Park ID".PadRight(20) + "Name".PadLeft(20) + "Location".PadLeft(30) + "Established".PadLeft(40) + "Area".PadLeft(30) + "Annual Visitors".PadLeft(30));
                Console.ResetColor();
                Console.WriteLine(p.Park_id.ToString().PadRight(20) + p.Name.ToString().PadLeft(20)  + p.Location.ToString().PadLeft(30) + p.Establish_date.ToString(format).PadLeft(40) + p.Area.ToString().PadLeft(30) + p.Visitors.ToString().PadLeft(30));
                Console.WriteLine("Description: " + p.Description);


            }
            Console.WriteLine();
            PrintMenu();
        }
    
        private void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(@"                                                                                                            ");
Console.WriteLine(@" _   _       _   _                   _   _____           _       _____           _                          ");
Console.WriteLine(@"| \ | |     | | (_)                 | | |  __ \         | |     / ____|         | |                         ");
Console.WriteLine(@"|  \| | __ _| |_ _  ___  _ __   __ _| | | |__) |_ _ _ __| | __ | (___  _   _ ___| |_ ___ _ __ ___           ");
Console.WriteLine(@"| . ` |/ _` | __| |/ _ \| '_ \ / _` | | |  ___/ _` | '__| |/ /  \___ \| | | / __| __/ _ \ '_ ` _ \          ");
Console.WriteLine(@"| |\  | (_| | |_| | (_) | | | | (_| | | | |  | (_| | |  |   <   ____) | |_| \__ \ ||  __/ | | | | |         ");
Console.WriteLine(@"|_| \_|\__,_|\__|_|\___/|_| |_|\__,_|_| |_|   \__,_|_|  |_|\_\ |_____/ \__, |___/\__\___|_| |_| |_|         ");
Console.WriteLine(@"                                                                        __/ |                               ");
Console.WriteLine(@"                                                                        |___/                               ");
Console.WriteLine(@"                                                                                                            ");
            Console.ResetColor();
        }                                                                                                                      
        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Main-Menu Type in a command");
            Console.WriteLine(" 1 - Show all National Parks in our System ");
            Console.WriteLine(" 2 - Show campgroup By Park");
         

            Console.WriteLine(" Q - Quit");
        }
    }
}

