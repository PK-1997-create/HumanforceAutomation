Feature: Login page

Ensuring the visibility of the login page

@smoke 
Scenario: Verify login page is loaded properly
When I visit <test instance>
Then I should see the login page
Then I Verify username and password fields are visible