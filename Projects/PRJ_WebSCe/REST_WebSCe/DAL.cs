using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_WebSCe
{
    public class DAL
    {
        private static string connString;
        private ErrorHandler err;

        private SqlConnection conn;
        private SqlCommand command;
        private static List<Employee> empList;


        public DAL(string _connString)
        {
            err = new ErrorHandler();
            connString=_connString;
        }

        
        #region CRUD

       public void AddEmployee(Employee emp)
       {
           try
           {
               using (conn)
               {

                   string sqlInsertString = "INSERT INTO Employee(FirstName,LastName,ID,Designation)" +
                                            " values(@firstname,@lastname,@id,@designation)";

                   conn = new SqlConnection(connString);
                   command = new SqlCommand();
                   command.Connection = conn;
                   command.Connection.Open();
                   command.CommandText = sqlInsertString;

                   SqlParameter firstnameParam = new SqlParameter("@firstname", emp.FirstName);
                   SqlParameter lastnameParam = new SqlParameter("@lastname", emp.LastName);
                   SqlParameter IDParam = new SqlParameter("@id", emp.EmpCode);
                   SqlParameter designationParam = new SqlParameter("@designation", emp.Designation);

                   command.Parameters.AddRange(new SqlParameter[] { firstnameParam, lastnameParam, IDParam, designationParam });
                   command.ExecuteNonQuery();
                   command.Connection.Close();
               };
           }
           catch (Exception ex)
           {
               err.ErrorMessage = ex.Message.ToString();
               throw;
           }
       }

       /// <summary>
       /// Database UPDATE - Update an Employee
       /// </summary>
       /// <param name="emp"></param>
       public void UpdateEmployee(Employee emp)
       {
           try
           {
               using (conn)
               {
                   string sqlUpdateString =
                   "UPDATE Employee SET FirstName=@firstName, LastName=@LastName, Designation=@Designation WHERE ID=@ID ";

                   conn = new SqlConnection(connString);

                   command = new SqlCommand();
                   command.Connection = conn;
                   command.Connection.Open();
                   command.CommandText = sqlUpdateString;

                   SqlParameter firstNameparam = new SqlParameter("@firstName", emp.FirstName);
                   SqlParameter lastNameparam = new SqlParameter("@lastName", emp.LastName);
                   SqlParameter IDparam = new SqlParameter("@ID", emp.EmpCode);
                   SqlParameter designationParam = new SqlParameter("@designation", emp.Designation);

                   command.Parameters.AddRange(new SqlParameter[] { firstNameparam, lastNameparam, IDparam, designationParam });
                   command.ExecuteNonQuery();
                   command.Connection.Close();
               }
           }
           catch (Exception ex)
           {
               err.ErrorMessage = ex.Message.ToString();
               throw;
           }
       }
       /// <summary>
       /// Database DELETE - Delete an Employee
       /// </summary>
       /// <param name="iD"></param>
       public void DeleteEmployee(int iD)
       {
           try
           {
               using (conn)
               {
                   string sqlDeleteString =
                   "DELETE FROM Employee WHERE ID=@ID ";

                   conn = new SqlConnection(connString);

                   command = new SqlCommand();
                   command.Connection = conn;
                   command.Connection.Open();
                   command.CommandText = sqlDeleteString;

                   SqlParameter IDparam = new SqlParameter("@ID", iD);
                   command.Parameters.Add(IDparam);
                   command.ExecuteNonQuery();
                   command.Connection.Close();
               }
           }
           catch (Exception ex)
           {
               err.ErrorMessage = ex.Message.ToString();
               throw;
           }
       }
       /// <summary>
       /// Database SELECT - Get an employee
       /// </summary>
       /// <param name="ID"></param>
       /// <returns></returns>
       public Employee GetEmployee(int ID)
       {
           try
           {
               if (empList == null)
               {
                   empList = GetEmployees();
               }
               // enumerate through all employee list
               // and select the concerned employee
               foreach (Employee emp in empList)
               {
                   if (emp.EmpCode == ID)
                   {
                       return emp;
                   }
               }
               return null;
           }
           catch (Exception ex)
           {
               err.ErrorMessage = ex.Message.ToString();
               throw;
           }
       }
       /// <summary>
       /// Method - Get list of all employees
       /// </summary>
       /// <returns>Employee</returns>
       private List<Employee> GetEmployees()
       {
           try
           {
               using (conn)
               {
                   empList = new List<Employee>();

                   conn = new SqlConnection(connString);

                   string sqlSelectString = "SELECT * FROM Employee";
                   command = new SqlCommand(sqlSelectString, conn);
                   command.Connection.Open();

                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {
                       Employee emp = new Employee();
                       emp.FirstName = reader[0].ToString();
                       emp.LastName = reader[1].ToString();
                       emp.EmpCode = Convert.ToInt16(reader[2]);
                       emp.Designation = reader[3].ToString();
                       empList.Add(emp);
                   }
                   command.Connection.Close();
                   return empList;
               }

           }
           catch (Exception ex)
           {
               err.ErrorMessage = ex.Message.ToString();
               throw;
           }
       }
       /// <summary>
       /// Get Exception if any
       /// </summary>
       /// <returns> Error Message</returns>
       public string GetException()
       {
           return err.ErrorMessage.ToString();
       }

        #endregion
    }
}
