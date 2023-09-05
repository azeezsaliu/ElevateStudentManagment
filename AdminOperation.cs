using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevateStudentManagment
{
    internal class AdminOperation : Operation<Admin>
    {
        public AdminOperation() : base()
        {

        }
        public override void Create(Admin t)
        {
            base.Query = "INSERT INTO " + Table.AdminTb.ToString() + " (Username, Password, Role) VALUES(@Username, @Password, @Role)";
            base.CreateCommand();
            base.Cmd.Parameters.AddWithValue("@Username", "admin");
            base.Cmd.Parameters.AddWithValue("@Password", "adminpwd");
            base.Cmd.Parameters.AddWithValue("@Role", "ADMIN");

            int row = base.Cmd.ExecuteNonQuery();

            base.CloseConnection();

        }

        public override void Delete(Admin t)
        {
            throw new NotImplementedException();
        }

        public override Admin GetById(int id)
        {
            Admin admin = new Admin();

            base.Query = "SELECT * FROM " + Table.AdminTb.ToString() + " WHERE Id = @Id";
            base.CreateCommand();
            base.Cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader =  base.Cmd.ExecuteReader();

            if (reader.Read())
            {
                admin.Id = (int)reader.GetValue(0);
                admin.Username = (string)reader.GetValue(1);
                admin.Password = (string)reader.GetValue(2);
                admin.Role = (string)reader.GetValue(3);

                return admin;
            }
            return null;

        }

        public override void Update(Admin t)
        {
            throw new NotImplementedException();
        }


        public Admin GetByUsernameAndPassword(string username, string password)
        {
            Admin admin = new Admin();

            base.Query = "SELECT * FROM " + Table.AdminTb.ToString() + " WHERE Username = @Username AND Password = @Password";
            base.CreateCommand();
            base.Cmd.Parameters.AddWithValue("@Username", username);
            base.Cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = base.Cmd.ExecuteReader();

            if (reader.Read())
            {
                admin.Id = (int)reader.GetValue(0);
                admin.Username = (string)reader.GetValue(1);
                admin.Password = (string)reader.GetValue(2);
                admin.Role = (string)reader.GetValue(3);

                return admin;
            }
            return null;

        }
    }
}
