using System;
using sqliteinversdata.Models;
using System.Linq;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite; //Bibliotheque officielle de microsoft pour se connecter à Sqlite

namespace sqliteinversdata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /* Commande pour générer le model à partir de la base de données
             * The “-o” command line argument is for specifing the output directory, “--context” is for 
             * specifing the DbContext class name, “-f” is for forcing the class generation, 
             * even if the classes exists. And the last “-d” is for using DataAnnotation attributes to 
             * configure the model, instead of fluent API. You can find more details about
             * the dbcontext scaffold command using –-help option.
             */
            // dotnet ef dbcontext scaffold "DataSource=C:\Users\work\source\repos\databasesoft\sqliteinversdata\chinook.db" -o Models Microsoft.EntityFrameworkCore.Sqlite  --context sqliteinversdatacontext -f -d

            //Querying with LINQ to Entities 
            //using (var context = new sqliteinversdatacontext())
            //{
            //    var query = from art in context.Artists
            //                orderby art.ArtistId ascending
            //                select art;

            //    foreach (Artist qq in query)
            //    {
            //        Console.WriteLine(qq.ArtistId+"    "+qq.Name);
            //    }
            //}


            // Utilisation de "Dapper" pour acceder aux données des bases de données : Install-Package Dapper
            // https://dapper-tutorial.net/dapper
            using (IDbConnection connection = new SqliteConnection(Helper.CnnVal("chinookcnn")))
            {
                Console.WriteLine("Connecté à la base de données");
                foreach(Album alb in connection.Query<Album>("SELECT * from albums").ToList())
                {
                    Console.WriteLine(alb.ArtistId + " " + alb.Title + "///// " + alb.Artist);
                };
                Console.WriteLine("Fermeture de la connection à la base de données");
            }
        }
    }
}
