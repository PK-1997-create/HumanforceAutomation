#HumanForceAutomation

#Description
This project is a Selenium-based test automation framework developed in C# for web application testing. 
The framework leverages the Selenium WebDriver to automate the testing of web applications, providing a scalable and maintainable solution for ensuring the quality of your web-based software.


#Table of Contents

*Prequisites
*Installation
*Configuration
*Running the Tests
*Folder Structure
*Contributing
*License

#Prerequisites

-Visual Studio: Ensure you have Visual Studio installed on your machine.
-Git: Install Git on your machine for cloning the repository.
-.NET Core SDK: Make sure you have .NET Core SDK installed. You can download it from dotnet.microsoft.com.

#Installation
Setup Instructions
Clone the Repository:

Open a command prompt or terminal window.

Run the following command to clone the repository:

-git clone https://github.com/PK-1997-create/HumanforceAutomation.git


Open Project in Visual Studio:

Open Visual Studio.
Choose File > Open > Project/Solution and navigate to the cloned project folder.
Select the .sln file and click Open.

Restore Packages:

Right-click on the solution in the Solution Explorer.
Choose Restore NuGet Packages to download and install the necessary packages.

#Configuartion

Locate the appsettings.json file in the project.
Edit the file to configure the following settings:
"RunHeadless": true to run tests in headless mode (change to false for non-headless).
"WebDriver": "Chrome" to specify the browser (default: chrome)

#Running the Tests

-Set the desired test configuration (e.g., Debug or Release).
-Build the solution:
-Right-click on the solution in Solution Explorer > Build.
-Open the Test Explorer:
-View > Test Explorer
-Run the tests from Test Explorer.

#Folder Structure

project_root/
|-- HumanforceAutomation.sln
|-- HumanforceAutomation/
|   |-- Features/
|   |   |--featurefiles.feature
|   |-- StepDefinitions/
|   |   |-- stepdefinitionfiles.cs
|   |-- PageObjects/
|   |   |-- Page.cs
|-- AppSettings.json
|-- README.md



