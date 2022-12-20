1.	This project is for Automate testing on Apis from Hosted Service: https://reqres.in/. 
2.	Using Restsharp, Specflow and C# to implement it. 
3.	Support multiple environments (Test, SIT, UAT) by getting correct environment info and related base URL from specflow.json in hooks -> FirstBeforeScenarios.
4.	Support Class/Feature level parallel running.
[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.ClassLevel)]
5.	Using scenario outline to make sure the test data can be changed with minimum update code.