namespace DataAccessADO.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EmployeeADOTests_External_Nuke
    {
        private EmployeeADO employeeADO;

        [TestInitialize]
        public void Setup()
        {
            this.employeeADO = new EmployeeADO();
        }

        [TestMethod]
        public void Find_WithoutFilters_ReturnAllEmployees()
        {
            List<Employee> employees = this.employeeADO.Find(null, null, null);

            Assert.AreEqual(3, employees.Count);
        }

        [TestMethod]
        public void Find_WithLastNameFilter_ReturnTheEmployeesWithTheExactLastName()
        {
            String lastName = "Pacheco";

            List<Employee> employees = this.employeeADO.Find(lastName, null, null);

            Assert.AreEqual(1, employees.Count);
        }

        [TestMethod]
        public void Find_WithHireDateFilters_ReturnTheEmployeesBetweenHireDates()
        {
            DateTime startHireDate = new DateTime(2010, 12, 29);
            DateTime endHireDate = new DateTime(2010, 12, 30);

            List<Employee> employees = this.employeeADO.Find(null, startHireDate, endHireDate);

            Assert.AreEqual(2, employees.Count);
        }

        [TestMethod]
        public void Find_WithAllFilters_ReturnTheEmployeesWithTheExactLastNameAndBetweenTheHiredDates()
        {
            String lastName = "Pacheco";
            DateTime startHireDate = new DateTime(2010, 12, 29);
            DateTime endHireDate = new DateTime(2010, 12, 30);

            List<Employee> employees = this.employeeADO.Find(lastName, startHireDate, endHireDate);

            Assert.AreEqual(1, employees.Count);
        }

        [TestMethod]
        public void Create_TheEmployeeIsPersisted()
        {
            Employee employee = new Employee
            {
                FirstName = "Luis",
                LastName = "Carranza",
                HireDate = new DateTime(2010, 12, 15)
            };

            this.employeeADO.Create(employee);

            Employee employeePersisted = this.employeeADO.Get(employee.Id);
            Assert.IsNotNull(employeePersisted);
        }

        [TestMethod]
        public void Delete_TheEmployeeIsDeleted()
        {
            this.employeeADO.Delete(1);

            Employee employeeDeleted = this.employeeADO.Get(1);
            Assert.IsNull(employeeDeleted);
        }
    }
}