using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksToReadWebApp.Data;
using BooksToReadWebApp.Models;

namespace BooksToReadWebApp.Controllers
{
    public class BooksController : Controller
    {
        private BooksDAO _booksDao;

        public BooksController()
        {
            _booksDao = new BooksDAO();
        }
        // GET: Books
        public ActionResult Index()
        {

            List<BooksModel> books = _booksDao.FetchAll();

            return View("Index", books);
        }


        public ActionResult Details(int id)
        {
            BooksModel booksModel = _booksDao.FetchOne(id);

            return View("Details", booksModel);
        }


        public ActionResult Create()
        {
            
            BooksModel bm = new BooksModel();



            return View("BookForm", bm);
        }

        [HttpPost]
        public ActionResult ProcessCreate(BooksModel booksModel)
        {


            //save to database

            BooksDAO booksDao = new BooksDAO();

           booksDao.CreateOrUpdate(booksModel);


            return View("Details", booksModel);
        }

        public ActionResult Edit(int id)
        {
            BooksDAO booksDao = new BooksDAO();
            BooksModel booksModel = booksDao.FetchOne(id);

            return View("BookForm", booksModel);
        }


        public ActionResult Delete(int id)
        {
            BooksDAO booksDao = new BooksDAO();
            booksDao.Delete(id);

            List<BooksModel> booksModel = booksDao.FetchAll();


            return View("Index", booksModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForTitle(string searchPhrase)
        {
            //get a list of search results from database.

            BooksDAO booksDao = new BooksDAO();

            List<BooksModel> searchResults = booksDao.SearchForTitle(searchPhrase);

            return View("Index", searchResults);
        }

        public ActionResult SearchForAuthors(string searchPhrase1)
        {
            //get a list of search results from database.

            BooksDAO booksDao = new BooksDAO();

            List<BooksModel> searchResults = booksDao.SearchForAuthors(searchPhrase1);

            return View("Index", searchResults);
        }

        //public ActionResult MyList()
        //{

        //    BooksDAO booksDao = new BooksDAO();

        //    List<MyListModel> mylist = booksDao.FetchAllList();

        //    return View("MyList", mylist);
        //}

        //public void AddList(int id)
        //{
        //    //BooksDAO booksDao = new BooksDAO();

        //    var book = _booksDao.FetchOne(id);

            //data acces emthod for adding a single book

            //add book - either with refernec to primary key or copy

            //pull back all books for user

            //return new view

            //return View("MyList", addlist);
        //}

        //[HttpPost]
        //public ActionResult ProcessAddBookList(MyListModel mylist)
        //{


        //    //save to database

        //    BooksDAO booksDao = new BooksDAO();

        //    booksDao.AddList(mylist);


        //    return View("MyList", mylist);
        //}
    }
}