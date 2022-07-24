# ArchiveFile
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
  * [Project Maturity](#project-maturity)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)

<!-- ABOUT THE PROJECT -->
## About The Project
This is a small command line tool that allows you to keep a history of versions of the same file if the respective storage system does not allow to revert back to older versions of the same file.  

### Built With
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/)
* [.NET Framework Developer Pack](https://aka.ms/msbuild/developerpacks)

### Project Maturity
Latest version of the most recent major release is provided as stable unless otherwise stated.      

<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Installation

1. Clone the repo
```sh
git clone https://github.com/WJoe39/ArchiveFile.git
```

## Usage
In a Windows command line interface, run the application:
```cmd
ArchiveFile <Source file> [Number of instances] [Enumeration method]
```

usingthe following options
```
 Source file               Full path to the file you want to archive. If you
                           just give the file name we assume it's in the local
                           directory.
 Number of instances       (Optional) How many instances will be kept.
                           Default is 10.
 Enumeration method [d,n]  (Optional) Date (d) or sequential number (n).
                           Default is n.
```

## Contributing
See the [CONTRIBUTING.MD](CONTRIBUTING.md) for conventions.

## License
See the [LICENSE](LICENSE) for terms and conditions for use, reproduction, and distribution.

## Contact
Project owner is  of WJoe39.
WJoe39 - [@WJoe39](https://twitter.com/WJoe39)

Project Link: [https://github.com/WJoe39/ArchiveFile](https://github.com/WJoe39/ArchiveFile)