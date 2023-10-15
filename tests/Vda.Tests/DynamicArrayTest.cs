namespace Vda.Tests
{
    [TestClass]
    public class VdaTest
    {
        [TestMethod]
        [DataRow()]
        public void Add()
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();
        }
    }

    struct Employee
    {
        public string Name;
        public int Salary;
        public Employee(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
    }
};