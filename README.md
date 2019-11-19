<!--Nutrify README.MD-->

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/ArmandPretorius/nutrify">
    <img src="cclone/cclone.Android/Resources/mipmap-hdpi/icon.png" alt="Logo" height="80" radius="40"/>
  </a>

  <h3 align="center">Nutrify</h3>

  <p align="center">
    Nutrify your Food.
    <br />
    <a href="https://github.com/ArmandPretorius/nutrify"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/ArmandPretorius/nutrify">View Demo</a>
    ·
    <a href="https://github.com/ArmandPretorius/nutrify/issues">Report Bug</a>
    ·
    <a href="https://github.com/ArmandPretorius/nutrify/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
  * [Installation](#installation)
* [Usage](#usage)
  * [Logic](#logic)
* [Changes](#changes)
* [Contact](#contact)

<!-- ABOUT THE PROJECT -->
## About The Project

For our term 3 project we were tasked to create a application that can help the user in regards
to their health. I decided to create a app that will help the user eat healthier and know what
they are putting into their bodies. 

Nutrify helps you "nutrify" your food by telling you the nutrients of your food. It gives you the
food's amount of energy, calories, fibre, fat and protein. After that you can search recipes that
contain those food. You see all the ingredients in the recipe, and also the same nutrients.

### Built With
This Android application was build using:
* [Xamarin Forms](https://dotnet.microsoft.com/apps/xamarin/xamarin-forms)
* [Edamam](https://developer.edamam.com/)
* [Clarifai](https://www.clarifai.com/)
* [SQLite](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases)


### Installation

1. DownloadVisual Studio 2019 [https://visualstudio.microsoft.com/vs/](https://visualstudio.microsoft.com/vs/) and Include Xamarin Forms in the installation process
2. Clone the repo
```sh
git clone https:://github.com/ArmandPretorius/nutrify.git
```
3. Then open the project in Visual Studio

<!-- USAGE -->
## Usage

When opening the app, you are taken to the search page, where you enter the food you want to analize.
The food can be anything from an apple to a Big Mac. The app will nutrify your food, giving you the
nutrients in the food. 

From there, you can choose to search for recipes containing the food you nutrified.
You get a list of recipes with each recipe showing an image, the recipe name, the time it takes to
prepare and the amount of calories in the dish. When selecting a recipe, you can view the ingridients
of the recipe and also the amount of nutrients in the dish.


[View Demo](https://youtu.be/OD3Wk6U-JDA)
<!-- HOW DOES IT WORK -->
## Logic

The app is programmed using Xamarin.Forms with C# handling the logic.
For a backend, Nutrify uses Edamam's Food and Recipe API containing all the nutrients of the food.
https://developer.edamam.com/

At the moment the App is only available on Android. The target operating system version is from 
Oreo 5.1 to Pie 9.


<!-- Changes Made -->
## Changes

* I'd like to finish it for iOS as well.

* I'd also like to add the ability to share a recipe with your friends on WhatsApp, email etc.

* I also didn't have time to implement a filter on the recipe page.



<!-- CONTACT -->
## Contact

Armand Pretorius - 170045@virtualwindow.co.za

Project Link: [https://github.com/ArmandPretorius/nutrify](https://github.com/ArmandPretorius/cclone)







<!-- MARKDOWN LINKS & IMAGES -->
[product-screenshot]: cclone_screenshot.png

