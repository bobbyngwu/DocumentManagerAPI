Feature: GetFiles
	Get Files

@listFiles
Scenario: Fetch list of PDF Documents
	Given I call the new document service API
	When I call the API to get a list of documents
	Then a list of PDFs’ is returned with the following properties: name, location, file-size