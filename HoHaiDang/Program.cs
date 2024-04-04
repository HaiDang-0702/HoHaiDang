using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

namespace HoHaiDang
{
	internal class Program
	{
		static List <Job> jobs = new List<Job> ();
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Job Management System");
				Console.WriteLine("1. Add Job");
				Console.WriteLine("2. Remove Job");
				Console.WriteLine("3. Update Job Status");
				Console.WriteLine("4. Search Job");
				Console.WriteLine("5. Display Jobs by Priority");
				Console.WriteLine("6. Display All Jobs");
				Console.WriteLine("7. Exit");
				Console.Write("Choose an option ");
				string option = Console.ReadLine();

				switch (option)
				{
					case "1":
						AddJob();
						break;
					case "2":
						RemoveJob();
						break;
					case "3":
						UpdateJobStatus();
						break;
					case "4":
						SearchJob();
						break;
					case "5":
						DisplayJobsByPriority();
						break;
					case "6":
						DisplayAllJobs();
						break;
					case "7":
						Exit();
						break;

				}
				
			}
		
		}


		static void Exit()
		{
			Environment.Exit(0);
		}
		
		static void AddJob()
		{
			Console.Write("Enter job name: ");
			string name = Console.ReadLine();
			Console.Write("Enter priority ( 1 to 5 ):");
			int priority = int.Parse(Console.ReadLine());
			Console.Write("Enter Job Description: ");
			string description = Console.ReadLine();
			string status = "Pending"; 
			jobs.Add(new Job(name, priority, description, status));
			Console.WriteLine("Job added successfully.");
		}

		static void RemoveJob()
		{
			Console.Write("Enter the index of the job to remove : ");
			int index = int.Parse(Console.ReadLine());
			if(index >= 0 && index < jobs.Count)
			{
				jobs.RemoveAt(index);
				Console.WriteLine("Job removed successfully. ");
			}
			else
			{
				Console.WriteLine("Invalid index.");
			}

		}


		static void UpdateJobStatus()
		{
			Console.Write("Enter the name of the job: ");
			string name = Console.ReadLine();
			Console.Write("Enter the new status: ");
			string status = Console.ReadLine();
			Job job = jobs.FirstOrDefault(j => j.Name== name);
			if(job != null)
			{
				job.Status= status;
				Console.WriteLine("Job status update successfully.");
			}
			else
			{
				Console.WriteLine("Job not found.");
			}
		}
		static void SearchJob()
		{
			Console.WriteLine("Enter job name or priority to search: ");
			string searchTerm = Console.ReadLine();
			List<Job> result = jobs.Where(j => j.Name.Contains(searchTerm) || j.Priority.ToString() == searchTerm).ToList();
			if (result.Any())
			{
				Console.WriteLine("Search result: ");
				DisplayJobs(result);
			}
			else
			{
				Console.WriteLine("No jobs found.");

			}
		}

		static void DisplayJobsByPriority()
		{
			List<Job> sortedJobs = jobs.OrderByDescending(j => j.Priority).ToList();
			Console.WriteLine("Job sorted by priority");
			DisplayJobs(sortedJobs);
		}

		static void DisplayAllJobs()
		{
			Console.WriteLine("All Jobs:");
			DisplayJobs(jobs);
		}
		static void DisplayJobs(List<Job> jobList)
		{
			foreach (var job in jobList)

			{
				Console.WriteLine($"Name: {job.Name}, Priority: {job.Priority}, Description: {job.Description}, Status: {job.Status}");
			}
		}

	}

}



