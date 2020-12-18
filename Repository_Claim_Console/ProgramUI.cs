using Repository_Komodo_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Claim_Console
{
    class ProgramUI
    {

        private ClaimContentRepository _contentRepo = new ClaimContentRepository();

        public void Run()
        {
            seedContentList();
            Claim();
        }

        private void Claim()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                   "1. Create New Claim\n" +
                   "2. View All Claims\n" +
                   "3. View Content By claim number\n" +
                   "4. Update Claim\n" +
                   "5. Delete Claim\n" +
                   "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //view all content
                        DisplayAllContent();
                        break;
                    case "3":
                        //view content by title
                        DisplayContentByNumber();
                        break;
                    case "4":
                        //update existing content
                        UpdateExistingContent();
                        break;
                    case "5":
                        //delete existing content
                        DeleteExistingContent();
                        break;
                    case "6":
                        //exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            

            }
        }

        private void CreateNewContent()
        {
            ClaimContent newContent = new ClaimContent();

            Console.WriteLine("enter the claim you would like to open");
            string claimNumberAsString = Console.ReadLine();
            newContent.ClaimId = int.Parse(claimNumberAsString);

            Console.WriteLine("Enter the claim type (Vehicle)");
            newContent.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter what happened.");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("what was the date of this incident (yyyy/mm/dd)");
            string dateOfIncidentAsString = Console.ReadLine();
            newContent.DateOfIncident = DateTime.Parse(dateOfIncidentAsString);

            Console.WriteLine("What was the date of the claim (yyyy/mm/dd)");
            string dateOfClaimAsString = Console.ReadLine();
            newContent.DateOfClaim = DateTime.Parse(dateOfClaimAsString);

            Console.WriteLine("How much does the claim cost");
            string claimAmountAsString = Console.ReadLine();
            newContent.ClaimAmount = double.Parse(claimAmountAsString);

            Console.WriteLine("Is this claim valid");
            string validAsString = Console.ReadLine().ToLower();
            
            if (validAsString == "y")
            {
                newContent.Valid = true;
            }
            else if (validAsString == "n")
            {
                newContent.Valid = false;
            }
            else
            {
                Console.WriteLine("type y/n...");
            }

            _contentRepo.AddContentToQueue(newContent);

        }

        private void DisplayAllContent()
        {
            Console.Clear();

            Queue<ClaimContent> listOfContent = _contentRepo.GetContentQueue();
            Console.WriteLine($"Current number of claims: {listOfContent.Count()}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


            Console.WriteLine($"Claim ID: \t" + $"Claim Type: \t" + $"Description: \t\t" + $"Date of incident: \t\t" + $"date of claim: \t\t" + $"claim amount: \t\t" + $"valid: \t");

            foreach (ClaimContent content in listOfContent)
            {

                Console.WriteLine($"{content.ClaimId}\t\t" +
                    $" {content.ClaimType}\t\t" +
                    $" {content.Description}\t\t" +
                    $" {content.DateOfIncident}\t\t" +
                    $" {content.DateOfClaim}\t\t" +
                    $" {content.ClaimAmount}\t\t" +
                    $" {content.Valid}");
            }
        }

        private void DisplayContentByNumber()
        {
            Console.Clear();

            Console.WriteLine("Enter a claim you would like to display");

            int claimId = int.Parse(Console.ReadLine());

            ClaimContent content = _contentRepo.GetContentByNumber(claimId);

            if (content != null)
            {
                Console.WriteLine($"Claim ID: {content.ClaimId}\n" +
                    $"Claim Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Date of incident: {content.DateOfIncident}\n" +
                    $"Date of claim: {content.DateOfClaim}\n" +
                    $"Claim Amount: {content.ClaimAmount}\n" +
                    $"Valid: {content.Valid}");
            }
            else
            {
                Console.WriteLine("no claim by that number");
            }



        }

        private void UpdateExistingContent()
        {
            DisplayAllContent();

            Console.WriteLine("enter the claim you would like to update");
            int oldContent = int.Parse(Console.ReadLine());

            ClaimContent newContent = new ClaimContent();

            Console.WriteLine("enter the claim you would like to open");
            string claimNumberAsString = Console.ReadLine();
            newContent.ClaimId = int.Parse(claimNumberAsString);

            Console.WriteLine("Enter the claim type (Vehicle)");
            newContent.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter what happened.");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("what was the date of this incident (yyyy/mm/dd)");
            string dateOfIncidentAsString = Console.ReadLine();
            newContent.DateOfIncident = DateTime.Parse(dateOfIncidentAsString);

            Console.WriteLine("What was the date of the claim (yyyy/mm/dd)");
            string dateOfClaimAsString = Console.ReadLine();
            newContent.DateOfClaim = DateTime.Parse(dateOfClaimAsString);

            Console.WriteLine("How much does the claim cost");
            string claimAmountAsString = Console.ReadLine();
            newContent.ClaimAmount = double.Parse(claimAmountAsString);

            


            Console.WriteLine("Is this claim valid");
            string validAsString = Console.ReadLine();

            if(validAsString == "y")
            {
                newContent.Valid = true;
            }
            else if (validAsString == "n")
            {
                newContent.Valid = false;
            }
            else
            {
                Console.WriteLine("Enter either y/n...");
            }

            bool wasUpdated = _contentRepo.UpdateExistingContent(oldContent, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("content successfully updated.");
            }
            else
            {
                Console.WriteLine("could not update");
            }

        }

        private void DeleteExistingContent()
        {
            DisplayAllContent();

            Console.WriteLine("Enter the claim you would like to delete");

            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _contentRepo.RemoveContentFromQueue(input);

            if (wasDeleted)
            {
                Console.WriteLine("content was successfully deleted");
            }
            else
            {
                Console.WriteLine("content could not be deleted");
            }

        }

        private void seedContentList()
        {
            ClaimContent numberOne = new ClaimContent(1, "car", "broken tire", new DateTime(2006 / 10 / 25), new DateTime(2006 / 12 / 25), 600.10, false);
            ClaimContent numberTwo = new ClaimContent(2, "car", "broken tire", new DateTime(2006 / 10 / 25), new DateTime(2006 / 12 / 25), 600.10, false);
            ClaimContent numberThree = new ClaimContent(3, "car", "broken tire", new DateTime(2006 / 10 / 25), new DateTime(2006 / 12 / 25), 600.10, false);

            _contentRepo.AddContentToQueue(numberOne);
            _contentRepo.AddContentToQueue(numberTwo);
            _contentRepo.AddContentToQueue(numberThree);
        }





    }
}
