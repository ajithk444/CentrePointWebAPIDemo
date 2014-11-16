This repository contains a C# implementation of the Study Admin API tester applicaiton. The application targets the .NET
Framework version 4.5 and utilizes Microsoft's Windows Forms technology. The graphical user interface allows users to easily
test requests and responses against our Study Admin API. 

Study Admin API Documentation
==========================
This codebase is built on the Study Admin API documentation: https://github.com/actigraph/StudyAdminAPIDocumentation


How to use Tester
==========================
Any Study Admin user with a researcher account will need to be granted API access to utilze the Study Admin API. In providing users with API
access, the Study Admin administrators will grant users with two keys, an access key and a secret key. These keys are used for authentication 
purposes and will need to be entered in the API Tester GUI.

After the API keys have been obtained and entered into the GUI. The user will have the option of selecting a pre-defined test from 
the "Built-In Tests" dropdown. After a test is selected, the user will click the "Populate" button which will generate the request.
The request consists of a resource URI and content box which consits of a Json object. For GET request, the user will able to modify
the URI. For PUT, POST, & DELETE requests, the user will be able to modify both the URI and the Json content. 

When a request is formulated, the user will click the "Send Request" button to submit the request to the api. The user
will be able to view the http response along with the status code in the response log.

![2014-10-30_07-48-33](https://www.dropbox.com/s/if6anyiluqcikwo/studyAdminAPITesterSceenShot.png)





