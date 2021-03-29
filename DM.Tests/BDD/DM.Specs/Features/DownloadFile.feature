Feature: DownloadFile
	Download File

@downloadFileFeature
Scenario: Download PDF File
	Given I have chosen a PDF from the list API
	When I request the location for one of the PDF's
	Then the PDF is downloaded