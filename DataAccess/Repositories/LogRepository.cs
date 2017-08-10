using System;
using System.IO;
using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class LogRepository : BaseRepository<Log>
    {

        public LogRepository(string filepath) : base(filepath)
        {

        }

        public List<Log> GetAll(int taskid)
        {
            List<Log> result = new List<Log>();

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Log log = new Log();
                    log.ID = Convert.ToInt32(sr.ReadLine());
                    log.TaskID = Convert.ToInt32(sr.ReadLine());
                    log.UserID = Convert.ToInt32(sr.ReadLine());
                    log.Hours = Convert.ToInt32(sr.ReadLine());
                    log.CreationDate = Convert.ToDateTime(sr.ReadLine());

                    if (log.TaskID == taskid) result.Add(log);
                }
            }
            finally
            {
                fs.Close();
                sr.Close();
            }

            return result;
        }

        public override void Reader(StreamReader sr, Log item)
        {
            item.ID = Convert.ToInt32(sr.ReadLine());
            item.TaskID = Convert.ToInt32(sr.ReadLine());
            item.UserID = Convert.ToInt32(sr.ReadLine());
            item.Hours = Convert.ToInt32(sr.ReadLine());
            item.CreationDate = Convert.ToDateTime(sr.ReadLine());
        }

        public override void Writer(StreamWriter sw, Log item)
        {
            sw.WriteLine(item.ID);
            sw.WriteLine(item.TaskID);
            sw.WriteLine(item.UserID);
            sw.WriteLine(item.Hours);
            sw.WriteLine(item.CreationDate);
        }
    }
}