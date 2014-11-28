This repository contains a C# implementation of the Study Admin API tester applicaiton. The application targets the .NET
Framework version 4.5 and utilizes Microsoft's Windows Forms technology. The graphical user interface allows users to easily
test requests and responses against the Study Admin API. 

Study Admin API Documentation
==========================
This codebase is built on the Study Admin API documentation: https://github.com/actigraph/StudyAdminAPIDocumentation


Study Admin API Tester
==========================

* Single Test Mode

To run this tool in "single test" mode you will need to obtain an API key value pair from a Study Admin administrator. After obtaining API key value pair, enter access & secret keys in corresponding text boxes within tool. To specify an endpoint, you can select a option from the "Built-In Tests" drop down and click "Populate" button. The user will also have to ability to specify a custom endpoint by selecting an HTTP verb and specifying the resource URI.

When a request is formulated, the user will click the "Send Request" button to submit the request to the api. The user
will be able to view the http response along with the status code in the response log.

![2014-11-28_12-12-39](https://cloud.githubusercontent.com/assets/9215408/5231156/46bf5e00-76f8-11e4-8e20-fdb03fe4ea2f.png)




* Batch Mode

To run this tool in "batch mode", you will have to import a Batch Config XML File. This XML file will specify the specific tests along with the expected http status codes and response for each test. The tool will contain a sample XML batch config along with the XML Schema that validates the XML.

![2014-11-28_12-13-33](https://cloud.githubusercontent.com/assets/9215408/5231160/50afade8-76f8-11e4-8bfd-6aba41df4b99.png)
