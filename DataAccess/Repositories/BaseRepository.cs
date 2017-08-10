using DataAccess.Entities;
using System.Collections.Generic;
using System.IO;
using System;

namespace DataAccess.Repository
{
    public abstract class BaseRepository<T> where T : BEntity, new()
    {
        protected readonly string filepath;

        public BaseRepository(string filepath)
        {
            this.filepath = filepath;
        }
        public abstract void Reader(StreamReader sr, T item);
        public abstract void Writer(StreamWriter sw, T item);

        private int GetNextID()
        {
            FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            int id = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    T item = new T();
                    Reader(sr, item);

                    if (id <= item.ID) id = item.ID + 1;
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }

        private void Insert(T item)
        {
            item.ID = GetNextID();
            FileStream fs = new FileStream(filepath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                Writer(sw, item);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        private void Update(T item)
        {
            string tempfilepath = "temp." + filepath;

            FileStream ifs = new FileStream(filepath, FileMode.OpenOrCreate);
            FileStream ofs = new FileStream(tempfilepath, FileMode.OpenOrCreate);

            StreamReader sr = new StreamReader(ifs);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    T current = new T();
                    Reader(sr, current);

                    if (current.ID != item.ID) Writer(sw, current);
                    else Writer(sw, item);
                }
            }
            finally
            {
                sw.Close();
                sr.Close();
                ofs.Close();
                ifs.Close();
            }

            File.Delete(filepath);
            File.Move(tempfilepath, filepath);
        }

        public T GetByID(int id)
        {
            FileStream idfs = new FileStream(this.filepath, FileMode.OpenOrCreate);
            StreamReader idsr = new StreamReader(idfs);

            try
            {
                while (!idsr.EndOfStream)
                {
                    T item = new T();
                    Reader(idsr, item);
                    if (item.ID == id) return item;
                }
            }
            finally
            {
                idsr.Close();
                idfs.Close();
            }

            return default(T);
        }

        public List<T> GetAll()
        {
            List<T> result = new List<T>();

            FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    T item = new T();
                    Reader(sr, item);
                    result.Add(item);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        public void Delete(T item)
        {
            string tempfilepath = "temp." + filepath;

            FileStream ifs = new FileStream(filepath, FileMode.OpenOrCreate);
            FileStream ofs = new FileStream(tempfilepath, FileMode.OpenOrCreate);

            StreamReader sr = new StreamReader(ifs);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    T current = new T();
                    Reader(sr, current);

                    if (current.ID != item.ID) Writer(sw, current);
                }
            }
            finally
            {
                sw.Close();
                sr.Close();
                ofs.Close();
                ifs.Close();
            }

            File.Delete(filepath);
            File.Move(tempfilepath, filepath);
        }

        public void Save(T item)
        {
            if (item.ID > 0) Update(item);
            else Insert(item);
        }
    }
}