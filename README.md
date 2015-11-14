# Restful Endpoint Tester

![BuildStatus](https://ci.appveyor.com/api/projects/status/ptvr7vxd0svxdgya?svg=true) ![MasterBranchBuildStatus](https://ci.appveyor.com/api/projects/status/ptvr7vxd0svxdgya/branch/master?svg=true)

A framework to make it easier to test RESTful endpoints using the syntax similar to what you would use when writing unit tests.

More documentation is coming soon.

To get started, install the NuGet package in your test project.  Create your tests using the sample test project as an example.  To run the tests, create a console application, initialize the tests and run them.  See the TestRunner project as an example.  The TestSuite component will search for assemblies with tests in the current directory.

The Restful Endpoint Tester is a framework to test RESTful Endpoints using .Net.  If you are familiar with NUnit, then the syntax should be similar.  There are four steps to creating tests for your endpoints.

##Get the Package on NuGet
Create a new project in your solution and add a reference to the package in the NuGet Package Manager Console.  Type:

install-package restfulendpointtester

##Create a Test Class and Add Tests
Add the [TestClass] attribute to your class.  Individual tests are marked with the [Test] attribute.  You can also mark a method with [PreTest] or [PostTest].  These methods will run before and after each test.  This is handy for adding data into a database and removing it after the test is run.

All tests are run asynchronously, so they should be marked with the async modifier and should return Task.

##Create the Test Runner project
You can use the code from the test runner to run your tests via a command line, or you can write your own.

##Run the Tests
By default, the RESTFul Endpoint Tester will look for tests in the assemblies in the current directory.  With the default test runner, you can specify a directory and filename with the directory={path\filename} argument.

#Suggestions are Always Welcome
I am always open to suggestion and contributions.  Feel free to submit an issue to ask a question or to report a problem.
