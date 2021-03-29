Feature: DocumentUpload
	Feature file for the various use cases associated with managing a document


@reorderFile
Scenario: Reorder PDF Lists
	Given I have a list of PDFs’
	When I choose to re-order the list of PDFs’
	Then the list of PDFs’ is returned in the new order for subsequent calls to the API











