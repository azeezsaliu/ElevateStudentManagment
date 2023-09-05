using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevateStudentManagment
{
    internal abstract class Operation<T>
    {
        public SqlConnection Con { get; set; }
        public SqlCommand Cmd { get; set; }
        private string connectionString = "Data Source=DESKTOP-7QUB928;Initial Catalog=ElevateStuDb;Integrated Security=True";
        public string Query { get; set; }


        public Operation()
        {
            Con = new SqlConnection(connectionString);
            Con.Open();
        }

        public void CreateCommand()
        {
            Cmd = new SqlCommand(Query, Con);
        }

        public void CloseConnection()
        {
            Con.Close();
        }

        public abstract void Create(T t);
        public abstract void Update(T t);
        public abstract void Delete(T t);
        public abstract T GetById(int id);

    }
}
