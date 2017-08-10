using DataAccess.Entities;
using System;
using System.IO;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>
    {

        public CommentRepository(string filepath) : base(filepath)
        {

        }

        public List<Comment> GetAll(int taskid)
        {
            List<Comment> result = new List<Comment>();

            FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Comment comment = new Comment();
                    comment.ID = Convert.ToInt32(sr.ReadLine());
                    comment.TaskID = Convert.ToInt32(sr.ReadLine());
                    comment.CommenterID = Convert.ToInt32(sr.ReadLine());
                    comment.CommentBody = sr.ReadLine();
                    comment.CreationDate = Convert.ToDateTime(sr.ReadLine());

                    if (comment.TaskID == taskid) result.Add(comment);


                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public override void Reader(StreamReader sr, Comment item)
        {
            item.ID = Convert.ToInt32(sr.ReadLine());
            item.TaskID = Convert.ToInt32(sr.ReadLine());
            item.CommenterID = Convert.ToInt32(sr.ReadLine());
            item.CommentBody = sr.ReadLine();
            item.CreationDate = Convert.ToDateTime(sr.ReadLine());
        }

        public override void Writer(StreamWriter sw, Comment item)
        {
            sw.WriteLine(item.ID);
            sw.WriteLine(item.TaskID);
            sw.WriteLine(item.CommenterID);
            sw.WriteLine(item.CommentBody);
            sw.WriteLine(item.CreationDate);
        }
    }
}