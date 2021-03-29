Feature: UploadFile
	Upload file feature

@uploadFile, @uploadPDFFile
Scenario: Upload a pdf file
	Given I have a PDF to upload
	When I Send the PDF to the API
	Then it is uploaded succesfully

@uploadFile, @uploadNonPDFFile
Scenario: Upload non-PDF File
	Given I have a non-pdf to upload
	When I send the non-pdf to the API
	Then the API does not accept the file and returns the appropriate messaging and status

@uploadFile, @checkFileSizeLimit
Scenario: File-Size Limit is Enforced
	Given I have a max pdf size of 5MB
	When I send the pdf to the API
	Then the API does not accept the file and returns the appropriate messaging and status
