namespace Vda.Tests
{
    [TestClass]
    public class VdaTest
    {
        public static IEnumerable<object[]> EmployeeData
        {
            get
            {
                return new []
                {
                    new object[]
                    {
                        new object[]
                        {
                        new object[] {9, "Ben", 3000},
                        new object[] {3, "Smith", 600},
                        new object[] {5, "Amy", 2500},
                        new object[] {1, "Sarah", 4500}
                        }
                    }
                };
            }
        }
        static Employee[] CreateEmployees(object[] employeeData)
        {
            Employee[] employees = new Employee[employeeData.Count()];
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].Id = (int)((object[])employeeData[i])[0];
                employees[i].Name = (string)((object[])employeeData[i])[1];
                employees[i].Salary = (int)((object[])employeeData[i])[2];
            }
            return employees;
        }
        [TestMethod]
        [DynamicData(nameof(EmployeeData))]
        public void Length_MultipleStructs_ReturnsLength(object[] inputData)
        {
            Employee[] employees = CreateEmployees(inputData);
            DynamicArray<Employee> dynamicArray = new DynamicArray<Employee>();
            for (int i = 0; i < employees.Length; i++)
            {
                dynamicArray.Add(employees[i]);
            }

            int result = dynamicArray.Length;

            Assert.AreEqual(employees.Length, result);
        }
        [TestMethod]
        [DynamicData(nameof(EmployeeData))]
        public void Add_MultipleStructs_ReturnsStruct(object[] inputData)
        {
            Employee[] employees = CreateEmployees(inputData);
            DynamicArray<Employee> dynamicArray = new DynamicArray<Employee>();
            for (int i = 0; i < employees.Length; i++)
            {
                dynamicArray.Add(employees[i]);
            }
            for (int i = 0; i < dynamicArray.Length; i++)
            {
                Employee result = dynamicArray[i];
                Assert.AreEqual(result, employees[i]);        
            }
        }
        [TestMethod]
        [DynamicData(nameof(EmployeeData))]
        public void Contains_MultipleStructs_ReturnsTrue(object[] inputData)
        {
            Employee[] employees = CreateEmployees(inputData);
            DynamicArray<Employee> dynamicArray = new DynamicArray<Employee>();
            for (int i = 0; i < employees.Length; i++)
            {
                dynamicArray.Add(employees[i]);
            }
            for (int i = 0; i < employees.Length; i++)
            {
                bool result = dynamicArray.Contains(employees[i]);
                Assert.IsTrue(result);
            }
        }
    }

    struct Employee : IEquatable<Employee>
    {
        public int Id;
        public string Name;
        public int Salary;
        public Employee(int id, string name, int salary)
        {
            this.Id = id;
            this.Name = name;
            this.Salary = salary;
        }

        public bool Equals(Employee other)
        {
            return this.Id.Equals(other.Id);
        }
    }
};