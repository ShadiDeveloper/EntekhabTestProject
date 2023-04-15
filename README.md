# EntekhabTestProject 
It is one project in .Net7.<br />
In the project I use efCore and dapper for using sqlServer database;<br />
# Run
for run project:<br />
1- change connection string in appsettings.development file<br />
2- run 'update-database' in Package Manager Console<br />

# input data
for Add and Update you can choose dataType that data in RequestModel depends on it;<br />

//for example <br />
dataType : 1;<br />
{<br />
  "data": "{'firstName': 'Ali','lastName': 'Ahmadi','basicSalary': 1200000,'allowance': 400000,'transportation': 350000,'date': '14020123'}",<br />
  "overTimeCalculator": "CalculatorB"<br />
}<br />
<br />
dataType: 3<br />
{<br />
  "data": "FirstName/LastName/BasicSalary/Allowance/Transportation/Date\nAli/Ahmadi/1200000/400000/350000/14010801",<br />
  "overTimeCalculator": "CalculatorB"<br />
}<br />
<br />
!!! if choose dataType:3, you must use '\n' between columnNames and fieldValues!!!

