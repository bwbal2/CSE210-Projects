using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Chicken Nugget Enthusiast";
        job1._company = "Myself";
        job1._startYear = 1982;
        job1._endYear = 2029;

        Job job2 = new Job();
        job2._jobTitle = "Agrarian Noodle Tester";
        job2._company = "Maruchan";
        job2._startYear = 1800;
        job2._endYear = 1801;

        Job job3 = new Job();
        job3._jobTitle = "Twitch Streamer";
        job3._company = "Also Maruchan";
        job3._startYear = 2021;
        job3._endYear = 2018;

        Job job4 = new Job();
        job4._jobTitle = "Chicken Nugget";
        job4._company = "McDonald's";
        job4._startYear = 2029;
        job4._endYear = 2029;

        Resume resume1 = new Resume();
        resume1._name = "Schmingleton Schmonkl";
        resume1._jobList.Add(job1);
        resume1._jobList.Add(job2);
        resume1._jobList.Add(job3);
        resume1._jobList.Add(job4);

        resume1.DisplayJobs();
    }

}