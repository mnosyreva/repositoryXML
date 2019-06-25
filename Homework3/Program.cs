using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilename = "..//..//file1.xml";
            string outputFilename = "..//..//file2.xml";

            var books = readXML(inputFilename);
            writeXML(outputFilename, books);
        }

        private static List<Book> readXML(string filename)
        {
            XmlReader reader = XmlReader.Create(filename);
            var Books = new List<Book>();
            Book book = null;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "catalog":
                            Console.WriteLine("<catalog> element.");
                            break;
                        case "book":
                            if (book != null)
                            {
                                Books.Add(book);
                            }
                            book = new Book();
                            Console.WriteLine("<book> element.");
                            string id = reader["id"];
                            if (id != null)
                            {
                                book.id = id;
                                Console.WriteLine("Book ID: " + id);
                            }
                            break;
                        case "title":
                            if (reader.Read())
                            {
                                book.title = reader.Value;
                                Console.WriteLine("Book title: " + reader.Value);
                            }
                            break;
                        case "author":
                            if (reader.Read())
                            {
                                book.author = reader.Value;
                                Console.WriteLine("Book author: " + reader.Value);
                            }
                            break;
                        case "genre":
                            if (reader.Read())
                            {
                                book.genre = reader.Value;
                                Console.WriteLine("Book genre: " + reader.Value);
                            }
                            break;
                        case "price":
                            if (reader.Read())
                            {
                                book.price = reader.Value;
                                Console.WriteLine("Book price: " + reader.Value);
                            }
                            break;
                        case "publish_date":
                            if (reader.Read())
                            {
                                book.publish_date = reader.Value;
                                Console.WriteLine("Book publish date: " + reader.Value);
                            }
                            break;
                        case "description":
                            if (reader.Read())
                            {
                                book.description = reader.Value;
                                Console.WriteLine("Book description: " + reader.Value);
                            }
                            break;

                    }

                }
            }
            return Books;
            
        }

        private static void writeXML(string filename, List<Book> books)
        {

            XElement catalog = new XElement("catalog");
            for(int i=0; i<books.Count; i++)
            { 
            catalog.Add(new XElement("book", new XAttribute("id", books[i].id),new XElement("author", books[i].author),
                        new XElement("title", books[i].title),new XElement("genre", books[i].genre),
                        new XElement("price", books[i].price),new XElement("publish_date", books[i].publish_date),new XElement("description", books[i].description)));
            }
            XDocument xDocument = new XDocument(catalog);
            xDocument.Save(filename);
        }
    }
}