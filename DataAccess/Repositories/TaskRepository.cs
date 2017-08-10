using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAccess.Repository
{
    public class TaskRepository : BaseRepository<Task>
    {
        public TaskRepository(string filepath) : base(filepath)
        {

        }

        public List<Task> GetAllWithID(int id)
        {
            List<Task> result = new List<Task>();

            FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    task.ID = Convert.ToInt32(sr.ReadLine());
                    task.Title = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.CreatorID = Convert.ToInt32(sr.ReadLine());
                    task.AssigneeID = Convert.ToInt32(sr.ReadLine());
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.CreationDate = Convert.ToDateTime(sr.ReadLine());
                    task.RecentDate = Convert.ToDateTime(sr.ReadLine());
                    task.Status = Convert.ToBoolean(sr.ReadLine());

                    if (task.CreatorID == id || task.AssigneeID == id)
                    {
                        result.Add(task);
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public override void Reader(StreamReader sr, Task item)
        {
            item.ID = Convert.ToInt32(sr.ReadLine());
            item.Title = sr.ReadLine();
            item.Description = sr.ReadLine();
            item.CreatorID = Convert.ToInt32(sr.ReadLine());
            item.AssigneeID = Convert.ToInt32(sr.ReadLine());
            item.Grade = Convert.ToInt32(sr.ReadLine());
            item.CreationDate = Convert.ToDateTime(sr.ReadLine());
            item.RecentDate = Convert.ToDateTime(sr.ReadLine());
            item.Status = Convert.ToBoolean(sr.ReadLine());
        }

        public override void Writer(StreamWriter sw, Task item)
        {
            sw.WriteLine(item.ID);
            sw.WriteLine(item.Title);
            sw.WriteLine(item.Description);
            sw.WriteLine(item.CreatorID);
            sw.WriteLine(item.AssigneeID);
            sw.WriteLine(item.Grade);
            sw.WriteLine(item.CreationDate);
            sw.WriteLine(item.RecentDate);
            sw.WriteLine(item.Status);
        }
    }
}