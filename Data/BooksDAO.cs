using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BooksToReadWebApp.Models;

namespace BooksToReadWebApp.Data
{
    internal class BooksDAO
    {
        private string connectionString =
            @"Data Source=JERUSS2-DESKTOP\SQLEXPRESS01;Initial Catalog=Josh;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Performs all operations on the database. get all, create, delete, get one, search etc

        public List<BooksModel> FetchAll()
        {
            List<BooksModel> returnList = new List<BooksModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from dbo.BooksRead";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new book object. Add it to the list to return.

                        BooksModel book = new BooksModel();
                        book.id = reader.GetInt32(0);
                        book.title = reader.GetString(1);
                        book.authors = reader.GetString(2);


                        returnList.Add(book);
                    }
                }
            }

            return returnList;
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Delete from dbo.BooksRead where id = @id";

                //associate @title with title parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 1000).Value = id;

                connection.Open();
                int DeletedId = command.ExecuteNonQuery();

                return DeletedId;
            }
        }



        public BooksModel FetchOne(int id)
        {


            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from dbo.BooksRead Where id = @id";

                //associate @id with id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                BooksModel book = new BooksModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new book object. Add it to the list to return.


                        book.id = reader.GetInt32(0);
                        book.title = reader.GetString(1);
                        book.authors = reader.GetString(2);



                    }
                }

                return book;
            }


        }

       

        // Create New
        public int CreateOrUpdate(BooksModel booksModel)
        {
            // if bookmodel.id <= 1 then create
            //if bookmodel.id > i then update




            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                sqlQuery = booksModel.id <= 0
                    ? "Insert into dbo.BooksRead Values(@title, @authors)"
                    : "Update dbo.BooksRead set title = @title, authors = @authors where id = @id";


                //associate @title with title parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 1000).Value = booksModel.id;
                command.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 1000).Value = booksModel.title;
                command.Parameters.Add("@authors", System.Data.SqlDbType.VarChar, 1000).Value = booksModel.authors;

                connection.Open();
                int newid = command.ExecuteNonQuery();

                return newid;
            }


        }


        // Search for title
        internal List<BooksModel> SearchForTitle(string searchPhrase)
        {
            List<BooksModel> returnList = new List<BooksModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from dbo.BooksRead where title like @searchForMe";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.VarChar, 1000).Value =
                    '%' + searchPhrase + '%';

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new book object. Add it to the list to return.

                        BooksModel book = new BooksModel();
                        book.id = reader.GetInt32(0);
                        book.title = reader.GetString(1);
                        book.authors = reader.GetString(2);


                        returnList.Add(book);
                    }


                }

                return returnList;

            }

        }

        // Search by Authors

        internal List<BooksModel> SearchForAuthors(string searchPhrase1)
        {
            List<BooksModel> returnList = new List<BooksModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from dbo.BooksRead where authors like @searchForMe1";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@searchForMe1", System.Data.SqlDbType.VarChar, 1000).Value =
                    '%' + searchPhrase1 + '%';

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new book object. Add it to the list to return.

                        BooksModel book = new BooksModel();
                        book.id = reader.GetInt32(0);
                        book.title = reader.GetString(1);
                        book.authors = reader.GetString(2);


                        returnList.Add(book);
                    }


                }

                return returnList;

            }

        }
         public List<MyListModel> FetchAllList()
        {
            List<MyListModel> returnList = new List<MyListModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * from dbo.MyList";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new book object. Add it to the list to return.

                        MyListModel list = new MyListModel();
                        list.id = reader.GetInt32(0);
                        list.title = reader.GetString(1);
                        list.authors = reader.GetString(2);


                        returnList.Add(list);
                    }
                }
            }

            return returnList;
        }

        public int AddList(MyListModel myList)
         {
             // if bookmodel.id <= 1 then create
             //if bookmodel.id > i then update

             // access the database
             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 string sqlQuery = "";

                 sqlQuery = myList.id <= 0
                     ? "Insert into dbo.MyList Values(@title, @authors)"
                     : "Update dbo.MyList set title = @title, authors = @authors where id = @id";


                 //associate @title with title parameter

                 SqlCommand command = new SqlCommand(sqlQuery, connection);

                 command.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 1000).Value = myList.id;
                 command.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 1000).Value = myList.title;
                 command.Parameters.Add("@authors", System.Data.SqlDbType.VarChar, 1000).Value = myList.authors;

                 connection.Open();
                 int newid = command.ExecuteNonQuery();

                 return newid;

             }


         }
    }
}