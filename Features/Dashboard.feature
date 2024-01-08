
Feature: Explore dashboard

@smoke @dashboard
Scenario: Verify authenticated user is able to access dashboard
	When I visit <test instance>
	Then I should see the login page
	When I login with the "manager" credentials
	Then Verify the greeting is visible for user "Bruce"

	Then I click on HF Academy at the bottom left of the page
	Then Verify that there is a pop up window

	Then I type 'Personal' in to the search box
	Then I click on 'How do I view or update my details' article
	Then Verify that the engine opens up a new browser tab

	Then I close the current tab
	Then I navigate back to the Home Page
	Then I log out

@smoke @negative @employee
Scenario: Verify employee can not access employeeManagement page
	When I visit <test instance>
	Then I should see the login page
	When I login with the "employee" credentials
	When I visit EmployeeManagement
	Then I should see 'Sorry, that is not currently allowed...'
	Then Verify that the 'Home' button is visible
	Then Verify clicking 'Home' button will redirect user back to the home page

@smoke @manager
Scenario: Verify admin can not edit own profile
	When I visit <test instance>
	Then I should see the login page
	When I login with the "admin" credentials
	When I visit EmployeeManagement
	Then I double click on my own employee profile 'ADM01'
	Then I should see the popup warning message advising 'You do not have permission to edit your own profile via Employee Managment.'
	Then Verify that the 'Save' button is not visible


