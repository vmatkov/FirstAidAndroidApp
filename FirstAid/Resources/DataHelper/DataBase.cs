using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Android.Util;
using FirstAid.Resources.Model;

namespace FirstAid.Resources.DataHelper
{
    public class DataBase
    {
        private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Questions.db")))
                {
                    connection.CreateTable<Question>();
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertIntoTableQuestion(Question question)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Questions.db")))
                {
                    connection.Insert(question);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Question> SelectTableQuestion()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Questions.db")))
                {
                    return connection.Table<Question>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool UpdateTableQuestion(Question question)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Questions.db")))
                {
                    connection.Query<Question>("UPDATE Question SET question=?, answer1=?, answer2=?, answer3=?, answer4=? WHERE Id=?", 
                        question.question, question.answer1, question.answer2, question.answer3, question.answer4, question.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeleteTableQuestion(Question question)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Questions.db")))
                {
                    connection.Delete(question);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool SelectQueryTableQuestion(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Questions.db")))
                {
                    connection.Query<Question>("SELECT * FROM Question WHERE Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}