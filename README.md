# WUElev8

# Hire-a-thon_Jai Soni

# Problem Statement 1- Employee Performance Problem
## Description
Employee Performance problem statement folder consists solution file for the same.

# Prerequisite
Need Visual studio and .net6 installed.

# How to run
## Steps to run Employee Performance Problem solution

1. Clone Repo SoniJai/WUElev8
2. Open Visual Studio.
3. Open solution file present at WUElev8\Employee performance problem statement\EmployeePerformanceProblem\EmployeePerformanceProblem.sln.
4. Run **EmployeePerfromanceProblem.Api Project**.
5. Run Api : **api/EmployeePerformance/teamEffort** for teamEfforts calculation problem. 
6. Run Api : **api/EmployeePerformance/lowestEmployeeEfficiency** for lowest n employees problem.


### 1. To Get Mean effort spent by various teams on different Projects: 

Api Call : GET https://localhost:7226/api/EmployeePerformance/teamEffort

Response: 
```json
[
	{
		"team": "Design",
		"projects": [
			{
				"projectName": "AAA",
				"hours": 3.9722222222222225
			},
			{
				"projectName": "CCC",
				"hours": 4
			},
			{
				"projectName": "DDD",
				"hours": 2.621794871794872
			}...
		]
	},
	{
		"team": "Dev",
		"projects": [
			{
				"projectName": "BBB",
				"hours": 5.869565217391305
			},
			{
				"projectName": "CCC",
				"hours": 3.5517241379310349
			},
			{
				"projectName": "DDD",
				"hours": 3.9606060606060606
			}...
	}...
]
```

### 2.  To Get the 5 Employees with the lowest efficiency:

API Call: https://localhost:7226/api/EmployeePerformance/lowestEmployeeEfficiency?n=5

Response:
```json
[
  {
    "employeeName": "0",
    "hours": 0.5
  },
  {
    "employeeName": "Gerard Benedict",
    "hours": 16.520000000000003
  },
  {
    "employeeName": "rajeshwaran",
    "hours": 23.5
  },
  {
    "employeeName": "shalini",
    "hours": 40.790000000000006
  },
  {
    "employeeName": "akarthick",
    "hours": 44.75
  }
]
```



# Problem Statement 2- Reminder Service Problem
## Description
ReminderServiceProblem folder consists solution file for the same. This solution provides api for to add reminder.
In background, the reminder are added to a collection at a given reminder time.
This solution consists an API project to add/get reminders and WorkerService project which continuoulsy polls the reminder tasks and add them to queue at correct time.


## Steps to run Reminder Service Problem solution

1. Clone Repo SoniJai/WUElev8
2. Open Visual Studio.
3. Open solution file present at WUElev8\ReminderServiceProblem\ReminderServiceProblem.sln
4. Run **ReminderServiceProblem.Api Project**.
5. Run Api : **POST api/TaskReminder** to add new TaskReminder. 
6. Run Api : **GET api/TaskReminder** to get all the tasks.(There are some existing tasks as well.).
7. You should be able to see newly added task in response of GET api call.
8. Now check the console window of current running api project.
9. You should be able to see that the reminders are being added to queue at the correct time.
10. You can compare the reminder time of tasks from GET call output to console logs.

For Ex.:

**GET TaskReminder api** returns: 

```json
[
	{
		"name": "A",
		"reminderTime": "2022-08-27T16:55:35.4843825+05:30"
	},
	{
		"name": "B",
		"reminderTime": "2022-08-27T16:55:40.4856986+05:30"
	},
	{
		"name": "C",
		"reminderTime": "2022-08-27T16:55:45.4857026+05:30"
	},
	{
		"name": "D",
		"reminderTime": "2022-08-27T16:55:50.4857028+05:30"
	},
	{
		"name": "E",
		"reminderTime": "2022-08-27T16:55:55.4857029+05:30"
	},
	{
		"name": "F",
		"reminderTime": "2022-08-27T16:56:00.485704+05:30"
	},
	{
		"name": "G",
		"reminderTime": "2022-08-27T16:56:30.4857042+05:30"
	},
	{
		"name": "H",
		"reminderTime": "2022-08-27T16:57:30.4884718+05:30"
	}
]
```

Now if you make **POST TaskReminder api** call for below request : 
```json
{
    "name": "Hakuna",
    "reminderTime": "2022-08-27T16:57:35"
}
```

Now if you open console logs of running api project, you will see below logs: 

```
currentTime: 8/27/2022 4:55:35 PM
Added Task:A, time:8/27/2022 4:55:35 PM
tasks added. Total tasks: 1


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:55:40 PM
Added Task:B, time:8/27/2022 4:55:40 PM
tasks added. Total tasks: 2


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:55:45 PM
Added Task:C, time:8/27/2022 4:55:45 PM
tasks added. Total tasks: 3


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:55:50 PM
Added Task:D, time:8/27/2022 4:55:50 PM
tasks added. Total tasks: 4


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:55:55 PM
Added Task:E, time:8/27/2022 4:55:55 PM
tasks added. Total tasks: 5


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:56:00 PM
Added Task:F, time:8/27/2022 4:56:00 PM
tasks added. Total tasks: 6


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:56:30 PM
Added Task:G, time:8/27/2022 4:56:30 PM
tasks added. Total tasks: 7


New tasks:1 found. Adding 1 to queue


----------------------------------------------------------------


currentTime: 8/27/2022 4:57:30 PM
Added Task:H, time:8/27/2022 4:57:30 PM
tasks added. Total tasks: 8


----------------------------------------------------------------


currentTime: 8/27/2022 4:57:35 PM
Added Task:Hakuna, time:8/27/2022 4:57:35 PM
tasks added. Total tasks: 9
```

which shows that at given reminder time, items are being added to collecton.
