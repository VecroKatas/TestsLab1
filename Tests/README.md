# Test Configuration Guide for JetBrains Rider

This document explains how to use the `testconfig.runsettings` file for configuring and running the tests in this project with JetBrains Rider.

## What is a .runsettings file?

A `.runsettings` file is an XML configuration file that provides settings for test execution in .NET projects. It allows you to configure various aspects of test execution, including:

- Test framework settings
- Test execution parameters
- Code coverage settings
- Logging and output configuration

## Using the testconfig.runsettings file in JetBrains Rider

### Method 1: Configure via Run/Debug Configurations

1. Go to `Run > Edit Configurations` or click on the configuration dropdown in the top-right corner and select `Edit Configurations...`
2. Select your unit test configuration or create a new one by clicking the `+` button and selecting `.NET Unit Test`
3. In the configuration dialog:
   - Make sure the correct test project is selected
   - Go to the `Test options` section
   - Add `--settings Tests/testconfig.runsettings` to the `Additional arguments` field
4. Click `Apply` and then `OK` to save the configuration

### Method 2: Configure via Rider's Unit Test Sessions

1. In Rider, open the Unit Tests window by going to `View > Tool Windows > Unit Tests`
2. Click on the settings icon (gear icon) in the Unit Tests window toolbar
3. In the `Test Runner` tab, find the `.NET` section
4. Add `--settings Tests/testconfig.runsettings` to the `Additional command-line arguments` field
5. Click `OK` to save the settings
# Tests Project

This project contains unit tests for the Lab1 application.

## Running Tests with Code Coverage

You can run the tests with code coverage using either Visual Studio or the .NET CLI.

### Using Visual Studio

1. Open the solution in Visual Studio
2. Go to Test > Test Settings > Select Settings File
3. Select the `Coverage.runsettings` file
4. Go to Test > Test Explorer to see all tests
5. Select the tests you want to run, right-click and select "Run Selected Tests with Code Coverage"
6. After the tests are run, a code coverage report will be displayed in the "Code Coverage Results" window

### Using .NET CLI

From the solution root directory, run:
### Method 3: Using dotnet CLI in Rider's Terminal

Run tests from Rider's built-in terminal using the runsettings file:
- Code coverage settings
- Logging and output configuration

## Using the testconfig.runsettings file

### In Visual Studio

1. **Select the settings file for your test run:**
   - Go to `Test > Configure Run Settings > Select Solution Wide runsettings File`
   - Browse to and select the `testconfig.runsettings` file
   
2. **Run tests with the configuration:**
   - After selecting the settings file, run your tests normally via Test Explorer
   - The tests will use the configuration specified in the settings file

### With dotnet CLI

Run tests from the command line using the runsettings file:
