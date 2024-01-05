Feature: Feature1

A short summary of the feature

@tag1
Scenario: Anonymous User Explores Humanforce Website 
	Given As an anonymous User
	When I visit https://www.humanforce.com/
	Then I should see the Humanforce public homepage
	And Verify Humanforce logo is visible
	When I scroll to the bottom and select 'Time & Attendance'
	Then I should see Helpful Resources, when I scroll to the bottom.
	Then I select '7 benefits of workforce analytics for business'