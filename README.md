<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better, please fork the repo and create a pull request or simply open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
***
***
***
*** To avoid retyping too much info. Do a search and replace for the following:
*** github_username, repo, twitter_handle, email
-->





<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">

  <h3 align="center">NomNoml Parser</h3>

  <p align="center">
    A Parser from NomNoml to any supported language
    <br />
    <a href="https://github.com/kleinefynn/NomNomlParser"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/kleinefynn/NomNomlParser">View Demo</a>
    ·
    <a href="https://github.com/kleinefynn/NomNomlParser/issues">Report Bug</a>
    ·
    <a href="https://github.com/kleinefynn/NomNomlParser/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

A simple Parser to parse NomNoml-UML diagrams and convert them to supported languages. 
Right now in beta and can only produce CSharp code.
Class interactions (dependency, generalization etc.) aren't supported yet.


### Built With

* [.Net Core 3.1](https://dotnet.microsoft.com/)
* [ANTLR 4.8](https://www.antlr.org/)


<!-- USAGE EXAMPLES -->
## Usage
1. Install Antlr4.8-Runtime (can be found on nuget)
2. Download and copy the /src folder into your project
3. add `using NomNoml.Languages` and `using NomNoml.Parser` into your code
4. Load the NomNoml text into a string
5. call `NomNomlLanguageParser.Parse<[Language to parse to]>([name of your string variable])`
6. use the classes the function `Parse` returns
7. Profit


<!-- ROADMAP -->
## Roadmap

* Add support for classifiers
* Add support for proper class interaction


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.


<!-- CONTACT -->
## Contact
Project Link: [https://github.com/kleinefynn/NomNomlParse](https://github.com/kleinefynn/NomNomlParse)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/kleinefynn/NomNomlParser.svg?style=flat-square
[forks-shield]: https://img.shields.io/github/forks/kleinefynn/NomNomlParser.svg?style=flat-square
[stars-shield]: https://img.shields.io/github/stars/kleinefynn/NomNomlParser.svg?style=flat-square
[issues-shield]: https://img.shields.io/github/issues/kleinefynn/NomNomlParser.svg?style=flat-square
[license-shield]: https://img.shields.io/github/license/kleinefynn/NomNomlParser.svg?style=flat-square

[contributors-url]: https://github.com/kleinefynn/NomNomlParser/graphs/contributors
[forks-url]: https://github.com/kleinefynn/NomNomlParser/network/members
[stars-url]: https://github.com/kleinefynn/NomNomlParser/stargazers
[issues-url]: https://github.com/kleinefynn/NomNomlParser/issues
[license-url]: https://github.com/kleinefynn/NomNomlParser/blob/master/LICENSE.txt
