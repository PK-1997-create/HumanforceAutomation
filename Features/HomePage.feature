Feature: Explore home page

Anonymous User wants to visit an article on the website

@smoke
Scenario: Anonymous User Explores Humanforce Website 
	When I visit 'https://humanforce.com/au'
	Then I should see the Humanforce public homepage
	And Verify Humanforce logo is visible
	When I scroll to the bottom and select 'Time & Attendance'
	Then I should see Helpful Resources, when I scroll to the bottom.
	Then I visit and verify '7 benefits of integrating your payroll'