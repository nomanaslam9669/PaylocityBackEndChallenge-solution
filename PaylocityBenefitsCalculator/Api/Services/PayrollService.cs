using Api.Contracts.Services;
using Api.Data;
using Api.Models;

namespace Api.Services;

public class PayrollService(PaylocityDbContext context) : IPayrollService
{

    public decimal? CalculatePaycheck(Employee employee)
    {
        var yearlySalary = employee.Salary;
        var baseCostPerMonth = 1000m;
        var dependentCostPerMonth = 600m;
        var over50DependentAdditionalCostPerMonth = 200m;
        int paychecksPerYear = 26;

        var totalMonthlyCost = baseCostPerMonth;
        var currentYear = DateTime.Now.Year;

        foreach (var dependent in employee.Dependents)
        {
            totalMonthlyCost += dependentCostPerMonth;
            if (currentYear - dependent.DateOfBirth.Year > 50) totalMonthlyCost += over50DependentAdditionalCostPerMonth;

        }

        var totalYearlyCost = totalMonthlyCost * 12;

        if (yearlySalary > 80000) totalYearlyCost += yearlySalary * 0.02m;


        var totalDeductionPerPaycheck = totalYearlyCost / paychecksPerYear;
        var paycheckAmount = (yearlySalary / paychecksPerYear) - totalDeductionPerPaycheck;

        return paycheckAmount;
    }
}
