using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        //IDbConnection was red until I added using System.Data
        //When you use readonly.. means it can only be given value thru constructor
        private readonly IDbConnection _connection;

        //Constructor:
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            //use Query when you want to run a select
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
        public void InsertDepartment(string newDepartmentName)
        {
            //use Execute if you want to insert into, update, or delete
            //calling IDb connection - I want to use your execute method
            //DEPARTMENTS is the table.. Name is the column
            //when you prefix with @ in SQL.. that means it is going to be a variable - use this variable value to give this row of data the name
            //think of it as string interpolation.. sql interpolation in a way
            //@department name.. adding parameter to query

            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);", 

                //anonymous type - whatever type we are trying to create.. it's going to create
                //think of it as linq
                new { departmentName = newDepartmentName }); //departmentName in line 34 is going to = newDepartmentName
                                                             //departmentName is the user input.. what they are entering
        }
    }
}
