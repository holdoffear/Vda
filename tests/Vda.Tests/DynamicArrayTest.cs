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
        [TestMethod]
        [DataRow(new int[]{31, 43, 4, 1, 0, 90, 11}, 3)]
        [DataRow(new int[]{31, 43, 4, 1, 0, 90, 11}, 0)]
        [DataRow(new int[]{31, 43, 4, 1, 0, 90, 11}, 7)]
        public void CreateSpan_Array_ReturnsArray(int[] array, int lastIndex)
        {
            Span<int> newSpan = DynamicArray<int>.CreateSpan(array, 0, lastIndex);

            int result = newSpan.Length;

            Assert.AreEqual(lastIndex, result);

            for (int i = 0; i < newSpan.Length; i++)
            {
                Assert.AreEqual(array[i], newSpan[i]);
            }
        }
        [TestMethod]
        [DataRow(new int[]{1, 5, 3, 8, 11}, 0, typeof(int))]
        [DataRow(new int[]{3, 2, 5, 8, 6, 4, 0}, 3, typeof(int))]
        [DataRow(new int[]{0, 3, 0, 1, 4, 7}, 5, typeof(int))]
        public void Resize_IntArray_ReturnsTrue(int[] inputArray, int newSize, Type inputType)
        {
            Array newArray = Array.CreateInstance(inputType, inputArray.Length);
            Array.Copy(inputArray, newArray, inputArray.Length);

            DynamicArray<int>.Resize(ref inputArray, newSize);
            Assert.AreEqual(newSize, inputArray.Length);
            
            for (int i = 0; i < inputArray.Length; i++)
            {
                int result = inputArray[i];
                Assert.AreEqual(newArray.GetValue(i), result);
            }
        }
        [TestMethod]
        [DynamicData(nameof(EmployeeData))]
        public void Remove_MultipleStructs_ReturnsFalse(object[] inputData)
        {
            Employee[] employees = CreateEmployees(inputData);
            if (employees.Length <= 0)
            {
                return;
            }
            Employee removeEmployee = employees[0];
            DynamicArray<Employee> dynamicArray = new DynamicArray<Employee>();
            for (int i = 0; i < employees.Length; i++)
            {
                dynamicArray.Add(employees[i]);
            }
            dynamicArray.Remove(removeEmployee);

            int size = dynamicArray.Length;
            bool result = dynamicArray.Contains(removeEmployee);

            Assert.AreEqual(employees.Length-1, size);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [DynamicData(nameof(EmployeeData))]
        public void RemoveAt_MultipleStructs_ReturnsFalse(object[] inputData)
        {
            Employee[] employees = CreateEmployees(inputData);
            if (employees.Length <= 0)
            {
                return;
            }
            Employee removeEmployee = employees[0];
            DynamicArray<Employee> dynamicArray = new DynamicArray<Employee>();
            for (int i = 0; i < employees.Length; i++)
            {
                dynamicArray.Add(employees[i]);
            }
            dynamicArray.RemoveAt(0);

            int size = dynamicArray.Length;
            bool result = dynamicArray.Contains(removeEmployee);

            Assert.AreEqual(employees.Length-1, size);
            Assert.IsFalse(result);
        }
        [TestMethod]
        [DataRow(new int[]{1, 5, 3, 8, 11}, 0, 4)]
        [DataRow(new int[]{3, 2, 5, 8, 6, 4, 0}, 2, 3)]
        [DataRow(new int[]{0, 3, 0, 1, 4, 7}, 1, 4)]
        public void SwapIndices_IntArray_ReturnsTrue(int[] inputArray, int indexA, int indexB)
        {
            int resultA = inputArray[indexA];
            int resultB = inputArray[indexB];
            DynamicArray<int>.SwapIndices(inputArray, indexA, indexB);

            Assert.AreEqual(resultA, inputArray[indexB]);
            Assert.AreEqual(resultB, inputArray[indexA]);
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