using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUTaller.Transactions
{
    public class AdministradorBLL
    {
        public static void create(Administrador a) {
            using (Entities db=new Entities()) {
                using (var transaction=db.Database.BeginTransaction()) {
                    try {
                        db.Administrador.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex) {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        
        }
        public static Administrador Get(int? id) {
            Entities db = new Entities();
            return db.Administrador.Find(id);
        }
        public static void Update(Administrador administrador) {
            using (Entities db = new Entities()) {
                using (var transaction=db.Database.BeginTransaction()) {
                    try {
                        db.Administrador.Attach(administrador);
                        db.Entry(administrador).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    } catch (Exception ex) {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public static void Delete(int? id) {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Administrador administrador = db.Administrador.Find(id);
                        db.Entry(administrador).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public static List<Administrador> list()
        {
            Entities db = new Entities();
            return db.Administrador.ToList();
        }
        public static List<Administrador> GetAdminstrador(string criterio)
        {
            Entities db = new Entities();
            return db.Administrador.Where(x => x.Categoria.ToLower().Contains(criterio)).ToList();
        }
     
    }
}
