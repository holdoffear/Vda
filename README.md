# Vda

[![Documentation](https://img.shields.io/badge/Docs-Vda-blue)](http://htmlpreview.github.io/?https://github.com/holdoffear/Vda/blob/main/docs/build/html/index.html)
<!-- <a href="http://htmlpreview.github.io/?https://github.com/holdoffear/Vda/blob/main/docs/build/html/index.html" target="_blank">![Documentation](https://img.shields.io/badge/Docs-Vda-blue)</a> -->


## DynamicArray\<T>

A generic dynamic array library that resembles the generic List<T> in C# but instead, returns ref T by its indexer.

## Installation

Simply include the src files in your project and reference the library with, 
```C# 
using Vda;
```

### Example Usage

```C#
using Vda;

DynamicArray<Employee> dynamicArray = new DynamicArray();
dynamicArray.Add(new Employee(4892, "Sarah", 10000));
dynamicArray.Add(new Employee(39, "Benjamin", 7500));
dynamicArray.Add(new Employee(192, "Alex", 11000));

dynamicArray[0].Name = "Walter";
dynamicArray[1].Salary = 8750;
dynamicArray[2].Salary = 15000;

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
```
