# RPG.Falu
Web application for tracking our AoR RPG group.

## Synopsis

This web application is a means for our group to keep track of changes in our character as well as log findings and events.

## Getting started

To open this project, open the .sln file at the root of the directory. There are two projects in the solution: the main project for the application and another for unit testing. 

## Database

The data connection is stored in the web.config file and the database itself lives in Azure. The database was designed with Code First so the /Models/RpgModel.cs file is what you want to edit when adding any entities (tables). To run an update on the database, run the command 'Update-Database' from the Package Manager Console (found in the Tools menu). To see the actual SQL being generated from the classes run 'Update-Database -Verbose'.

## Tests

There is a project for running unit tests but none have been implemented yet.

## Contributors

Matt Bennett
Daniel Bennett
Nathan Bell
Jim Kiraly
Phillip Bercot

## License

MIT License

Copyright (c) 2016 FaluFour

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
