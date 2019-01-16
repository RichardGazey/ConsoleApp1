using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft;




public class MyDate
{
    public int year;
    public int month;
    public int day;
}

public class Lad
{
    public string firstName;
    public string lastName;
    public MyDate dateOfBirth;
}






public class WriteTextFile
{
    

    static void Main()
    {


        var obj = new Lad
        {
            firstName = "RICHARDXXX XBRUCE",
            lastName = "GAZEY",
            dateOfBirth = new MyDate
            {
                year = 1911,
                month = 5,
                day = 30
            }
          
        };
        //var json = new JsonSerializer.JsonSerializer(


        // Console.WriteLine(json);








        const string MyPassword = "password=OCyprn76;server=WALSNT80922\\SQLEXPRESS;";
        const string MyConnectioNTiemout = "connection timeout=15";
        const string MyTruestedConnection = "Trusted_Connection=yes;";
        const string MyUSerid = "user id=sa;";
        const string MyDatabase = "database=TestCSharp; ";
        SqlConnection myConnection = new SqlConnection(MyUSerid +
                                               MyPassword +
                                               MyTruestedConnection +
                                               MyDatabase +
                                               MyConnectioNTiemout);
        



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
            int v_loop = 0;
            System.IO.File.WriteAllText(@"C:\Ab Initio\WriteLines.txt","FirstName1,LastName" + "\r\n");
            while (myReader.Read())
            {

                //      Console.WriteLine(myReader["FirstName"].ToString());
                //      Console.WriteLine(myReader["LastName"].ToString());

                string TrimString = myReader["FirstName"].ToString().Trim();
                System.Threading.Thread.Sleep(300);
                v_loop += 1;
                string LoopString = v_loop.ToString();
                
                System.IO.File.AppendAllText(@"C:\Ab Initio\WriteLines.txt",
                    myReader["FirstName"].ToString().Trim() + "," + LoopString + "," + myReader["LastName"].ToString().Trim() + "\r\n");






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
