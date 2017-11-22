﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using Dominio;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistencia
{
    public class Persistence : DbContext
    {        
        public DbSet<Van> dbVans { get; set; }
        public DbSet<Student> dbStudents { get; set; }
        public DbSet<Teacher> dbTeachers{ get; set; }
        public DbSet<Subject> dbSubjects { get; set; }
        public DbSet<Fee> dbFees { get; set; }
        public DbSet<Exam> dbExams{ get; set; }
        public DbSet<Activity> dbActivities { get; set; }

        string conexionstr;

        
        public Persistence()
        {
            //emptybase();
        }

        public void emptybase(string dbname)
        {
            this.Database.Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog="+dbname+";Integrated Security=True";
            conexionstr = this.Database.Connection.ConnectionString;

            foreach (var entity in dbExams)
                dbExams.Remove(entity);
            foreach (var entity in dbActivities)
                dbActivities.Remove(entity);
            foreach (var entity in dbFees)
                dbFees.Remove(entity);
            foreach (var entity in dbStudents)
                dbStudents.Remove(entity);
            foreach (var entity in dbSubjects)
                dbSubjects.Remove(entity);
            foreach (var entity in dbTeachers)
                dbTeachers.Remove(entity);
            foreach (var entity in dbVans)
                dbVans.Remove(entity);
            SaveChanges();
        }
        public void preloaded()
        {
            this.Database.Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Obligatorio2;Integrated Security=True";
            conexionstr = this.Database.Connection.ConnectionString;
            LoadAllDbs();
        }


        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Activity>().ToTable("Activities");
            modelBuilder.Entity<Fee>().ToTable("Fees");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Person>().ToTable("Persons");           
            modelBuilder.Entity<Student>().ToTable("Students");                        
            modelBuilder.Entity<Subject>().ToTable("Subjects");            
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Van>().ToTable("Vans");
            modelBuilder.Entity<Exam>().ToTable("Exams");
          
         }
        */


        public bool connected()
        {
            bool estado = false;
            try
            {
                EndConnection();
                this.Database.Connection.Open();
                estado = true;
            }
            catch (SqlException odbcEx)
            {
                odbcEx.Data.ToString();
            }
            return estado;
        }

        public void LoadAllDbs()
        {            
            dbExams.Load();
            dbFees.Load();
            dbStudents.Load();
            dbSubjects.Load();
            dbTeachers.Load();
            dbVans.Load();
        }

        public bool Conected()
        {
            bool estado = false;
            string connectionString = conexionstr;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    estado=true;                    
                }
                catch (SqlException odbcEx)
                {
                    odbcEx.Data.ToString();
                }
            }
            return estado;
        }

        public void SaveExam(Exam ExamToSave)
        {
            StartConnection();
            using (var db = new Persistence())
            {
                db.dbExams.Add(ExamToSave);
                db.SaveChanges();
                db.dbExams.Load();
            }
            EndConnection();
        }

        public void SaveVan(Van VanToSave)
        {
            StartConnection();
            using (var db = new Persistence())
            {
                db.dbVans.Add(VanToSave);
                db.SaveChanges();
                db.dbVans.Load();
            }
            EndConnection(); 
        }

        public void SaveFee(Fee FeeToSave)
        {
            StartConnection();
            using (var db = new Persistence())
            {
                db.dbFees.Add(FeeToSave);
                db.SaveChanges();
                db.dbFees.Load();
            }
            EndConnection();
        }

        public void SaveActivity(Activity ActivityToSave)
        {
            StartConnection();
            using (var db = new Persistence())
            {
                db.dbActivities.Add(ActivityToSave);
                db.SaveChanges();
                db.dbFees.Load();
            }
            EndConnection();
        }

        public bool SaveStudent(Student StudentToSave)
        {
            if (Conected())
            {
                StartConnection();
                if (connected())
                {
                    dbStudents.Add(StudentToSave);
                    SaveChanges();
                    dbStudents.Load();
                }
                else
                {
                    MessageBox.Show("La conexión con la base de datos no esta disponible");
                }
                EndConnection();
            }
            return Conected();
        }

        public void DeleteStudent(Student dummy)
        {
            if (Conected())
            {
                StartConnection();
                if (connected())
                {
                    dbStudents.Remove(dummy);
                    SaveChanges();
                    dbStudents.Load();
                }
                else
                {
                    MessageBox.Show("La conexión con la base de datos no esta disponible");
                }
                EndConnection();
            }
        }


        public bool SaveTeacher(Teacher TeacherToSave)
        {
            if (Conected())
            {
                StartConnection();
                if (connected())
                {
                    dbTeachers.Add(TeacherToSave);
                    SaveChanges();
                    dbStudents.Load();
                }
                else
                {
                    MessageBox.Show("La conexión con la base de datos no esta disponible");
                }
                EndConnection();
            }
            return Conected();
        }
        public void SaveSubject(Subject SubjectToSave)
        {
            StartConnection();
            dbSubjects.Add(SubjectToSave);
            SaveChanges();
            dbSubjects.Load();
            EndConnection();
        }



        public bool ExistsVan(int idVan)
        {
            bool hay = false;
            using (var db = new Persistence())
            {
                var query = from b in db.dbVans
                            where b.VanId==idVan
                            select b;

                if ((query.Count()==1) && (query.First().VanId==idVan))
                    hay = true;
            }
            return hay;
        }

        public Van GetVan(int idVan)
        {
            if (ExistsVan(idVan))
            {
                using (var db = new Persistence())
                {
                    var query = from b in db.dbVans
                                where b.VanId == idVan
                                select b;
                    return query.First();
                }
            }
            else
            {
                return null;
            }
        }

        public bool ExistsVan1(Van OneVan)
        {
            if (OneVan!=null)
                return dbVans.Any(v => v.VanId == OneVan.VanId);
            else
                return false;
        }


        

        public void ModifyVan(Van OneVan)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Vans SET  capacity = "+ OneVan.capacity.ToString()+ ", name = '" + OneVan.name.ToString() + "' , available = '" + OneVan.available.ToString() + "' WHERE VanId = " + OneVan.VanId.ToString();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = conexionstr;
            
            cmd.Connection = sc;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void ModifyStudent(Student OneStudent)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Students SET  name = '" + 
                OneStudent.name.ToString() + "', surname = '" + 
                OneStudent.surname.ToString() + "',number = " +
                OneStudent.number.ToString() + ", x = '" +
                OneStudent.x.ToString() + "' , y = '" + 
                OneStudent.y.ToString() +  "' WHERE CardId = " + 
                OneStudent.cardId.ToString();                      
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = conexionstr;

            cmd.Connection = sc;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            //cmd.CommandText = "UPDATE Persons SET  name = '" + OneStudent.name.ToString() + "', surname = '" + OneStudent.surname.ToString() + "' WHERE CardId = " + OneStudent.cardId.ToString();
           // cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void ModifyTeacher(Teacher OneTeacher)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Teachers SET  name  = '" +
                OneTeacher.name.ToString() + "', surname = '" + 
                OneTeacher.surname.ToString() + "' WHERE CardId = " + 
                OneTeacher.cardId.ToString();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = conexionstr;

            cmd.Connection = sc;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public void ModifySubject(Subject OneSubject)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Subjects SET  name  = '" + OneSubject.name.ToString() +  "' WHERE codeId = " + OneSubject.codeId.ToString();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = conexionstr;

            cmd.Connection = sc;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void ModifyFee(Fee OneFee)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Fees SET  month  = '" + OneFee.month.ToString() + "', year = '" + OneFee.year.ToString() + "' WHERE payId = " + OneFee.payId.ToString();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = conexionstr;

            cmd.Connection = sc;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        
        public List<Van> GetVans()
        {
            this.dbVans.Load();
            return dbVans.ToList();
        }

        public List<Van> GetVans1(int param)
        {
            using (Persistence db = new Persistence())
            {
                var query = from p in db.dbVans
                            where p.VanId == param
                            select p ;
                return query.ToList<Van>();
            }
                
        }


        private void EndConnection()
        {
            Database.Connection.Close();
        }
        private void StartConnection()
        {
            Database.Connection.Open();
        }

    }
    
}
