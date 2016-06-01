using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCF_SProc
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ttModel();
            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            var query = from t in db.tts
                        select t;
            var data = query.ToList();

            // insert sp example 
            tt newRow = new tt { id = 1, fname = "joe" };
            db.tts.Add(newRow);
            db.SaveChanges();

            // update sp example
            tt updateRow = db.tts.Find(1);
            updateRow.fname = "fred";
            db.SaveChanges();

            // delete sp example
            tt deleteRow = db.tts.Find(1);
            db.tts.Remove(deleteRow);
            db.SaveChanges();

        }
    }
}

























/*

    drop table tt 
go
create table tt (id int not null primary key, fname varchar(10))
go
drop procedure pitt 
go
create procedure pItt
@id int,
@fname varchar(10)
as
insert tt values(@id,@fname)
go
exec pItt 2,joe 
go
select * from tt
go
drop procedure putt 
go
create procedure putt
@id int,
@fname varchar(10)
as
update tt set fname=@fname where id =@id 
go
exec pUtt 2,fred 
go
select * from tt
go
drop procedure pDtt 
go
create procedure pDtt
@id int
as
delete from tt where id=@id 
go
exec pDtt 2
go
select * from tt


    */
