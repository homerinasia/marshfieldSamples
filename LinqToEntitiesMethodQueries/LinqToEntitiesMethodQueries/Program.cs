using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LinqToEntitiesMethodQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            pubsModel db = new pubsModel();
            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var select = db.titles.Select(t => new
            {
                Title = t.title1,
                Type = t.type
            });

            var join = db.titles.Select(t => new
            {
                Publisher = t.publisher.pub_name,
                Title = t.title1,
                Type = t.type
            }).OrderBy(t => t.Type).ToList();

            var join3 = db.titles.Select(t => new
            {
                Publisher = t.publisher.pub_name,
                Title = t.title1,
                Type = t.type,
                Price = t.price,
                TotalSalesQty = t.sales.Sum(s => s.qty)
            }).Where(t => t.Price != null);

            var ytdGT100 = db.titles.Where(t => t.price != null).All(t => t.ytd_sales > 100);

            var ytdGT9999 = db.titles.Any(t => t.ytd_sales > 9999);

            db.titles.Attach(new title { title_id = "aa1234" });
            var attach = db.titles.ToList(); //look at local

            var avg = db.titles.Average(t => t.price);

            // union eliminates dupe, concat does not
            var concat = db.titles.Concat(db.titles);
            var union = db.titles.Union(db.titles);

            var numrows = db.titles.Count();

            // creates an empty instance. not attached to titles collection
            var emptyTitle = db.titles.Create();

            var distinctTypes = db.titles.Select(t => t.type).Distinct();

            var bizbooks = db.titles.Where(t => t.type == "business");
            var exceptbizbooks = db.titles.Except(bizbooks);

            var find = db.titles.Find("bu1032");

            var firstBizBook = db.titles.First(t => t.type == "business");

            var groupBy = db.titles.GroupBy(g => g.type).Select(t => new
            {
                BookType = t.Key,
                TotalYTD = t.Sum(y => y.ytd_sales)
            });

            // this is pretty amazing
            var include = db.titles.Include("sales").Where(t => t.price > 1);
            foreach (var i in include)
            {
                string t = i.title1;
                var s = i.sales;
                var q = s.Sum(r => r.qty);
                var u = i.sales.Sum(v => v.qty);
            }

            // intersect: if i already have the info in memory, why go back to the db?
            // also note the custom comparer in utils
            var busbooks = db.titles.Where(t => t.type == "business");
            var gt19books = db.titles.Where(t => t.price > 19);
            var booksWithSales = busbooks.AsQueryable().ToList().Intersect(gt19books, new bookComparer()).ToList();

            // output looks to be the same
            var mJoin = db.titles.Join(db.sales,
                t => t.title_id,
                s => s.title_id,
                (t, s) => new { title = t, sales = s })
                .Select(x => x.title);

            var qJoin = from t in db.titles
                        join s in db.sales
                        on t.title_id equals s.title_id
                        select t;

            var min = db.titles.Min(t => t.price);
            var max = db.titles.Max(t => t.price);

            var order = db.titles.OrderBy(t => t.pubdate);

            // this may cause an update error because of a pk-fk thing if i call savechanges
            var nullrow = db.titles.Where(t => t.price == null).First();
            //db.titles.Remove(nullrow);
            //db.SaveChanges();

            // removed is populated with rows that will be removed if i call savechanges
            var removed = db.titles.RemoveRange(db.titles.Where(t => t.type == "business"));

            // will throw an error of there are more than 1
            var only = db.titles.Where(t => t.title_id == "bu1032").Single();

            var skipper = db.titles.OrderBy(t => t.price).Skip(15);
                        
            var exec = db.Database.ExecuteSqlCommand("update statistics titles");

            //sqlquery method
            string sql = "select * from publishers where state='ca'";
            var capubs = db.publishers.SqlQuery(sql).ToList();
            var sales = db.sales.SqlQuery("select * from sales where qty >70").ToList();
           
            var sqljoin = db.Database.SqlQuery<bookSales>
                ("select t.title, s.qty from titles t inner join sales s on t.title_id = s.title_id where t.type=@type", new SqlParameter("@type","business")).ToList();
            

            string uglysql = "select title_id, title as title1,pub_id, type, price,notes, royalty,advance, ytd_sales, pubdate from titles where price between 10 and 12";
            var books = db.titles.SqlQuery(uglysql).ToList();

            var similarToTop = db.titles.Take(3).OrderBy(t => t.price);
            
            //notice the elements portion of the 'rows'
            var lp =db.titles.ToLookup(t => t.type);
                                   
        }
    }

    public class bookSales
    {        
        public string  Title { get; set; }
        public short qty { get; set; }
    }
}
                
                
                