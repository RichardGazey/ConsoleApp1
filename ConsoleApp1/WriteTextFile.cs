using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

class WriteTextFile
{
    static void Main()
    {
        SqlConnection myConnection = new SqlConnection("user id=sa;" +
                                               "password=OCyprn76;server=WALSNT80922\\SQLEXPRESS;" +
                                               "Trusted_Connection=yes;" +
                                               "database=TestCSharp; " +
                                               "connection timeout=5");

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("INSERT INTO Person (FirstName, LastName) " +
                                     "Values ('Bob', 'Bobby')", myConnection);

            myCommand.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        try
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Person",
                                                     myConnection);
            myReader = myCommand.ExecuteReader();
            System.IO.File.WriteAllText(@"C:\Ab Initio\WriteLines.txt","FirstName,LastName" + "\r\n");
            while (myReader.Read())
            {
                //      Console.WriteLine(myReader["FirstName"].ToString());
                //      Console.WriteLine(myReader["LastName"].ToString());

                string TrimString = myReader["FirstName"].ToString().Trim();

                

                System.IO.File.AppendAllText(@"C:\Ab Initio\WriteLines.txt",
                    myReader["FirstName"].ToString().Trim() + ","  + myReader["LastName"].ToString().Trim() + "\r\n");






            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }





}
//Output (to WriteLines.txt):
//   First line
//   Second line
//   Third line

//Output (to WriteText.txt):
//   A class is the most powerful data type in C#. Like a structure, a class defines the data and behavior of the data type.

//Output to WriteLines2.txt after Example #3:
//   First line
//   Third line

//Output to WriteLines2.txt after Example #4:
//   First line
//   Third line
//   Fourth line
