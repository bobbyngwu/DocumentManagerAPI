Feature: DeleteFile
	Delete File

@deleteFile, @validFileDeleteRequest
Scenario: Delete PDF File
	Given I have selected a PDF from the list API that I no longer require
	When I request to delete the PDF
	Then the PDF is deleted and will no longer return from the list API and can no longer be downloaded from its location directly

@deleteFile, @invalidFileDeleteRequest
Scenario: Cannot Delete Non-Existent File
	Given I attempt to delete a file that does not exist
	When I request to delete the non-existing pdf
	Then the API returns an appropriate response