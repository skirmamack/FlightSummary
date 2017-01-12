*** How to use ***

In command line make path of [bin\FlightSummary.exe] as a working directory
Run command "FlightSummary.exe [filename]"

Where:
[filename] - File name without path, for example InputFile1.txt

Input files should be placed inside folder "DataFiles".


Full example:
FlightSummary.exe InputFile1.txt

Output would be written to file [filename].out.txt, in this case it would be FlightSummary.exe InputFile1.txt.out.txt


tests.bat that runs two tests, also included in [bin] directory



*** Code ***

Code itself is written more or less as I would like it to be written, testing because of time matters has been written just partially. Only main business requirements were covered with unit tests, such as fligh proceeding rules, only one route per file rule, only one aircraft per file rule. The rest is covered with integration tests, when only interaction with file system has been excluded. These tests could stay, but apart of them more detailed unit tests could be written. But the code itself was written to be testable.