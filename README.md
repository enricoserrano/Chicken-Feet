# Chicken-Feet
This is the repository of the group 'Chicken Feet' for ezyVet hackathon


<img src="https://redhousespice.com/wp-content/uploads/2022/04/classic-chicken-feet-dish-scaled.jpg" width="35%" height="35%"/>

Pet Health Checker

Aim- To help pet owners assess the health of the pet anytime anywhere just a click away

Description:-

This application is a one stop shop for pet owners. It is a powerful tool which assists pet owners determine various facts about their pets in real time. 
The app accepts input from pet owners asking breed,gender,age,weight and height. Based on the data received, the app will then display data indicating the following:
-Healthy or overweight
-% chances of getting chronic illnesses depeding upon breed species
-Breed specific temperament
-Common diseases the breed witnesses in their lifetime

Working:-

The front end of the application is based on HTML which sends http request to C# RestAPI which in turn queries MySQL Database to retrieve data and stores it in Machine Learning Classification Model and then API calls are made back to C# RestAPI. Lastly, C# RestAPI returns results of request. 

![HackathonProject drawio_1](https://user-images.githubusercontent.com/114555574/193238328-178e9c05-17e2-477f-b7ec-dbed9a5b8537.png)

[EndPointDocumentation.pdf](https://github.com/enricoserrano/Chicken-Feet/files/9682683/EndPointDocumentation.pdf)
[database.zip](https://github.com/enricoserrano/Chicken-Feet/files/9682788/database.zip)
